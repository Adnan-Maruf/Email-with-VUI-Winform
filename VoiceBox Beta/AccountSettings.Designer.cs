namespace VoiceBox_Beta
{
    partial class AccountSettings
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
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.emailID = new System.Windows.Forms.Label();
            this.BtnSave = new System.Windows.Forms.Button();
            this.addPic = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.addNametxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.addPic)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(234, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Account Settings";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(158, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Email:";
            // 
            // emailID
            // 
            this.emailID.BackColor = System.Drawing.Color.White;
            this.emailID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.emailID.Location = new System.Drawing.Point(205, 117);
            this.emailID.Name = "emailID";
            this.emailID.Size = new System.Drawing.Size(225, 20);
            this.emailID.TabIndex = 13;
            this.emailID.TextChanged += new System.EventHandler(this.emailID_TextChanged);
            // 
            // BtnSave
            // 
            this.BtnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(81)))), ((int)(((byte)(194)))));
            this.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSave.ForeColor = System.Drawing.Color.White;
            this.BtnSave.Location = new System.Drawing.Point(272, 339);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(96, 32);
            this.BtnSave.TabIndex = 12;
            this.BtnSave.Text = "Save";
            this.BtnSave.UseVisualStyleBackColor = false;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // addPic
            // 
            this.addPic.BackColor = System.Drawing.Color.White;
            this.addPic.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.addPic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addPic.Location = new System.Drawing.Point(264, 189);
            this.addPic.Name = "addPic";
            this.addPic.Size = new System.Drawing.Size(115, 115);
            this.addPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.addPic.TabIndex = 11;
            this.addPic.TabStop = false;
            this.addPic.MouseClick += new System.Windows.Forms.MouseEventHandler(this.addPic_MouseClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(202, 189);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 15);
            this.label2.TabIndex = 10;
            this.label2.Text = "Picture:";
            // 
            // addNametxt
            // 
            this.addNametxt.Location = new System.Drawing.Point(205, 151);
            this.addNametxt.Name = "addNametxt";
            this.addNametxt.Size = new System.Drawing.Size(225, 20);
            this.addNametxt.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(150, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "Name:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "Select an image";
            // 
            // AccountSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.emailID);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.addPic);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.addNametxt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "AccountSettings";
            this.Size = new System.Drawing.Size(627, 473);
            ((System.ComponentModel.ISupportInitialize)(this.addPic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label emailID;
        private System.Windows.Forms.Button BtnSave;
        public System.Windows.Forms.PictureBox addPic;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox addNametxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}
