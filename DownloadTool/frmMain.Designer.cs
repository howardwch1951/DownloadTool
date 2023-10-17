namespace DownloadTool
{
    partial class frmMain
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.btnDownload = new System.Windows.Forms.Button();
            this.txtVideoUrl = new System.Windows.Forms.TextBox();
            this.labPercent = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.rbtnVideo = new System.Windows.Forms.RadioButton();
            this.rbtnAudio = new System.Windows.Forms.RadioButton();
            this.labCheckUrl = new System.Windows.Forms.Label();
            this.cmbVideoQuality = new System.Windows.Forms.ComboBox();
            this.cmbAudioQuality = new System.Windows.Forms.ComboBox();
            this.labStatus = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pbxYoutube = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.labDuration = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbxYoutube)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDownload
            // 
            this.btnDownload.Enabled = false;
            this.btnDownload.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnDownload.Location = new System.Drawing.Point(357, 140);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(84, 23);
            this.btnDownload.TabIndex = 0;
            this.btnDownload.Text = "下載";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // txtVideoUrl
            // 
            this.txtVideoUrl.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtVideoUrl.Location = new System.Drawing.Point(58, 10);
            this.txtVideoUrl.Name = "txtVideoUrl";
            this.txtVideoUrl.Size = new System.Drawing.Size(382, 25);
            this.txtVideoUrl.TabIndex = 1;
            this.txtVideoUrl.TextChanged += new System.EventHandler(this.txtVideoUrl_TextChanged);
            // 
            // labPercent
            // 
            this.labPercent.AutoSize = true;
            this.labPercent.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labPercent.Location = new System.Drawing.Point(446, 205);
            this.labPercent.Name = "labPercent";
            this.labPercent.Size = new System.Drawing.Size(27, 17);
            this.labPercent.TabIndex = 3;
            this.labPercent.Text = "0%";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(10, 203);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(430, 21);
            this.progressBar1.TabIndex = 4;
            // 
            // rbtnVideo
            // 
            this.rbtnVideo.AutoSize = true;
            this.rbtnVideo.Checked = true;
            this.rbtnVideo.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.rbtnVideo.Location = new System.Drawing.Point(11, 141);
            this.rbtnVideo.Name = "rbtnVideo";
            this.rbtnVideo.Size = new System.Drawing.Size(52, 21);
            this.rbtnVideo.TabIndex = 7;
            this.rbtnVideo.TabStop = true;
            this.rbtnVideo.Text = "影片";
            this.rbtnVideo.UseVisualStyleBackColor = true;
            this.rbtnVideo.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // rbtnAudio
            // 
            this.rbtnAudio.AutoSize = true;
            this.rbtnAudio.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.rbtnAudio.Location = new System.Drawing.Point(181, 141);
            this.rbtnAudio.Name = "rbtnAudio";
            this.rbtnAudio.Size = new System.Drawing.Size(52, 21);
            this.rbtnAudio.TabIndex = 7;
            this.rbtnAudio.Text = "音樂";
            this.rbtnAudio.UseVisualStyleBackColor = true;
            this.rbtnAudio.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // labCheckUrl
            // 
            this.labCheckUrl.AutoSize = true;
            this.labCheckUrl.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labCheckUrl.Location = new System.Drawing.Point(440, 14);
            this.labCheckUrl.Name = "labCheckUrl";
            this.labCheckUrl.Size = new System.Drawing.Size(0, 17);
            this.labCheckUrl.TabIndex = 3;
            // 
            // cmbVideoQuality
            // 
            this.cmbVideoQuality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVideoQuality.Enabled = false;
            this.cmbVideoQuality.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cmbVideoQuality.FormattingEnabled = true;
            this.cmbVideoQuality.Location = new System.Drawing.Point(66, 139);
            this.cmbVideoQuality.Name = "cmbVideoQuality";
            this.cmbVideoQuality.Size = new System.Drawing.Size(93, 25);
            this.cmbVideoQuality.TabIndex = 8;
            // 
            // cmbAudioQuality
            // 
            this.cmbAudioQuality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAudioQuality.Enabled = false;
            this.cmbAudioQuality.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cmbAudioQuality.FormattingEnabled = true;
            this.cmbAudioQuality.Location = new System.Drawing.Point(239, 139);
            this.cmbAudioQuality.Name = "cmbAudioQuality";
            this.cmbAudioQuality.Size = new System.Drawing.Size(93, 25);
            this.cmbAudioQuality.TabIndex = 8;
            // 
            // labStatus
            // 
            this.labStatus.AutoSize = true;
            this.labStatus.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labStatus.Location = new System.Drawing.Point(81, 183);
            this.labStatus.Margin = new System.Windows.Forms.Padding(0);
            this.labStatus.Name = "labStatus";
            this.labStatus.Size = new System.Drawing.Size(0, 17);
            this.labStatus.TabIndex = 3;
            this.labStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(8, 183);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "目前進度：";
            // 
            // txtTitle
            // 
            this.txtTitle.BackColor = System.Drawing.SystemColors.Control;
            this.txtTitle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTitle.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtTitle.Location = new System.Drawing.Point(58, 52);
            this.txtTitle.Multiline = true;
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.ReadOnly = true;
            this.txtTitle.Size = new System.Drawing.Size(484, 34);
            this.txtTitle.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(8, 52);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "標題：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(8, 14);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "網址：";
            // 
            // pbxYoutube
            // 
            this.pbxYoutube.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxYoutube.Location = new System.Drawing.Point(548, 10);
            this.pbxYoutube.Name = "pbxYoutube";
            this.pbxYoutube.Size = new System.Drawing.Size(313, 228);
            this.pbxYoutube.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxYoutube.TabIndex = 11;
            this.pbxYoutube.TabStop = false;
            this.pbxYoutube.Click += new System.EventHandler(this.pbxYoutube_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(8, 103);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "影片長度：";
            // 
            // labDuration
            // 
            this.labDuration.AutoSize = true;
            this.labDuration.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labDuration.Location = new System.Drawing.Point(81, 103);
            this.labDuration.Margin = new System.Windows.Forms.Padding(0);
            this.labDuration.Name = "labDuration";
            this.labDuration.Size = new System.Drawing.Size(0, 17);
            this.labDuration.TabIndex = 3;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 248);
            this.Controls.Add(this.pbxYoutube);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.cmbAudioQuality);
            this.Controls.Add(this.cmbVideoQuality);
            this.Controls.Add(this.rbtnAudio);
            this.Controls.Add(this.rbtnVideo);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labDuration);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labCheckUrl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labStatus);
            this.Controls.Add(this.labPercent);
            this.Controls.Add(this.txtVideoUrl);
            this.Controls.Add(this.btnDownload);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.Text = "Youtube下載工具";
            ((System.ComponentModel.ISupportInitialize)(this.pbxYoutube)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.TextBox txtVideoUrl;
        private System.Windows.Forms.Label labPercent;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.RadioButton rbtnVideo;
        private System.Windows.Forms.RadioButton rbtnAudio;
        private System.Windows.Forms.Label labCheckUrl;
        private System.Windows.Forms.ComboBox cmbVideoQuality;
        private System.Windows.Forms.ComboBox cmbAudioQuality;
        private System.Windows.Forms.Label labStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pbxYoutube;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labDuration;
        private System.Windows.Forms.ToolTip toolTip;
    }
}

