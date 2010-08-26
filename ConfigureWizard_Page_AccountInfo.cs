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

using ZoneFiveSoftware.Common.Visuals;

namespace WithingsBodyScale
{
    public partial class ConfigureWizard_Page_AccountInfo : UserControl, IWizardPage
    {
        public ConfigureWizard_Page_AccountInfo(ConfigureWizard wizard)
        {
            InitializeComponent();
            this.wizard = wizard;
            accountTextBox.Text = wizard.Settings.Email;

            accountTextBox.TextChanged += new EventHandler(OnAccountTextBoxTextChanged);
            passwordTextBox.TextChanged += new EventHandler(OnPasswordTextBoxTextChanged);
        }

        public string AccountName
        {
            get { return accountTextBox.Text.Trim(); }
        }

        public string Password
        {
            get { return passwordTextBox.Text.Trim(); }
        }

        public string PageName
        {
            get { return ResourceLookup.UI_ConfigureWizard_Page_AccountInfo_Title; }
        }

        public void ThemeChanged(ITheme visualTheme)
        {
            topTextLabel.ForeColor = visualTheme.ControlText;
            accountLabel.ForeColor = visualTheme.ControlText;
            accountTextBox.ThemeChanged(visualTheme);
            passwordLabel.ForeColor = visualTheme.ControlText;
            passwordTextBox.ThemeChanged(visualTheme);
        }

        public void UICultureChanged(CultureInfo culture)
        {
            topTextLabel.Text = ResourceLookup.UI_ConfigureWizard_Page_AccountInfo_topTextLabel_Text;
            accountLabel.Text = ResourceLookup.UI_LogbookSettingsPanel_accountLabel_Text;
            passwordLabel.Text = ResourceLookup.UI_ConfigureWizard_Page_AccountInfo_passwordLabel_Text;
        }

        public void ShowPage(string bookmark)
        {
            if (accountTextBox.Text.Length > 0)
            {
                passwordTextBox.Focus();
            }
            else
            {
                accountTextBox.Focus();
            }
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
            get { return false; }
        }

        public bool CanNext
        {
            get { return AccountName.Length > 0 && Password.Length > 0; }
        }

        public bool CanPrev
        {
            get { return false; }
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

        private void OnAccountTextBoxTextChanged(object sender, EventArgs e)
        {
            OnPropertyChanged("CanNext");
        }

        private void OnPasswordTextBoxTextChanged(object sender, EventArgs e)
        {
            OnPropertyChanged("CanNext");
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private ConfigureWizard wizard;
    }
}
