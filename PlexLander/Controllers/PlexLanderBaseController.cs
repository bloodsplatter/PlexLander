﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;
using PlexLander.Configuration;
using PlexLander.Data;
using PlexLander.ViewModels;
using System;

namespace PlexLander.Controllers
{
    public abstract class PlexLanderBaseController : Controller
    {
        public const string APPVERSION_VIEWDATAKEY = "AppVersion";

        private readonly IConfigurationManager configManager;
        protected IConfigurationManager ConfigManager => configManager;
        protected string ServerName
        {
            get
            {
                return configManager.ServerName;
            }
        }

        public PlexLanderBaseController(IConfigurationManager configManager) : base()
        {
            this.configManager = configManager;
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            string appVersion = ViewData[APPVERSION_VIEWDATAKEY] as string;
            if (string.IsNullOrEmpty(appVersion))
            {
                ViewData[APPVERSION_VIEWDATAKEY] = configManager.ApplicationVersion;
            }

            var controller = context.Controller as PlexLanderBaseController;

            if (controller != null && controller.ViewData.Model == null)
            {
                controller.ViewData.Model = new BasicViewModel(ServerName);
            }
            base.OnActionExecuted(context);
        }

        private sealed class BasicViewModel : ViewModelBase
        {
            public BasicViewModel(string serverName) : base(serverName)
            {
            }
        }
    }
}
