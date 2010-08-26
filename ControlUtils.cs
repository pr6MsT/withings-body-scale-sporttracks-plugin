// Copyright (C) 2010 Zone Five Software
// Author: Aaron Averill
using System;
using System.Collections.Generic;
using System.Text;
using ZoneFiveSoftware.Common.Visuals;

namespace WithingsBodyScale
{
    class ControlUtils
    {
        public delegate void ItemSelectHandler<T>(T selected);

        public static void OpenListPopup<T>(ITheme theme, IList<T> items, System.Windows.Forms.Control control, T selected, ItemSelectHandler<T> selectHandler)
        {
            TreeListPopup popup = new TreeListPopup();
            popup.ThemeChanged(theme);
            popup.Tree.Columns.Add(new TreeList.Column());
            popup.Tree.RowData = items;
            if (selected != null)
            {
                popup.Tree.Selected = new object[] { selected };
            }
            popup.ItemSelected += delegate(object sender, TreeListPopup.ItemSelectedEventArgs e)
            {
                if (e.Item is T)
                {
                    selectHandler((T)e.Item);
                }
            };
            popup.Popup(control.Parent.RectangleToScreen(control.Bounds));
        }
    }
}
