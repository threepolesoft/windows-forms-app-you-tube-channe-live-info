namespace YouTubeChannelLiveInfo
{
    partial class ChannelInfo
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
            this.cmbFilter = new System.Windows.Forms.ComboBox();
            this.txtIdorUserName = new System.Windows.Forms.TextBox();
            this.btnGet = new System.Windows.Forms.Button();
            this.txtInfo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cmbFilter
            // 
            this.cmbFilter.FormattingEnabled = true;
            this.cmbFilter.Items.AddRange(new object[] {
            "id",
            "forUsername"});
            this.cmbFilter.Location = new System.Drawing.Point(12, 12);
            this.cmbFilter.Name = "cmbFilter";
            this.cmbFilter.Size = new System.Drawing.Size(48, 21);
            this.cmbFilter.TabIndex = 0;
            this.cmbFilter.Text = "id";
            // 
            // txtIdorUserName
            // 
            this.txtIdorUserName.Location = new System.Drawing.Point(66, 12);
            this.txtIdorUserName.Name = "txtIdorUserName";
            this.txtIdorUserName.Size = new System.Drawing.Size(133, 20);
            this.txtIdorUserName.TabIndex = 1;
            // 
            // btnGet
            // 
            this.btnGet.Location = new System.Drawing.Point(205, 9);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(75, 23);
            this.btnGet.TabIndex = 2;
            this.btnGet.Text = "Get";
            this.btnGet.UseVisualStyleBackColor = true;
            this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // txtInfo
            // 
            this.txtInfo.Location = new System.Drawing.Point(12, 41);
            this.txtInfo.Multiline = true;
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.Size = new System.Drawing.Size(268, 155);
            this.txtInfo.TabIndex = 3;
            // 
            // ChannelInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 207);
            this.Controls.Add(this.txtInfo);
            this.Controls.Add(this.btnGet);
            this.Controls.Add(this.txtIdorUserName);
            this.Controls.Add(this.cmbFilter);
            this.Name = "ChannelInfo";
            this.Text = "ChannelInfo";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbFilter;
        private System.Windows.Forms.TextBox txtIdorUserName;
        private System.Windows.Forms.Button btnGet;
        private System.Windows.Forms.TextBox txtInfo;
    }
}