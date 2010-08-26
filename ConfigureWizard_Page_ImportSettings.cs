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
    public partial class ConfigureWizard_Page_ImportSettings : UserControl, IWizardPage
    {
        public ConfigureWizard_Page_ImportSettings(ConfigureWizard wizard)
        {
            InitializeComponent();
            this.wizard = wizard;

            multipleEntriesTextBox.ButtonClick += new EventHandler(OnMultipleEntriesTextBoxButtonClick);
        }

        public LogbookSettings.MultipleEntriesUpdateStyles ImportMultipleEntries
        {
            get { return importMultipleEntries; }
        }

        public bool ImportManualEntries
        {
            get { return manualCheckBox.Checked; }
        }

        public bool ImportAmbiguousEntries
        {
            get { return ambiguousCheckBox.Checked; }
        }

        public bool ImportHeightEntries
        {
            get { return heightCheckBox.Checked; }
        }

        public bool UpdateBMI
        {
            get { return bmiCheckBox.Checked; }
        }

        public string PageName
        {
            get { return ResourceLookup.UI_ConfigureWizard_Page_ImportSettings_Title; }
        }

        public void ThemeChanged(ITheme visualTheme)
        {
            this.theme = visualTheme;
            multipleEntriesLabel.ForeColor = theme.ControlText;
            multipleEntriesTextBox.ThemeChanged(theme);
            manualLabel.ForeColor = theme.ControlText;
            ambiguousLabel.ForeColor = theme.ControlText;
            heightLabel.ForeColor = theme.ControlText;
            updateBMILabel.ForeColor = theme.ControlText;
        }

        public void UICultureChanged(CultureInfo culture)
        {
            multipleEntriesLabel.Text = ResourceLookup.UI_LogbookSettingsPanel_multipleEntriesLabel_Text;
            RefreshMutipleEntriesTextBox();
            manualLabel.Text = ResourceLookup.UI_LogbookSettingsPanel_manualLabel_Text;
            ambiguousLabel.Text = ResourceLookup.UI_LogbookSettingsPanel_ambiguousLabel_Text;
            heightLabel.Text = ResourceLookup.UI_LogbookSettingsPanel_heightLabel_Text;
            updateBMILabel.Text = ResourceLookup.UI_LogbookSettingsPanel_updateBMILabel_Text;
        }

        public void ShowPage(string bookmark)
        {
            importMultipleEntries = wizard.Settings.ImportMultipleEntries;
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

        public bool CanFinish
        {
            get { return false; }
        }

        public bool CanNext
        {
            get { return true; }
        }

        public bool CanPrev
        {
            get { return true; }
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

        private void RefreshControls()
        {
            RefreshMutipleEntriesTextBox();
            manualCheckBox.Checked = wizard.Settings.ImportManualEntries;
            ambiguousCheckBox.Checked = wizard.Settings.ImportAmbiguousEntries;
            heightCheckBox.Checked = wizard.Settings.ImportHeightEntries;
            bmiCheckBox.Checked = wizard.Settings.UpdateBMI;
        }

        private void RefreshMutipleEntriesTextBox()
        {
            multipleEntriesTextBox.Text = MutipleEntriesText(importMultipleEntries);
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
            public override string ToString() { return Text; }
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
            MultipleEntriesPopupItem selected = null;
            IList<MultipleEntriesPopupItem> items = new List<MultipleEntriesPopupItem>();
            items.Add(new MultipleEntriesPopupItem(LogbookSettings.MultipleEntriesUpdateStyles.Earliest));
            items.Add(new MultipleEntriesPopupItem(LogbookSettings.MultipleEntriesUpdateStyles.Latest));
            items.Add(new MultipleEntriesPopupItem(LogbookSettings.MultipleEntriesUpdateStyles.Lowest));
            items.Add(new MultipleEntriesPopupItem(LogbookSettings.MultipleEntriesUpdateStyles.Highest));
            foreach (MultipleEntriesPopupItem item in items)
            {
                if (importMultipleEntries == item.Item)
                {
                    selected = item;
                }
            }
            ControlUtils.OpenListPopup<MultipleEntriesPopupItem>(theme, items, multipleEntriesTextBox, selected,
                delegate(MultipleEntriesPopupItem selectedItem)
                {
                    importMultipleEntries = selectedItem.Item;
                    RefreshMutipleEntriesTextBox();
                });
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private ConfigureWizard wizard;
        private ITheme theme;

        private LogbookSettings.MultipleEntriesUpdateStyles importMultipleEntries = LogbookSettings.MultipleEntriesUpdateStyles.Earliest;
    }
}
