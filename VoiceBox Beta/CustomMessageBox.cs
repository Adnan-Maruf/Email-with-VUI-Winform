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
    public partial class CustomMessageBox : Form
    {
        int TogMove;
        int MValX;
        int MValY;

        public CustomMessageBox()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(642, 346);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            TogMove = 1;
            MValX = e.X;
            MValY = e.Y;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (TogMove == 1)
            {
                this.SetDesktopLocation(MousePosition.X - MValX, MousePosition.Y - MValY);
                this.Update();
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            TogMove = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CustomMessageTxt.Text = String.Empty;
            this.Close();
        }
    }
}
