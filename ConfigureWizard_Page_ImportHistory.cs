// Copyright (C) 2010 Zone Five Software
// Author: Aaron Averill
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

using ZoneFiveSoftware.Common.Visuals;

namespace WithingsBodyScale
{
    public partial class ConfigureWizard_Page_ImportHistory : UserControl, IWizardPage
    {
        public ConfigureWizard_Page_ImportHistory(ConfigureWizard wizard)
        {
            InitializeComponent();
            this.wizard = wizard;

            animation.Images = new Image[] {
                Properties.Resources.progress_1,
                Properties.Resources.progress_2,
                Properties.Resources.progress_3,
                Properties.Resources.progress_4,
                Properties.Resources.progress_5,
                Properties.Resources.progress_6,
                Properties.Resources.progress_7,
                Properties.Resources.progress_8,
                Properties.Resources.progress_9,
                Properties.Resources.progress_10,
                Properties.Resources.progress_11,
                Properties.Resources.progress_12,
            };
        }

        public void HistoryImportComplete(string errorText, IList<WithingsWebServiceProxy.MeasurementInfo> measurements)
        {
            animation.Stop();
            animation.Visible = false;
            if (errorText.Length == 0)
            {
                topTextLabel.Text = ResourceLookup.UI_ConfigureWizard_Page_ImportHistory_Complete_Text;
                string text = "";
                if (measurements.Count == 0)
                {
                    text = ResourceLookup.UI_ConfigureWizard_Page_ImportHistory_RetrievedNone_Text;
                }
                else if (measurements.Count == 1)
                {
                    DateTime date = measurements[0].Time;
                    string dateText = date.ToLocalTime().ToShortDateString() + " " + date.ToLocalTime().ToShortTimeString();
                    text = string.Format(ResourceLookup.UI_ConfigureWizard_Page_ImportHistory_RetrievedSingle_Text, dateText);
                }
                else
                {
                    DateTime fromDate = measurements[0].Time;
                    DateTime toDate = measurements[0].Time;
                    foreach (WithingsWebServiceProxy.MeasurementInfo measurement in measurements)
                    {
                        if (measurement.Time < fromDate) fromDate = measurement.Time;
                        if (measurement.Time > toDate) toDate = measurement.Time;
                    }
                    string fromDateText = fromDate.ToLocalTime().ToShortDateString() + " " + fromDate.ToLocalTime().ToShortTimeString();
                    string toDateText = toDate.ToLocalTime().ToShortDateString() + " " + toDate.ToLocalTime().ToShortTimeString();
                    text = string.Format(ResourceLookup.UI_ConfigureWizard_Page_ImportHistory_RetrievedRange_Text, measurements.Count, fromDateText, toDateText);
                }
                this.errorText.Text = text;
            }
            else
            {
                topTextLabel.Text = ResourceLookup.UI_ConfigureWizard_Page_ImportHistory_Failed_Text;
                this.errorText.Text = errorText;
            }
            canFinish = errorText.Length == 0;
            canBack = true;
            OnPropertyChanged("CanFinish");
            OnPropertyChanged("CanPrev");
        }

        public string PageName
        {
            get { return Properties.Resources.UI_ConfigureWizard_Page_ImportHistory_Title; }
        }

        public void ThemeChanged(ITheme visualTheme)
        {
            topTextLabel.ForeColor = visualTheme.ControlText;
        }

        public void UICultureChanged(CultureInfo culture)
        {
            topTextLabel.Text = ResourceLookup.UI_ConfigureWizard_Page_ImportHistory_topTextLabel_Text;
        }

        public void ShowPage(string bookmark)
        {
            topTextLabel.Text = ResourceLookup.UI_ConfigureWizard_Page_ImportHistory_topTextLabel_Text;
            canFinish = false;
            canBack = false;
            animation.Visible = true;
            animation.Start();
        }

        public IPageStatus Status
        {
            get { return null; }
        }

        public bool HidePage()
        {
            return true;
        }

        public bool CanFinish
        {
            get { return canFinish; }
        }

        public bool CanNext
        {
            get { return false; }
        }

        public bool CanPrev
        {
            get { return canBack; }
        }

        public Control CreatePageControl()
        {
            return this;
        }

        public string Title
        {
            get { return PageName; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private ConfigureWizard wizard;
        private bool canFinish = false;
        private bool canBack = false;
    }
}
