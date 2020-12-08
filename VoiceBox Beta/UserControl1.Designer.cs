namespace VoiceBox_Beta
{
    partial class ucLogIn
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
            this.pnlLogin = new System.Windows.Forms.Panel();
            this.showHidePassBtn = new System.Windows.Forms.Button();
            this.chkLbl = new System.Windows.Forms.Label();
            this.pnlSuccessLogin = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.lblUsrNm = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.checkRemember = new System.Windows.Forms.CheckBox();
            this.btnLogIn = new System.Windows.Forms.Button();
            this.passwordTxt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.usrnameTxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlLogin.SuspendLayout();
            this.pnlSuccessLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlLogin
            // 
            this.pnlLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.pnlLogin.Controls.Add(this.showHidePassBtn);
            this.pnlLogin.Controls.Add(this.chkLbl);
            this.pnlLogin.Controls.Add(this.pnlSuccessLogin);
            this.pnlLogin.Controls.Add(this.checkRemember);
            this.pnlLogin.Controls.Add(this.btnLogIn);
            this.pnlLogin.Controls.Add(this.passwordTxt);
            this.pnlLogin.Controls.Add(this.label4);
            this.pnlLogin.Controls.Add(this.usrnameTxt);
            this.pnlLogin.Controls.Add(this.label3);
            this.pnlLogin.Controls.Add(this.label2);
            this.pnlLogin.Controls.Add(this.label1);
            this.pnlLogin.Location = new System.Drawing.Point(93, 18);
            this.pnlLogin.Name = "pnlLogin";
            this.pnlLogin.Size = new System.Drawing.Size(443, 436);
            this.pnlLogin.TabIndex = 0;
            // 
            // showHidePassBtn
            // 
            this.showHidePassBtn.BackColor = System.Drawing.Color.Transparent;
            this.showHidePassBtn.BackgroundImage = global::VoiceBox_Beta.Properties.Resources.hidePass;
            this.showHidePassBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.showHidePassBtn.Enabled = false;
            this.showHidePassBtn.FlatAppearance.BorderSize = 0;
            this.showHidePassBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.showHidePassBtn.Location = new System.Drawing.Point(394, 218);
            this.showHidePassBtn.Name = "showHidePassBtn";
            this.showHidePassBtn.Size = new System.Drawing.Size(23, 22);
            this.showHidePassBtn.TabIndex = 9;
            this.showHidePassBtn.UseVisualStyleBackColor = false;
            this.showHidePassBtn.Click += new System.EventHandler(this.showHidePassBtn_Click);
            // 
            // chkLbl
            // 
            this.chkLbl.AutoSize = true;
            this.chkLbl.ForeColor = System.Drawing.Color.Red;
            this.chkLbl.Location = new System.Drawing.Point(52, 244);
            this.chkLbl.Name = "chkLbl";
            this.chkLbl.Size = new System.Drawing.Size(222, 13);
            this.chkLbl.TabIndex = 6;
            this.chkLbl.Text = "Wrong UserName or Password! Check again.\r\n";
            this.chkLbl.Visible = false;
            // 
            // pnlSuccessLogin
            // 
            this.pnlSuccessLogin.Controls.Add(this.btnLogout);
            this.pnlSuccessLogin.Controls.Add(this.lblUsrNm);
            this.pnlSuccessLogin.Controls.Add(this.label5);
            this.pnlSuccessLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSuccessLogin.Location = new System.Drawing.Point(0, 0);
            this.pnlSuccessLogin.Name = "pnlSuccessLogin";
            this.pnlSuccessLogin.Size = new System.Drawing.Size(443, 436);
            this.pnlSuccessLogin.TabIndex = 7;
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(159, 228);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(125, 43);
            this.btnLogout.TabIndex = 2;
            this.btnLogout.Text = "Sign out";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // lblUsrNm
            // 
            this.lblUsrNm.AutoSize = true;
            this.lblUsrNm.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsrNm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(134)))), ((int)(((byte)(245)))));
            this.lblUsrNm.Location = new System.Drawing.Point(112, 145);
            this.lblUsrNm.Name = "lblUsrNm";
            this.lblUsrNm.Size = new System.Drawing.Size(209, 22);
            this.lblUsrNm.TabIndex = 1;
            this.lblUsrNm.Text = "- amdbrenda@gmail.com";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(0)))), ((int)(((byte)(26)))));
            this.label5.Location = new System.Drawing.Point(34, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(381, 29);
            this.label5.TabIndex = 0;
            this.label5.Text = "Yo&u have s&uccessfully logged into:";
            // 
            // checkRemember
            // 
            this.checkRemember.AutoSize = true;
            this.checkRemember.Location = new System.Drawing.Point(57, 331);
            this.checkRemember.Name = "checkRemember";
            this.checkRemember.Size = new System.Drawing.Size(122, 17);
            this.checkRemember.TabIndex = 5;
            this.checkRemember.Text = "Remember this login";
            this.checkRemember.UseVisualStyleBackColor = true;
            this.checkRemember.CheckStateChanged += new System.EventHandler(this.checkRemember_CheckStateChanged);
            // 
            // btnLogIn
            // 
            this.btnLogIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(81)))), ((int)(((byte)(194)))));
            this.btnLogIn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogIn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(81)))), ((int)(((byte)(194)))));
            this.btnLogIn.FlatAppearance.BorderSize = 0;
            this.btnLogIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogIn.ForeColor = System.Drawing.Color.White;
            this.btnLogIn.Location = new System.Drawing.Point(307, 273);
            this.btnLogIn.Name = "btnLogIn";
            this.btnLogIn.Size = new System.Drawing.Size(80, 35);
            this.btnLogIn.TabIndex = 3;
            this.btnLogIn.Text = "NEXT";
            this.btnLogIn.UseVisualStyleBackColor = false;
            this.btnLogIn.Click += new System.EventHandler(this.btnLogIn_Click);
            // 
            // passwordTxt
            // 
            this.passwordTxt.BackColor = System.Drawing.Color.White;
            this.passwordTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordTxt.Location = new System.Drawing.Point(51, 218);
            this.passwordTxt.Name = "passwordTxt";
            this.passwordTxt.PasswordChar = '●';
            this.passwordTxt.Size = new System.Drawing.Size(340, 23);
            this.passwordTxt.TabIndex = 2;
            this.passwordTxt.TextChanged += new System.EventHandler(this.passwordTxt_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(134)))), ((int)(((byte)(245)))));
            this.label4.Location = new System.Drawing.Point(49, 188);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Enter your password";
            // 
            // usrnameTxt
            // 
            this.usrnameTxt.BackColor = System.Drawing.Color.White;
            this.usrnameTxt.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.usrnameTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usrnameTxt.Location = new System.Drawing.Point(51, 151);
            this.usrnameTxt.Name = "usrnameTxt";
            this.usrnameTxt.Size = new System.Drawing.Size(340, 23);
            this.usrnameTxt.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(134)))), ((int)(((byte)(245)))));
            this.label3.Location = new System.Drawing.Point(49, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Email or UserName";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(48, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "to continue to Email";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(45, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sign in";
            // 
            // ucLogIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.Controls.Add(this.pnlLogin);
            this.Name = "ucLogIn";
            this.Size = new System.Drawing.Size(627, 473);
            this.Load += new System.EventHandler(this.ucLogIn_Load);
            this.pnlLogin.ResumeLayout(false);
            this.pnlLogin.PerformLayout();
            this.pnlSuccessLogin.ResumeLayout(false);
            this.pnlSuccessLogin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLogIn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnLogout;
        public System.Windows.Forms.TextBox usrnameTxt;
        public System.Windows.Forms.TextBox passwordTxt;
        public System.Windows.Forms.CheckBox checkRemember;
        public System.Windows.Forms.Panel pnlLogin;
        public System.Windows.Forms.Panel pnlSuccessLogin;
        public System.Windows.Forms.Label lblUsrNm;
        public System.Windows.Forms.Label chkLbl;
        public System.Windows.Forms.Button showHidePassBtn;
    }
}
