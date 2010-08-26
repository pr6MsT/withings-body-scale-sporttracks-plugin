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
    public partial class LogbookSettingsPanel : UserControl
    {
        public LogbookSettingsPanel()
        {
            InitializeComponent();

            multipleEntriesTextBox.ButtonClick += new EventHandler(OnMultipleEntriesTextBoxButtonClick);
            manualCheckBox.CheckedChanged += new EventHandler(OnManualCheckBoxCheckedChanged);
            ambiguousCheckBox.CheckedChanged += new EventHandler(OnAmbiguousCheckBoxCheckedChanged);
            heightCheckBox.CheckedChanged += new EventHandler(OnHeightCheckBoxCheckedChanged);
            bmiCheckBox.CheckedChanged += new EventHandler(OnBmiCheckBoxCheckedChanged);
            deactivateButton.Click += new EventHandler(OnDeactivateButtonClick);
            reconfigureButton.Click += new EventHandler(OnReconfigureButtonClick);
        }

        public void ThemeChanged(ITheme visualTheme)
        {
            this.theme = visualTheme;
            accountLabel.ForeColor = theme.ControlText;
            accountTextBox.ForeColor = theme.ControlText;
            userLabel.ForeColor = theme.ControlText;
            userTextBox.ForeColor = theme.ControlText;
            optionsLabel.ForeColor = theme.ControlText;
            multipleEntriesLabel.ForeColor = theme.ControlText;
            multipleEntriesTextBox.ThemeChanged(theme);
            manualLabel.ForeColor = theme.ControlText;
            ambiguousLabel.ForeColor = theme.ControlText;
            heightLabel.ForeColor = theme.ControlText;
            updateBMILabel.ForeColor = theme.ControlText;
            lastConnectionLabel.ForeColor = theme.ControlText;
            lastConnectionDateTextBox.ForeColor = theme.ControlText;
            lastConnectionStatusTextBox.ForeColor = theme.ControlText;
            deactivateButton.ForeColor = visualTheme.ControlText;
            reconfigureButton.ForeColor = visualTheme.ControlText;
        }

        public void UICultureChanged(CultureInfo culture)
        {
            accountLabel.Text = ResourceLookup.UI_LogbookSettingsPanel_accountLabel_Text;
            userLabel.Text = ResourceLookup.UI_LogbookSettingsPanel_userLabel_Text;
            optionsLabel.Text = ResourceLookup.UI_LogbookSettingsPanel_optionsLabel_Text;
            multipleEntriesLabel.Text = ResourceLookup.UI_LogbookSettingsPanel_multipleEntriesLabel_Text;
            RefreshMutipleEntriesTextBox();
            manualLabel.Text = ResourceLookup.UI_LogbookSettingsPanel_manualLabel_Text;
            ambiguousLabel.Text = ResourceLookup.UI_LogbookSettingsPanel_ambiguousLabel_Text;
            heightLabel.Text = ResourceLookup.UI_LogbookSettingsPanel_heightLabel_Text;
            updateBMILabel.Text = ResourceLookup.UI_LogbookSettingsPanel_updateBMILabel_Text;
            lastConnectionLabel.Text = ResourceLookup.UI_LogbookSettingsPanel_lastConnectionLabel_Text;
            deactivateButton.Text = ResourceLookup.UI_LogbookSettingsPanel_deactivateButton_Text;
            reconfigureButton.Text = ResourceLookup.UI_LogbookSettingsPanel_reconfigureButton_Text;
        }

        public void SetSettings(ILogbook logbook, LogbookSettings settings)
        {
            this.logbook = logbook;
            this.settings = settings;
            RefreshControls();
        }

        private void RefreshControls()
        {
            accountTextBox.Text = settings.Email;
            userTextBox.Text = settings.UserName;
            RefreshMutipleEntriesTextBox();
            manualCheckBox.Checked = settings.ImportManualEntries;
            ambiguousCheckBox.Checked = settings.ImportAmbiguousEntries;
            heightCheckBox.Checked = settings.ImportHeightEntries;
            bmiCheckBox.Checked = settings.UpdateBMI;
            lastConnectionDateTextBox.Text = settings.LastLogEntryDate != DateTime.MinValue ? settings.LastLogEntryDate.ToShortDateString() : "";
            lastConnectionStatusTextBox.Text = settings.LastLogEntry;
        }

        private void RefreshMutipleEntriesTextBox()
        {
            multipleEntriesTextBox.Text = MutipleEntriesText(settings.ImportMultipleEntries);
        }

        internal static string MutipleEntriesText(LogbookSettings.MultipleEntriesUpdateStyles value)
        {
            switch (value)
            {
                case LogbookSettings.MultipleEntriesUpdateStyles.Earliest:
                    return ResourceLookup.MultipleEntriesUpdateStyles_Earliest_Text;
                case LogbookSettings.MultipleEntriesUpdateStyles.Latest:
                    return ResourceLookup.MultipleEntriesUpdateStyles_Latest_Text;
                case LogbookSettings.MultipleEntriesUpdateStyles.Lowest:
                    return ResourceLookup.MultipleEntriesUpdateStyles_Lowest_Text;
                case LogbookSettings.MultipleEntriesUpdateStyles.Highest:
                    return ResourceLookup.MultipleEntriesUpdateStyles_Highest_Text;
            }
            return "";
        }

        private class PopupItem<T>
        {
            public PopupItem(T item, string text)
            {
                Item = item;
                Text = text;
            }

            public T Item;
            public string Text;
            public override string  ToString() { return Text; }
        }

        private class MultipleEntriesPopupItem : PopupItem<LogbookSettings.MultipleEntriesUpdateStyles>
        {
            public MultipleEntriesPopupItem(LogbookSettings.MultipleEntriesUpdateStyles style)
                : base(style, MutipleEntriesText(style))
            {
            }
        }

        private void OnMultipleEntriesTextBoxButtonClick(object sender, EventArgs e)
        {
            MultipleEntriesPopupItem  selected = null;
            IList<MultipleEntriesPopupItem > items = new List<MultipleEntriesPopupItem>();
            items.Add(new MultipleEntriesPopupItem(LogbookSettings.MultipleEntriesUpdateStyles.Earliest));
            items.Add(new MultipleEntriesPopupItem(LogbookSettings.MultipleEntriesUpdateStyles.Latest));
            items.Add(new MultipleEntriesPopupItem(LogbookSettings.MultipleEntriesUpdateStyles.Lowest));
            items.Add(new MultipleEntriesPopupItem(LogbookSettings.MultipleEntriesUpdateStyles.Highest));
            foreach (MultipleEntriesPopupItem item in items)
            {
                if (settings.ImportMultipleEntries == item.Item)
                {
                    selected = item;
                }
            }
            ControlUtils.OpenListPopup<MultipleEntriesPopupItem>(theme, items, multipleEntriesTextBox, selected,
                delegate(MultipleEntriesPopupItem selectedItem)
                {
                    if (logbook == null) return;
                    settings.ImportMultipleEntries = selectedItem.Item;
                    settings.Save(logbook);
                    RefreshMutipleEntriesTextBox();
                });
        }

        private void OnManualCheckBoxCheckedChanged(object sender, EventArgs e)
        {
            if (logbook != null && settings.ImportManualEntries != manualCheckBox.Checked)
            {
                settings.ImportManualEntries = manualCheckBox.Checked;
                settings.Save(logbook);
            }
        }

        private void OnAmbiguousCheckBoxCheckedChanged(object sender, EventArgs e)
        {
            if (logbook != null && settings.ImportAmbiguousEntries != ambiguousCheckBox.Checked)
            {
                settings.ImportAmbiguousEntries = ambiguousCheckBox.Checked;
                settings.Save(logbook);
            }
        }

        private void OnHeightCheckBoxCheckedChanged(object sender, EventArgs e)
        {
            if (logbook != null && settings.ImportHeightEntries != heightCheckBox.Checked)
            {
                settings.ImportHeightEntries = heightCheckBox.Checked;
                settings.Save(logbook);
            }
        }

        private void OnBmiCheckBoxCheckedChanged(object sender, EventArgs e)
        {
            if (logbook != null && settings.UpdateBMI != bmiCheckBox.Checked)
            {
                settings.UpdateBMI = bmiCheckBox.Checked;
                settings.Save(logbook);
            }
        }

        private void OnDeactivateButtonClick(object sender, EventArgs e)
        {
            if (logbook != null && MessageDialog.Show(ResourceLookup.UI_LogbookSettingsPanel_Deactivate_Text,
                ResourceLookup.UI_LogbookSettingsPanel_Deactivate_Title, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                settings.Email = "";
                settings.UserName = "";
                settings.UserId = "";
                settings.PublicKey = "";
                settings.Save(logbook);
                ExtendSettingsPages.RefreshSettings();
            }
        }

        private void OnReconfigureButtonClick(object sender, EventArgs e)
        {
            ConfigureWizard wizard = new ConfigureWizard();
            wizard.ThemeChanged(theme);
            wizard.ShowDialog();
            ExtendSettingsPages.RefreshSettings();
        }

        ITheme theme;
        private ILogbook logbook = null;
        private LogbookSettings settings = new LogbookSettings();
    }
}
