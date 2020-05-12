namespace YoutubeDL_GUI
{
    partial class mainWindow
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLink = new System.Windows.Forms.TextBox();
            this.txtOut = new System.Windows.Forms.TextBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.chkTitle = new System.Windows.Forms.CheckBox();
            this.btnGetData = new System.Windows.Forms.Button();
            this.txtNumber = new System.Windows.Forms.NumericUpDown();
            this.chkNumber = new System.Windows.Forms.CheckBox();
            this.chkPlaylistStart = new System.Windows.Forms.CheckBox();
            this.txtPlaylistStart = new System.Windows.Forms.NumericUpDown();
            this.chkPlaylistEnd = new System.Windows.Forms.CheckBox();
            this.txtPlaylistEnd = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkDownloadLink = new System.Windows.Forms.CheckBox();
            this.chkNotPlaylist = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtPad = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSend = new System.Windows.Forms.Button();
            this.lblVidCount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtExternalAppArgs = new System.Windows.Forms.TextBox();
            this.txtExternalApp = new System.Windows.Forms.TextBox();
            this.chkExternalApp = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbQuality = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkCustomArgs = new System.Windows.Forms.CheckBox();
            this.txtCustomArgs = new System.Windows.Forms.TextBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.btnCopyToClipboard = new System.Windows.Forms.Button();
            this.btnUpdateYoutubeDL = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlaylistStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlaylistEnd)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPad)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Link :";
            // 
            // txtLink
            // 
            this.txtLink.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLink.Location = new System.Drawing.Point(51, 12);
            this.txtLink.Name = "txtLink";
            this.txtLink.Size = new System.Drawing.Size(463, 20);
            this.txtLink.TabIndex = 1;
            this.txtLink.Text = "https://www.viki.com/tv/36416c-touch-your-heart";
            // 
            // txtOut
            // 
            this.txtOut.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOut.Location = new System.Drawing.Point(6, 19);
            this.txtOut.Multiline = true;
            this.txtOut.Name = "txtOut";
            this.txtOut.ReadOnly = true;
            this.txtOut.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtOut.Size = new System.Drawing.Size(490, 196);
            this.txtOut.TabIndex = 2;
            this.txtOut.WordWrap = false;
            // 
            // txtTitle
            // 
            this.txtTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTitle.Enabled = false;
            this.txtTitle.Location = new System.Drawing.Point(146, 38);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(368, 20);
            this.txtTitle.TabIndex = 3;
            this.txtTitle.Text = "- Episode \\d{1,2}";
            // 
            // chkTitle
            // 
            this.chkTitle.AutoSize = true;
            this.chkTitle.Location = new System.Drawing.Point(15, 41);
            this.chkTitle.Name = "chkTitle";
            this.chkTitle.Size = new System.Drawing.Size(125, 17);
            this.chkTitle.TabIndex = 5;
            this.chkTitle.Text = "Match-Title (REGEX)";
            this.toolTip.SetToolTip(this.chkTitle, "--match-title REGEX");
            this.chkTitle.UseVisualStyleBackColor = true;
            this.chkTitle.CheckedChanged += new System.EventHandler(this.chkTitle_CheckedChanged);
            // 
            // btnGetData
            // 
            this.btnGetData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetData.Location = new System.Drawing.Point(439, 64);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(75, 23);
            this.btnGetData.TabIndex = 6;
            this.btnGetData.Text = "Get Data";
            this.btnGetData.UseVisualStyleBackColor = true;
            this.btnGetData.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtNumber
            // 
            this.txtNumber.Enabled = false;
            this.txtNumber.Location = new System.Drawing.Point(149, 74);
            this.txtNumber.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.txtNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(120, 20);
            this.txtNumber.TabIndex = 8;
            this.txtNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // chkNumber
            // 
            this.chkNumber.AutoSize = true;
            this.chkNumber.Enabled = false;
            this.chkNumber.Location = new System.Drawing.Point(7, 75);
            this.chkNumber.Name = "chkNumber";
            this.chkNumber.Size = new System.Drawing.Size(127, 17);
            this.chkNumber.TabIndex = 9;
            this.chkNumber.Text = "Auto-Numbering Start";
            this.chkNumber.UseVisualStyleBackColor = true;
            this.chkNumber.CheckedChanged += new System.EventHandler(this.chkNumber_CheckedChanged);
            // 
            // chkPlaylistStart
            // 
            this.chkPlaylistStart.AutoSize = true;
            this.chkPlaylistStart.Location = new System.Drawing.Point(6, 65);
            this.chkPlaylistStart.Name = "chkPlaylistStart";
            this.chkPlaylistStart.Size = new System.Drawing.Size(83, 17);
            this.chkPlaylistStart.TabIndex = 11;
            this.chkPlaylistStart.Text = "Playlist Start";
            this.toolTip.SetToolTip(this.chkPlaylistStart, "--playlist-start NUMBER");
            this.chkPlaylistStart.UseVisualStyleBackColor = true;
            this.chkPlaylistStart.CheckedChanged += new System.EventHandler(this.chkPlaylistStart_CheckedChanged);
            // 
            // txtPlaylistStart
            // 
            this.txtPlaylistStart.Enabled = false;
            this.txtPlaylistStart.Location = new System.Drawing.Point(137, 64);
            this.txtPlaylistStart.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.txtPlaylistStart.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtPlaylistStart.Name = "txtPlaylistStart";
            this.txtPlaylistStart.Size = new System.Drawing.Size(120, 20);
            this.txtPlaylistStart.TabIndex = 10;
            this.txtPlaylistStart.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // chkPlaylistEnd
            // 
            this.chkPlaylistEnd.AutoSize = true;
            this.chkPlaylistEnd.Location = new System.Drawing.Point(6, 91);
            this.chkPlaylistEnd.Name = "chkPlaylistEnd";
            this.chkPlaylistEnd.Size = new System.Drawing.Size(80, 17);
            this.chkPlaylistEnd.TabIndex = 13;
            this.chkPlaylistEnd.Text = "Playlist End";
            this.toolTip.SetToolTip(this.chkPlaylistEnd, "--playlist-end NUMBER, alternative --playlist-items NUMBER");
            this.chkPlaylistEnd.UseVisualStyleBackColor = true;
            this.chkPlaylistEnd.CheckedChanged += new System.EventHandler(this.chkPlaylistEnd_CheckedChanged);
            // 
            // txtPlaylistEnd
            // 
            this.txtPlaylistEnd.Enabled = false;
            this.txtPlaylistEnd.Location = new System.Drawing.Point(137, 90);
            this.txtPlaylistEnd.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.txtPlaylistEnd.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtPlaylistEnd.Name = "txtPlaylistEnd";
            this.txtPlaylistEnd.Size = new System.Drawing.Size(120, 20);
            this.txtPlaylistEnd.TabIndex = 12;
            this.txtPlaylistEnd.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.txtOut);
            this.groupBox2.Location = new System.Drawing.Point(12, 399);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(502, 221);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Output";
            // 
            // chkDownloadLink
            // 
            this.chkDownloadLink.AutoSize = true;
            this.chkDownloadLink.Location = new System.Drawing.Point(6, 42);
            this.chkDownloadLink.Name = "chkDownloadLink";
            this.chkDownloadLink.Size = new System.Drawing.Size(132, 17);
            this.chkDownloadLink.TabIndex = 16;
            this.chkDownloadLink.Text = "Show Download Links";
            this.chkDownloadLink.UseVisualStyleBackColor = true;
            // 
            // chkNotPlaylist
            // 
            this.chkNotPlaylist.AutoSize = true;
            this.chkNotPlaylist.Location = new System.Drawing.Point(6, 19);
            this.chkNotPlaylist.Name = "chkNotPlaylist";
            this.chkNotPlaylist.Size = new System.Drawing.Size(78, 17);
            this.chkNotPlaylist.TabIndex = 17;
            this.chkNotPlaylist.Text = "Not Playlist";
            this.toolTip.SetToolTip(this.chkNotPlaylist, "--no-playlist");
            this.chkNotPlaylist.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(439, 370);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 18;
            this.button1.Text = "Clear Output";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.txtPad);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.chkNumber);
            this.groupBox3.Controls.Add(this.btnSend);
            this.groupBox3.Controls.Add(this.txtNumber);
            this.groupBox3.Controls.Add(this.lblVidCount);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.txtExternalAppArgs);
            this.groupBox3.Controls.Add(this.txtExternalApp);
            this.groupBox3.Controls.Add(this.chkExternalApp);
            this.groupBox3.Location = new System.Drawing.Point(12, 243);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(502, 121);
            this.groupBox3.TabIndex = 19;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "External App Options";
            // 
            // txtPad
            // 
            this.txtPad.Enabled = false;
            this.txtPad.Location = new System.Drawing.Point(327, 74);
            this.txtPad.Name = "txtPad";
            this.txtPad.Size = new System.Drawing.Size(88, 20);
            this.txtPad.TabIndex = 23;
            this.txtPad.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(275, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Padding";
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.Enabled = false;
            this.btnSend.Location = new System.Drawing.Point(421, 72);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 21;
            this.btnSend.Text = "Send to App";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // lblVidCount
            // 
            this.lblVidCount.AutoSize = true;
            this.lblVidCount.Location = new System.Drawing.Point(147, 102);
            this.lblVidCount.Name = "lblVidCount";
            this.lblVidCount.Size = new System.Drawing.Size(82, 13);
            this.lblVidCount.TabIndex = 20;
            this.lblVidCount.Text = "0 videos loaded";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(78, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Arguments";
            // 
            // txtExternalAppArgs
            // 
            this.txtExternalAppArgs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtExternalAppArgs.Enabled = false;
            this.txtExternalAppArgs.Location = new System.Drawing.Point(149, 45);
            this.txtExternalAppArgs.Name = "txtExternalAppArgs";
            this.txtExternalAppArgs.Size = new System.Drawing.Size(347, 20);
            this.txtExternalAppArgs.TabIndex = 2;
            this.txtExternalAppArgs.Text = "/a /d \"{url}\" /f \"{file}.mp4\"";
            // 
            // txtExternalApp
            // 
            this.txtExternalApp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtExternalApp.Enabled = false;
            this.txtExternalApp.Location = new System.Drawing.Point(149, 18);
            this.txtExternalApp.Name = "txtExternalApp";
            this.txtExternalApp.Size = new System.Drawing.Size(347, 20);
            this.txtExternalApp.TabIndex = 1;
            this.txtExternalApp.Text = "C:\\Program Files (x86)\\Internet Download Manager\\idman.exe";
            // 
            // chkExternalApp
            // 
            this.chkExternalApp.AutoSize = true;
            this.chkExternalApp.Location = new System.Drawing.Point(7, 20);
            this.chkExternalApp.Name = "chkExternalApp";
            this.chkExternalApp.Size = new System.Drawing.Size(136, 17);
            this.chkExternalApp.TabIndex = 0;
            this.chkExternalApp.Text = "External App - Location";
            this.chkExternalApp.UseVisualStyleBackColor = true;
            this.chkExternalApp.CheckedChanged += new System.EventHandler(this.chkExternalApp_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(80, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Max quality";
            this.toolTip.SetToolTip(this.label3, "-f \"best[height<=1080]+best[ext=mp4]\"");
            // 
            // cmbQuality
            // 
            this.cmbQuality.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbQuality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbQuality.FormattingEnabled = true;
            this.cmbQuality.Location = new System.Drawing.Point(146, 66);
            this.cmbQuality.Name = "cmbQuality";
            this.cmbQuality.Size = new System.Drawing.Size(287, 21);
            this.cmbQuality.TabIndex = 21;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.chkNotPlaylist);
            this.groupBox1.Controls.Add(this.chkPlaylistStart);
            this.groupBox1.Controls.Add(this.txtPlaylistStart);
            this.groupBox1.Controls.Add(this.txtPlaylistEnd);
            this.groupBox1.Controls.Add(this.chkDownloadLink);
            this.groupBox1.Controls.Add(this.chkPlaylistEnd);
            this.groupBox1.Location = new System.Drawing.Point(15, 93);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(499, 118);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Queries";
            // 
            // chkCustomArgs
            // 
            this.chkCustomArgs.AutoSize = true;
            this.chkCustomArgs.Location = new System.Drawing.Point(15, 219);
            this.chkCustomArgs.Name = "chkCustomArgs";
            this.chkCustomArgs.Size = new System.Drawing.Size(85, 17);
            this.chkCustomArgs.TabIndex = 23;
            this.chkCustomArgs.Text = "Custom Args";
            this.toolTip.SetToolTip(this.chkCustomArgs, "If enabled, none of the other options will be applicable");
            this.chkCustomArgs.UseVisualStyleBackColor = true;
            this.chkCustomArgs.CheckedChanged += new System.EventHandler(this.chkCustomArgs_CheckedChanged);
            // 
            // txtCustomArgs
            // 
            this.txtCustomArgs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCustomArgs.Enabled = false;
            this.txtCustomArgs.Location = new System.Drawing.Point(106, 217);
            this.txtCustomArgs.Name = "txtCustomArgs";
            this.txtCustomArgs.Size = new System.Drawing.Size(408, 20);
            this.txtCustomArgs.TabIndex = 24;
            this.toolTip.SetToolTip(this.txtCustomArgs, "--write-auto-sub : Youtube ONLY\r\n--write-sub : All others\r\n> asd.txt : Console ou" +
        "tput to file");
            // 
            // btnCopyToClipboard
            // 
            this.btnCopyToClipboard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopyToClipboard.AutoSize = true;
            this.btnCopyToClipboard.Location = new System.Drawing.Point(309, 370);
            this.btnCopyToClipboard.Name = "btnCopyToClipboard";
            this.btnCopyToClipboard.Size = new System.Drawing.Size(124, 23);
            this.btnCopyToClipboard.TabIndex = 25;
            this.btnCopyToClipboard.Text = "Copy links to Clipboard";
            this.btnCopyToClipboard.UseVisualStyleBackColor = true;
            this.btnCopyToClipboard.Click += new System.EventHandler(this.btnCopyToClipboard_Click);
            // 
            // btnUpdateYoutubeDL
            // 
            this.btnUpdateYoutubeDL.AutoSize = true;
            this.btnUpdateYoutubeDL.Location = new System.Drawing.Point(15, 370);
            this.btnUpdateYoutubeDL.Name = "btnUpdateYoutubeDL";
            this.btnUpdateYoutubeDL.Size = new System.Drawing.Size(124, 23);
            this.btnUpdateYoutubeDL.TabIndex = 26;
            this.btnUpdateYoutubeDL.Text = "Update Youtube-DL";
            this.btnUpdateYoutubeDL.UseVisualStyleBackColor = true;
            this.btnUpdateYoutubeDL.Click += new System.EventHandler(this.btnUpdateYoutubeDL_Click);
            // 
            // mainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 632);
            this.Controls.Add(this.btnUpdateYoutubeDL);
            this.Controls.Add(this.btnCopyToClipboard);
            this.Controls.Add(this.txtCustomArgs);
            this.Controls.Add(this.chkCustomArgs);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.cmbQuality);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnGetData);
            this.Controls.Add(this.chkTitle);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.txtLink);
            this.Controls.Add(this.label1);
            this.MinimumSize = new System.Drawing.Size(542, 624);
            this.Name = "mainWindow";
            this.Text = "YoutubeDL GUI";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlaylistStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlaylistEnd)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPad)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLink;
        private System.Windows.Forms.TextBox txtOut;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.CheckBox chkTitle;
        private System.Windows.Forms.Button btnGetData;
        private System.Windows.Forms.NumericUpDown txtNumber;
        private System.Windows.Forms.CheckBox chkNumber;
        private System.Windows.Forms.CheckBox chkPlaylistStart;
        private System.Windows.Forms.NumericUpDown txtPlaylistStart;
        private System.Windows.Forms.CheckBox chkPlaylistEnd;
        private System.Windows.Forms.NumericUpDown txtPlaylistEnd;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkDownloadLink;
        private System.Windows.Forms.CheckBox chkNotPlaylist;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chkExternalApp;
        private System.Windows.Forms.TextBox txtExternalApp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtExternalAppArgs;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label lblVidCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbQuality;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkCustomArgs;
        private System.Windows.Forms.TextBox txtCustomArgs;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button btnCopyToClipboard;
        private System.Windows.Forms.Button btnUpdateYoutubeDL;
        private System.Windows.Forms.NumericUpDown txtPad;
        private System.Windows.Forms.Label label4;
    }
}

