﻿/**
 * Enables confirming a deletion through a modal dialog
 * @param {string} urlToCall the url that will be called if the delete is allowed
 * @param {any} modalElement the element containing the modal dialog
 * @returns {boolean} true or false
 */
function confirmDelete(urlToCall, modalElement) {
    $(modalElement).find('#deleteButton').on("click", function () {
        location.href = urlToCall;
    });
    $(modalElement).modal("show");
    return false;
}

/**
 * Enable edit mode for the app row
 * @param {string} appId the id of the app
 */
function editApp(appId) {
    var viewClass = ".view-id-" + appId;
    var editClass = ".edit-id-" + appId;
    $(viewClass).css('visibility','collapse').hide();
    $(editClass).css('visibility','visible').show();
}

/**
 * Cancels out of edit mode for an app row
 * @param {string} appId the id of the app
 */
function cancelEditApp(appId) {
    var viewClass = '.view-id-' + appId;
    var editClass = '.edit-id-' + appId;
    $(viewClass).css('visibility', 'initial').show();
    $(editClass).css('visibility', 'initial').hide();
}

/**
 * Enables hiding a certain element if a toggle switch is untoggled
 * @param {any} switchName the name or jquery object of the switch
 * @param {string} followUpDiv the name of the div to hide
 */
function disableWithToggle(switchName, followUpDiv) {
    $("[name='"+switchName+"']").change(function () {
        var divSelector = "div#" + followUpDiv;
        if ($(this).prop('checked')) {
            //we are checked, make sure the element is shown
            $(divSelector).css("display", "");
        } else {
            //we are unchecked, hide the element
            $(divSelector).css("display", "none");
        }
    })
}

/**
 * Asynchronously saves the app's settings
 * @param {string} appId the id of the app
 */
function saveApp(appId) {
    //warning!! this relies heavily on the format of the page and any change to the structure of the html can break this.
    var editClass = '.edit-id-' + appId;
    var inputFields = $(editClass + '> input');
    var appObj = new Object();
    inputFields.each(function () {
        var name = $(this).attr('name');
        var val = $(this).val();
        appObj[name] = val;
    });
    appObj['Id'] = appId;
    $.post('/Settings/SaveApp', appObj, function (result) {
        if (Object.prototype.hasOwnProperty.call(result, 'ErrorMessage')) {
            //something went wrong
            $.notify(result.ErrorMessage, 'error');
        } else {
            $('tr#app-' + appId).replaceWith(result);
            $.notify('Save successful', 'success');
        }
    });
}