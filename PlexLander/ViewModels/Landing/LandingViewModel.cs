﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlexLander.Models;

namespace PlexLander.ViewModels.Landing
{
    public class LandingViewModel : ViewModelBase
    {
        public LandingViewModel(string serverName) : base(serverName)
        {
        }

        public ICollection<App> AppList { get; set; }
    }
}
