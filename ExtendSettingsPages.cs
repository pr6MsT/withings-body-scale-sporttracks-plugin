// Copyright (C) 2010 Zone Five Software
// Author: Aaron Averill
using System;
using System.Collections.Generic;

using ZoneFiveSoftware.Common.Visuals;
using ZoneFiveSoftware.Common.Visuals.Fitness;

namespace WithingsBodyScale
{
    class ExtendSettingsPages : IExtendSettingsPages
    {
        public IList<ISettingsPage> SettingsPages
        {
            get
            {
                LoadPages();
                return pages;
            }
        }

        public static void RefreshSettings()
        {
            if (settingsPage != null) settingsPage.RefreshControls();
        }

        private void LoadPages()
        {
            if (pages != null) return;
            settingsPage = new SettingsPage();
            pages = new List<ISettingsPage>();
            pages.Add(settingsPage);
        }

        private static IList<ISettingsPage> pages = null;
        private static SettingsPage settingsPage;
    }
}
