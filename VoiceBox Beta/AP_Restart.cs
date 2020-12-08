using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VoiceBox_Beta
{
    public partial class AP_Restart : Form
    {
        int TogMove;
        int MValX;
        int MValY;

        public AP_Restart()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(615, 310);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Application.Exit();
            Application.Restart();
            Environment.Exit(0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            TogMove = 1;
            MValX = e.X;
            MValY = e.Y;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            TogMove = 0;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (TogMove == 1)
            {
                this.SetDesktopLocation(MousePosition.X - MValX, MousePosition.Y - MValY);
                this.Update();
            }
        }
    }
}
