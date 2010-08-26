// Copyright (C) 2010 Zone Five Software
// Author: Aaron Averill
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

using ZoneFiveSoftware.Common.Data.Fitness;
using ZoneFiveSoftware.Common.Visuals;

namespace WithingsBodyScale
{
    public partial class SettingsPage : UserControl, ISettingsPage
    {
        public SettingsPage()
        {
            InitializeComponent();

            configureButton.Click += new EventHandler(OnConfigureButtonClick);
        }

        public Guid Id
        {
            get { return new Guid("369f21fa-995a-4c3c-986f-a68b8bb49e69"); }
        }

        public string PageName
        {
            get { return Plugin.Instance.Name; }
        }

        public string Title
        {
            get { return PageName; }
        }

        public void ShowPage(string bookmark)
        {
            RefreshControls();
        }

        public IPageStatus Status
        {
            get { return null; }
        }

        public bool HidePage()
        {
            return true;
        }

        public void ThemeChanged(ITheme visualTheme)
        {
            this.theme = visualTheme;
            configureButton.ForeColor = visualTheme.ControlText;
            settingsPanel.ThemeChanged(visualTheme);
        }

        public void UICultureChanged(CultureInfo culture)
        {
            labelBannerText.Text = ResourceLookup.UI_SettingsPage_labelBannerText_Text;
            configureButton.Text = ResourceLookup.UI_SettingsPage_configureButton_Text;

            settingsPanel.UICultureChanged(culture);
        }

        public IList<ISettingsPage> SubPages
        {
            get { return null; }
        }

        public Control CreatePageControl()
        {
            return this;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void RefreshControls()
        {
            settings = new LogbookSettings();
            ILogbook logbook = Plugin.Instance.Application != null ? Plugin.Instance.Application.Logbook : null;
            if (logbook != null)
            {
                settings.Load(logbook);
            }

            if (settings.PublicKey.Length == 0)
            {
                configureButton.Visible = true;
                tableLayoutPanel.RowStyles[0].Height = 60;
                settingsPanel.Visible = false;
            }
            else
            {
                configureButton.Visible = false;
                tableLayoutPanel.RowStyles[0].Height = 0;
                settingsPanel.SetSettings(logbook, settings);
                settingsPanel.Visible = true;
            }
        }

        private void OnConfigureButtonClick(object sender, EventArgs e)
        {
            ConfigureWizard wizard = new ConfigureWizard();
            wizard.ThemeChanged(theme);
            wizard.ShowDialog();
            ExtendSettingsPages.RefreshSettings();
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private LogbookSettings settings;
        private ITheme theme;
    }
}
