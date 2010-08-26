// Copyright (C) 2010 Zone Five Software
// Author: Aaron Averill
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

using ZoneFiveSoftware.Common.Data.Fitness;
using ZoneFiveSoftware.Common.Visuals;

namespace WithingsBodyScale
{
    public partial class ConfigureWizard : Wizard
    {
        public ConfigureWizard()
        {
            InitializeComponent();

            Text = ResourceLookup.UI_ConfigureWizard_Title;

            logbook = Plugin.Instance.Application != null ? Plugin.Instance.Application.Logbook : null;
            settings = new LogbookSettings();
            if (logbook != null)
            {
                settings.Load(logbook);
            }

            accountInfoPage = new ConfigureWizard_Page_AccountInfo(this);
            selectUserPage = new ConfigureWizard_Page_SelectUser(this);
            importSettingsPage = new ConfigureWizard_Page_ImportSettings(this);
            importHistoryPage = new ConfigureWizard_Page_ImportHistory(this);

            Pages = new IWizardPage[] { accountInfoPage, selectUserPage, importSettingsPage, importHistoryPage };
        }

        protected override void NextClicked()
        {
            if (ActivePage == accountInfoPage)
            {
                if (!GetUsers()) return;
                settings.Email = accountInfoPage.AccountName;
            }
            else if (ActivePage == selectUserPage)
            {
                if (selectUserPage.SelectedUser != null)
                {
                    settings.UserName = selectUserPage.SelectedUser.FirstName + " " + selectUserPage.SelectedUser.LastName;
                    settings.UserId = selectUserPage.SelectedUser.Id;
                    settings.PublicKey = selectUserPage.SelectedUser.PublicKey;
                }
            }
            else if (ActivePage == importSettingsPage)
            {
                settings.LastUpdate = 0;
                settings.LastLogEntryDate = DateTime.MinValue;
                settings.LastLogEntry = "";
                settings.ImportMultipleEntries = importSettingsPage.ImportMultipleEntries;
                settings.ImportManualEntries = importSettingsPage.ImportManualEntries;
                settings.ImportAmbiguousEntries = importSettingsPage.ImportAmbiguousEntries;
                settings.ImportHeightEntries = importSettingsPage.ImportHeightEntries;
                settings.UpdateBMI = importSettingsPage.UpdateBMI;
                culture = Thread.CurrentThread.CurrentUICulture.ToString();
                ThreadPool.QueueUserWorkItem(HistoryImportBackgroundCallback, this);
            }
            base.NextClicked();
        }

        protected override void FinishClicked()
        {
            if (ActivePage == importHistoryPage)
            {
                if (historyImportedOk)
                {
                    ProcessReceivedMeasurements();
                }
            }
            base.FinishClicked();
        }

        internal ILogbook Logbook
        {
            get { return logbook; }
        }

        internal LogbookSettings Settings
        {
            get { return settings; }
        }

        private bool GetUsers()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                string culture = Thread.CurrentThread.CurrentUICulture.ToString();
                IList<WithingsWebServiceProxy.UserInfo> users = WithingsWebServiceProxy.GetUserList(culture, accountInfoPage.AccountName, accountInfoPage.Password);
                selectUserPage.Users = users;
            }
            catch (Exception ex)
            {
                MessageDialog.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                Cursor = Cursors.Default;
            }
            return true;
        }

        private static void HistoryImportBackgroundCallback(object objState)
        {
            // Running in a background thread, wrapper to call ConfigureWizard.HistoryImport()
            ConfigureWizard wizard = (ConfigureWizard)objState;
            wizard.HistoryImport();
        }

        private void HistoryImport()
        {
            // Running in a background thread
            errorText = "";
            historyImportedOk = false;
            try
            {
                measurements = WithingsWebServiceProxy.GetAllMeasurements(culture, settings.UserId, settings.PublicKey);
                historyImportedOk = true;
            }
            catch (Exception ex)
            {
                errorText = ex.Message;
            }

            if (!IsDisposed && IsHandleCreated) BeginInvoke(new HistoryImportCompleteCallback(HistoryImportComplete));
        }

        delegate void HistoryImportCompleteCallback();
        private void HistoryImportComplete()
        {
            // Running in the UI thread.
            ShowPage(importHistoryPage);
            importHistoryPage.HistoryImportComplete(errorText, measurements);
        }

        private void ProcessReceivedMeasurements()
        {
            MeasurementImporter.ImportMeasurements(logbook, settings, measurements);
            settings.LastLogEntryDate = DateTime.Today;
            settings.LastLogEntry = CommonResources.Text.ActionOk;
            settings.LastUpdate = WithingsWebServiceProxy.GetNowEpoch();
            settings.Save(logbook);
        }

        private ILogbook logbook;
        private LogbookSettings settings;

        private ConfigureWizard_Page_AccountInfo accountInfoPage;
        private ConfigureWizard_Page_SelectUser selectUserPage;
        private ConfigureWizard_Page_ImportSettings importSettingsPage;
        private ConfigureWizard_Page_ImportHistory importHistoryPage;

        // Data for import operation
        string culture = "";
        string errorText = "";
        private IList<WithingsWebServiceProxy.MeasurementInfo> measurements = new List<WithingsWebServiceProxy.MeasurementInfo>();
        private bool historyImportedOk = false;
    }
}