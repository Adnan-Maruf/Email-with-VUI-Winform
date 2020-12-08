namespace VoiceBox_Beta
{
    partial class voiceBoxIdel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(voiceBoxIdel));
            this.onOff = new System.Windows.Forms.Button();
            this.clsBtwn = new System.Windows.Forms.Label();
            this.statusTxt = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.MicLvl = new System.Windows.Forms.PictureBox();
            this.MicStatus = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.MicLvl)).BeginInit();
            this.SuspendLayout();
            // 
            // onOff
            // 
            this.onOff.BackColor = System.Drawing.Color.SpringGreen;
            this.onOff.BackgroundImage = global::VoiceBox_Beta.Properties.Resources.Icon1;
            this.onOff.ForeColor = System.Drawing.SystemColors.ControlText;
            this.onOff.Location = new System.Drawing.Point(12, 12);
            this.onOff.Name = "onOff";
            this.onOff.Size = new System.Drawing.Size(79, 47);
            this.onOff.TabIndex = 0;
            this.onOff.UseVisualStyleBackColor = false;
            this.onOff.MouseLeave += new System.EventHandler(this.button1_MouseLeave);
            this.onOff.Click += new System.EventHandler(this.onOff_Click);
            this.onOff.MouseHover += new System.EventHandler(this.button1_MouseHover);
            // 
            // clsBtwn
            // 
            this.clsBtwn.AutoSize = true;
            this.clsBtwn.BackColor = System.Drawing.Color.Transparent;
            this.clsBtwn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clsBtwn.ForeColor = System.Drawing.Color.Black;
            this.clsBtwn.Location = new System.Drawing.Point(395, 4);
            this.clsBtwn.Name = "clsBtwn";
            this.clsBtwn.Size = new System.Drawing.Size(21, 20);
            this.clsBtwn.TabIndex = 1;
            this.clsBtwn.Text = "X";
            this.clsBtwn.MouseLeave += new System.EventHandler(this.clsBtwn_MouseLeave);
            this.clsBtwn.Click += new System.EventHandler(this.clsBtwn_Click);
            this.clsBtwn.MouseHover += new System.EventHandler(this.clsBtwn_MouseHover);
            // 
            // statusTxt
            // 
            this.statusTxt.AutoSize = true;
            this.statusTxt.BackColor = System.Drawing.Color.Transparent;
            this.statusTxt.Font = new System.Drawing.Font("Microsoft Tai Le", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusTxt.ForeColor = System.Drawing.Color.DarkCyan;
            this.statusTxt.Location = new System.Drawing.Point(187, 31);
            this.statusTxt.Name = "statusTxt";
            this.statusTxt.Size = new System.Drawing.Size(189, 31);
            this.statusTxt.TabIndex = 2;
            this.statusTxt.Text = "Sleeping now...";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Cyan;
            this.label1.Location = new System.Drawing.Point(100, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 28);
            this.label1.TabIndex = 3;
            this.label1.Text = "Status:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MicLvl
            // 
            this.MicLvl.Image = global::VoiceBox_Beta.Properties.Resources.lvl0;
            this.MicLvl.Location = new System.Drawing.Point(382, 28);
            this.MicLvl.Name = "MicLvl";
            this.MicLvl.Size = new System.Drawing.Size(18, 31);
            this.MicLvl.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.MicLvl.TabIndex = 4;
            this.MicLvl.TabStop = false;
            // 
            // MicStatus
            // 
            this.MicStatus.Interval = 1000;
            this.MicStatus.Tick += new System.EventHandler(this.MicStatus_Tick);
            // 
            // voiceBoxIdel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::VoiceBox_Beta.Properties.Resources.VoiceBoxIdel;
            this.ClientSize = new System.Drawing.Size(415, 71);
            this.Controls.Add(this.MicLvl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusTxt);
            this.Controls.Add(this.clsBtwn);
            this.Controls.Add(this.onOff);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "voiceBoxIdel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "voiceBoxIdel";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.voiceBoxIdel_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.MicLvl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button onOff;
        private System.Windows.Forms.Label clsBtwn;
        private System.Windows.Forms.Label statusTxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox MicLvl;
        private System.Windows.Forms.Timer MicStatus;



    }
}

