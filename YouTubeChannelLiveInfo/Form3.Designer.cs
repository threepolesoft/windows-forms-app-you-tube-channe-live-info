﻿namespace YouTubeChannelLiveInfo
{
    partial class Form3
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.wbYoutubeLive = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // wbYoutubeLive
            // 
            this.wbYoutubeLive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbYoutubeLive.Location = new System.Drawing.Point(0, 0);
            this.wbYoutubeLive.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbYoutubeLive.Name = "wbYoutubeLive";
            this.wbYoutubeLive.Size = new System.Drawing.Size(692, 428);
            this.wbYoutubeLive.TabIndex = 0;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 428);
            this.Controls.Add(this.wbYoutubeLive);
            this.Name = "Form3";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser wbYoutubeLive;
    }
}