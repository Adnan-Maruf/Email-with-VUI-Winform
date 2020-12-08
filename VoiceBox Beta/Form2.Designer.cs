namespace VoiceBox_Beta
{
    partial class voiceBoxMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(voiceBoxMain));
            this.TitleBar = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblDay = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnDraft = new System.Windows.Forms.Button();
            this.btnSentMails = new System.Windows.Forms.Button();
            this.btnCompose = new System.Windows.Forms.Button();
            this.btnInbox = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.timeDate = new System.Windows.Forms.Timer(this.components);
            this.panelSlide = new System.Windows.Forms.Panel();
            this.composePanel = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAttatchCncl = new System.Windows.Forms.Button();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.bodyTxt = new System.Windows.Forms.TextBox();
            this.btnAttatch = new System.Windows.Forms.Button();
            this.attachTxt = new System.Windows.Forms.TextBox();
            this.subjectTxt = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.addressTxt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.controlBar = new System.Windows.Forms.Panel();
            this.HelpBtn = new System.Windows.Forms.Button();
            this.HomeBtn = new System.Windows.Forms.Button();
            this.GotoSleepBtn = new System.Windows.Forms.Button();
            this.menuListBtn = new System.Windows.Forms.Button();
            this.minimizeBtn = new System.Windows.Forms.Button();
            this.closeBtn = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.topMenuSlide = new System.Windows.Forms.Panel();
            this.UnreadMassg = new System.Windows.Forms.Button();
            this.InboxUnreadMailslbl = new System.Windows.Forms.Label();
            this.notificationLbl = new System.Windows.Forms.Label();
            this.userAcSetngs = new System.Windows.Forms.Button();
            this.UsrNotifictn = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.AnimationTimer = new System.Windows.Forms.Timer(this.components);
            this.statusTimer = new System.Windows.Forms.Timer(this.components);
            this.browseOpt = new System.Windows.Forms.OpenFileDialog();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.CheckInboxTm = new System.Windows.Forms.Timer(this.components);
            this.NotifyUser = new System.Windows.Forms.Timer(this.components);
            this.CheckForUnread = new System.Windows.Forms.Timer(this.components);
            this.LogHelpAssistant = new System.Windows.Forms.Timer(this.components);
            this.WaitToFinish = new System.Windows.Forms.Timer(this.components);
            this.homePage = new VoiceBox_Beta.HomeUC();
            this.UI_Settings = new VoiceBox_Beta.UIsettings();
            this.DraftMailsLoad = new VoiceBox_Beta.MailLoader();
            this.SentMailsLoad = new VoiceBox_Beta.MailLoader();
            this.InboxMailLoad = new VoiceBox_Beta.MailLoader();
            this.LogInPage = new VoiceBox_Beta.ucLogIn();
            this.UserAccountSettings = new VoiceBox_Beta.AccountSettings();
            this.TitleBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel4.SuspendLayout();
            this.panelSlide.SuspendLayout();
            this.composePanel.SuspendLayout();
            this.panel3.SuspendLayout();
            this.controlBar.SuspendLayout();
            this.topMenuSlide.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // TitleBar
            // 
            this.TitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(51)))), ((int)(((byte)(255)))));
            this.TitleBar.Controls.Add(this.label2);
            this.TitleBar.Controls.Add(this.pictureBox1);
            this.TitleBar.Location = new System.Drawing.Point(0, 0);
            this.TitleBar.Name = "TitleBar";
            this.TitleBar.Size = new System.Drawing.Size(247, 47);
            this.TitleBar.TabIndex = 0;
            this.TitleBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TitleBar_MouseMove);
            this.TitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TitleBar_MouseDown);
            this.TitleBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TitleBar_MouseUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Agency FB", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(0)))), ((int)(((byte)(26)))));
            this.label2.Location = new System.Drawing.Point(122, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "-VoiceBox";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::VoiceBox_Beta.Properties.Resources.IconVB4_Main;
            this.pictureBox1.Location = new System.Drawing.Point(63, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(72, 54);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(0)))), ((int)(((byte)(26)))));
            this.panel1.Controls.Add(this.lblStatus);
            this.panel1.Controls.Add(this.pictureBox5);
            this.panel1.Controls.Add(this.pictureBox4);
            this.panel1.Controls.Add(this.lblTime);
            this.panel1.Controls.Add(this.lblDate);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.btnSettings);
            this.panel1.Controls.Add(this.btnDraft);
            this.panel1.Controls.Add(this.btnSentMails);
            this.panel1.Controls.Add(this.btnCompose);
            this.panel1.Controls.Add(this.btnInbox);
            this.panel1.Controls.Add(this.btnLogin);
            this.panel1.Location = new System.Drawing.Point(0, 47);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(247, 534);
            this.panel1.TabIndex = 1;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblStatus.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
            this.lblStatus.Location = new System.Drawing.Point(118, 47);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 21);
            this.lblStatus.TabIndex = 17;
            this.lblStatus.Visible = false;
            this.lblStatus.TextChanged += new System.EventHandler(this.lblStatus_TextChanged);
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::VoiceBox_Beta.Properties.Resources.SBI_0;
            this.pictureBox5.Location = new System.Drawing.Point(108, 29);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(136, 60);
            this.pictureBox5.TabIndex = 16;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::VoiceBox_Beta.Properties.Resources.pass1;
            this.pictureBox4.Location = new System.Drawing.Point(2, 6);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(104, 104);
            this.pictureBox4.TabIndex = 15;
            this.pictureBox4.TabStop = false;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.Color.White;
            this.lblTime.Location = new System.Drawing.Point(129, 466);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(65, 21);
            this.lblTime.TabIndex = 9;
            this.lblTime.Text = "HH:MM PM";
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDate.Font = new System.Drawing.Font("Agency FB", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(170)))), ((int)(((byte)(255)))));
            this.lblDate.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblDate.Location = new System.Drawing.Point(63, 450);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(68, 18);
            this.lblDate.TabIndex = 10;
            this.lblDate.Text = "MMM DD YYYY";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::VoiceBox_Beta.Properties.Resources.TnD;
            this.pictureBox2.Location = new System.Drawing.Point(8, 443);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(48, 51);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 14;
            this.pictureBox2.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.lblDay);
            this.panel4.Font = new System.Drawing.Font("Segoe MDL2 Assets", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel4.Location = new System.Drawing.Point(63, 468);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(81, 25);
            this.panel4.TabIndex = 13;
            // 
            // lblDay
            // 
            this.lblDay.AutoSize = true;
            this.lblDay.Font = new System.Drawing.Font("Agency FB", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDay.ForeColor = System.Drawing.Color.White;
            this.lblDay.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDay.Location = new System.Drawing.Point(26, 2);
            this.lblDay.Name = "lblDay";
            this.lblDay.Size = new System.Drawing.Size(29, 16);
            this.lblDay.TabIndex = 11;
            this.lblDay.Text = "DATE";
            this.lblDay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(77)))));
            this.label4.Location = new System.Drawing.Point(0, 516);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "(C).2018.V1.0.0 ";
            // 
            // btnSettings
            // 
            this.btnSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSettings.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(0)))), ((int)(((byte)(51)))));
            this.btnSettings.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(51)))), ((int)(((byte)(255)))));
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSettings.ForeColor = System.Drawing.Color.White;
            this.btnSettings.Image = ((System.Drawing.Image)(resources.GetObject("btnSettings.Image")));
            this.btnSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSettings.Location = new System.Drawing.Point(0, 371);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(249, 52);
            this.btnSettings.TabIndex = 6;
            this.btnSettings.Text = "Settings";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnDraft
            // 
            this.btnDraft.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDraft.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(0)))), ((int)(((byte)(51)))));
            this.btnDraft.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(51)))), ((int)(((byte)(255)))));
            this.btnDraft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDraft.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDraft.ForeColor = System.Drawing.Color.White;
            this.btnDraft.Image = ((System.Drawing.Image)(resources.GetObject("btnDraft.Image")));
            this.btnDraft.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDraft.Location = new System.Drawing.Point(0, 320);
            this.btnDraft.Name = "btnDraft";
            this.btnDraft.Size = new System.Drawing.Size(249, 52);
            this.btnDraft.TabIndex = 5;
            this.btnDraft.Text = "Drafts";
            this.btnDraft.UseVisualStyleBackColor = true;
            this.btnDraft.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnSentMails
            // 
            this.btnSentMails.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSentMails.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(0)))), ((int)(((byte)(51)))));
            this.btnSentMails.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(51)))), ((int)(((byte)(255)))));
            this.btnSentMails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSentMails.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSentMails.ForeColor = System.Drawing.Color.White;
            this.btnSentMails.Image = ((System.Drawing.Image)(resources.GetObject("btnSentMails.Image")));
            this.btnSentMails.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSentMails.Location = new System.Drawing.Point(0, 269);
            this.btnSentMails.Name = "btnSentMails";
            this.btnSentMails.Size = new System.Drawing.Size(249, 52);
            this.btnSentMails.TabIndex = 4;
            this.btnSentMails.Text = "Sent Mails";
            this.btnSentMails.UseVisualStyleBackColor = true;
            this.btnSentMails.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnCompose
            // 
            this.btnCompose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCompose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(0)))), ((int)(((byte)(51)))));
            this.btnCompose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(51)))), ((int)(((byte)(255)))));
            this.btnCompose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCompose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCompose.ForeColor = System.Drawing.Color.White;
            this.btnCompose.Image = ((System.Drawing.Image)(resources.GetObject("btnCompose.Image")));
            this.btnCompose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCompose.Location = new System.Drawing.Point(0, 167);
            this.btnCompose.Name = "btnCompose";
            this.btnCompose.Size = new System.Drawing.Size(249, 52);
            this.btnCompose.TabIndex = 2;
            this.btnCompose.Text = "Compose";
            this.btnCompose.UseVisualStyleBackColor = true;
            this.btnCompose.Click += new System.EventHandler(this.btnCompose_Click);
            // 
            // btnInbox
            // 
            this.btnInbox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInbox.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(0)))), ((int)(((byte)(51)))));
            this.btnInbox.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(51)))), ((int)(((byte)(255)))));
            this.btnInbox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInbox.ForeColor = System.Drawing.Color.White;
            this.btnInbox.Image = global::VoiceBox_Beta.Properties.Resources.Inbox_;
            this.btnInbox.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInbox.Location = new System.Drawing.Point(0, 218);
            this.btnInbox.Name = "btnInbox";
            this.btnInbox.Size = new System.Drawing.Size(249, 52);
            this.btnInbox.TabIndex = 3;
            this.btnInbox.Text = "Inbox";
            this.btnInbox.UseVisualStyleBackColor = true;
            this.btnInbox.Click += new System.EventHandler(this.btnInbox_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(0)))), ((int)(((byte)(51)))));
            this.btnLogin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(51)))), ((int)(((byte)(255)))));
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Image = ((System.Drawing.Image)(resources.GetObject("btnLogin.Image")));
            this.btnLogin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogin.Location = new System.Drawing.Point(0, 116);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(248, 52);
            this.btnLogin.TabIndex = 1;
            this.btnLogin.Text = "Log In";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // timeDate
            // 
            this.timeDate.Tick += new System.EventHandler(this.timeDate_Tick);
            // 
            // panelSlide
            // 
            this.panelSlide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(0)))), ((int)(((byte)(26)))));
            this.panelSlide.Controls.Add(this.composePanel);
            this.panelSlide.Location = new System.Drawing.Point(245, 107);
            this.panelSlide.Name = "panelSlide";
            this.panelSlide.Size = new System.Drawing.Size(1, 428);
            this.panelSlide.TabIndex = 2;
            // 
            // composePanel
            // 
            this.composePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.composePanel.Controls.Add(this.panel3);
            this.composePanel.Controls.Add(this.btnAttatchCncl);
            this.composePanel.Controls.Add(this.SaveBtn);
            this.composePanel.Controls.Add(this.btnSend);
            this.composePanel.Controls.Add(this.bodyTxt);
            this.composePanel.Controls.Add(this.btnAttatch);
            this.composePanel.Controls.Add(this.attachTxt);
            this.composePanel.Controls.Add(this.subjectTxt);
            this.composePanel.Controls.Add(this.label7);
            this.composePanel.Controls.Add(this.addressTxt);
            this.composePanel.Controls.Add(this.label6);
            this.composePanel.Location = new System.Drawing.Point(3, 0);
            this.composePanel.Name = "composePanel";
            this.composePanel.Size = new System.Drawing.Size(375, 427);
            this.composePanel.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel3.Controls.Add(this.label5);
            this.panel3.Location = new System.Drawing.Point(-1, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(377, 40);
            this.panel3.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(4, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "[New Message]";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnAttatchCncl
            // 
            this.btnAttatchCncl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAttatchCncl.Enabled = false;
            this.btnAttatchCncl.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.btnAttatchCncl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAttatchCncl.Image = global::VoiceBox_Beta.Properties.Resources.CmpAtchCncl;
            this.btnAttatchCncl.Location = new System.Drawing.Point(39, 109);
            this.btnAttatchCncl.Name = "btnAttatchCncl";
            this.btnAttatchCncl.Size = new System.Drawing.Size(23, 23);
            this.btnAttatchCncl.TabIndex = 12;
            this.btnAttatchCncl.UseVisualStyleBackColor = true;
            this.btnAttatchCncl.Click += new System.EventHandler(this.btnAttatchCncl_Click);
            // 
            // SaveBtn
            // 
            this.SaveBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(0)))), ((int)(((byte)(26)))));
            this.SaveBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SaveBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(0)))), ((int)(((byte)(26)))));
            this.SaveBtn.FlatAppearance.BorderSize = 0;
            this.SaveBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.SaveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveBtn.Font = new System.Drawing.Font("Microsoft PhagsPa", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveBtn.ForeColor = System.Drawing.Color.White;
            this.SaveBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.SaveBtn.Location = new System.Drawing.Point(26, 388);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(98, 33);
            this.SaveBtn.TabIndex = 11;
            this.SaveBtn.Text = "Save";
            this.SaveBtn.UseVisualStyleBackColor = false;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // btnSend
            // 
            this.btnSend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(71)))), ((int)(((byte)(170)))));
            this.btnSend.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSend.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(71)))), ((int)(((byte)(170)))));
            this.btnSend.FlatAppearance.BorderSize = 0;
            this.btnSend.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSend.Font = new System.Drawing.Font("Microsoft PhagsPa", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSend.ForeColor = System.Drawing.Color.White;
            this.btnSend.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSend.Location = new System.Drawing.Point(246, 388);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(98, 33);
            this.btnSend.TabIndex = 10;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // bodyTxt
            // 
            this.bodyTxt.BackColor = System.Drawing.Color.White;
            this.bodyTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bodyTxt.Location = new System.Drawing.Point(6, 141);
            this.bodyTxt.Multiline = true;
            this.bodyTxt.Name = "bodyTxt";
            this.bodyTxt.Size = new System.Drawing.Size(363, 241);
            this.bodyTxt.TabIndex = 8;
            // 
            // btnAttatch
            // 
            this.btnAttatch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAttatch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.btnAttatch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAttatch.Image = ((System.Drawing.Image)(resources.GetObject("btnAttatch.Image")));
            this.btnAttatch.Location = new System.Drawing.Point(10, 109);
            this.btnAttatch.Name = "btnAttatch";
            this.btnAttatch.Size = new System.Drawing.Size(23, 23);
            this.btnAttatch.TabIndex = 6;
            this.btnAttatch.UseVisualStyleBackColor = true;
            this.btnAttatch.Click += new System.EventHandler(this.btnAttatch_Click);
            // 
            // attachTxt
            // 
            this.attachTxt.BackColor = System.Drawing.Color.White;
            this.attachTxt.Enabled = false;
            this.attachTxt.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.attachTxt.Location = new System.Drawing.Point(68, 109);
            this.attachTxt.Name = "attachTxt";
            this.attachTxt.Size = new System.Drawing.Size(294, 21);
            this.attachTxt.TabIndex = 5;
            this.attachTxt.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // subjectTxt
            // 
            this.subjectTxt.BackColor = System.Drawing.Color.White;
            this.subjectTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subjectTxt.Location = new System.Drawing.Point(47, 78);
            this.subjectTxt.Name = "subjectTxt";
            this.subjectTxt.Size = new System.Drawing.Size(315, 26);
            this.subjectTxt.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(1, 78);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 20);
            this.label7.TabIndex = 2;
            this.label7.Text = "Sub:";
            // 
            // addressTxt
            // 
            this.addressTxt.BackColor = System.Drawing.Color.White;
            this.addressTxt.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.addressTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addressTxt.Location = new System.Drawing.Point(47, 46);
            this.addressTxt.Name = "addressTxt";
            this.addressTxt.Size = new System.Drawing.Size(315, 26);
            this.addressTxt.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "To:";
            // 
            // controlBar
            // 
            this.controlBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(0)))), ((int)(((byte)(26)))));
            this.controlBar.Controls.Add(this.HelpBtn);
            this.controlBar.Controls.Add(this.HomeBtn);
            this.controlBar.Controls.Add(this.GotoSleepBtn);
            this.controlBar.Controls.Add(this.menuListBtn);
            this.controlBar.Controls.Add(this.minimizeBtn);
            this.controlBar.Controls.Add(this.closeBtn);
            this.controlBar.Location = new System.Drawing.Point(247, 0);
            this.controlBar.Name = "controlBar";
            this.controlBar.Size = new System.Drawing.Size(628, 47);
            this.controlBar.TabIndex = 4;
            this.controlBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseMove);
            this.controlBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseDown);
            this.controlBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseUp);
            // 
            // HelpBtn
            // 
            this.HelpBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.HelpBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(0)))), ((int)(((byte)(26)))));
            this.HelpBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(0)))), ((int)(((byte)(77)))));
            this.HelpBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HelpBtn.Image = ((System.Drawing.Image)(resources.GetObject("HelpBtn.Image")));
            this.HelpBtn.Location = new System.Drawing.Point(68, 8);
            this.HelpBtn.Name = "HelpBtn";
            this.HelpBtn.Size = new System.Drawing.Size(33, 32);
            this.HelpBtn.TabIndex = 8;
            this.HelpBtn.UseVisualStyleBackColor = true;
            // 
            // HomeBtn
            // 
            this.HomeBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.HomeBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(0)))), ((int)(((byte)(26)))));
            this.HomeBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(0)))), ((int)(((byte)(77)))));
            this.HomeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HomeBtn.Image = ((System.Drawing.Image)(resources.GetObject("HomeBtn.Image")));
            this.HomeBtn.Location = new System.Drawing.Point(37, 8);
            this.HomeBtn.Name = "HomeBtn";
            this.HomeBtn.Size = new System.Drawing.Size(33, 32);
            this.HomeBtn.TabIndex = 7;
            this.HomeBtn.UseVisualStyleBackColor = true;
            this.HomeBtn.Click += new System.EventHandler(this.HomeBtn_Click);
            // 
            // GotoSleepBtn
            // 
            this.GotoSleepBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GotoSleepBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(0)))), ((int)(((byte)(26)))));
            this.GotoSleepBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(0)))), ((int)(((byte)(77)))));
            this.GotoSleepBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GotoSleepBtn.Image = ((System.Drawing.Image)(resources.GetObject("GotoSleepBtn.Image")));
            this.GotoSleepBtn.Location = new System.Drawing.Point(569, 9);
            this.GotoSleepBtn.Name = "GotoSleepBtn";
            this.GotoSleepBtn.Size = new System.Drawing.Size(26, 29);
            this.GotoSleepBtn.TabIndex = 11;
            this.GotoSleepBtn.UseVisualStyleBackColor = true;
            this.GotoSleepBtn.Click += new System.EventHandler(this.GotoSleepBtn_Click);
            // 
            // menuListBtn
            // 
            this.menuListBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.menuListBtn.Enabled = false;
            this.menuListBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(0)))), ((int)(((byte)(26)))));
            this.menuListBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(0)))), ((int)(((byte)(77)))));
            this.menuListBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.menuListBtn.Image = ((System.Drawing.Image)(resources.GetObject("menuListBtn.Image")));
            this.menuListBtn.Location = new System.Drawing.Point(6, 8);
            this.menuListBtn.Name = "menuListBtn";
            this.menuListBtn.Size = new System.Drawing.Size(33, 32);
            this.menuListBtn.TabIndex = 10;
            this.menuListBtn.UseVisualStyleBackColor = true;
            this.menuListBtn.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // minimizeBtn
            // 
            this.minimizeBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.minimizeBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(0)))), ((int)(((byte)(26)))));
            this.minimizeBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(0)))), ((int)(((byte)(77)))));
            this.minimizeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minimizeBtn.Image = ((System.Drawing.Image)(resources.GetObject("minimizeBtn.Image")));
            this.minimizeBtn.Location = new System.Drawing.Point(545, 9);
            this.minimizeBtn.Name = "minimizeBtn";
            this.minimizeBtn.Size = new System.Drawing.Size(26, 29);
            this.minimizeBtn.TabIndex = 10;
            this.minimizeBtn.UseVisualStyleBackColor = true;
            this.minimizeBtn.Click += new System.EventHandler(this.minimizeBtn_Click);
            // 
            // closeBtn
            // 
            this.closeBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closeBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(0)))), ((int)(((byte)(26)))));
            this.closeBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(0)))), ((int)(((byte)(77)))));
            this.closeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeBtn.Image = ((System.Drawing.Image)(resources.GetObject("closeBtn.Image")));
            this.closeBtn.Location = new System.Drawing.Point(592, 9);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(26, 29);
            this.closeBtn.TabIndex = 12;
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(0)))), ((int)(((byte)(26)))));
            this.label9.Location = new System.Drawing.Point(477, 34);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(0, 13);
            this.label9.TabIndex = 9;
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(0)))), ((int)(((byte)(26)))));
            this.label3.Location = new System.Drawing.Point(478, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 17);
            this.label3.TabIndex = 8;
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // topMenuSlide
            // 
            this.topMenuSlide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.topMenuSlide.Controls.Add(this.UnreadMassg);
            this.topMenuSlide.Controls.Add(this.InboxUnreadMailslbl);
            this.topMenuSlide.Controls.Add(this.notificationLbl);
            this.topMenuSlide.Controls.Add(this.userAcSetngs);
            this.topMenuSlide.Controls.Add(this.UsrNotifictn);
            this.topMenuSlide.Controls.Add(this.label9);
            this.topMenuSlide.Controls.Add(this.pictureBox3);
            this.topMenuSlide.Controls.Add(this.label3);
            this.topMenuSlide.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.topMenuSlide.Location = new System.Drawing.Point(247, 48);
            this.topMenuSlide.Name = "topMenuSlide";
            this.topMenuSlide.Size = new System.Drawing.Size(1, 59);
            this.topMenuSlide.TabIndex = 5;
            // 
            // UnreadMassg
            // 
            this.UnreadMassg.BackgroundImage = global::VoiceBox_Beta.Properties.Resources._002_messages_silhouette;
            this.UnreadMassg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.UnreadMassg.Cursor = System.Windows.Forms.Cursors.Hand;
            this.UnreadMassg.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(0)))), ((int)(((byte)(26)))));
            this.UnreadMassg.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.UnreadMassg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UnreadMassg.Location = new System.Drawing.Point(334, 12);
            this.UnreadMassg.Name = "UnreadMassg";
            this.UnreadMassg.Size = new System.Drawing.Size(33, 32);
            this.UnreadMassg.TabIndex = 10;
            this.UnreadMassg.UseVisualStyleBackColor = true;
            this.UnreadMassg.Click += new System.EventHandler(this.UnreadMassg_Click);
            // 
            // InboxUnreadMailslbl
            // 
            this.InboxUnreadMailslbl.AutoSize = true;
            this.InboxUnreadMailslbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InboxUnreadMailslbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.InboxUnreadMailslbl.Location = new System.Drawing.Point(339, 42);
            this.InboxUnreadMailslbl.Name = "InboxUnreadMailslbl";
            this.InboxUnreadMailslbl.Size = new System.Drawing.Size(23, 12);
            this.InboxUnreadMailslbl.TabIndex = 13;
            this.InboxUnreadMailslbl.Text = "320";
            this.InboxUnreadMailslbl.Visible = false;
            this.InboxUnreadMailslbl.TextChanged += new System.EventHandler(this.InboxUnreadMailslbl_TextChanged);
            // 
            // notificationLbl
            // 
            this.notificationLbl.AutoSize = true;
            this.notificationLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.notificationLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(81)))), ((int)(((byte)(194)))));
            this.notificationLbl.Location = new System.Drawing.Point(143, 21);
            this.notificationLbl.Name = "notificationLbl";
            this.notificationLbl.Size = new System.Drawing.Size(144, 15);
            this.notificationLbl.TabIndex = 12;
            this.notificationLbl.Text = "-> New mail arrived!!!";
            this.notificationLbl.Visible = false;
            // 
            // userAcSetngs
            // 
            this.userAcSetngs.Cursor = System.Windows.Forms.Cursors.Hand;
            this.userAcSetngs.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(0)))), ((int)(((byte)(26)))));
            this.userAcSetngs.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.userAcSetngs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.userAcSetngs.Image = ((System.Drawing.Image)(resources.GetObject("userAcSetngs.Image")));
            this.userAcSetngs.Location = new System.Drawing.Point(15, 12);
            this.userAcSetngs.Name = "userAcSetngs";
            this.userAcSetngs.Size = new System.Drawing.Size(34, 31);
            this.userAcSetngs.TabIndex = 1;
            this.userAcSetngs.UseVisualStyleBackColor = true;
            this.userAcSetngs.Click += new System.EventHandler(this.userAcSetngs_Click);
            // 
            // UsrNotifictn
            // 
            this.UsrNotifictn.BackgroundImage = global::VoiceBox_Beta.Properties.Resources._003_notification;
            this.UsrNotifictn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.UsrNotifictn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.UsrNotifictn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(0)))), ((int)(((byte)(26)))));
            this.UsrNotifictn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.UsrNotifictn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UsrNotifictn.Location = new System.Drawing.Point(375, 12);
            this.UsrNotifictn.Name = "UsrNotifictn";
            this.UsrNotifictn.Size = new System.Drawing.Size(33, 32);
            this.UsrNotifictn.TabIndex = 11;
            this.UsrNotifictn.UseVisualStyleBackColor = true;
            this.UsrNotifictn.Click += new System.EventHandler(this.UsrNotifictn_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox3.Location = new System.Drawing.Point(421, 4);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(52, 50);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 7;
            this.pictureBox3.TabStop = false;
            // 
            // AnimationTimer
            // 
            this.AnimationTimer.Tick += new System.EventHandler(this.AnimationTimer_Tick);
            // 
            // statusTimer
            // 
            this.statusTimer.Tick += new System.EventHandler(this.statusTimer_Tick);
            // 
            // browseOpt
            // 
            this.browseOpt.FileName = "Browse";
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(245, 568);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(629, 10);
            this.dataGridView.TabIndex = 13;
            this.dataGridView.Visible = false;
            // 
            // CheckInboxTm
            // 
            this.CheckInboxTm.Tick += new System.EventHandler(this.CheckInboxTm_Tick);
            // 
            // NotifyUser
            // 
            this.NotifyUser.Interval = 1500;
            this.NotifyUser.Tick += new System.EventHandler(this.NotifyUser_Tick);
            // 
            // CheckForUnread
            // 
            this.CheckForUnread.Tick += new System.EventHandler(this.CheckForUnread_Tick);
            // 
            // LogHelpAssistant
            // 
            this.LogHelpAssistant.Interval = 5000;
            this.LogHelpAssistant.Tick += new System.EventHandler(this.LogHelpAssistant_Tick);
            // 
            // WaitToFinish
            // 
            this.WaitToFinish.Interval = 17000;
            this.WaitToFinish.Tick += new System.EventHandler(this.WaitToFinish_Tick);
            // 
            // homePage
            // 
            this.homePage.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("homePage.BackgroundImage")));
            this.homePage.Location = new System.Drawing.Point(247, 47);
            this.homePage.Name = "homePage";
            this.homePage.Size = new System.Drawing.Size(627, 532);
            this.homePage.TabIndex = 11;
            // 
            // UI_Settings
            // 
            this.UI_Settings.Location = new System.Drawing.Point(247, 108);
            this.UI_Settings.Name = "UI_Settings";
            this.UI_Settings.Size = new System.Drawing.Size(627, 473);
            this.UI_Settings.TabIndex = 10;
            this.UI_Settings.Visible = false;
            // 
            // DraftMailsLoad
            // 
            this.DraftMailsLoad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.DraftMailsLoad.Location = new System.Drawing.Point(248, 108);
            this.DraftMailsLoad.Name = "DraftMailsLoad";
            this.DraftMailsLoad.Size = new System.Drawing.Size(627, 473);
            this.DraftMailsLoad.TabIndex = 9;
            this.DraftMailsLoad.Visible = false;
            // 
            // SentMailsLoad
            // 
            this.SentMailsLoad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.SentMailsLoad.Location = new System.Drawing.Point(248, 108);
            this.SentMailsLoad.Name = "SentMailsLoad";
            this.SentMailsLoad.Size = new System.Drawing.Size(627, 473);
            this.SentMailsLoad.TabIndex = 8;
            this.SentMailsLoad.Visible = false;
            // 
            // InboxMailLoad
            // 
            this.InboxMailLoad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.InboxMailLoad.Location = new System.Drawing.Point(248, 108);
            this.InboxMailLoad.Name = "InboxMailLoad";
            this.InboxMailLoad.Size = new System.Drawing.Size(627, 473);
            this.InboxMailLoad.TabIndex = 7;
            this.InboxMailLoad.Visible = false;
            // 
            // LogInPage
            // 
            this.LogInPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.LogInPage.Location = new System.Drawing.Point(247, 105);
            this.LogInPage.Name = "LogInPage";
            this.LogInPage.Size = new System.Drawing.Size(627, 473);
            this.LogInPage.TabIndex = 6;
            this.LogInPage.Visible = false;
            // 
            // UserAccountSettings
            // 
            this.UserAccountSettings.Location = new System.Drawing.Point(247, 106);
            this.UserAccountSettings.Name = "UserAccountSettings";
            this.UserAccountSettings.Size = new System.Drawing.Size(627, 473);
            this.UserAccountSettings.TabIndex = 12;
            this.UserAccountSettings.Visible = false;
            // 
            // voiceBoxMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(873, 579);
            this.Controls.Add(this.homePage);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.panelSlide);
            this.Controls.Add(this.UI_Settings);
            this.Controls.Add(this.DraftMailsLoad);
            this.Controls.Add(this.SentMailsLoad);
            this.Controls.Add(this.InboxMailLoad);
            this.Controls.Add(this.LogInPage);
            this.Controls.Add(this.controlBar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.TitleBar);
            this.Controls.Add(this.UserAccountSettings);
            this.Controls.Add(this.topMenuSlide);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "voiceBoxMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "voiceBoxMain";
            this.Load += new System.EventHandler(this.voiceBoxMain_Load);
            this.VisibleChanged += new System.EventHandler(this.voiceBoxMain_VisibleChanged);
            this.TitleBar.ResumeLayout(false);
            this.TitleBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panelSlide.ResumeLayout(false);
            this.composePanel.ResumeLayout(false);
            this.composePanel.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.controlBar.ResumeLayout(false);
            this.topMenuSlide.ResumeLayout(false);
            this.topMenuSlide.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel TitleBar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnInbox;
        private System.Windows.Forms.Button btnCompose;
        private System.Windows.Forms.Button btnDraft;
        private System.Windows.Forms.Button btnSentMails;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Timer timeDate;
        private System.Windows.Forms.Label lblDay;
        private System.Windows.Forms.Panel panelSlide;
        private System.Windows.Forms.Panel composePanel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox addressTxt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnAttatch;
        private System.Windows.Forms.TextBox attachTxt;
        private System.Windows.Forms.TextBox subjectTxt;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox bodyTxt;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.Panel controlBar;
        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.Button minimizeBtn;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Panel topMenuSlide;
        private System.Windows.Forms.Button menuListBtn;
        private System.Windows.Forms.Button UsrNotifictn;
        private System.Windows.Forms.Button UnreadMassg;
        private System.Windows.Forms.Button userAcSetngs;
        private ucLogIn LogInPage;
        private System.Windows.Forms.Button GotoSleepBtn;
        private System.Windows.Forms.Button HomeBtn;
        private MailLoader InboxMailLoad;
        private MailLoader SentMailsLoad;
        private MailLoader DraftMailsLoad;
        private UIsettings UI_Settings;
        private System.Windows.Forms.Button HelpBtn;
        private HomeUC homePage;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Timer AnimationTimer;
        private System.Windows.Forms.PictureBox pictureBox4;
        public System.Windows.Forms.PictureBox pictureBox5;
        public System.Windows.Forms.Timer statusTimer;
        private System.Windows.Forms.Button btnAttatchCncl;
        private System.Windows.Forms.OpenFileDialog browseOpt;
        private AccountSettings UserAccountSettings;
        public System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Timer CheckInboxTm;
        private System.Windows.Forms.Timer NotifyUser;
        private System.Windows.Forms.Label notificationLbl;
        private System.Windows.Forms.Label InboxUnreadMailslbl;
        private System.Windows.Forms.Timer CheckForUnread;
        private System.Windows.Forms.Timer LogHelpAssistant;
        private System.Windows.Forms.Timer WaitToFinish;
    }
}