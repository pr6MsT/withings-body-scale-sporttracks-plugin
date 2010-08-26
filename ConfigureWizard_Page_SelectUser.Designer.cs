namespace WithingsBodyScale
{
    partial class ConfigureWizard_Page_SelectUser
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.usersList = new ZoneFiveSoftware.Common.Visuals.TreeList();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel.ColumnCount = 4;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 129F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Controls.Add(this.usersList, 1, 1);
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 3;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(529, 311);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // usersList
            // 
            this.usersList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.usersList.BackColor = System.Drawing.Color.Transparent;
            this.usersList.Border = ZoneFiveSoftware.Common.Visuals.ControlBorder.Style.None;
            this.usersList.CheckBoxes = false;
            this.tableLayoutPanel.SetColumnSpan(this.usersList, 2);
            this.usersList.DefaultIndent = 15;
            this.usersList.DefaultRowHeight = -1;
            this.usersList.HeaderRowHeight = 21;
            this.usersList.Location = new System.Drawing.Point(43, 50);
            this.usersList.Margin = new System.Windows.Forms.Padding(0);
            this.usersList.MultiSelect = false;
            this.usersList.Name = "usersList";
            this.usersList.NumHeaderRows = ZoneFiveSoftware.Common.Visuals.TreeList.HeaderRows.None;
            this.usersList.NumLockedColumns = 0;
            this.usersList.RowAlternatingColors = false;
            this.usersList.RowHotlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(49)))), ((int)(((byte)(106)))), ((int)(((byte)(197)))));
            this.usersList.RowHotlightColorText = System.Drawing.SystemColors.HighlightText;
            this.usersList.RowHotlightMouse = true;
            this.usersList.RowSelectedColor = System.Drawing.SystemColors.Highlight;
            this.usersList.RowSelectedColorText = System.Drawing.SystemColors.HighlightText;
            this.usersList.RowSeparatorLines = false;
            this.usersList.ShowLines = false;
            this.usersList.ShowPlusMinus = false;
            this.usersList.Size = new System.Drawing.Size(429, 241);
            this.usersList.TabIndex = 1;
            // 
            // ConfigureWizard_Page_SelectUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WithingsBodyScale.Properties.Resources.scale_watermark_large;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Controls.Add(this.tableLayoutPanel);
            this.DoubleBuffered = true;
            this.Name = "ConfigureWizard_Page_SelectUser";
            this.Size = new System.Drawing.Size(529, 311);
            this.tableLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private ZoneFiveSoftware.Common.Visuals.TreeList usersList;
    }
}
