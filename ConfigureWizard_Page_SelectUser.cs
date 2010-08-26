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
    public partial class ConfigureWizard_Page_SelectUser : UserControl, IWizardPage
    {
        public ConfigureWizard_Page_SelectUser(ConfigureWizard wizard)
        {
            InitializeComponent();
            this.wizard = wizard;

            usersList.Columns.Add(new TreeList.Column());
            usersList.SelectedItemsChanged += new EventHandler(OnUsersListSelectedItemsChanged);
        }

        public IList<WithingsWebServiceProxy.UserInfo> Users
        {
            set
            {
                usersList.RowData = value;
                if (value.Count > 0) usersList.SelectedItems = new object[] { value[0] };
            }
        }

        public WithingsWebServiceProxy.UserInfo SelectedUser
        {
            get { return selectedUser; }
        }

        public string PageName
        {
            get { return ResourceLookup.UI_ConfigureWizard_Page_SelectUser_Title; }
        }

        public void ThemeChanged(ITheme visualTheme)
        {
            usersList.ThemeChanged(visualTheme);
            usersList.BackColor = Color.Transparent;
        }

        public void UICultureChanged(CultureInfo culture)
        {
        }

        public void ShowPage(string bookmark)
        {
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
            get { return selectedUser != null; }
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

        private void OnUsersListSelectedItemsChanged(object sender, EventArgs e)
        {
            IList selection = usersList.SelectedItems;
            if (selection.Count > 0 && selection[0] is WithingsWebServiceProxy.UserInfo)
            {
                selectedUser = (WithingsWebServiceProxy.UserInfo)selection[0];
            }
            else
            {
                selectedUser = null;
            }
            OnPropertyChanged("CanNext");
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private ConfigureWizard wizard;
        private WithingsWebServiceProxy.UserInfo selectedUser = null;
    }
}
