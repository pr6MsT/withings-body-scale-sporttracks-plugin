namespace WithingsBodyScale
{
    partial class SettingsPage
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
            this.configureButton = new ZoneFiveSoftware.Common.Visuals.Button();
            this.settingsPanel = new WithingsBodyScale.LogbookSettingsPanel();
            this.headingPictureBox = new System.Windows.Forms.PictureBox();
            this.labelBannerText = new System.Windows.Forms.Label();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headingPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel.ColumnCount = 3;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Controls.Add(this.configureButton, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.settingsPanel, 0, 1);
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 96);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 2;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(500, 304);
            this.tableLayoutPanel.TabIndex = 1;
            // 
            // configureButton
            // 
            this.configureButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.configureButton.BackColor = System.Drawing.Color.Transparent;
            this.configureButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(120)))));
            this.configureButton.CenterImage = null;
            this.configureButton.DialogResult = System.Windows.Forms.DialogResult.None;
            this.configureButton.HyperlinkStyle = false;
            this.configureButton.ImageMargin = 2;
            this.configureButton.LeftImage = null;
            this.configureButton.Location = new System.Drawing.Point(150, 37);
            this.configureButton.Margin = new System.Windows.Forms.Padding(0);
            this.configureButton.Name = "configureButton";
            this.configureButton.PushStyle = true;
            this.configureButton.RightImage = null;
            this.configureButton.Size = new System.Drawing.Size(200, 23);
            this.configureButton.TabIndex = 0;
            this.configureButton.Text = "Configure...";
            this.configureButton.TextAlign = System.Drawing.StringAlignment.Center;
            this.configureButton.TextLeftMargin = 2;
            this.configureButton.TextRightMargin = 2;
            // 
            // settingsPanel
            // 
            this.settingsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel.SetColumnSpan(this.settingsPanel, 3);
            this.settingsPanel.Location = new System.Drawing.Point(0, 60);
            this.settingsPanel.Margin = new System.Windows.Forms.Padding(0);
            this.settingsPanel.Name = "settingsPanel";
            this.settingsPanel.Size = new System.Drawing.Size(500, 244);
            this.settingsPanel.TabIndex = 1;
            // 
            // headingPictureBox
            // 
            this.headingPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.headingPictureBox.BackColor = System.Drawing.Color.White;
            this.headingPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.headingPictureBox.Image = global::WithingsBodyScale.Properties.Resources.horizontal_banner;
            this.headingPictureBox.InitialImage = null;
            this.headingPictureBox.Location = new System.Drawing.Point(0, 0);
            this.headingPictureBox.Name = "headingPictureBox";
            this.headingPictureBox.Size = new System.Drawing.Size(500, 90);
            this.headingPictureBox.TabIndex = 0;
            this.headingPictureBox.TabStop = false;
            // 
            // labelBannerText
            // 
            this.labelBannerText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelBannerText.BackColor = System.Drawing.Color.White;
            this.labelBannerText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBannerText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(140)))), ((int)(((byte)(225)))));
            this.labelBannerText.Location = new System.Drawing.Point(100, 58);
            this.labelBannerText.Name = "labelBannerText";
            this.labelBannerText.Size = new System.Drawing.Size(397, 23);
            this.labelBannerText.TabIndex = 2;
            this.labelBannerText.Text = "The Internet connected Body Scale";
            // 
            // SettingsPage
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.labelBannerText);
            this.Controls.Add(this.tableLayoutPanel);
            this.Controls.Add(this.headingPictureBox);
            this.MinimumSize = new System.Drawing.Size(500, 400);
            this.Name = "SettingsPage";
            this.Size = new System.Drawing.Size(500, 400);
            this.tableLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headingPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox headingPictureBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private ZoneFiveSoftware.Common.Visuals.Button configureButton;
        private LogbookSettingsPanel settingsPanel;
        private System.Windows.Forms.Label labelBannerText;
    }
}
