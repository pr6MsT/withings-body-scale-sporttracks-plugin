// Copyright (C) 2010 Zone Five Software
// Author: Aaron Averill
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Xml;

using ZoneFiveSoftware.Common.Visuals.Fitness;

namespace WithingsBodyScale
{
    class Plugin : IPlugin
    {
        public Plugin()
        {
            instance = this;
        }

        public static string ApplicationNamespace = "urn:uuid:D0EB2ED5-49B6-44e3-B13C-CF15BE7DD7DD";
        public Guid Id
        {
            get { return new Guid("6b88fdb5-d2f2-4742-b42f-911dc7700451"); }
        }

        public IApplication Application
        {
            get { return application; }
            set
            {
                if (application != null) application.PropertyChanged -= new PropertyChangedEventHandler(OnApplicationPropertyChanged);
                application = value;
                if (application != null) application.PropertyChanged += new PropertyChangedEventHandler(OnApplicationPropertyChanged);
            }
        }

        public string Name
        {
            get { return "Withings WiFi Body Scale Sync"; }
        }

        public string Version
        {
            get { return GetType().Assembly.GetName().Version.ToString(3); }
        }

        public void ReadOptions(XmlDocument xmlDoc, XmlNamespaceManager nsmgr, XmlElement pluginNode)
        {
        }

        public void WriteOptions(XmlDocument xmlDoc, XmlElement pluginNode)
        {
        }

        public static Plugin Instance
        {
            get { return instance; }
        }

        private void OnApplicationPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Logbook" && application != null && application.Logbook != null)
            {
                Synchronizer.FetchDataFromServer(application.Logbook);
                ExtendSettingsPages.RefreshSettings();
            }
        }

        private static Plugin instance = null;

        private IApplication application;
    }
}
