using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Media;


namespace VoiceBox_Beta
{
    public partial class UIsettings : UserControl
    {
        SoundPlayer InfoS;
        public UIsettings()
        {
            InitializeComponent();
            checkVR();
            checkHA();
        }

        private void checkHA()
        {
            string tt;
            string filename = @"C:\Users\adnan\Desktop\VoiceBox Beta.Final\Log\UI_Settings.txt";
            if (File.Exists(filename))
            {
                string[] lines = File.ReadAllLines(filename);
                tt = lines[2].ToString();
                if (tt.Equals("help_assist_state=1"))
                {
                    HelpAssist.CheckState = CheckState.Checked;
                }
                else if (tt.Equals("help_assist_state=0"))
                {
                    HelpAssist.CheckState = CheckState.Unchecked;
                }
            }
        }

        private void checkVR()
        {
            string tt;
            string filename = @"C:\Users\adnan\Desktop\VoiceBox Beta.Final\Log\UI_Settings.txt";
            if (File.Exists(filename))
            {
                string[] lines = File.ReadAllLines(filename);
                tt = lines[1].ToString();
                if (tt.Equals("voice_recognition_state=1"))
                {
                    VRoNoFFmaster.CheckState = CheckState.Checked;
                }
                else if (tt.Equals("voice_recognition_state=0"))
                {
                    VRoNoFFmaster.CheckState = CheckState.Unchecked;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            VoiceRegOnOff();
           
            InfoS = new SoundPlayer("Info.wav");
            AP_Restart restart = new AP_Restart();
            InfoS.Play();
            restart.ShowDialog();

        }

        private void VoiceRegOnOff()
        {
            if (VRoNoFFmaster.CheckState.Equals(CheckState.Checked) && HelpAssist.CheckState.Equals(CheckState.Checked))
            {
                string Txt = "[UserSettings]\r\nvoice_recognition_state=1\r\nhelp_assist_state=1";
                TextWriter txt = new StreamWriter("C:\\Users\\adnan\\Desktop\\VoiceBox Beta.Final\\Log\\UI_Settings.txt");
                txt.Write(Txt);
                txt.Close();
            }
            else if (VRoNoFFmaster.CheckState.Equals(CheckState.Checked) && HelpAssist.CheckState.Equals(CheckState.Unchecked))
            {
                string Txt = "[UserSettings]\r\nvoice_recognition_state=1\r\nhelp_assist_state=0";
                TextWriter txt = new StreamWriter("C:\\Users\\adnan\\Desktop\\VoiceBox Beta.Final\\Log\\UI_Settings.txt");
                txt.Write(Txt);
                txt.Close();
            }
            else if (VRoNoFFmaster.CheckState.Equals(CheckState.Unchecked) && HelpAssist.CheckState.Equals(CheckState.Checked))
            {
                string Txt = "[UserSettings]\r\nvoice_recognition_state=0\r\nhelp_assist_state=1";
                TextWriter txt = new StreamWriter("C:\\Users\\adnan\\Desktop\\VoiceBox Beta.Final\\Log\\UI_Settings.txt");
                txt.Write(Txt);
                txt.Close();
            }
            else if (VRoNoFFmaster.CheckState.Equals(CheckState.Unchecked) && HelpAssist.CheckState.Equals(CheckState.Unchecked))
            {
                string Txt = "[UserSettings]\r\nvoice_recognition_state=0\r\nhelp_assist_state=0";
                TextWriter txt = new StreamWriter("C:\\Users\\adnan\\Desktop\\VoiceBox Beta.Final\\Log\\UI_Settings.txt");
                txt.Write(Txt);
                txt.Close();
            }
        }
    }
}
