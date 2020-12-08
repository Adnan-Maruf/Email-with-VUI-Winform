using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Speech;
using System.Speech.Synthesis;
using System.Speech.Recognition;
using System.Threading;
using System.IO;
using NAudio.CoreAudioApi;
using NAudio.Wave;
using System.Media;

namespace VoiceBox_Beta
{
    public partial class voiceBoxIdel : Form
    {

        NAudio.Wave.WaveIn sourceStrem = null;
        NAudio.Wave.WaveIn sourceStremMic = null;
        NAudio.CoreAudioApi.MMDevice firstMic = null;

        int b = 0, Count10s = 0, value, checkPoint=0;
        Choices Slp_Awk = new Choices();
        Choices Awk_Slp = new Choices();
        //Choices Exit_app = new Choices();
        SpeechRecognitionEngine awake = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-US"));
        SpeechRecognitionEngine sleep = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-US"));
        //SpeechRecognitionEngine EXIT = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-US"));
        SpeechSynthesizer TalkBk = new SpeechSynthesizer();

        private voiceBoxMain VBM;


        public voiceBoxIdel()
        {
            InitializeComponent();
            //MicVm();
            //-----------------------------------
            const string Folder = @"C:\Users\adnan\Desktop\VoiceBox Beta.Final\Log";
            if (!Directory.Exists(Folder))
            {
                Directory.CreateDirectory(Folder);
                File.WriteAllText(Path.Combine(Folder, "UI_Settings.txt"), null);
                File.WriteAllText(Path.Combine(Folder, "User_Info.txt"), null);
                string Txt = "[UserSettings]\r\nvoice_recognition_state=1\r\nhelp_assist_state=1";
                string Txt2 = "[UserInfo]\r\nus:\r\n\r\nps:\r\n\r\n-.-";
                TextWriter txt = new StreamWriter("C:\\Users\\adnan\\Desktop\\VoiceBox Beta.Final\\Log\\UI_Settings.txt");
                TextWriter txt2 = new StreamWriter("C:\\Users\\adnan\\Desktop\\VoiceBox Beta.Final\\Log\\User_Info.txt");
                txt.Write(Txt);
                txt2.Write(Txt2);
                txt.Close();
                txt2.Close();
            }
            //-----------------------------------
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(450, 0);
            VBM = new voiceBoxMain();
            VBM.OnGotoSleepBtnClicked += new EventHandler(VBM_OnGotoSleepBtnClicked);
            VBM.OnTerminated += new EventHandler(VBM_OnTerminated);
       
            Slp_Awk.Add(new string[] {"Wake up"});
            GrammarBuilder gb = new GrammarBuilder();
            gb.Append(Slp_Awk);
            Grammar g = new Grammar(gb);
            try
            {
                awake.LoadGrammar(g);
                awake.SetInputToDefaultAudioDevice();
                if (b == 0)
                {
                    checkOpt();
                }
                //awake.RequestRecognizerUpdate();
                awake.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(awake_SpeechRecognized);
                
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Error");
            }

            Awk_Slp.Add(new string[] {"Go to sleep"});
            GrammarBuilder gb1 = new GrammarBuilder();
            gb1.Append(Awk_Slp);
            Grammar gr = new Grammar(gb1);
            try
            {
                sleep.LoadGrammar(gr);
                sleep.SetInputToDefaultAudioDevice();
                //sleep.RequestRecognizerUpdate();
                sleep.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(sleep_SpeechRecognized);
                
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Error");
            }
        }

        private void MicVm()
        {
            int i;
            sourceStrem = new NAudio.Wave.WaveIn();
            sourceStrem.WaveFormat = new NAudio.Wave.WaveFormat(44100, NAudio.Wave.WaveIn.GetCapabilities(0).Channels);
            sourceStrem.StartRecording();
            sourceStrem.DataAvailable += new EventHandler<WaveInEventArgs>(sourceStrem_DataAvailable);
            MMDeviceEnumerator mde = new MMDeviceEnumerator();
            var devices = mde.EnumerateAudioEndPoints(DataFlow.Capture, DeviceState.Active);
            if (devices.Count == 1)
            {
                i = 0;
                firstMic = devices.ElementAt(i);
            }
            else if (devices.Count == 2)
            {
                i = 1;
                firstMic = devices.ElementAt(i);
            }
        }

        void sourceStrem_DataAvailable(object sender, WaveInEventArgs e)
        {
           
            if (this.Visible)
            {
                //int value;
                value = (int)(Math.Round(firstMic.AudioMeterInformation.MasterPeakValue * 130));
                switch (value)
                {
                    case 0:
                        if (checkPoint == 0)
                        {
                            //MicrophoneStatus();
                        }
                        this.MicLvl.Image = Properties.Resources.lvl0;
                        break;
                    case 1:
                        this.MicLvl.Image = Properties.Resources.lvl1;
                        break;
                    case 2:
                        this.MicLvl.Image = Properties.Resources.lvl2;
                        break;
                    case 3:
                        this.MicLvl.Image = Properties.Resources.lvl3;
                        break;
                    case 4:
                        this.MicLvl.Image = Properties.Resources.lvl4;
                        break;
                    case 5:
                        this.MicLvl.Image = Properties.Resources.lvl5;
                        break;
                    case 6:
                        this.MicLvl.Image = Properties.Resources.lvl6;
                        break;
                    case 7:
                        this.MicLvl.Image = Properties.Resources.lvl7;
                        break;
                    case 8:
                        this.MicLvl.Image = Properties.Resources.lvl8;
                        break;
                    case 9:
                        this.MicLvl.Image = Properties.Resources.lvl9;
                        break;
                    case 10:
                        this.MicLvl.Image = Properties.Resources.lvl10;
                        break;
                }
            }
        }

        private void MicrophoneStatus()
        {
            checkPoint = 999;
            MicStatus.Start();
        }

        private void checkOpt()
        {
            string tt;
            string filename = @"C:\Users\adnan\Desktop\VoiceBox Beta.Final\Log\UI_Settings.txt";
            if (File.Exists(filename))
            {
                string[] lines = File.ReadAllLines(filename);
                tt = lines[1].ToString();
                if (tt.Equals("voice_recognition_state=1"))
                {
                    awake.RecognizeAsync(RecognizeMode.Multiple);
                    MicVm();
                }
                else if (tt.Equals("voice_recognition_state=0"))
                {
                    awake.RecognizeAsyncStop();
                }
            }
        }

        void VBM_OnTerminated(object sender, EventArgs e)
        {
            sleep.RecognizeAsync(RecognizeMode.Multiple);
        }

        void VBM_OnGotoSleepBtnClicked(object sender, EventArgs e)
        {
            this.Show();
            sleep.RecognizeAsyncStop();
            awake.RecognizeAsync(RecognizeMode.Multiple);
        }


        private void Wake_Up()
        {
            if (!VBM.Visible)
            {
                VBM.Show();
                VBM.statusTimer.Start();
            }
            this.Hide();
        }

        void awake_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (e.Result.Text.Equals("Wake up"))
            {
                awake.RecognizeAsyncStop();
                //sleep.RecognizeAsync(RecognizeMode.Multiple);
                TalkBk.SpeakAsync("Hello there");
                VBM.state = true;
                Thread.Sleep(100);
                Wake_Up();

            } 
        }
        void sleep_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (e.Result.Text.Equals("Go to sleep"))
            {

                sleep.RecognizeAsyncStop();
                b = 0;
                awake.RecognizeAsync(RecognizeMode.Multiple);
                TalkBk.SpeakAsync("See you again");
                Thread.Sleep(1500);
                if (VBM.Visible)
                {
                    VBM.statusTimer.Stop();
                    VBM.Hide();
                    VBM.BtnCmmnd.RecognizeAsyncStop();
                    VBM.selectionENG.RecognizeAsyncStop();
                }
                this.Show();
            }
        }

        Color clsBtn;
        Color onfBtn;

        private void clsBtwn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void clsBtwn_MouseHover(object sender, EventArgs e)
        {
            clsBtn = clsBtwn.ForeColor;
            clsBtwn.ForeColor = Color.DarkRed;
        }

        private void clsBtwn_MouseLeave(object sender, EventArgs e)
        {
            clsBtwn.ForeColor = clsBtn;
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            onfBtn = onOff.BackColor;
            onOff.BackColor = Color.Cyan;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            onOff.BackColor = onfBtn;
        }

        private void onOff_Click(object sender, EventArgs e)
        {
            awake.RecognizeAsyncStop();
            //sleep.RecognizeAsync(RecognizeMode.Multiple);
            Wake_Up();
            VBM.state = false;

        }

        private void voiceBoxIdel_FormClosed(object sender, FormClosedEventArgs e)
        {
            awake.UnloadAllGrammars();
            sleep.UnloadAllGrammars();

        }

        private void MicStatus_Tick(object sender, EventArgs e)
        {
            if (value <= 0)
            {
                Count10s++;
            }
            else if (value > 0)
            {
                Count10s = 0;
                MicStatus.Stop();
                checkPoint = 0;
            }

            try
            {
                if (Count10s == 20 && value<=0)
                {
                    TalkBk.SpeakAsync("Microphone error! Please make sure your Microphone is properly connected");
                    Count10s = 0;  
                }
            }
            catch (Exception ex)
            {
                //
            }

        }
    }
}
