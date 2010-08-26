// Copyright (C) 2010 Zone Five Software
// Author: Aaron Averill
using System;
using System.Collections.Generic;
using System.Threading;

namespace WithingsBodyScale
{
    internal class ResourceLookup
    {
        internal static string MultipleEntriesUpdateStyles_Earliest_Text
        {
            get {return GetString("MultipleEntriesUpdateStyles_Earliest_Text"); }
        }

        internal static string MultipleEntriesUpdateStyles_Highest_Text
        {
            get {return GetString("MultipleEntriesUpdateStyles_Highest_Text"); }
        }

        internal static string MultipleEntriesUpdateStyles_Latest_Text
        {
            get {return GetString("MultipleEntriesUpdateStyles_Latest_Text"); }
        }

        internal static string MultipleEntriesUpdateStyles_Lowest_Text
        {
            get {return GetString("MultipleEntriesUpdateStyles_Lowest_Text"); }
        }

        internal static string UI_ConfigureWizard_Page_AccountInfo_passwordLabel_Text
        {
            get {return GetString("UI_ConfigureWizard_Page_AccountInfo_passwordLabel_Text"); }
        }

        internal static string UI_ConfigureWizard_Page_AccountInfo_Title
        {
            get {return GetString("UI_ConfigureWizard_Page_AccountInfo_Title"); }
        }

        internal static string UI_ConfigureWizard_Page_AccountInfo_topTextLabel_Text
        {
            get {return GetString("UI_ConfigureWizard_Page_AccountInfo_topTextLabel_Text"); }
        }

        internal static string UI_ConfigureWizard_Page_ImportHistory_Complete_Text
        {
            get {return GetString("UI_ConfigureWizard_Page_ImportHistory_Complete_Text"); }
        }

        internal static string UI_ConfigureWizard_Page_ImportHistory_Failed_Text
        {
            get {return GetString("UI_ConfigureWizard_Page_ImportHistory_Failed_Text"); }
        }

        internal static string UI_ConfigureWizard_Page_ImportHistory_Title
        {
            get {return GetString("UI_ConfigureWizard_Page_ImportHistory_Title"); }
        }

        internal static string UI_ConfigureWizard_Page_ImportHistory_topTextLabel_Text
        {
            get {return GetString("UI_ConfigureWizard_Page_ImportHistory_topTextLabel_Text"); }
        }

        internal static string UI_ConfigureWizard_Page_SelectUser_Title
        {
            get {return GetString("UI_ConfigureWizard_Page_SelectUser_Title"); }
        }

        internal static string UI_ConfigureWizard_Title
        {
            get {return GetString("UI_ConfigureWizard_Title"); }
        }

        internal static string UI_LogbookSettingsPanel_accountLabel_Text
        {
            get {return GetString("UI_LogbookSettingsPanel_accountLabel_Text"); }
        }

        internal static string UI_LogbookSettingsPanel_ambiguousLabel_Text
        {
            get {return GetString("UI_LogbookSettingsPanel_ambiguousLabel_Text"); }
        }

        internal static string UI_LogbookSettingsPanel_Deactivate_Text
        {
            get {return GetString("UI_LogbookSettingsPanel_Deactivate_Text"); }
        }

        internal static string UI_LogbookSettingsPanel_Deactivate_Title
        {
            get {return GetString("UI_LogbookSettingsPanel_Deactivate_Title"); }
        }

        internal static string UI_LogbookSettingsPanel_deactivateButton_Text
        {
            get {return GetString("UI_LogbookSettingsPanel_deactivateButton_Text"); }
        }

        internal static string UI_LogbookSettingsPanel_heightLabel_Text
        {
            get {return GetString("UI_LogbookSettingsPanel_heightLabel_Text"); }
        }

        internal static string UI_LogbookSettingsPanel_lastConnectionLabel_Text
        {
            get {return GetString("UI_LogbookSettingsPanel_lastConnectionLabel_Text"); }
        }

        internal static string UI_LogbookSettingsPanel_manualLabel_Text
        {
            get {return GetString("UI_LogbookSettingsPanel_manualLabel_Text"); }
        }

        internal static string UI_LogbookSettingsPanel_multipleEntriesLabel_Text
        {
            get {return GetString("UI_LogbookSettingsPanel_multipleEntriesLabel_Text"); }
        }

        internal static string UI_LogbookSettingsPanel_optionsLabel_Text
        {
            get {return GetString("UI_LogbookSettingsPanel_optionsLabel_Text"); }
        }

        internal static string UI_LogbookSettingsPanel_reconfigureButton_Text
        {
            get {return GetString("UI_LogbookSettingsPanel_reconfigureButton_Text"); }
        }

        internal static string UI_LogbookSettingsPanel_updateBMILabel_Text
        {
            get {return GetString("UI_LogbookSettingsPanel_updateBMILabel_Text"); }
        }

        internal static string UI_LogbookSettingsPanel_userLabel_Text
        {
            get {return GetString("UI_LogbookSettingsPanel_userLabel_Text"); }
        }

        internal static string UI_SettingsPage_configureButton_Text
        {
            get {return GetString("UI_SettingsPage_configureButton_Text"); }
        }

        internal static string UI_SettingsPage_labelBannerText_Text
        {
            get {return GetString("UI_SettingsPage_labelBannerText_Text"); }
        }

        internal static string UI_ConfigureWizard_Page_ImportSettings_Title
        {
            get { return GetString("UI_ConfigureWizard_Page_ImportSettings_Title"); }
        }

        internal static string UI_ConfigureWizard_Page_ImportHistory_RetrievedRange_Text
        {
            get { return GetString("UI_ConfigureWizard_Page_ImportHistory_RetrievedRange_Text"); }
        }

        internal static string UI_ConfigureWizard_Page_ImportHistory_RetrievedSingle_Text
        {
            get { return GetString("UI_ConfigureWizard_Page_ImportHistory_RetrievedSingle_Text"); }
        }

        internal static string UI_ConfigureWizard_Page_ImportHistory_RetrievedNone_Text
        {
            get { return GetString("UI_ConfigureWizard_Page_ImportHistory_RetrievedNone_Text"); }
        }

        internal static string GetString(string resourceId)
        {
            string[] locale = Thread.CurrentThread.CurrentUICulture.Name.Split('-');
            string text = null;
            if (locale.Length > 1) text = Properties.Resources.ResourceManager.GetString(locale[0] + "_" + locale[1] + "_" + resourceId);
            if (text == null && locale.Length > 0) text = Properties.Resources.ResourceManager.GetString(locale[0] + "_" + resourceId);
            if (text == null) text = Properties.Resources.ResourceManager.GetString(resourceId);
            if (text == null) text = "[MISSING: " + resourceId + "]";
            return text;
        }
    }
}
