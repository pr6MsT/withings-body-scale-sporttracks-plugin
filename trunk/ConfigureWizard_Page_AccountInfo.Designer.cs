namespace WithingsBodyScale
{
    partial class ConfigureWizard_Page_AccountInfo
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
            this.topTextLabel = new System.Windows.Forms.Label();
            this.accountLabel = new System.Windows.Forms.Label();
            this.accountTextBox = new ZoneFiveSoftware.Common.Visuals.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.passwordTextBox = new ZoneFiveSoftware.Common.Visuals.TextBox();
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
            this.tableLayoutPanel.Controls.Add(this.topTextLabel, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.accountLabel, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.accountTextBox, 2, 1);
            this.tableLayoutPanel.Controls.Add(this.passwordLabel, 1, 2);
            this.tableLayoutPanel.Controls.Add(this.passwordTextBox, 2, 2);
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 4;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(529, 311);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // topTextLabel
            // 
            this.topTextLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel.SetColumnSpan(this.topTextLabel, 4);
            this.topTextLabel.Location = new System.Drawing.Point(0, 0);
            this.topTextLabel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.topTextLabel.Name = "topTextLabel";
            this.topTextLabel.Size = new System.Drawing.Size(529, 50);
            this.topTextLabel.TabIndex = 0;
            this.topTextLabel.Text = "";
            // 
            // accountLabel
            // 
            this.accountLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.accountLabel.Location = new System.Drawing.Point(43, 63);
            this.accountLabel.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.accountLabel.Name = "accountLabel";
            this.accountLabel.Size = new System.Drawing.Size(126, 14);
            this.accountLabel.TabIndex = 1;
            this.accountLabel.Text = "Account:";
            // 
            // accountTextBox
            // 
            this.accountTextBox.AcceptsReturn = false;
            this.accountTextBox.AcceptsTab = false;
            this.accountTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.accountTextBox.BackColor = System.Drawing.Color.White;
            this.accountTextBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(114)))), ((int)(((byte)(108)))));
            this.accountTextBox.ButtonImage = null;
            this.accountTextBox.Location = new System.Drawing.Point(172, 60);
            this.accountTextBox.Margin = new System.Windows.Forms.Padding(0, 0, 3, 13);
            this.accountTextBox.MaxLength = 32767;
            this.accountTextBox.Multiline = false;
            this.accountTextBox.Name = "accountTextBox";
            this.accountTextBox.ReadOnly = false;
            this.accountTextBox.ReadOnlyColor = System.Drawing.SystemColors.Control;
            this.accountTextBox.ReadOnlyTextColor = System.Drawing.SystemColors.ControlLight;
            this.accountTextBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.accountTextBox.Size = new System.Drawing.Size(297, 19);
            this.accountTextBox.TabIndex = 2;
            this.accountTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // passwordLabel
            // 
            this.passwordLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.passwordLabel.Location = new System.Drawing.Point(43, 95);
            this.passwordLabel.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(126, 14);
            this.passwordLabel.TabIndex = 3;
            this.passwordLabel.Text = "Password:";
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.AcceptsReturn = false;
            this.passwordTextBox.AcceptsTab = false;
            this.passwordTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.passwordTextBox.BackColor = System.Drawing.Color.White;
            this.passwordTextBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(114)))), ((int)(((byte)(108)))));
            this.passwordTextBox.ButtonImage = null;
            this.passwordTextBox.Location = new System.Drawing.Point(172, 92);
            this.passwordTextBox.Margin = new System.Windows.Forms.Padding(0, 0, 3, 3);
            this.passwordTextBox.MaxLength = 32767;
            this.passwordTextBox.Multiline = false;
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.ReadOnly = false;
            this.passwordTextBox.ReadOnlyColor = System.Drawing.SystemColors.Control;
            this.passwordTextBox.ReadOnlyTextColor = System.Drawing.SystemColors.ControlLight;
            this.passwordTextBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.passwordTextBox.Size = new System.Drawing.Size(297, 19);
            this.passwordTextBox.TabIndex = 4;
            this.passwordTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // ConfigureWizard_Page_AccountInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WithingsBodyScale.Properties.Resources.scale_watermark_large;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Controls.Add(this.tableLayoutPanel);
            this.DoubleBuffered = true;
            this.Name = "ConfigureWizard_Page_AccountInfo";
            this.Size = new System.Drawing.Size(529, 311);
            this.tableLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Label topTextLabel;
        private System.Windows.Forms.Label accountLabel;
        private ZoneFiveSoftware.Common.Visuals.TextBox accountTextBox;
        private System.Windows.Forms.Label passwordLabel;
        private ZoneFiveSoftware.Common.Visuals.TextBox passwordTextBox;
    }
}
