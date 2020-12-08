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
using System.Data.SqlClient;
using System.IO;
using System.Media;

namespace VoiceBox_Beta
{
    public partial class voiceBoxMain : Form
    {
        int animation = 0, animationIdel = -1, tkb = 0, i = 0, j, caseSet = 0
            , caseSet1 = 0, ignorCmd = 0, inbx = 0, ss = 0, sntm = 0, dd = 0
            , drft = 0, ii = 0, LatestCount, OldRecord, NewRecord, resetUnreadCmnd = 0
            , confAct = 0, SkipTut = 0, HelpAssist = 0, LoginAssistant = 999
            , NeedToInsert = 999, NeedToInsert1 = 999, IfSaidNo = 999
            , UsrNm, UsrPs, IwillRemember = 999, TryCase1 = 999, TryCase2 = 999, FirstPriority = 0
            , onlyWrk = 0, UserAsstOptChoose = 0, UserAsstOptChoose1 = 0, uniqPermission5 = 0;
        int ShutUp = 1;
        string temp, temp1, imgLoc, currentUser, cDateTime;
        int uniqPermission1 = 00, uniqPermission2 = 00, uniqPermission3 = 00, uniqPermission4 = 00
            , unreadTogg = 0, searchType = 0, searchType_SI = 0, searchType_DR = 0;
        //....................................
        Choices UserRSP = new Choices();
        SpeechRecognitionEngine UserRSPeng = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-US"));
        //....................................
        Choices UserRSP1 = new Choices();
        SpeechRecognitionEngine UserRSPeng1 = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-US"));
        //....................................
        Choices UserRSP2 = new Choices();
        SpeechRecognitionEngine UserRSPeng2 = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-US"));
        //....................................
        Choices UserRSP3 = new Choices();
        SpeechRecognitionEngine UserRSPeng3 = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-US"));
        //....................................
        Choices UserRSP4 = new Choices();
        SpeechRecognitionEngine UserRSPeng4 = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-US"));
        //....................................
        Choices btn_Commands = new Choices();
        Choices selection = new Choices();
        Choices switchONoff = new Choices();
        Choices charCase = new Choices();
        public SpeechRecognitionEngine BtnCmmnd = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-US"));
        public SpeechRecognitionEngine selectionENG = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-US"));
        SpeechRecognitionEngine switchOnoffENG = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-US"));
        SpeechRecognitionEngine typeENG = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-US"));
        SpeechRecognitionEngine charCaseENG = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-US"));
        //....................................
        Choices selection1 = new Choices();
        Choices switchONoff1 = new Choices();
        Choices charCase1 = new Choices();
        SpeechRecognitionEngine selectionENG1 = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-US"));
        SpeechRecognitionEngine switchOnoffENG1 = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-US"));
        SpeechRecognitionEngine typeENG1 = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-US"));
        SpeechRecognitionEngine charCaseENG1 = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-US"));
        //....................................
        Choices operationInbox = new Choices();
        Choices InboxTypeActive = new Choices();
        SpeechRecognitionEngine InboxOperation = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-US"));
        SpeechRecognitionEngine InboxSearchActive = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-US"));
        SpeechRecognitionEngine InboxSearchType = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-US"));
        //....................................
        Choices operationSentItems = new Choices();
        Choices SentItemsTypeActive = new Choices();
        SpeechRecognitionEngine SentItemsOperation = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-US"));
        SpeechRecognitionEngine SentItemsSearchActive = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-US"));
        SpeechRecognitionEngine SentItemsSearchType = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-US"));
        //....................................
        Choices operationDraft = new Choices();
        Choices draftTypeActive = new Choices();
        SpeechRecognitionEngine DraftOperation = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-US"));
        SpeechRecognitionEngine DraftSearchActive = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-US"));
        SpeechRecognitionEngine DraftSearchType = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-US"));
        //....................................
        Confirmation cf;
        Choices confirmation = new Choices();
        SpeechRecognitionEngine confirmEng = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-US"));
        //....................................
        SpeechSynthesizer TalkBk = new SpeechSynthesizer();
        SoundPlayer NotifyS;
        SoundPlayer InfoS;
        SoundPlayer typeOn;
        SoundPlayer confMsg;

        //TitleBar mouse move control
        int TogMove;
        int MValX;
        int MValY;
        //ControlBar mouse move control

        private bool _dragging = false;
        private Point _start_point = new Point(0, 0);

        public event EventHandler OnGotoSleepBtnClicked;
        public event EventHandler OnTerminated;

        public bool state;

        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\adnan\Desktop\VoiceBox Beta.Final\VoiceBox Beta\DemoEmailServer.mdf;Integrated Security=True;User Instance=True");
        SqlCommand cmd = new SqlCommand();
        SqlCommand cmd1 = new SqlCommand();
        byte[] img = null;
        int imgAvil = 0;

        DataTable InboxData;
        DataTable SentData;
        DataTable DraftData;


        public voiceBoxMain()
        {
            InitializeComponent();
            CheckHA();
            btn_Commands.Add(new string[] { "Select login", "Open compose tab", "Close compose tab"
                , "Select inbox", "Select sent items", "Select draft", "Select settings"
                , "Select home tab", "What time is it now?", "What is the date today?"
                , "That's all for now", "Open account settings", "Close account settings"
                , "Reset notification", "Select unread mails","Deselect unread mails"
                , "Enable inbox", "Enable sentitems", "Enable draft" });
            GrammarBuilder GB = new GrammarBuilder();
            GB.Append(btn_Commands);
            Grammar gr = new Grammar(GB);
                try
                {
                    BtnCmmnd.LoadGrammar(gr);
                    BtnCmmnd.SetInputToDefaultAudioDevice();
                    //BtnCmmnd.RecognizeAsync(RecognizeMode.Multiple);
                    BtnCmmnd.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(BtnCmmnd_SpeechRecognized);

                }
                catch (Exception ex)
                {
                    //Error handle method
                }
            checkit();
            LogChechk();
            LogInPage.OnButtonClicked += new EventHandler(LogInPage_OnButtonClicked);
            LogInPage.OnButtonClickClosed += new EventHandler(LogInPage_OnButtonClickClosed);
            UserAccountSettings.NameChanged += new EventHandler(UserAccountSettings_NameChanged);
            InboxMailLoad.DeleteBtnClicked += new EventHandler(InboxMailLoad_DeleteBtnClicked);
            SentMailsLoad.DeleteBtnClicked += new EventHandler(SentMailsLoad_DeleteBtnClicked);
            DraftMailsLoad.DeleteBtnClicked += new EventHandler(DraftMailsLoad_DeleteBtnClicked);
            InboxMailLoad.ReplayBtnClicked += new EventHandler(InboxMailLoad_ReplayBtnClicked);
            InboxMailLoad.CancleBtnClicked += new EventHandler(InboxMailLoad_CancleBtnClicked);
            SentMailsLoad.CancleBtnClicked += new EventHandler(SentMailsLoad_CancleBtnClicked);
            DraftMailsLoad.CancleBtnClicked += new EventHandler(DraftMailsLoad_CancleBtnClicked);
            InboxMailLoad.ForwardBtnClicked += new EventHandler(InboxMailLoad_ForwardBtnClicked);
            SentMailsLoad.ForwardBtnClicked += new EventHandler(SentMailsLoad_ForwardBtnClicked);
            DraftMailsLoad.ForwardBtnClicked += new EventHandler(DraftMailsLoad_ForwardBtnClicked);
            InboxMailLoad.ScrollLeftBtnClicked += new EventHandler(InboxMailLoad_ScrollLeftBtnClicked);
            InboxMailLoad.ScrollRightBtnClicked += new EventHandler(InboxMailLoad_ScrollRightBtnClicked);
            SentMailsLoad.ScrollLeftBtnClicked += new EventHandler(SentMailsLoad_ScrollLeftBtnClicked);
            SentMailsLoad.ScrollRightBtnClicked += new EventHandler(SentMailsLoad_ScrollRightBtnClicked);
            DraftMailsLoad.ScrollLeftBtnClicked += new EventHandler(DraftMailsLoad_ScrollLeftBtnClicked);
            DraftMailsLoad.ScrollRightBtnClicked += new EventHandler(DraftMailsLoad_ScrollRightBtnClicked);
            InboxMailLoad.SearchEmpty += new EventHandler(InboxMailLoad_SearchEmpty);
            SentMailsLoad.SearchEmpty += new EventHandler(SentMailsLoad_SearchEmpty);
            DraftMailsLoad.SearchEmpty += new EventHandler(DraftMailsLoad_SearchEmpty);
            InboxMailLoad.SearchBtnClicked += new EventHandler(InboxMailLoad_SearchBtnClicked);
            SentMailsLoad.SearchBtnClicked += new EventHandler(SentMailsLoad_SearchBtnClicked);
            DraftMailsLoad.SearchBtnClicked += new EventHandler(DraftMailsLoad_SearchBtnClicked);
            InboxMailLoad.InboxRefresh += new EventHandler(InboxMailLoad_InboxRefresh);

        }

        private void CheckHA()
        {
            string tt;
            string filename = @"C:\Users\adnan\Desktop\VoiceBox Beta.Final\Log\UI_Settings.txt";
            if (File.Exists(filename))
            {
                string[] lines = File.ReadAllLines(filename);
                tt = lines[2].ToString();
                if (tt.Equals("help_assist_state=1"))
                {
                    HelpAssist = 1;
                }
                else if (tt.Equals("help_assist_state=0"))
                {
                    HelpAssist = 0;
                }
            }
        }

        void InboxMailLoad_InboxRefresh(object sender, EventArgs e)
        {
            CountUserMail_Inbox();
            inboxMail();
        }

        void DraftMailsLoad_SearchBtnClicked(object sender, EventArgs e)
        {
            try
            {
                DataView dv = new DataView(DraftData);
                dv.RowFilter = string.Format("Mail_ID LIKE '%{0}%'", DraftMailsLoad.searchTxt.Text);
                dataGridView.DataSource = dv;
                int index = 0;
                DataGridViewRow row = new DataGridViewRow();
                //----------------------------------------------

                row = this.dataGridView.Rows[index];
                DraftMailsLoad.lbl1.Text = "Address: " + row.Cells["Mail_ID"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                DraftMailsLoad.x1 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index += 1];
                DraftMailsLoad.lbl2.Text = "Address: " + row.Cells["Mail_ID"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                DraftMailsLoad.x2 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index += 1];
                DraftMailsLoad.lbl3.Text = "Address: " + row.Cells["Mail_ID"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                DraftMailsLoad.x3 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index += 1];
                DraftMailsLoad.lbl4.Text = "Address: " + row.Cells["Mail_ID"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                DraftMailsLoad.x4 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index += 1];
                DraftMailsLoad.lbl5.Text = "Address: " + row.Cells["Mail_ID"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                DraftMailsLoad.x5 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index += 1];
                DraftMailsLoad.lbl6.Text = "Address: " + row.Cells["Mail_ID"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                DraftMailsLoad.x6 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index += 1];
                DraftMailsLoad.lbl7.Text = "Address: " + row.Cells["Mail_ID"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                DraftMailsLoad.x7 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index += 1];
                DraftMailsLoad.lbl8.Text = "Address: " + row.Cells["Mail_ID"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                DraftMailsLoad.x8 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index += 1];
                DraftMailsLoad.lbl9.Text = "Address: " + row.Cells["Mail_ID"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                DraftMailsLoad.x9 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index += 1];
                DraftMailsLoad.lbl10.Text = "Address: " + row.Cells["Mail_ID"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                DraftMailsLoad.x10 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index += 1];
                DraftMailsLoad.lbl11.Text = "Address: " + row.Cells["Mail_ID"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                DraftMailsLoad.x11 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index += 1];
                DraftMailsLoad.lbl12.Text = "Address: " + row.Cells["Mail_ID"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                DraftMailsLoad.x12 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index += 1];
                DraftMailsLoad.lbl13.Text = "Address: " + row.Cells["Mail_ID"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                DraftMailsLoad.x13 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index += 1];
                DraftMailsLoad.lbl14.Text = "Address: " + row.Cells["Mail_ID"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                DraftMailsLoad.x14 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index += 1];
                DraftMailsLoad.lbl15.Text = "Address: " + row.Cells["Mail_ID"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                DraftMailsLoad.x15 = row.Cells["Serial"].Value.ToString();
                //--------------------------------------------------
            }
            catch (Exception ex)
            {
                //.................................
                //MessageBox.Show(ex.Message);
            }
        }

        void SentMailsLoad_SearchBtnClicked(object sender, EventArgs e)
        {
            try
            {
                DataView dv = new DataView(SentData);
                dv.RowFilter = string.Format("To LIKE '%{0}%'", SentMailsLoad.searchTxt.Text);
                dataGridView.DataSource = dv;
                int index = 0;
                DataGridViewRow row = new DataGridViewRow();
                //----------------------------------------------
                row = this.dataGridView.Rows[index];
                SentMailsLoad.lbl1.Text = "To: " + row.Cells["To"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                SentMailsLoad.x1 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index += 1];
                SentMailsLoad.lbl2.Text = "To: " + row.Cells["To"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                SentMailsLoad.x2 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index += 1];
                SentMailsLoad.lbl3.Text = "To: " + row.Cells["To"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                SentMailsLoad.x3 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index += 1];
                SentMailsLoad.lbl4.Text = "To: " + row.Cells["To"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                SentMailsLoad.x4 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index += 1];
                SentMailsLoad.lbl5.Text = "To: " + row.Cells["To"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                SentMailsLoad.x5 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index += 1];
                SentMailsLoad.lbl6.Text = "To: " + row.Cells["To"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                SentMailsLoad.x6 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index += 1];
                SentMailsLoad.lbl7.Text = "To: " + row.Cells["To"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                SentMailsLoad.x7 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index += 1];
                SentMailsLoad.lbl8.Text = "To: " + row.Cells["To"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                SentMailsLoad.x8 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index += 1];
                SentMailsLoad.lbl9.Text = "To: " + row.Cells["To"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                SentMailsLoad.x9 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index += 1];
                SentMailsLoad.lbl10.Text = "To: " + row.Cells["To"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                SentMailsLoad.x10 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index += 1];
                SentMailsLoad.lbl11.Text = "To: " + row.Cells["To"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                SentMailsLoad.x11 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index += 1];
                SentMailsLoad.lbl12.Text = "To: " + row.Cells["To"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                SentMailsLoad.x12 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index += 1];
                SentMailsLoad.lbl13.Text = "To: " + row.Cells["To"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                SentMailsLoad.x13 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index += 1];
                SentMailsLoad.lbl14.Text = "To: " + row.Cells["To"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                SentMailsLoad.x14 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index += 1];
                SentMailsLoad.lbl15.Text = "To: " + row.Cells["To"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                SentMailsLoad.x15 = row.Cells["Serial"].Value.ToString();
                //--------------------------------------------------

            }
            catch (Exception ex)
            {
                //...........................
            }
        }

        void InboxMailLoad_SearchBtnClicked(object sender, EventArgs e)
        {
            CheckInboxTm.Stop();
            try
            {
                DataView dv = new DataView(InboxData);
                dv.RowFilter = string.Format("From LIKE '%{0}%'", InboxMailLoad.searchTxt.Text);
                dataGridView.DataSource = dv;
                int index = 0;
                DataGridViewRow row = new DataGridViewRow();
                //----------------------------------------------
                row = this.dataGridView.Rows[index];
                InboxMailLoad.lbl1.Text = "From: " + row.Cells["From"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                InboxMailLoad.x1 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index += 1];
                InboxMailLoad.lbl2.Text = "From: " + row.Cells["From"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                InboxMailLoad.x2 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index += 1];
                InboxMailLoad.lbl3.Text = "From: " + row.Cells["From"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                InboxMailLoad.x3 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index += 1];
                InboxMailLoad.lbl4.Text = "From: " + row.Cells["From"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                InboxMailLoad.x4 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index += 1];
                InboxMailLoad.lbl5.Text = "From: " + row.Cells["From"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                InboxMailLoad.x5 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index += 1];
                InboxMailLoad.lbl6.Text = "From: " + row.Cells["From"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                InboxMailLoad.x6 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index += 1];
                InboxMailLoad.lbl7.Text = "From: " + row.Cells["From"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                InboxMailLoad.x7 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index += 1];
                InboxMailLoad.lbl8.Text = "From: " + row.Cells["From"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                InboxMailLoad.x8 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index += 1];
                InboxMailLoad.lbl9.Text = "From: " + row.Cells["From"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                InboxMailLoad.x9 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index += 1];
                InboxMailLoad.lbl10.Text = "From: " + row.Cells["From"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                InboxMailLoad.x10 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index += 1];
                InboxMailLoad.lbl11.Text = "From: " + row.Cells["From"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                InboxMailLoad.x11 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index += 1];
                InboxMailLoad.lbl12.Text = "From: " + row.Cells["From"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                InboxMailLoad.x12 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index += 1];
                InboxMailLoad.lbl13.Text = "From: " + row.Cells["From"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                InboxMailLoad.x13 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index += 1];
                InboxMailLoad.lbl14.Text = "From: " + row.Cells["From"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                InboxMailLoad.x14 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index += 1];
                InboxMailLoad.lbl15.Text = "From: " + row.Cells["From"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                InboxMailLoad.x15 = row.Cells["Serial"].Value.ToString();
                //--------------------------------------------------
            }
            catch (Exception ex)
            {
                //
            }
        }

        void DraftMailsLoad_SearchEmpty(object sender, EventArgs e)
        {
            CountUserMail_Drft();
            draftMails();
        }

        void SentMailsLoad_SearchEmpty(object sender, EventArgs e)
        {
            CountUserMail_SM();
            sentItemsMails();
        }

        void InboxMailLoad_SearchEmpty(object sender, EventArgs e)
        {
            CheckInboxTm.Start();
            CountUserMail_Inbox();
            inboxMail();
        }

        void DraftMailsLoad_ScrollRightBtnClicked(object sender, EventArgs e)
        {
            drft = drft - 15;
            draftMails();
        }

        void DraftMailsLoad_ScrollLeftBtnClicked(object sender, EventArgs e)
        {
            drft = drft + 15;
            draftMails();
        }

        void SentMailsLoad_ScrollRightBtnClicked(object sender, EventArgs e)
        {
            sntm = sntm - 15;
            sentItemsMails();
        }

        void SentMailsLoad_ScrollLeftBtnClicked(object sender, EventArgs e)
        {
            sntm = sntm + 15;
            sentItemsMails();
        }

        void InboxMailLoad_ScrollRightBtnClicked(object sender, EventArgs e)
        {
            CheckInboxTm.Stop();
            inbx = inbx - 15;
            inboxMail();
        }

        void InboxMailLoad_ScrollLeftBtnClicked(object sender, EventArgs e)
        {
            if (InboxMailLoad.pageLbl.Text == "1")
            {
                CheckInboxTm.Start();
            }
            inbx = inbx + 15;
            inboxMail();
        }

        void DraftMailsLoad_ForwardBtnClicked(object sender, EventArgs e)
        {
            if (panelSlide.Width == 1 && panelSlide.Height == 428)
            {
                panelSlide.Width = 379;
                panelSlide.Height = 428;
                subjectTxt.Text = DraftMailsLoad.F_Subject;
                attachTxt.Text = DraftMailsLoad.F_Attachment;
                bodyTxt.Text = DraftMailsLoad.F_Body;
            }
        }

        void SentMailsLoad_ForwardBtnClicked(object sender, EventArgs e)
        {
            if (panelSlide.Width == 1 && panelSlide.Height == 428)
            {
                panelSlide.Width = 379;
                panelSlide.Height = 428;
                subjectTxt.Text = SentMailsLoad.F_Subject;
                attachTxt.Text = SentMailsLoad.F_Attachment;
                bodyTxt.Text = SentMailsLoad.F_Body;
            }
        }

        void InboxMailLoad_ForwardBtnClicked(object sender, EventArgs e)
        {
            if (panelSlide.Width == 1 && panelSlide.Height == 428)
            {
                panelSlide.Width = 379;
                panelSlide.Height = 428;
                subjectTxt.Text = InboxMailLoad.F_Subject;
                attachTxt.Text = InboxMailLoad.F_Attachment;
                bodyTxt.Text = InboxMailLoad.F_Body;
            }
        }

        void DraftMailsLoad_CancleBtnClicked(object sender, EventArgs e)
        {
            panelSlide.Width = 1;
            panelSlide.Height = 428;
            addressTxt.Text = String.Empty;
            subjectTxt.Text = String.Empty;
            bodyTxt.Text = String.Empty;
            attachTxt.Text = String.Empty;
        }

        void SentMailsLoad_CancleBtnClicked(object sender, EventArgs e)
        {
            panelSlide.Width = 1;
            panelSlide.Height = 428;
            addressTxt.Text = String.Empty;
            subjectTxt.Text = String.Empty;
            bodyTxt.Text = String.Empty;
            attachTxt.Text = String.Empty;
        }

        void InboxMailLoad_CancleBtnClicked(object sender, EventArgs e)
        {
            panelSlide.Width = 1;
            panelSlide.Height = 428;
            addressTxt.Text = String.Empty;
            subjectTxt.Text = String.Empty;
            bodyTxt.Text = String.Empty;
            attachTxt.Text = String.Empty;
        }

        void InboxMailLoad_ReplayBtnClicked(object sender, EventArgs e)
        {
            if (panelSlide.Width == 1 && panelSlide.Height == 428)
            {
                panelSlide.Width = 379;
                panelSlide.Height = 428;
                addressTxt.Text = InboxMailLoad.Mail_Reply;
            }
        }

        void DraftMailsLoad_DeleteBtnClicked(object sender, EventArgs e)
        {
            CountUserMail_Drft();
            draftMails();
            InfoS = new SoundPlayer("Info.wav");
            CustomMessageBox mb = new CustomMessageBox();
            InfoS.Play();
            mb.CustomMessageTxt.Text = "Delete successfull!!!";
            mb.ShowDialog();
        }

        void SentMailsLoad_DeleteBtnClicked(object sender, EventArgs e)
        {
            CountUserMail_SM();
            sentItemsMails();
            InfoS = new SoundPlayer("Info.wav");
            CustomMessageBox mb = new CustomMessageBox();
            InfoS.Play();
            mb.CustomMessageTxt.Text = "Delete successfull!!!";
            mb.ShowDialog();
        }

        void InboxMailLoad_DeleteBtnClicked(object sender, EventArgs e)
        {
            if (InboxMailLoad.pageLbl.Text == "1")
            {
                CheckInboxTm.Start();
            }
            CountUserMail_Inbox();
            inboxMail();
            ResetMailCount();
            InfoS = new SoundPlayer("Info.wav");
            CustomMessageBox mb = new CustomMessageBox();
            InfoS.Play();
            mb.CustomMessageTxt.Text = "Delete successfull!!!";
            mb.ShowDialog();
        }

        void UserAccountSettings_NameChanged(object sender, EventArgs e)
        {
            getInfo();
            //lblStatus.Text = " ";
            //lblStatus.Text = "Saved successfull!";
            InfoS = new SoundPlayer("Info.wav");
            CustomMessageBox mb = new CustomMessageBox();
            InfoS.Play();
            mb.CustomMessageTxt.Text = "Save successfull!!!";
            mb.ShowDialog();
        }

        private void checkit()
        {
            SelectOperation();
            DictationOperation();
            typeCast();
            TypeOperation();
            //....................................
            SelectOperation1();
            DictationOperation1();
            typeCast1();
            TypeOperation1();
            //....................................
            InboxMailOperations();
            InboxSearchOperation();
            InboxSearchTypeEng();
            //....................................
            SentItemsMailOperations();
            SentItemsSearchOperation();
            SentItemsSearchTypeEng();
            //....................................
            DraftMailOperations();
            DraftSearchOperation();
            DraftSearchTypeEng();
            //....................................
            ConfirmationMsgPop();
        }

        private void ConfirmationMsgPop()
        {
            confirmation.Add(new string[] {"yes", "no"});
            GrammarBuilder gb100 = new GrammarBuilder();
            gb100.Append(confirmation);
            Grammar g100 = new Grammar(gb100);
            try
            {
                confirmEng.LoadGrammar(g100);
                confirmEng.SetInputToDefaultAudioDevice();
                confirmEng.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(confirmEng_SpeechRecognized);
            }
            catch (Exception ex)
            {
                //Error........
            }
        }

        void confirmEng_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            switch (e.Result.Text.ToString())
            {
                case "yes":
                    {
                        confAct = 1;
                        cf.Recognizer.ForeColor = ColorTranslator.FromHtml("#00e600");
                        cf.Recognizer.Text = "YES";
                        //cf.Hide();
                        break;
                    }
                case "no":
                    {
                        confAct = 0;
                        cf.Recognizer.ForeColor = ColorTranslator.FromHtml("#cc0000");
                        cf.Recognizer.Text = "NO";
                        //cf.Hide();
                        break;
                    }
            }
        }

        private void DraftSearchTypeEng()
        {
            try
            {
                DraftSearchType.LoadGrammar(new DictationGrammar());
                DraftSearchType.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(DraftSearchType_SpeechRecognized);
                DraftSearchType.SetInputToDefaultAudioDevice();
            }
            catch (Exception ex)
            {
                //.........
            }
        }

        void DraftSearchType_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            switch (searchType_DR)
            {
                case 1:
                    {
                        DraftMailsLoad.searchTxt.Text = (e.Result.Text.ToLower()).ToString();
                        TalkBk.SpeakAsync("Keyword entered");
                        break;
                    }
                case 0:
                    {
                        DraftSearchType.RecognizeAsyncStop();
                        break;
                    }
            }
        }

        private void DraftSearchOperation()
        {
            draftTypeActive.Add(new string[] { "Keyword", "Search", "Readback keyword" });
            GrammarBuilder gb57 = new GrammarBuilder();
            gb57.Append(draftTypeActive);
            Grammar g57 = new Grammar(gb57);
            try
            {
                DraftSearchActive.LoadGrammar(g57);
                DraftSearchActive.SetInputToDefaultAudioDevice();
                DraftSearchActive.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(DraftSearchActive_SpeechRecognized);
            }
            catch (Exception ex)
            {
                //............
            }
        }

        void DraftSearchActive_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            switch (e.Result.Text.ToString())
            {
                case "Keyword":
                    {
                        searchType_DR = 1;
                        DraftSearchType.RecognizeAsync(RecognizeMode.Multiple);
                        lblStatus.Text = " ";
                        lblStatus.Text = "Dictating...!";
                        typeOn = new SoundPlayer("Dictation enable.wav");
                        typeOn.Play();
                        break;
                    }
                case "Search":
                    {
                        searchType_DR = 0;
                        DraftSearchActive.RecognizeAsyncStop();
                        DraftSearchType.RecognizeAsyncStop();
                        lblStatus.Text = " ";
                        lblStatus.Text = "Searching mail";
                        DraftOperation.RecognizeAsync(RecognizeMode.Multiple);
                        DraftMailsLoad.Mcount = 0;
                        DraftMailsLoadLBLRefresh();
                        SearchDraftOperation();
                        TalkBk.SpeakAsync(DraftMailsLoad.Mcount + " matching mail found");
                        break;
                    }
                case "Readback keyword":
                    {
                        if (DraftMailsLoad.searchTxt.Text != String.Empty)
                        {
                            searchType_DR = 0;
                            DraftSearchActive.RecognizeAsyncStop();
                            TalkBk.SpeakAsync(DraftMailsLoad.searchTxt.Text);
                        }
                        break;
                    }
            }
        }

        private void SearchDraftOperation()
        {
            try
            {
                DataView dv = new DataView(DraftData);
                dv.RowFilter = string.Format("Mail_ID LIKE '%{0}%'", DraftMailsLoad.searchTxt.Text);
                dataGridView.DataSource = dv;
                int index = 0;
                DataGridViewRow row = new DataGridViewRow();
                //----------------------------------------------

                row = this.dataGridView.Rows[index];
                DraftMailsLoad.lbl1.Text = "Address: " + row.Cells["Mail_ID"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                DraftMailsLoad.x1 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index += 1];
                DraftMailsLoad.lbl2.Text = "Address: " + row.Cells["Mail_ID"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                DraftMailsLoad.x2 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index += 1];
                DraftMailsLoad.lbl3.Text = "Address: " + row.Cells["Mail_ID"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                DraftMailsLoad.x3 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index += 1];
                DraftMailsLoad.lbl4.Text = "Address: " + row.Cells["Mail_ID"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                DraftMailsLoad.x4 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index += 1];
                DraftMailsLoad.lbl5.Text = "Address: " + row.Cells["Mail_ID"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                DraftMailsLoad.x5 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index += 1];
                DraftMailsLoad.lbl6.Text = "Address: " + row.Cells["Mail_ID"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                DraftMailsLoad.x6 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index += 1];
                DraftMailsLoad.lbl7.Text = "Address: " + row.Cells["Mail_ID"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                DraftMailsLoad.x7 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index += 1];
                DraftMailsLoad.lbl8.Text = "Address: " + row.Cells["Mail_ID"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                DraftMailsLoad.x8 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index += 1];
                DraftMailsLoad.lbl9.Text = "Address: " + row.Cells["Mail_ID"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                DraftMailsLoad.x9 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index += 1];
                DraftMailsLoad.lbl10.Text = "Address: " + row.Cells["Mail_ID"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                DraftMailsLoad.x10 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index += 1];
                DraftMailsLoad.lbl11.Text = "Address: " + row.Cells["Mail_ID"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                DraftMailsLoad.x11 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index += 1];
                DraftMailsLoad.lbl12.Text = "Address: " + row.Cells["Mail_ID"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                DraftMailsLoad.x12 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index += 1];
                DraftMailsLoad.lbl13.Text = "Address: " + row.Cells["Mail_ID"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                DraftMailsLoad.x13 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index += 1];
                DraftMailsLoad.lbl14.Text = "Address: " + row.Cells["Mail_ID"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                DraftMailsLoad.x14 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index += 1];
                DraftMailsLoad.lbl15.Text = "Address: " + row.Cells["Mail_ID"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                DraftMailsLoad.x15 = row.Cells["Serial"].Value.ToString();
                //--------------------------------------------------
            }
            catch (Exception ex)
            {
                //.................................
            }
        }

        private void DraftMailOperations()
        {
            operationDraft.Add(new string[] { "Disable draft", "How many mails are there"
                , "Close and go back to draft", "Readback again", "Open and read first"
                , "Open and read second", "Open and read third", "Open and read fourth"
                , "Open and read fifth", "Open and read sixth", "Open and read seventh"
                , "Open and read eighth", "Open and read ninth", "Open and read tenth"
                , "Open and read eleventh", "Open and read twelfth", "Open and read thirteenth"
                , "Open and read fourteenth", "Open and read fifteenth", "Delete this mail"
                , "Forward this", "Search mail", "Clear search", "Reset notification", "Scroll next", "Scroll back" });
            GrammarBuilder gb47 = new GrammarBuilder();
            gb47.Append(operationDraft);
            Grammar g47 = new Grammar(gb47);
            try
            {
                DraftOperation.LoadGrammar(g47);
                DraftOperation.SetInputToDefaultAudioDevice();
                DraftOperation.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(DraftOperation_SpeechRecognized);
            }
            catch (Exception ex)
            {
                //Error........
            }
        }

        void DraftOperation_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (DraftMailsLoad.Visible != false)
            {
                switch (e.Result.Text.ToString())
                {
                    case "Disable draft":
                        {
                            if (DraftMailsLoad.ReadBox.Visible != true)
                            {
                                TalkBk.SpeakAsync("Draft operation disabled");
                                DraftOperation.RecognizeAsyncStop();
                                BtnCmmnd.RecognizeAsync(RecognizeMode.Multiple);
                                lblStatus.Text = " ";
                                lblStatus.Text = "D.O disabled";
                            }
                            break;
                        }
                    case "How many mails are there":
                        {
                            TalkBk.SpeakAsync("There are, " + DraftMailsLoad.amounttxt.Text + " mails in draft, page " + DraftMailsLoad.pageLbl.Text + " showing " + DraftMailsLoad.Mcount + " of " + DraftMailsLoad.amounttxt.Text);
                            lblStatus.Text = " ";
                            lblStatus.Text = "Counting total mails";
                            break;
                        }
                    case "Close and go back to draft":
                        {
                            if (DraftMailsLoad.ReadBox.Visible != false)
                            {
                                TalkBk.SpeakAsync("Closed and backed to draft");
                                GoBackToDraft();
                            }
                            if (panelSlide.Width == 379 && panelSlide.Height == 428)
                            {
                                panelSlide.Width = 1;
                                panelSlide.Height = 428;
                            }
                            lblStatus.Text = " ";
                            lblStatus.Text = "Closing R.B.";
                            break;
                        }
                    case "Readback again":
                        {
                            if (DraftMailsLoad.ReadBox.Visible != false)
                            {
                                TalkBk.SpeakAsync("This mail was created on, " + DraftMailsLoad.DateTimeLBL.Text + "," + " subject, " + DraftMailsLoad.textBox3.Text + "," + "  mail body, " + DraftMailsLoad.richTextBox1.Text);
                                if (DraftMailsLoad.AttachmentTXT.Text != String.Empty)
                                {
                                    TalkBk.SpeakAsync("There is also an attachment with this mail");
                                }
                                lblStatus.Text = " ";
                                lblStatus.Text = "Initiating readback";
                            }
                            break;
                        }
                    case "Open and read first":
                        {
                            if (DraftMailsLoad.ReadBox.Visible != true && DraftMailsLoad.lbl1.Text != String.Empty)
                            {
                                TalkBk.SpeakAsync("First mail is opened, initiating readback, ");
                                DraftMailsLoad.cap = DraftMailsLoad.x1;
                                RunDraftSQLOperation();
                                OpenReadBox_DR();
                                TalkBk.SpeakAsync("This mail was created on, " + DraftMailsLoad.DateTimeLBL.Text + "," + " subject, " + DraftMailsLoad.textBox3.Text + "," + "  mail body, " + DraftMailsLoad.richTextBox1.Text);
                                if (DraftMailsLoad.AttachmentTXT.Text != String.Empty)
                                {
                                    TalkBk.SpeakAsync("There is also an attachment with this mail");
                                }
                                lblStatus.Text = " ";
                                lblStatus.Text = "1st mail opened";
                            }
                            break;
                        }
                    case "Open and read second":
                        {
                            if (DraftMailsLoad.ReadBox.Visible != true && DraftMailsLoad.lbl2.Text != String.Empty)
                            {
                                TalkBk.SpeakAsync("Second mail is opened, initiating readback, ");
                                DraftMailsLoad.cap = DraftMailsLoad.x2;
                                RunDraftSQLOperation();
                                OpenReadBox_DR();
                                TalkBk.SpeakAsync("This mail was created on, " + DraftMailsLoad.DateTimeLBL.Text + "," + " subject, " + DraftMailsLoad.textBox3.Text + "," + "  mail body, " + DraftMailsLoad.richTextBox1.Text);
                                if (DraftMailsLoad.AttachmentTXT.Text != String.Empty)
                                {
                                    TalkBk.SpeakAsync("There is also an attachment with this mail");
                                }
                                lblStatus.Text = " ";
                                lblStatus.Text = "2nd mail opened";
                            }
                            break;
                        }
                    case "Open and read third":
                        {
                            if (DraftMailsLoad.ReadBox.Visible != true && DraftMailsLoad.lbl3.Text != String.Empty)
                            {
                                TalkBk.SpeakAsync("Third mail is opened, initiating readback, ");
                                DraftMailsLoad.cap = DraftMailsLoad.x3;
                                RunDraftSQLOperation();
                                OpenReadBox_DR();
                                TalkBk.SpeakAsync("This mail was created on, " + DraftMailsLoad.DateTimeLBL.Text + "," + " subject, " + DraftMailsLoad.textBox3.Text + "," + "  mail body, " + DraftMailsLoad.richTextBox1.Text);
                                if (DraftMailsLoad.AttachmentTXT.Text != String.Empty)
                                {
                                    TalkBk.SpeakAsync("There is also an attachment with this mail");
                                }
                                lblStatus.Text = " ";
                                lblStatus.Text = "3rd mail opened";
                            }
                            break;
                        }
                    case "Open and read fourth":
                        {
                            if (DraftMailsLoad.ReadBox.Visible != true && DraftMailsLoad.lbl4.Text != String.Empty)
                            {
                                TalkBk.SpeakAsync("Fourth mail is opened, initiating readback, ");
                                DraftMailsLoad.cap = DraftMailsLoad.x4;
                                RunDraftSQLOperation();
                                OpenReadBox_DR();
                                TalkBk.SpeakAsync("This mail was created on, " + DraftMailsLoad.DateTimeLBL.Text + "," + " subject, " + DraftMailsLoad.textBox3.Text + "," + "  mail body, " + DraftMailsLoad.richTextBox1.Text);
                                if (DraftMailsLoad.AttachmentTXT.Text != String.Empty)
                                {
                                    TalkBk.SpeakAsync("There is also an attachment with this mail");
                                }
                                lblStatus.Text = " ";
                                lblStatus.Text = "4th mail opened";
                            }
                            break;
                        }
                    case "Open and read fifth":
                        {
                            if (DraftMailsLoad.ReadBox.Visible != true && DraftMailsLoad.lbl5.Text != String.Empty)
                            {
                                TalkBk.SpeakAsync("Fifth mail is opened, initiating readback, ");
                                DraftMailsLoad.cap = DraftMailsLoad.x5;
                                RunDraftSQLOperation();
                                OpenReadBox_DR();
                                TalkBk.SpeakAsync("This mail was created on, " + DraftMailsLoad.DateTimeLBL.Text + "," + " subject, " + DraftMailsLoad.textBox3.Text + "," + "  mail body, " + DraftMailsLoad.richTextBox1.Text);
                                if (DraftMailsLoad.AttachmentTXT.Text != String.Empty)
                                {
                                    TalkBk.SpeakAsync("There is also an attachment with this mail");
                                }
                                lblStatus.Text = " ";
                                lblStatus.Text = "5th mail opened";
                            }
                            break;
                        }
                    case "Open and read sixth":
                        {
                            if (DraftMailsLoad.ReadBox.Visible != true && DraftMailsLoad.lbl6.Text != String.Empty)
                            {
                                TalkBk.SpeakAsync("Sixth mail is opened, initiating readback, ");
                                DraftMailsLoad.cap = DraftMailsLoad.x6;
                                RunDraftSQLOperation();
                                OpenReadBox_DR();
                                TalkBk.SpeakAsync("This mail was created on, " + DraftMailsLoad.DateTimeLBL.Text + "," + " subject, " + DraftMailsLoad.textBox3.Text + "," + "  mail body, " + DraftMailsLoad.richTextBox1.Text);
                                if (DraftMailsLoad.AttachmentTXT.Text != String.Empty)
                                {
                                    TalkBk.SpeakAsync("There is also an attachment with this mail");
                                }
                                lblStatus.Text = " ";
                                lblStatus.Text = "6th mail opened";
                            }
                            break;
                        }
                    case "Open and read seventh":
                        {
                            if (DraftMailsLoad.ReadBox.Visible != true && DraftMailsLoad.lbl7.Text != String.Empty)
                            {
                                TalkBk.SpeakAsync("Seventh mail is opened, initiating readback, ");
                                DraftMailsLoad.cap = DraftMailsLoad.x7;
                                RunDraftSQLOperation();
                                OpenReadBox_DR();
                                TalkBk.SpeakAsync("This mail was created on, " + DraftMailsLoad.DateTimeLBL.Text + "," + " subject, " + DraftMailsLoad.textBox3.Text + "," + "  mail body, " + DraftMailsLoad.richTextBox1.Text);
                                if (DraftMailsLoad.AttachmentTXT.Text != String.Empty)
                                {
                                    TalkBk.SpeakAsync("There is also an attachment with this mail");
                                }
                                lblStatus.Text = " ";
                                lblStatus.Text = "7th mail opened";
                            }
                            break;
                        }
                    case "Open and read eighth":
                        {
                            if (DraftMailsLoad.ReadBox.Visible != true && DraftMailsLoad.lbl8.Text != String.Empty)
                            {
                                TalkBk.SpeakAsync("Eighth mail is opened, initiating readback, ");
                                DraftMailsLoad.cap = DraftMailsLoad.x8;
                                RunDraftSQLOperation();
                                OpenReadBox_DR();
                                TalkBk.SpeakAsync("This mail was created on, " + DraftMailsLoad.DateTimeLBL.Text + "," + " subject, " + DraftMailsLoad.textBox3.Text + "," + "  mail body, " + DraftMailsLoad.richTextBox1.Text);
                                if (DraftMailsLoad.AttachmentTXT.Text != String.Empty)
                                {
                                    TalkBk.SpeakAsync("There is also an attachment with this mail");
                                }
                                lblStatus.Text = " ";
                                lblStatus.Text = "8th mail opened";
                            }
                            break;
                        }
                    case "Open and read ninth":
                        {
                            if (DraftMailsLoad.ReadBox.Visible != true && DraftMailsLoad.lbl9.Text != String.Empty)
                            {
                                TalkBk.SpeakAsync("Ninth mail is opened, initiating readback, ");
                                DraftMailsLoad.cap = DraftMailsLoad.x9;
                                RunDraftSQLOperation();
                                OpenReadBox_DR();
                                TalkBk.SpeakAsync("This mail was created on, " + DraftMailsLoad.DateTimeLBL.Text + "," + " subject, " + DraftMailsLoad.textBox3.Text + "," + "  mail body, " + DraftMailsLoad.richTextBox1.Text);
                                if (DraftMailsLoad.AttachmentTXT.Text != String.Empty)
                                {
                                    TalkBk.SpeakAsync("There is also an attachment with this mail");
                                }
                                lblStatus.Text = " ";
                                lblStatus.Text = "9th mail opened";
                            }
                            break;
                        }
                    case "Open and read tenth":
                        {
                            if (DraftMailsLoad.ReadBox.Visible != true && DraftMailsLoad.lbl10.Text != String.Empty)
                            {
                                TalkBk.SpeakAsync("Tenth mail is opened, initiating readback, ");
                                DraftMailsLoad.cap = DraftMailsLoad.x10;
                                RunDraftSQLOperation();
                                OpenReadBox_DR();
                                TalkBk.SpeakAsync("This mail was created on, " + DraftMailsLoad.DateTimeLBL.Text + "," + " subject, " + DraftMailsLoad.textBox3.Text + "," + "  mail body, " + DraftMailsLoad.richTextBox1.Text);
                                if (DraftMailsLoad.AttachmentTXT.Text != String.Empty)
                                {
                                    TalkBk.SpeakAsync("There is also an attachment with this mail");
                                }
                                lblStatus.Text = " ";
                                lblStatus.Text = "10th mail opened";
                            }
                            break;
                        }
                    case "Open and read eleventh":
                        {
                            if (DraftMailsLoad.ReadBox.Visible != true && DraftMailsLoad.lbl11.Text != String.Empty)
                            {
                                TalkBk.SpeakAsync("Eleventh mail is opened, initiating readback, ");
                                DraftMailsLoad.cap = DraftMailsLoad.x11;
                                RunDraftSQLOperation();
                                OpenReadBox_DR();
                                TalkBk.SpeakAsync("This mail was created on, " + DraftMailsLoad.DateTimeLBL.Text + "," + " subject, " + DraftMailsLoad.textBox3.Text + "," + "  mail body, " + DraftMailsLoad.richTextBox1.Text);
                                if (DraftMailsLoad.AttachmentTXT.Text != String.Empty)
                                {
                                    TalkBk.SpeakAsync("There is also an attachment with this mail");
                                }
                                lblStatus.Text = " ";
                                lblStatus.Text = "11th mail opened";
                            }
                            break;
                        }
                    case "Open and read twelfth":
                        {
                            if (DraftMailsLoad.ReadBox.Visible != true && DraftMailsLoad.lbl12.Text != String.Empty)
                            {
                                TalkBk.SpeakAsync("Twelfth mail is opened, initiating readback, ");
                                DraftMailsLoad.cap = DraftMailsLoad.x12;
                                RunDraftSQLOperation();
                                OpenReadBox_DR();
                                TalkBk.SpeakAsync("This mail was created on, " + DraftMailsLoad.DateTimeLBL.Text + "," + " subject, " + DraftMailsLoad.textBox3.Text + "," + "  mail body, " + DraftMailsLoad.richTextBox1.Text);
                                if (DraftMailsLoad.AttachmentTXT.Text != String.Empty)
                                {
                                    TalkBk.SpeakAsync("There is also an attachment with this mail");
                                }
                                lblStatus.Text = " ";
                                lblStatus.Text = "12th mail opened";
                            }
                            break;
                        }
                    case "Open and read thirteenth":
                        {
                            if (DraftMailsLoad.ReadBox.Visible != true && DraftMailsLoad.lbl13.Text != String.Empty)
                            {
                                TalkBk.SpeakAsync("Thirteenth mail is opened, initiating readback, ");
                                DraftMailsLoad.cap = DraftMailsLoad.x13;
                                RunDraftSQLOperation();
                                OpenReadBox_DR();
                                TalkBk.SpeakAsync("This mail was created on, " + DraftMailsLoad.DateTimeLBL.Text + "," + " subject, " + DraftMailsLoad.textBox3.Text + "," + "  mail body, " + DraftMailsLoad.richTextBox1.Text);
                                if (DraftMailsLoad.AttachmentTXT.Text != String.Empty)
                                {
                                    TalkBk.SpeakAsync("There is also an attachment with this mail");
                                }
                                lblStatus.Text = " ";
                                lblStatus.Text = "13th mail opened";
                            }
                            break;
                        }
                    case "Open and read fourteenth":
                        {
                            if (DraftMailsLoad.ReadBox.Visible != true && DraftMailsLoad.lbl14.Text != String.Empty)
                            {
                                TalkBk.SpeakAsync("Fourteenth mail is opened, initiating readback, ");
                                DraftMailsLoad.cap = DraftMailsLoad.x14;
                                RunDraftSQLOperation();
                                OpenReadBox_DR();
                                TalkBk.SpeakAsync("This mail was created on, " + DraftMailsLoad.DateTimeLBL.Text + "," + " subject, " + DraftMailsLoad.textBox3.Text + "," + "  mail body, " + DraftMailsLoad.richTextBox1.Text);
                                if (DraftMailsLoad.AttachmentTXT.Text != String.Empty)
                                {
                                    TalkBk.SpeakAsync("There is also an attachment with this mail");
                                }
                                lblStatus.Text = " ";
                                lblStatus.Text = "14th mail opened";
                            }
                            break;
                        }
                    case "Open and read fifteenth":
                        {
                            if (DraftMailsLoad.ReadBox.Visible != true && DraftMailsLoad.lbl15.Text != String.Empty)
                            {
                                TalkBk.SpeakAsync("Fifteenth mail is opened, initiating readback, ");
                                DraftMailsLoad.cap = DraftMailsLoad.x15;
                                RunDraftSQLOperation();
                                OpenReadBox_DR();
                                TalkBk.SpeakAsync("This mail was created on, " + DraftMailsLoad.DateTimeLBL.Text + "," + " subject, " + DraftMailsLoad.textBox3.Text + "," + "  mail body, " + DraftMailsLoad.richTextBox1.Text);
                                if (DraftMailsLoad.AttachmentTXT.Text != String.Empty)
                                {
                                    TalkBk.SpeakAsync("There is also an attachment with this mail");
                                }
                                lblStatus.Text = " ";
                                lblStatus.Text = "15th mail opened";
                            }
                            break;
                        }
                    case "Delete this mail":
                        {
                            if (DraftMailsLoad.ReadBox.Visible != false)
                            {
                                //TalkBk.Pause();
                                DraftMailsLoadMailDelete();
                                DraftMailsLoadLBLRefresh();
                                CountUserMail_Drft();
                                draftMails();
                                DraftMailsLoad.page = 1;
                                DraftMailsLoad.pageLbl.Text = DraftMailsLoad.page.ToString();
                                GoBackToDraft();
                                if (confAct == 1)
                                {
                                    TalkBk.SpeakAsync("Mail has been deleted");
                                }
                                else if (confAct == 0)
                                {
                                    TalkBk.SpeakAsync("Operation canceled");
                                }
                                lblStatus.Text = " ";
                                lblStatus.Text = "Mail deleting";
                            }
                            break;
                        }
                    case "Forward this":
                        {
                            if (DraftMailsLoad.ReadBox.Visible != false)
                            {
                                DraftMailForward();
                                uniqPermission4 = 11;
                                DraftOperation.RecognizeAsyncStop();
                                selectionENG1.RecognizeAsync(RecognizeMode.Multiple);
                                TalkBk.SpeakAsync("Compose box opened and subject, mail body, attachment has been inserted, insert mail address");
                                lblStatus.Text = " ";
                                lblStatus.Text = "Forward initiating";
                            }
                            break;
                        }
                    case "Search mail":
                        {
                            TalkBk.SpeakAsync("Keyword necessary");
                            DraftOperation.RecognizeAsyncStop();
                            DraftSearchActive.RecognizeAsync(RecognizeMode.Multiple);
                            lblStatus.Text = " ";
                            lblStatus.Text = "Search initiating";
                            break;
                        }
                    case "Clear search":
                        {
                            DraftMailsLoad.searchTxt.Text = String.Empty;
                            TalkBk.SpeakAsync("Search cleared");
                            lblStatus.Text = " ";
                            lblStatus.Text = "Clearing....";
                            break;
                        }
                    case "Reset notification":
                        {
                            if (notificationLbl.Visible == true)
                            {
                                CmndInbox();
                                UsrNotifictn.BackgroundImage = Properties.Resources._003_notification;
                                notificationLbl.Visible = false;
                                ResetMailCount();
                                NotifyUser.Start();
                                TalkBk.SpeakAsync("Notification reset");
                                lblStatus.Text = " ";
                                lblStatus.Text = "Resetting";
                            }
                            break;
                        }
                    case "Scroll next":
                        {
                            if (DraftMailsLoad.lbl15.Text != String.Empty)
                            {
                                DraftMailsLoad.Mcount = 0;
                                DraftMailsLoad.page = DraftMailsLoad.page + 1;
                                DraftMailsLoad.pageLbl.Text = DraftMailsLoad.page.ToString();
                                DraftMailsLoadLBLRefresh();
                                drft = drft - 15;
                                draftMails();
                                TalkBk.SpeakAsync("Page " + DraftMailsLoad.pageLbl.Text + " is showing");
                            }
                            else
                            {
                                TalkBk.SpeakAsync("Can not scroll to next, page limit reached");
                            }
                            break;
                        }
                    case "Scroll back":
                        {
                            if (DraftMailsLoad.pageLbl.Text != "1")
                            {
                                DraftMailsLoad.Mcount = 0;
                                DraftMailsLoad.page = DraftMailsLoad.page - 1;
                                DraftMailsLoad.pageLbl.Text = DraftMailsLoad.page.ToString();
                                DraftMailsLoadLBLRefresh();
                                drft = drft + 15;
                                draftMails();
                                TalkBk.SpeakAsync("Page " + DraftMailsLoad.pageLbl.Text + " is showing");
                            }
                            else
                            {
                                TalkBk.SpeakAsync("Can not scroll back, page limit reached");
                            }
                            break;
                        }
                }
            }
        }

        private void DraftMailForward()
        {
            if (DraftMailsLoad.cap != null)
            {
                try
                {
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }
                    cmd.Connection = con;
                    cmd.CommandText = "Select Subject,Body,Attachment From Draft where Serial='" + DraftMailsLoad.cap + "'";
                    cmd.ExecuteNonQuery();
                    cmd.Clone();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        DraftMailsLoad.F_Subject = sdr[0].ToString();
                        DraftMailsLoad.F_Body = sdr[1].ToString();
                        DraftMailsLoad.F_Attachment = sdr[2].ToString();
                    }
                    if (panelSlide.Width == 1 && panelSlide.Height == 428)
                    {
                        panelSlide.Width = 379;
                        panelSlide.Height = 428;
                        subjectTxt.Text = DraftMailsLoad.F_Subject;
                        attachTxt.Text = DraftMailsLoad.F_Attachment;
                        bodyTxt.Text = DraftMailsLoad.F_Body;
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    con.Close();
                    //MessageBox.Show(ex.Message);
                }
            }
        }

        private void DraftMailsLoadLBLRefresh()
        {
            DraftMailsLoad.lbl1.Text = String.Empty;
            DraftMailsLoad.lbl2.Text = String.Empty;
            DraftMailsLoad.lbl3.Text = String.Empty;
            DraftMailsLoad.lbl4.Text = String.Empty;
            DraftMailsLoad.lbl5.Text = String.Empty;
            DraftMailsLoad.lbl6.Text = String.Empty;
            DraftMailsLoad.lbl7.Text = String.Empty;
            DraftMailsLoad.lbl8.Text = String.Empty;
            DraftMailsLoad.lbl9.Text = String.Empty;
            DraftMailsLoad.lbl10.Text = String.Empty;
            DraftMailsLoad.lbl11.Text = String.Empty;
            DraftMailsLoad.lbl12.Text = String.Empty;
            DraftMailsLoad.lbl13.Text = String.Empty;
            DraftMailsLoad.lbl14.Text = String.Empty;
            DraftMailsLoad.lbl15.Text = String.Empty;
        }

        private void DraftMailsLoadMailDelete()
        {
            confMsg = new SoundPlayer("Notify.wav");
            confMsg.Play();
            cf = new Confirmation();
            TalkBk.SpeakAsync("Are you really want to delete this mail?");
            confirmEng.RecognizeAsync(RecognizeMode.Multiple);
            cf.ShowDialog();
            if (confAct == 1)
            {
                confirmEng.RecognizeAsyncStop();
                DraftMailsLoad.Mcount = 0;
                if (DraftMailsLoad.cap != null)
                {
                    try
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }
                        cmd.Connection = con;
                        cmd.CommandText = "Delete Draft where Serial='" + DraftMailsLoad.cap + "'";
                        cmd.ExecuteNonQuery();
                        cmd.Clone();
                        con.Close();
                    }
                    catch (Exception ex)
                    {
                        con.Close();
                        //MessageBox.Show(ex.Message);
                    }
                }
            }
            else if (confAct == 0)
            {
                try
                {
                    confirmEng.RecognizeAsyncStop();
                    DraftMailsLoad.cap = null;
                }
                catch (Exception ex)
                {
                    //error......
                }
            }
        }

        private void OpenReadBox_DR()
        {
            DraftMailsLoad.label5.Visible = false;
            DraftMailsLoad.label7.Visible = false;
            DraftMailsLoad.amounttxt.Visible = false;
            DraftMailsLoad.pageLbl.Visible = false;
            DraftMailsLoad.ReadBox.Width = 627;
            DraftMailsLoad.ReadBox.Height = 473;
            DraftMailsLoad.ReadBox.Visible = true;
        }

        private void RunDraftSQLOperation()
        {
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                cmd.Connection = con;
                cmd.CommandText = "Select Mail_ID,Subject,Body,TimeDate,Attachment From Draft where User_ID='" + currentUser + "' and Serial='" + DraftMailsLoad.cap + "'";
                cmd.ExecuteNonQuery();
                cmd.Clone();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    DraftMailsLoad.textBox2.Text = sdr[0].ToString();
                    DraftMailsLoad.textBox3.Text = sdr[1].ToString();
                    DraftMailsLoad.richTextBox1.Text = sdr[2].ToString();
                    DraftMailsLoad.DateTimeLBL.Text = sdr[3].ToString();
                    DraftMailsLoad.img = (byte[])(sdr[4]);
                    if (DraftMailsLoad.img == null)
                    {
                        DraftMailsLoad.AttachmentTXT.Text = "";
                    }
                    else
                    {
                        MemoryStream ms = new MemoryStream(DraftMailsLoad.img);
                        DraftMailsLoad.AttachmentTXT.Text = Image.FromStream(ms).ToString();
                    }
                }
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
                //MessageBox.Show(ex.Message);
            }
        }

        private void GoBackToDraft()
        {
            DraftMailsLoad.label5.Visible = true;
            DraftMailsLoad.label7.Visible = true;
            DraftMailsLoad.amounttxt.Visible = true;
            DraftMailsLoad.pageLbl.Visible = true;
            DraftMailsLoad.ReadBox.Width = 1;
            DraftMailsLoad.ReadBox.Height = 466;
            DraftMailsLoad.ReadBox.Visible = false;
            DraftMailsLoad.textBox2.Text = String.Empty;
            DraftMailsLoad.textBox3.Text = String.Empty;
            DraftMailsLoad.richTextBox1.Text = String.Empty;
            DraftMailsLoad.AttachmentTXT.Text = String.Empty;
            DraftMailsLoad.img = null;
            DraftMailsLoad.cap = String.Empty;
            DraftMailsLoad.ReadStatus = String.Empty;
        }

        private void SentItemsSearchTypeEng()
        {
            try
            {
                SentItemsSearchType.LoadGrammar(new DictationGrammar());
                SentItemsSearchType.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(SentItemsSearchType_SpeechRecognized);
                SentItemsSearchType.SetInputToDefaultAudioDevice();
            }
            catch (Exception ex)
            {
                //.........
            }
        }

        void SentItemsSearchType_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            switch (searchType_SI)
            {
                case 1:
                    {
                        SentMailsLoad.searchTxt.Text = (e.Result.Text.ToLower()).ToString();
                        TalkBk.SpeakAsync("Keyword entered");
                        break;
                    }
                case 0:
                    {
                        SentItemsSearchType.RecognizeAsyncStop();
                        break;
                    }
            }
        }

        private void SentItemsSearchOperation()
        {
            SentItemsTypeActive.Add(new string[] { "Keyword", "Search", "Readback keyword" });
            GrammarBuilder gb51 = new GrammarBuilder();
            gb51.Append(SentItemsTypeActive);
            Grammar g51 = new Grammar(gb51);
            try
            {
                SentItemsSearchActive.LoadGrammar(g51);
                SentItemsSearchActive.SetInputToDefaultAudioDevice();
                SentItemsSearchActive.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(SentItemsSearchActive_SpeechRecognized);
            }
            catch (Exception ex)
            {
                //............
            }
        }

        void SentItemsSearchActive_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            switch (e.Result.Text.ToString())
            {
                case "Keyword":
                    {
                        searchType_SI = 1;
                        SentItemsSearchType.RecognizeAsync(RecognizeMode.Multiple);
                        lblStatus.Text = " ";
                        lblStatus.Text = "Dictating...!";
                        typeOn = new SoundPlayer("Dictation enable.wav");
                        typeOn.Play();
                        break;
                    }
                case "Search":
                    {
                        searchType_SI = 0;
                        SentItemsSearchActive.RecognizeAsyncStop();
                        SentItemsSearchType.RecognizeAsyncStop();
                        lblStatus.Text = " ";
                        lblStatus.Text = "Searching mail";
                        SentItemsOperation.RecognizeAsync(RecognizeMode.Multiple);
                        SentMailsLoad.Mcount = 0;
                        SentMailsLoadLBLRefresh();
                        SearchSentItemsOperation();
                        TalkBk.SpeakAsync(SentMailsLoad.Mcount + " matching mail found");
                        break;
                    }
                case "Readback keyword":
                    {
                        if (SentMailsLoad.searchTxt.Text != String.Empty)
                        {
                            searchType_SI = 0;
                            SentItemsSearchActive.RecognizeAsyncStop();
                            TalkBk.SpeakAsync(SentMailsLoad.searchTxt.Text);
                        }
                        break;
                    }
            }
        }

        private void SearchSentItemsOperation()
        {
            try
            {
                DataView dv = new DataView(SentData);
                dv.RowFilter = string.Format("To LIKE '%{0}%'", SentMailsLoad.searchTxt.Text);
                dataGridView.DataSource = dv;
                int index = 0;
                DataGridViewRow row = new DataGridViewRow();
                //----------------------------------------------
                row = this.dataGridView.Rows[index];
                SentMailsLoad.lbl1.Text = "To: " + row.Cells["To"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                SentMailsLoad.x1 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index += 1];
                SentMailsLoad.lbl2.Text = "To: " + row.Cells["To"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                SentMailsLoad.x2 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index += 1];
                SentMailsLoad.lbl3.Text = "To: " + row.Cells["To"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                SentMailsLoad.x3 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index += 1];
                SentMailsLoad.lbl4.Text = "To: " + row.Cells["To"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                SentMailsLoad.x4 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index += 1];
                SentMailsLoad.lbl5.Text = "To: " + row.Cells["To"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                SentMailsLoad.x5 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index += 1];
                SentMailsLoad.lbl6.Text = "To: " + row.Cells["To"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                SentMailsLoad.x6 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index += 1];
                SentMailsLoad.lbl7.Text = "To: " + row.Cells["To"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                SentMailsLoad.x7 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index += 1];
                SentMailsLoad.lbl8.Text = "To: " + row.Cells["To"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                SentMailsLoad.x8 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index += 1];
                SentMailsLoad.lbl9.Text = "To: " + row.Cells["To"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                SentMailsLoad.x9 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index += 1];
                SentMailsLoad.lbl10.Text = "To: " + row.Cells["To"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                SentMailsLoad.x10 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index += 1];
                SentMailsLoad.lbl11.Text = "To: " + row.Cells["To"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                SentMailsLoad.x11 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index += 1];
                SentMailsLoad.lbl12.Text = "To: " + row.Cells["To"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                SentMailsLoad.x12 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index += 1];
                SentMailsLoad.lbl13.Text = "To: " + row.Cells["To"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                SentMailsLoad.x13 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index += 1];
                SentMailsLoad.lbl14.Text = "To: " + row.Cells["To"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                SentMailsLoad.x14 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index += 1];
                SentMailsLoad.lbl15.Text = "To: " + row.Cells["To"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                SentMailsLoad.x15 = row.Cells["Serial"].Value.ToString();
                //--------------------------------------------------

            }
            catch (Exception ex)
            {
                //...........................
            }
        }

        private void SentItemsMailOperations()
        {
            operationSentItems.Add(new string[] { "Disable sentitems", "How many mails are there"
                , "Close and go back to sent items", "Readback again", "Open and read first"
                , "Open and read second", "Open and read third", "Open and read fourth"
                , "Open and read fifth", "Open and read sixth", "Open and read seventh"
                , "Open and read eighth", "Open and read ninth", "Open and read tenth"
                , "Open and read eleventh", "Open and read twelfth", "Open and read thirteenth"
                , "Open and read fourteenth", "Open and read fifteenth", "Delete this mail"
                , "Forward this", "Search mail", "Clear search", "Reset notification", "Scroll next", "Scroll back" });
            GrammarBuilder gb41 = new GrammarBuilder();
            gb41.Append(operationSentItems);
            Grammar g41 = new Grammar(gb41);
            try
            {
                SentItemsOperation.LoadGrammar(g41);
                SentItemsOperation.SetInputToDefaultAudioDevice();
                SentItemsOperation.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(SentItemsOperation_SpeechRecognized);
            }
            catch (Exception ex)
            {
                //Error........
            }
        }

        void SentItemsOperation_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (SentMailsLoad.Visible != false)
            {
                switch (e.Result.Text.ToString())
                {
                    case "Disable sentitems":
                        {
                            if (SentMailsLoad.ReadBox.Visible != true)
                            {
                                TalkBk.SpeakAsync("Sent items operation disabled");
                                SentItemsOperation.RecognizeAsyncStop();
                                BtnCmmnd.RecognizeAsync(RecognizeMode.Multiple);
                                lblStatus.Text = " ";
                                lblStatus.Text = "S.I.O disabled";
                            }
                            break;
                        }
                    case "How many mails are there":
                        {
                            TalkBk.SpeakAsync("There are, " + SentMailsLoad.amounttxt.Text + " mails in sent items, page " + SentMailsLoad.pageLbl.Text + " showing " + SentMailsLoad.Mcount + " of " + SentMailsLoad.amounttxt.Text);
                            lblStatus.Text = " ";
                            lblStatus.Text = "Counting total mails";
                            break;
                        }
                    case "Close and go back to sent items":
                        {
                            if (SentMailsLoad.ReadBox.Visible != false)
                            {
                                TalkBk.SpeakAsync("Closed and backed to sent items");
                                GoBackToSentItems();
                            }
                            if (panelSlide.Width == 379 && panelSlide.Height == 428)
                            {
                                panelSlide.Width = 1;
                                panelSlide.Height = 428;
                            }
                            lblStatus.Text = " ";
                            lblStatus.Text = "Closing R.B.";
                            break;
                        }
                    case "Readback again":
                        {
                            if (SentMailsLoad.ReadBox.Visible != false)
                            {
                                TalkBk.SpeakAsync("This mail was sent to " + SentMailsLoad.textBox2.Text + "," + "  on, " + SentMailsLoad.DateTimeLBL.Text + "," + " subject, " + SentMailsLoad.textBox3.Text + "," + "  mail body, " + SentMailsLoad.richTextBox1.Text);
                                if (SentMailsLoad.AttachmentTXT.Text != String.Empty)
                                {
                                    TalkBk.SpeakAsync("There is also an attachment with this mail");
                                }
                                lblStatus.Text = " ";
                                lblStatus.Text = "Initiating readback";
                            }
                            break;
                        }
                    case "Open and read first":
                        {
                            if (SentMailsLoad.ReadBox.Visible != true && SentMailsLoad.lbl1.Text != String.Empty)
                            {
                                TalkBk.SpeakAsync("First mail is opened, initiating readback, ");
                                SentMailsLoad.cap = SentMailsLoad.x1;
                                RunSentItemsSQLOperation();
                                OpenReadBox_SI();
                                TalkBk.SpeakAsync("This mail was sent to " + SentMailsLoad.textBox2.Text + "," + "  on, " + SentMailsLoad.DateTimeLBL.Text + "," + " subject, " + SentMailsLoad.textBox3.Text + "," + "  mail body, " + SentMailsLoad.richTextBox1.Text);
                                if (SentMailsLoad.AttachmentTXT.Text != String.Empty)
                                {
                                    TalkBk.SpeakAsync("There is also an attachment with this mail");
                                }
                                lblStatus.Text = " ";
                                lblStatus.Text = "1st mail opened";
                            }
                            break;
                        }
                    case "Open and read second":
                        {
                            if (SentMailsLoad.ReadBox.Visible != true && SentMailsLoad.lbl2.Text != String.Empty)
                            {
                                TalkBk.SpeakAsync("Second mail is opened, initiating readback, ");
                                SentMailsLoad.cap = SentMailsLoad.x2;
                                RunSentItemsSQLOperation();
                                OpenReadBox_SI();
                                TalkBk.SpeakAsync("This mail was sent to " + SentMailsLoad.textBox2.Text + "," + "  on, " + SentMailsLoad.DateTimeLBL.Text + "," + " subject, " + SentMailsLoad.textBox3.Text + "," + "  mail body, " + SentMailsLoad.richTextBox1.Text);
                                if (SentMailsLoad.AttachmentTXT.Text != String.Empty)
                                {
                                    TalkBk.SpeakAsync("There is also an attachment with this mail");
                                }
                                lblStatus.Text = " ";
                                lblStatus.Text = "2nd mail opened";
                            }
                            break;
                        }
                    case "Open and read third":
                        {
                            if (SentMailsLoad.ReadBox.Visible != true && SentMailsLoad.lbl3.Text != String.Empty)
                            {
                                TalkBk.SpeakAsync("Third mail is opened, initiating readback, ");
                                SentMailsLoad.cap = SentMailsLoad.x3;   
                                RunSentItemsSQLOperation();
                                OpenReadBox_SI();
                                TalkBk.SpeakAsync("This mail was sent to " + SentMailsLoad.textBox2.Text + "," + "  on, " + SentMailsLoad.DateTimeLBL.Text + "," + " subject, " + SentMailsLoad.textBox3.Text + "," + "  mail body, " + SentMailsLoad.richTextBox1.Text);
                                if (SentMailsLoad.AttachmentTXT.Text != String.Empty)
                                {
                                    TalkBk.SpeakAsync("There is also an attachment with this mail");
                                }
                                lblStatus.Text = " ";
                                lblStatus.Text = "3rd mail opened";
                            }
                            break;
                        }
                    case "Open and read fourth":
                        {
                            if (SentMailsLoad.ReadBox.Visible != true && SentMailsLoad.lbl4.Text != String.Empty)
                            {
                                TalkBk.SpeakAsync("Fourth mail is opened, initiating readback, ");
                                SentMailsLoad.cap = SentMailsLoad.x4;
                                RunSentItemsSQLOperation();
                                OpenReadBox_SI();
                                TalkBk.SpeakAsync("This mail was sent to " + SentMailsLoad.textBox2.Text + "," + "  on, " + SentMailsLoad.DateTimeLBL.Text + "," + " subject, " + SentMailsLoad.textBox3.Text + "," + "  mail body, " + SentMailsLoad.richTextBox1.Text);
                                if (SentMailsLoad.AttachmentTXT.Text != String.Empty)
                                {
                                    TalkBk.SpeakAsync("There is also an attachment with this mail");
                                }
                                lblStatus.Text = " ";
                                lblStatus.Text = "4th mail opened";
                            }
                            break;
                        }
                    case "Open and read fifth":
                        {
                            if (SentMailsLoad.ReadBox.Visible != true && SentMailsLoad.lbl5.Text != String.Empty)
                            {
                                TalkBk.SpeakAsync("Fifth mail is opened, initiating readback, ");
                                SentMailsLoad.cap = SentMailsLoad.x5;
                                RunSentItemsSQLOperation();
                                OpenReadBox_SI();
                                TalkBk.SpeakAsync("This mail was sent to " + SentMailsLoad.textBox2.Text + "," + "  on, " + SentMailsLoad.DateTimeLBL.Text + "," + " subject, " + SentMailsLoad.textBox3.Text + "," + "  mail body, " + SentMailsLoad.richTextBox1.Text);
                                if (SentMailsLoad.AttachmentTXT.Text != String.Empty)
                                {
                                    TalkBk.SpeakAsync("There is also an attachment with this mail");
                                }
                                lblStatus.Text = " ";
                                lblStatus.Text = "5th mail opened";
                            }
                            break;
                        }
                    case "Open and read sixth":
                        {
                            if (SentMailsLoad.ReadBox.Visible != true && SentMailsLoad.lbl6.Text != String.Empty)
                            {
                                TalkBk.SpeakAsync("Sixth mail is opened, initiating readback, ");
                                SentMailsLoad.cap = SentMailsLoad.x6;
                                RunSentItemsSQLOperation();
                                OpenReadBox_SI();
                                TalkBk.SpeakAsync("This mail was sent to " + SentMailsLoad.textBox2.Text + "," + "  on, " + SentMailsLoad.DateTimeLBL.Text + "," + " subject, " + SentMailsLoad.textBox3.Text + "," + "  mail body, " + SentMailsLoad.richTextBox1.Text);
                                if (SentMailsLoad.AttachmentTXT.Text != String.Empty)
                                {
                                    TalkBk.SpeakAsync("There is also an attachment with this mail");
                                }
                                lblStatus.Text = " ";
                                lblStatus.Text = "6th mail opened";
                            }
                            break;
                        }
                    case "Open and read seventh":
                        {
                            if (SentMailsLoad.ReadBox.Visible != true && SentMailsLoad.lbl7.Text != String.Empty)
                            {
                                TalkBk.SpeakAsync("Seventh mail is opened, initiating readback, ");
                                SentMailsLoad.cap = SentMailsLoad.x7;
                                RunSentItemsSQLOperation();
                                OpenReadBox_SI();
                                TalkBk.SpeakAsync("This mail was sent to " + SentMailsLoad.textBox2.Text + "," + "  on, " + SentMailsLoad.DateTimeLBL.Text + "," + " subject, " + SentMailsLoad.textBox3.Text + "," + "  mail body, " + SentMailsLoad.richTextBox1.Text);
                                if (SentMailsLoad.AttachmentTXT.Text != String.Empty)
                                {
                                    TalkBk.SpeakAsync("There is also an attachment with this mail");
                                }
                                lblStatus.Text = " ";
                                lblStatus.Text = "7th mail opened";
                            }
                            break;
                        }
                    case "Open and read eighth":
                        {
                            if (SentMailsLoad.ReadBox.Visible != true && SentMailsLoad.lbl8.Text != String.Empty)
                            {
                                TalkBk.SpeakAsync("Eighth mail is opened, initiating readback, ");
                                SentMailsLoad.cap = SentMailsLoad.x8;
                                RunSentItemsSQLOperation();
                                OpenReadBox_SI();
                                TalkBk.SpeakAsync("This mail was sent to " + SentMailsLoad.textBox2.Text + "," + "  on, " + SentMailsLoad.DateTimeLBL.Text + "," + " subject, " + SentMailsLoad.textBox3.Text + "," + "  mail body, " + SentMailsLoad.richTextBox1.Text);
                                if (SentMailsLoad.AttachmentTXT.Text != String.Empty)
                                {
                                    TalkBk.SpeakAsync("There is also an attachment with this mail");
                                }
                                lblStatus.Text = " ";
                                lblStatus.Text = "8th mail opened";
                            }
                            break;
                        }
                    case "Open and read ninth":
                        {
                            if (SentMailsLoad.ReadBox.Visible != true && SentMailsLoad.lbl9.Text != String.Empty)
                            {
                                TalkBk.SpeakAsync("Ninth mail is opened, initiating readback, ");
                                SentMailsLoad.cap = SentMailsLoad.x9;
                                RunSentItemsSQLOperation();
                                OpenReadBox_SI();
                                TalkBk.SpeakAsync("This mail was sent to " + SentMailsLoad.textBox2.Text + "," + "  on, " + SentMailsLoad.DateTimeLBL.Text + "," + " subject, " + SentMailsLoad.textBox3.Text + "," + "  mail body, " + SentMailsLoad.richTextBox1.Text);
                                if (SentMailsLoad.AttachmentTXT.Text != String.Empty)
                                {
                                    TalkBk.SpeakAsync("There is also an attachment with this mail");
                                }
                                lblStatus.Text = " ";
                                lblStatus.Text = "9th mail opened";
                            }
                            break;
                        }
                    case "Open and read tenth":
                        {
                            if (SentMailsLoad.ReadBox.Visible != true && SentMailsLoad.lbl10.Text != String.Empty)
                            {
                                TalkBk.SpeakAsync("Tenth mail is opened, initiating readback, ");
                                SentMailsLoad.cap = SentMailsLoad.x10;
                                RunSentItemsSQLOperation();
                                OpenReadBox_SI();
                                TalkBk.SpeakAsync("This mail was sent to " + SentMailsLoad.textBox2.Text + "," + "  on, " + SentMailsLoad.DateTimeLBL.Text + "," + " subject, " + SentMailsLoad.textBox3.Text + "," + "  mail body, " + SentMailsLoad.richTextBox1.Text);
                                if (SentMailsLoad.AttachmentTXT.Text != String.Empty)
                                {
                                    TalkBk.SpeakAsync("There is also an attachment with this mail");
                                }
                                lblStatus.Text = " ";
                                lblStatus.Text = "10th mail opened";
                            }
                            break;
                        }
                    case "Open and read eleventh":
                        {
                            if (SentMailsLoad.ReadBox.Visible != true && SentMailsLoad.lbl11.Text != String.Empty)
                            {
                                TalkBk.SpeakAsync("Eleventh mail is opened, initiating readback, ");
                                SentMailsLoad.cap = SentMailsLoad.x1;
                                RunSentItemsSQLOperation();
                                OpenReadBox_SI();
                                TalkBk.SpeakAsync("This mail was sent to " + SentMailsLoad.textBox2.Text + "," + "  on, " + SentMailsLoad.DateTimeLBL.Text + "," + " subject, " + SentMailsLoad.textBox3.Text + "," + "  mail body, " + SentMailsLoad.richTextBox1.Text);
                                if (SentMailsLoad.AttachmentTXT.Text != String.Empty)
                                {
                                    TalkBk.SpeakAsync("There is also an attachment with this mail");
                                }
                                lblStatus.Text = " ";
                                lblStatus.Text = "11th mail opened";
                            }
                            break;
                        }
                    case "Open and read twelfth":
                        {
                            if (SentMailsLoad.ReadBox.Visible != true && SentMailsLoad.lbl12.Text != String.Empty)
                            {
                                TalkBk.SpeakAsync("Twelfth mail is opened, initiating readback, ");
                                SentMailsLoad.cap = SentMailsLoad.x12;
                                RunSentItemsSQLOperation();
                                OpenReadBox_SI();
                                TalkBk.SpeakAsync("This mail was sent to " + SentMailsLoad.textBox2.Text + "," + "  on, " + SentMailsLoad.DateTimeLBL.Text + "," + " subject, " + SentMailsLoad.textBox3.Text + "," + "  mail body, " + SentMailsLoad.richTextBox1.Text);
                                if (SentMailsLoad.AttachmentTXT.Text != String.Empty)
                                {
                                    TalkBk.SpeakAsync("There is also an attachment with this mail");
                                }
                                lblStatus.Text = " ";
                                lblStatus.Text = "12th mail opened";
                            }
                            break;
                        }
                    case "Open and read thirteenth":
                        {
                            if (SentMailsLoad.ReadBox.Visible != true && SentMailsLoad.lbl13.Text != String.Empty)
                            {
                                TalkBk.SpeakAsync("Thirteenth mail is opened, initiating readback, ");
                                SentMailsLoad.cap = SentMailsLoad.x13;
                                RunSentItemsSQLOperation();
                                OpenReadBox_SI();
                                TalkBk.SpeakAsync("This mail was sent to " + SentMailsLoad.textBox2.Text + "," + "  on, " + SentMailsLoad.DateTimeLBL.Text + "," + " subject, " + SentMailsLoad.textBox3.Text + "," + "  mail body, " + SentMailsLoad.richTextBox1.Text);
                                if (SentMailsLoad.AttachmentTXT.Text != String.Empty)
                                {
                                    TalkBk.SpeakAsync("There is also an attachment with this mail");
                                }
                                lblStatus.Text = " ";
                                lblStatus.Text = "13th mail opened";
                            }
                            break;
                        }
                    case "Open and read fourteenth":
                        {
                            if (SentMailsLoad.ReadBox.Visible != true && SentMailsLoad.lbl14.Text != String.Empty)
                            {
                                TalkBk.SpeakAsync("Fourteenth mail is opened, initiating readback, ");
                                SentMailsLoad.cap = SentMailsLoad.x14;
                                RunSentItemsSQLOperation();
                                OpenReadBox_SI();
                                TalkBk.SpeakAsync("This mail was sent to " + SentMailsLoad.textBox2.Text + "," + "  on, " + SentMailsLoad.DateTimeLBL.Text + "," + " subject, " + SentMailsLoad.textBox3.Text + "," + "  mail body, " + SentMailsLoad.richTextBox1.Text);
                                if (SentMailsLoad.AttachmentTXT.Text != String.Empty)
                                {
                                    TalkBk.SpeakAsync("There is also an attachment with this mail");
                                }
                                lblStatus.Text = " ";
                                lblStatus.Text = "14th mail opened";
                            }
                            break;
                        }
                    case "Open and read fifteenth":
                        {
                            if (SentMailsLoad.ReadBox.Visible != true && SentMailsLoad.lbl5.Text != String.Empty)
                            {
                                TalkBk.SpeakAsync("Fifteenth mail is opened, initiating readback, ");
                                SentMailsLoad.cap = SentMailsLoad.x15;
                                RunSentItemsSQLOperation();
                                OpenReadBox_SI();
                                TalkBk.SpeakAsync("This mail was sent to " + SentMailsLoad.textBox2.Text + "," + "  on, " + SentMailsLoad.DateTimeLBL.Text + "," + " subject, " + SentMailsLoad.textBox3.Text + "," + "  mail body, " + SentMailsLoad.richTextBox1.Text);
                                if (SentMailsLoad.AttachmentTXT.Text != String.Empty)
                                {
                                    TalkBk.SpeakAsync("There is also an attachment with this mail");
                                }
                                lblStatus.Text = " ";
                                lblStatus.Text = "15th mail opened";
                            }
                            break;
                        }
                    case "Delete this mail":
                        {
                            if (SentMailsLoad.ReadBox.Visible != false)
                            {
                                //TalkBk.Pause();
                                SentMailsLoadMailDelete();
                                SentMailsLoadLBLRefresh();
                                CountUserMail_SM();
                                sentItemsMails();
                                SentMailsLoad.page = 1;
                                SentMailsLoad.pageLbl.Text = SentMailsLoad.page.ToString();
                                GoBackToSentItems();
                                if (confAct == 1)
                                {
                                    TalkBk.SpeakAsync("Mail has been deleted");
                                }
                                else if (confAct == 0)
                                {
                                    TalkBk.SpeakAsync("Operation canceled");
                                }
                                lblStatus.Text = " ";
                                lblStatus.Text = "Mail deleting";
                            }
                            break;
                        }
                    case "Forward this":
                        {
                            if (SentMailsLoad.ReadBox.Visible != false)
                            {
                                SentItemsMailForward();
                                uniqPermission3 = 11;
                                SentItemsOperation.RecognizeAsyncStop();
                                selectionENG1.RecognizeAsync(RecognizeMode.Multiple);
                                TalkBk.SpeakAsync("Compose box opened and subject, mail body, attachment has been inserted, insert mail address");
                                lblStatus.Text = " ";
                                lblStatus.Text = "Forward initiating";
                            }
                            break;
                        }
                    case "Search mail":
                        {
                            TalkBk.SpeakAsync("Keyword necessary");
                            SentItemsOperation.RecognizeAsyncStop();
                            SentItemsSearchActive.RecognizeAsync(RecognizeMode.Multiple);
                            lblStatus.Text = " ";
                            lblStatus.Text = "Search initiating";
                            break;
                        }
                    case "Clear search":
                        {
                            SentMailsLoad.searchTxt.Text = String.Empty;
                            TalkBk.SpeakAsync("Search cleared");
                            lblStatus.Text = " ";
                            lblStatus.Text = "Clearing....";
                            break;
                        }
                    case "Reset notification":
                        {
                            if (notificationLbl.Visible == true)
                            {
                                CmndInbox();
                                UsrNotifictn.BackgroundImage = Properties.Resources._003_notification;
                                notificationLbl.Visible = false;
                                ResetMailCount();
                                NotifyUser.Start();
                                TalkBk.SpeakAsync("Notification reset");
                                lblStatus.Text = " ";
                                lblStatus.Text = "Resetting";
                            }
                            break;
                        }
                    case "Scroll next":
                        {
                            if (SentMailsLoad.lbl15.Text != String.Empty)
                            {
                                SentMailsLoad.Mcount = 0;
                                SentMailsLoad.page = SentMailsLoad.page + 1;
                                SentMailsLoad.pageLbl.Text = SentMailsLoad.page.ToString();
                                SentMailsLoadLBLRefresh();
                                sntm = sntm - 15;
                                sentItemsMails();
                                TalkBk.SpeakAsync("Page " + SentMailsLoad.pageLbl.Text + " is showing");
                            }
                            else
                            {
                                TalkBk.SpeakAsync("Can not scroll to next, page limit reached");
                            }
                            break;
                        }
                    case "Scroll back":
                        {
                            if (SentMailsLoad.pageLbl.Text != "1")
                            {
                                SentMailsLoad.Mcount = 0;
                                SentMailsLoad.page = SentMailsLoad.page - 1;
                                SentMailsLoad.pageLbl.Text = SentMailsLoad.page.ToString();
                                SentMailsLoadLBLRefresh();
                                sntm = sntm + 15;
                                sentItemsMails();
                                TalkBk.SpeakAsync("Page " + SentMailsLoad.pageLbl.Text + " is showing");
                            }
                            else
                            {
                                TalkBk.SpeakAsync("Can not scroll back, page limit reached");
                            }
                            break;
                        }
                }
            }
        }

        private void SentItemsMailForward()
        {
            if (SentMailsLoad.cap != null)
            {
                try
                {
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }
                    cmd.Connection = con;
                    cmd.CommandText = "Select Subject,Body,Attachment From SentItems where Serial='" + SentMailsLoad.cap + "'";
                    cmd.ExecuteNonQuery();
                    cmd.Clone();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        SentMailsLoad.F_Subject = sdr[0].ToString();
                        SentMailsLoad.F_Body = sdr[1].ToString();
                        SentMailsLoad.F_Attachment = sdr[2].ToString();
                    }
                    if (panelSlide.Width == 1 && panelSlide.Height == 428)
                    {
                        panelSlide.Width = 379;
                        panelSlide.Height = 428;
                        subjectTxt.Text = SentMailsLoad.F_Subject;
                        attachTxt.Text = SentMailsLoad.F_Attachment;
                        bodyTxt.Text = SentMailsLoad.F_Body;
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    con.Close();
                    //MessageBox.Show(ex.Message);
                }
            }
        }

        private void SentMailsLoadLBLRefresh()
        {
            SentMailsLoad.lbl1.Text = String.Empty;
            SentMailsLoad.lbl2.Text = String.Empty;
            SentMailsLoad.lbl3.Text = String.Empty;
            SentMailsLoad.lbl4.Text = String.Empty;
            SentMailsLoad.lbl5.Text = String.Empty;
            SentMailsLoad.lbl6.Text = String.Empty;
            SentMailsLoad.lbl7.Text = String.Empty;
            SentMailsLoad.lbl8.Text = String.Empty;
            SentMailsLoad.lbl9.Text = String.Empty;
            SentMailsLoad.lbl10.Text = String.Empty;
            SentMailsLoad.lbl11.Text = String.Empty;
            SentMailsLoad.lbl12.Text = String.Empty;
            SentMailsLoad.lbl13.Text = String.Empty;
            SentMailsLoad.lbl14.Text = String.Empty;
            SentMailsLoad.lbl15.Text = String.Empty;
        }

        private void SentMailsLoadMailDelete()
        {
            confMsg = new SoundPlayer("Notify.wav");
            confMsg.Play();
            cf = new Confirmation();
            TalkBk.SpeakAsync("Are you really want to delete this mail?");
            confirmEng.RecognizeAsync(RecognizeMode.Multiple);
            cf.ShowDialog();
            if (confAct == 1)
            {
                confirmEng.RecognizeAsyncStop();
                SentMailsLoad.Mcount = 0;
                if (SentMailsLoad.cap != null)
                {
                    try
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }
                        cmd.Connection = con;
                        cmd.CommandText = "Delete SentItems where Serial='" + SentMailsLoad.cap + "'";
                        cmd.ExecuteNonQuery();
                        cmd.Clone();
                        con.Close();
                    }
                    catch (Exception ex)
                    {
                        con.Close();
                        //MessageBox.Show(ex.Message);
                    }
                }
            }
            else if (confAct == 0)
            {
                try
                {
                    confirmEng.RecognizeAsyncStop();
                    SentMailsLoad.cap = null;
                }
                catch (Exception ex)
                {
                    //error......
                }
            }
        }

        private void OpenReadBox_SI()
        {
            SentMailsLoad.label5.Visible = false;
            SentMailsLoad.label7.Visible = false;
            SentMailsLoad.amounttxt.Visible = false;
            SentMailsLoad.pageLbl.Visible = false;
            SentMailsLoad.ReadBox.Width = 627;
            SentMailsLoad.ReadBox.Height = 473;
            SentMailsLoad.ReadBox.Visible = true;
        }

        private void RunSentItemsSQLOperation()
        {
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                cmd.Connection = con;
                cmd.CommandText = "Select [To],Subject,Body,TimeDate,Attachment From SentItems where [From]='" + currentUser + "' and Serial='" + SentMailsLoad.cap + "'";
                cmd.ExecuteNonQuery();
                cmd.Clone();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    SentMailsLoad.textBox2.Text = sdr[0].ToString();
                    SentMailsLoad.textBox3.Text = sdr[1].ToString();
                    SentMailsLoad.richTextBox1.Text = sdr[2].ToString();
                    SentMailsLoad.DateTimeLBL.Text = sdr[3].ToString();
                    SentMailsLoad.img = (byte[])(sdr[4]);
                    if (SentMailsLoad.img == null)
                    {
                        SentMailsLoad.AttachmentTXT.Text = "";
                    }
                    else
                    {
                        MemoryStream ms = new MemoryStream(SentMailsLoad.img);
                        SentMailsLoad.AttachmentTXT.Text = Image.FromStream(ms).ToString();
                    }
                }
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
                //MessageBox.Show(ex.Message);
            }
        }

        private void GoBackToSentItems()
        {
            SentMailsLoad.label5.Visible = true;
            SentMailsLoad.label7.Visible = true;
            SentMailsLoad.amounttxt.Visible = true;
            SentMailsLoad.pageLbl.Visible = true;
            SentMailsLoad.ReadBox.Width = 1;
            SentMailsLoad.ReadBox.Height = 466;
            SentMailsLoad.ReadBox.Visible = false;
            SentMailsLoad.textBox2.Text = String.Empty;
            SentMailsLoad.textBox3.Text = String.Empty;
            SentMailsLoad.richTextBox1.Text = String.Empty;
            SentMailsLoad.AttachmentTXT.Text = String.Empty;
            SentMailsLoad.img = null;
            SentMailsLoad.cap = String.Empty;
            SentMailsLoad.ReadStatus = String.Empty;
        }

        private void InboxSearchTypeEng()
        {
            try
            {
                InboxSearchType.LoadGrammar(new DictationGrammar());
                InboxSearchType.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(InboxSearchType_SpeechRecognized);
                InboxSearchType.SetInputToDefaultAudioDevice();
            }
            catch (Exception ex)
            {
                //.........
            }
        }

        void InboxSearchType_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            switch (searchType)
            {
                case 1:
                    {
                        InboxMailLoad.searchTxt.Text = (e.Result.Text.ToLower()).ToString();
                        TalkBk.SpeakAsync("Keyword entered");
                        break;
                    }
                case 0:
                    {
                        InboxSearchType.RecognizeAsyncStop();
                        break;
                    }
            }
        }

        private void InboxSearchOperation()
        {
            InboxTypeActive.Add(new string[] { "Keyword", "Search", "Readback keyword" });
            GrammarBuilder gb50 = new GrammarBuilder();
            gb50.Append(InboxTypeActive);
            Grammar g50 = new Grammar(gb50);
            try
            {
                InboxSearchActive.LoadGrammar(g50);
                InboxSearchActive.SetInputToDefaultAudioDevice();
                InboxSearchActive.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(InboxSearchActive_SpeechRecognized);
            }
            catch (Exception ex)
            {
                //............
            }
        }

        void InboxSearchActive_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            switch (e.Result.Text.ToString())
            {
                case "Keyword":
                    {
                        searchType = 1;
                        InboxSearchType.RecognizeAsync(RecognizeMode.Multiple);
                        lblStatus.Text = " ";
                        lblStatus.Text = "Dictating...!";
                        typeOn = new SoundPlayer("Dictation enable.wav");
                        typeOn.Play();
                        break;
                    }
                case "Search":
                    {
                        searchType = 0;
                        InboxSearchActive.RecognizeAsyncStop();
                        InboxSearchType.RecognizeAsyncStop();
                        lblStatus.Text = " ";
                        lblStatus.Text = "Searching mail";
                        InboxOperation.RecognizeAsync(RecognizeMode.Multiple);
                        InboxMailLoad.Mcount = 0;
                        InboxLBLRefresh();
                        SearchInboxOperation();
                        TalkBk.SpeakAsync(InboxMailLoad.Mcount+" matching mail found");
                        break;
                    }
                case "Readback keyword":
                    {
                        if (InboxMailLoad.searchTxt.Text != String.Empty)
                        {
                            searchType = 0;
                            InboxSearchType.RecognizeAsyncStop();
                            TalkBk.SpeakAsync(InboxMailLoad.searchTxt.Text);
                        }
                        break;
                    }
            }
        }

        private void SearchInboxOperation()
        {
            CheckInboxTm.Stop();
            try
            {
                DataView dv = new DataView(InboxData);
                dv.RowFilter = string.Format("From LIKE '%{0}%'", InboxMailLoad.searchTxt.Text);
                dataGridView.DataSource = dv;
                int index = 0;
                DataGridViewRow row = new DataGridViewRow();
                //----------------------------------------------
                row = this.dataGridView.Rows[index];
                InboxMailLoad.lbl1.Text = "From: " + row.Cells["From"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                InboxMailLoad.x1 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index += 1];
                InboxMailLoad.lbl2.Text = "From: " + row.Cells["From"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                InboxMailLoad.x2 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index += 1];
                InboxMailLoad.lbl3.Text = "From: " + row.Cells["From"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                InboxMailLoad.x3 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index += 1];
                InboxMailLoad.lbl4.Text = "From: " + row.Cells["From"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                InboxMailLoad.x4 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index += 1];
                InboxMailLoad.lbl5.Text = "From: " + row.Cells["From"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                InboxMailLoad.x5 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index += 1];
                InboxMailLoad.lbl6.Text = "From: " + row.Cells["From"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                InboxMailLoad.x6 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index += 1];
                InboxMailLoad.lbl7.Text = "From: " + row.Cells["From"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                InboxMailLoad.x7 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index += 1];
                InboxMailLoad.lbl8.Text = "From: " + row.Cells["From"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                InboxMailLoad.x8 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index += 1];
                InboxMailLoad.lbl9.Text = "From: " + row.Cells["From"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                InboxMailLoad.x9 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index += 1];
                InboxMailLoad.lbl10.Text = "From: " + row.Cells["From"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                InboxMailLoad.x10 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index += 1];
                InboxMailLoad.lbl11.Text = "From: " + row.Cells["From"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                InboxMailLoad.x11 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index += 1];
                InboxMailLoad.lbl12.Text = "From: " + row.Cells["From"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                InboxMailLoad.x12 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index += 1];
                InboxMailLoad.lbl13.Text = "From: " + row.Cells["From"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                InboxMailLoad.x13 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index += 1];
                InboxMailLoad.lbl14.Text = "From: " + row.Cells["From"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                InboxMailLoad.x14 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index += 1];
                InboxMailLoad.lbl15.Text = "From: " + row.Cells["From"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                InboxMailLoad.x15 = row.Cells["Serial"].Value.ToString();
                //--------------------------------------------------
            }
            catch (Exception ex)
            {
                //
            }
        }

        private void InboxMailOperations()
        {
            operationInbox.Add(new string[] { "Disable inbox", "How many mails are there"
                , "Close and go back to inbox", "Readback again", "Open and read first"
                , "Open and read second", "Open and read third", "Open and read fourth"
                , "Open and read fifth", "Open and read sixth", "Open and read seventh"
                , "Open and read eighth", "Open and read ninth", "Open and read tenth"
                , "Open and read eleventh", "Open and read twelfth", "Open and read thirteenth"
                , "Open and read fourteenth", "Open and read fifteenth", "Delete this mail"
                , "Reply to tihs", "Forward this", "How many unread mails are there", "Search mail"
                , "Clear search", "Reset notification", "Select unread mails", "Deselect unread mails"
                , "Scroll next", "Scroll back" });
            GrammarBuilder gb40 = new GrammarBuilder();
            gb40.Append(operationInbox);
            Grammar g40 = new Grammar(gb40);
            try
            {
                InboxOperation.LoadGrammar(g40);
                InboxOperation.SetInputToDefaultAudioDevice();
                InboxOperation.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(InboxOperation_SpeechRecognized);
            }
            catch (Exception ex)
            {
                //Error........
            }
            
        }

        private void OpenReadBox()
        {
            InboxMailLoad.label5.Visible = false;
            InboxMailLoad.label7.Visible = false;
            InboxMailLoad.amounttxt.Visible = false;
            InboxMailLoad.pageLbl.Visible = false;
            InboxMailLoad.ReadBox.Width = 627;
            InboxMailLoad.ReadBox.Height = 473;
            InboxMailLoad.ReadBox.Visible = true;
           
        }

        private void GoBacktoInbox()
        {
            InboxMailLoad.label5.Visible = true;
            InboxMailLoad.label7.Visible = true;
            InboxMailLoad.amounttxt.Visible = true;
            InboxMailLoad.pageLbl.Visible = true;
            InboxMailLoad.ReadBox.Width = 1;
            InboxMailLoad.ReadBox.Height = 466;
            InboxMailLoad.ReadBox.Visible = false;
            InboxMailLoad.textBox2.Text = String.Empty;
            InboxMailLoad.textBox3.Text = String.Empty;
            InboxMailLoad.richTextBox1.Text = String.Empty;
            InboxMailLoad.AttachmentTXT.Text = String.Empty;
            InboxMailLoad.img = null;
            InboxMailLoad.cap = String.Empty;
            InboxMailLoad.ReadStatus = String.Empty;
        }

        private void ChangeReadStatus()
        {
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                cmd.Connection = con;
                cmd.CommandText = "update Inbox set ReadStatus='" + InboxMailLoad.ReadStatus + "' where [To]='" + currentUser + "' and Serial='" + InboxMailLoad.cap + "'";
                cmd.ExecuteNonQuery();
                cmd.Clone();
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
            }
        }

        private void RunInboxSQLOperation()
        {
 
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                cmd.Connection = con;
                cmd.CommandText = "Select [From],Subject,Body,TimeDate,Attachment From Inbox where [To]='" + currentUser + "' and Serial='" + InboxMailLoad.cap + "'";
                cmd.ExecuteNonQuery();
                cmd.Clone();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    InboxMailLoad.textBox2.Text = sdr[0].ToString();
                    InboxMailLoad.textBox3.Text = sdr[1].ToString();
                    InboxMailLoad.richTextBox1.Text = sdr[2].ToString();
                    InboxMailLoad.DateTimeLBL.Text = sdr[3].ToString();
                    InboxMailLoad.img = (byte[])(sdr[4]);
                    if (InboxMailLoad.img == null)
                    {
                        InboxMailLoad.AttachmentTXT.Text = "";
                    }
                    else
                    {
                        MemoryStream ms = new MemoryStream(InboxMailLoad.img);
                        InboxMailLoad.AttachmentTXT.Text = Image.FromStream(ms).ToString();
                    }
                }
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
                //MessageBox.Show(ex.Message);
            }
        }

        void InboxOperation_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (InboxMailLoad.Visible != false)
            {
                switch (e.Result.Text.ToString())
                {
                    case "Disable inbox":
                        {
                            if (InboxMailLoad.ReadBox.Visible != true)
                            {
                                TalkBk.SpeakAsync("Inbox operation disabled");
                                InboxOperation.RecognizeAsyncStop();
                                BtnCmmnd.RecognizeAsync(RecognizeMode.Multiple);
                                lblStatus.Text = " ";
                                lblStatus.Text = "I.O disabled";
                            }
                            break;
                        }
                    case "How many mails are there":
                        {
                            TalkBk.SpeakAsync("There are, " + InboxMailLoad.amounttxt.Text + " mails in inbox, page " + InboxMailLoad.pageLbl.Text + " showing " + InboxMailLoad.Mcount + " of " + InboxMailLoad.amounttxt.Text);
                            lblStatus.Text = " ";
                            lblStatus.Text = "Counting total mails";
                            break;
                        }
                    case "Close and go back to inbox":
                        {
                            if (InboxMailLoad.ReadBox.Visible != false)
                            {
                                TalkBk.SpeakAsync("Closed and backed to inbox");
                                GoBacktoInbox();
                            }
                            if (panelSlide.Width == 379 && panelSlide.Height == 428)
                            {
                                panelSlide.Width = 1;
                                panelSlide.Height = 428;
                            }
                            lblStatus.Text = " ";
                            lblStatus.Text = "Closing R.B.";
                            break;
                        }
                    case "Readback again":
                        {
                            if (InboxMailLoad.ReadBox.Visible != false)
                            {
                                TalkBk.SpeakAsync("This mail is sent by, " + InboxMailLoad.textBox2.Text + "," + "  on, " + InboxMailLoad.DateTimeLBL.Text + "," + " subject, " + InboxMailLoad.textBox3.Text + "," + "  mail body, " + InboxMailLoad.richTextBox1.Text);
                                if (InboxMailLoad.AttachmentTXT.Text != String.Empty)
                                {
                                    TalkBk.SpeakAsync("There is also an attachment with this mail");
                                }
                                lblStatus.Text = " ";
                                lblStatus.Text = "Initiating readback";
                            }
                            break;
                        }
                    case "Open and read first":
                        {
                            if (InboxMailLoad.ReadBox.Visible != true && InboxMailLoad.lbl1.Text != String.Empty)
                            {
                                TalkBk.SpeakAsync("First mail is opened, initiating readback, ");
                                InboxMailLoad.cap = InboxMailLoad.x1;
                                InboxMailLoad.rd1 = "1";
                                InboxMailLoad.ReadStatus = InboxMailLoad.rd1;
                                InboxMailLoad.lbl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))); 
                                RunInboxSQLOperation();
                                OpenReadBox();
                                ChangeReadStatus();
                                TalkBk.SpeakAsync("This mail is sent by, " + InboxMailLoad.textBox2.Text + "," + "  on, " + InboxMailLoad.DateTimeLBL.Text + "," + " subject, " + InboxMailLoad.textBox3.Text + "," + "  mail body, " + InboxMailLoad.richTextBox1.Text);
                                if (InboxMailLoad.AttachmentTXT.Text != String.Empty)
                                {
                                    TalkBk.SpeakAsync("There is also an attachment with this mail");
                                }
                                lblStatus.Text = " ";
                                lblStatus.Text = "1st mail opened";
                            }
                            break;
                        }
                    case "Open and read second":
                        {
                            if (InboxMailLoad.ReadBox.Visible != true && InboxMailLoad.lbl2.Text != String.Empty)
                            {
                                TalkBk.SpeakAsync("Second mail is opened, initiating readback, ");
                                InboxMailLoad.cap = InboxMailLoad.x2;
                                InboxMailLoad.rd2 = "1";
                                InboxMailLoad.ReadStatus = InboxMailLoad.rd2;
                                InboxMailLoad.lbl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                                RunInboxSQLOperation();
                                OpenReadBox();
                                ChangeReadStatus();
                                TalkBk.SpeakAsync("This mail is sent by, " + InboxMailLoad.textBox2.Text + "," + "  on, " + InboxMailLoad.DateTimeLBL.Text + "," + " subject, " + InboxMailLoad.textBox3.Text + "," + "  mail body, " + InboxMailLoad.richTextBox1.Text);
                                if (InboxMailLoad.AttachmentTXT.Text != String.Empty)
                                {
                                    TalkBk.SpeakAsync("There is also an attachment with this mail");
                                }
                                lblStatus.Text = " ";
                                lblStatus.Text = "2nd mail opened";
                            }
                            break;
                        }
                    case "Open and read third":
                        {
                            if (InboxMailLoad.ReadBox.Visible != true && InboxMailLoad.lbl3.Text != String.Empty)
                            {
                                TalkBk.SpeakAsync("Third mail is opened, initiating readback, ");
                                InboxMailLoad.cap = InboxMailLoad.x3;
                                InboxMailLoad.rd3 = "1";
                                InboxMailLoad.ReadStatus = InboxMailLoad.rd3;
                                InboxMailLoad.lbl3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                                RunInboxSQLOperation();
                                OpenReadBox();
                                ChangeReadStatus();
                                TalkBk.SpeakAsync("This mail is sent by, " + InboxMailLoad.textBox2.Text + "," + "  on, " + InboxMailLoad.DateTimeLBL.Text + "," + " subject, " + InboxMailLoad.textBox3.Text + "," + "  mail body, " + InboxMailLoad.richTextBox1.Text);
                                if (InboxMailLoad.AttachmentTXT.Text != String.Empty)
                                {
                                    TalkBk.SpeakAsync("There is also an attachment with this mail");
                                }
                                lblStatus.Text = " ";
                                lblStatus.Text = "3rd mail opened";
                            }
                            break;
                        }
                    case "Open and read fourth":
                        {
                            if (InboxMailLoad.ReadBox.Visible != true && InboxMailLoad.lbl4.Text != String.Empty)
                            {
                                TalkBk.SpeakAsync("Fourth mail is opened, initiating readback, ");
                                InboxMailLoad.cap = InboxMailLoad.x4;
                                InboxMailLoad.rd4 = "1";
                                InboxMailLoad.ReadStatus = InboxMailLoad.rd4;
                                InboxMailLoad.lbl4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                                RunInboxSQLOperation();
                                OpenReadBox();
                                ChangeReadStatus();
                                TalkBk.SpeakAsync("This mail is sent by, " + InboxMailLoad.textBox2.Text + "," + "  on, " + InboxMailLoad.DateTimeLBL.Text + "," + " subject, " + InboxMailLoad.textBox3.Text + "," + "  mail body, " + InboxMailLoad.richTextBox1.Text);
                                if (InboxMailLoad.AttachmentTXT.Text != String.Empty)
                                {
                                    TalkBk.SpeakAsync("There is also an attachment with this mail");
                                }
                                lblStatus.Text = " ";
                                lblStatus.Text = "4th mail opened";
                            }
                            break;
                        }
                    case "Open and read fifth":
                        {
                            if (InboxMailLoad.ReadBox.Visible != true && InboxMailLoad.lbl5.Text != String.Empty)
                            {
                                TalkBk.SpeakAsync("Fifth mail is opened, initiating readback, ");
                                InboxMailLoad.cap = InboxMailLoad.x5;
                                InboxMailLoad.rd5 = "1";
                                InboxMailLoad.ReadStatus = InboxMailLoad.rd5;
                                InboxMailLoad.lbl5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                                RunInboxSQLOperation();
                                OpenReadBox();
                                ChangeReadStatus();
                                TalkBk.SpeakAsync("This mail is sent by, " + InboxMailLoad.textBox2.Text + "," + "  on, " + InboxMailLoad.DateTimeLBL.Text + "," + " subject, " + InboxMailLoad.textBox3.Text + "," + "  mail body, " + InboxMailLoad.richTextBox1.Text);
                                if (InboxMailLoad.AttachmentTXT.Text != String.Empty)
                                {
                                    TalkBk.SpeakAsync("There is also an attachment with this mail");
                                }
                                lblStatus.Text = " ";
                                lblStatus.Text = "5th mail opened";
                            }
                            break;
                        }
                    case "Open and read sixth":
                        {
                            if (InboxMailLoad.ReadBox.Visible != true && InboxMailLoad.lbl6.Text != String.Empty)
                            {
                                TalkBk.SpeakAsync("Sixth mail is opened, initiating readback, ");
                                InboxMailLoad.cap = InboxMailLoad.x6;
                                InboxMailLoad.rd6 = "1";
                                InboxMailLoad.ReadStatus = InboxMailLoad.rd6;
                                InboxMailLoad.lbl6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                                RunInboxSQLOperation();
                                OpenReadBox();
                                ChangeReadStatus();
                                TalkBk.SpeakAsync("This mail is sent by, " + InboxMailLoad.textBox2.Text + "," + "  on, " + InboxMailLoad.DateTimeLBL.Text + "," + " subject, " + InboxMailLoad.textBox3.Text + "," + "  mail body, " + InboxMailLoad.richTextBox1.Text);
                                if (InboxMailLoad.AttachmentTXT.Text != String.Empty)
                                {
                                    TalkBk.SpeakAsync("There is also an attachment with this mail");
                                }
                                lblStatus.Text = " ";
                                lblStatus.Text = "6th mail opened";
                            }
                            break;
                        }
                    case "Open and read seventh":
                        {
                            if (InboxMailLoad.ReadBox.Visible != true && InboxMailLoad.lbl7.Text != String.Empty)
                            {
                                TalkBk.SpeakAsync("Seventh mail is opened, initiating readback, ");
                                InboxMailLoad.cap = InboxMailLoad.x7;
                                InboxMailLoad.rd7 = "1";
                                InboxMailLoad.ReadStatus = InboxMailLoad.rd7;
                                InboxMailLoad.lbl7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                                RunInboxSQLOperation();
                                OpenReadBox();
                                ChangeReadStatus();
                                TalkBk.SpeakAsync("This mail is sent by, " + InboxMailLoad.textBox2.Text + "," + "  on, " + InboxMailLoad.DateTimeLBL.Text + "," + " subject, " + InboxMailLoad.textBox3.Text + "," + "  mail body, " + InboxMailLoad.richTextBox1.Text);
                                if (InboxMailLoad.AttachmentTXT.Text != String.Empty)
                                {
                                    TalkBk.SpeakAsync("There is also an attachment with this mail");
                                }
                                lblStatus.Text = " ";
                                lblStatus.Text = "7th mail opened";
                            }
                            break;
                        }
                    case "Open and read eighth":
                        {
                            if (InboxMailLoad.ReadBox.Visible != true && InboxMailLoad.lbl8.Text != String.Empty)
                            {
                                TalkBk.SpeakAsync("Eighth mail is opened, initiating readback, ");
                                InboxMailLoad.cap = InboxMailLoad.x8;
                                InboxMailLoad.rd8 = "1";
                                InboxMailLoad.ReadStatus = InboxMailLoad.rd8;
                                InboxMailLoad.lbl8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                                RunInboxSQLOperation();
                                OpenReadBox();
                                ChangeReadStatus();
                                TalkBk.SpeakAsync("This mail is sent by, " + InboxMailLoad.textBox2.Text + "," + "  on, " + InboxMailLoad.DateTimeLBL.Text + "," + " subject, " + InboxMailLoad.textBox3.Text + "," + "  mail body, " + InboxMailLoad.richTextBox1.Text);
                                if (InboxMailLoad.AttachmentTXT.Text != String.Empty)
                                {
                                    TalkBk.SpeakAsync("There is also an attachment with this mail");
                                }
                                lblStatus.Text = " ";
                                lblStatus.Text = "8th mail opened";
                            }
                            break;
                        }
                    case "Open and read ninth":
                        {
                            if (InboxMailLoad.ReadBox.Visible != true && InboxMailLoad.lbl9.Text != String.Empty)
                            {
                                TalkBk.SpeakAsync("Ninth mail is opened, initiating readback, ");
                                InboxMailLoad.cap = InboxMailLoad.x9;
                                InboxMailLoad.rd9 = "1";
                                InboxMailLoad.ReadStatus = InboxMailLoad.rd9;
                                InboxMailLoad.lbl9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                                RunInboxSQLOperation();
                                OpenReadBox();
                                ChangeReadStatus();
                                TalkBk.SpeakAsync("This mail is sent by, " + InboxMailLoad.textBox2.Text + "," + "  on, " + InboxMailLoad.DateTimeLBL.Text + "," + " subject, " + InboxMailLoad.textBox3.Text + "," + "  mail body, " + InboxMailLoad.richTextBox1.Text);
                                if (InboxMailLoad.AttachmentTXT.Text != String.Empty)
                                {
                                    TalkBk.SpeakAsync("There is also an attachment with this mail");
                                }
                                lblStatus.Text = " ";
                                lblStatus.Text = "9th mail opened";
                            }
                            break;
                        }
                    case "Open and read tenth":
                        {
                            if (InboxMailLoad.ReadBox.Visible != true && InboxMailLoad.lbl10.Text != String.Empty)
                            {
                                TalkBk.SpeakAsync("Tenth mail is opened, initiating readback, ");
                                InboxMailLoad.cap = InboxMailLoad.x10;
                                InboxMailLoad.rd10 = "1";
                                InboxMailLoad.ReadStatus = InboxMailLoad.rd10;
                                InboxMailLoad.lbl10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                                RunInboxSQLOperation();
                                OpenReadBox();
                                ChangeReadStatus();
                                TalkBk.SpeakAsync("This mail is sent by, " + InboxMailLoad.textBox2.Text + "," + "  on, " + InboxMailLoad.DateTimeLBL.Text + "," + " subject, " + InboxMailLoad.textBox3.Text + "," + "  mail body, " + InboxMailLoad.richTextBox1.Text);
                                if (InboxMailLoad.AttachmentTXT.Text != String.Empty)
                                {
                                    TalkBk.SpeakAsync("There is also an attachment with this mail");
                                }
                                lblStatus.Text = " ";
                                lblStatus.Text = "10th mail opened";
                            }
                            break;
                        }
                    case "Open and read eleventh":
                        {
                            if (InboxMailLoad.ReadBox.Visible != true && InboxMailLoad.lbl11.Text != String.Empty)
                            {
                                TalkBk.SpeakAsync("Eleventh mail is opened, initiating readback, ");
                                InboxMailLoad.cap = InboxMailLoad.x11;
                                InboxMailLoad.rd11 = "1";
                                InboxMailLoad.ReadStatus = InboxMailLoad.rd11;
                                InboxMailLoad.lbl11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                                RunInboxSQLOperation();
                                OpenReadBox();
                                ChangeReadStatus();
                                TalkBk.SpeakAsync("This mail is sent by, " + InboxMailLoad.textBox2.Text + "," + "  on, " + InboxMailLoad.DateTimeLBL.Text + "," + " subject, " + InboxMailLoad.textBox3.Text + "," + "  mail body, " + InboxMailLoad.richTextBox1.Text);
                                if (InboxMailLoad.AttachmentTXT.Text != String.Empty)
                                {
                                    TalkBk.SpeakAsync("There is also an attachment with this mail");
                                }
                                lblStatus.Text = " ";
                                lblStatus.Text = "11th mail opened";
                            }
                            break;
                        }
                    case "Open and read twelfth":
                        {
                            if (InboxMailLoad.ReadBox.Visible != true && InboxMailLoad.lbl12.Text != String.Empty)
                            {
                                TalkBk.SpeakAsync("Twelfth mail is opened, initiating readback, ");
                                InboxMailLoad.cap = InboxMailLoad.x12;
                                InboxMailLoad.rd12 = "1";
                                InboxMailLoad.ReadStatus = InboxMailLoad.rd12;
                                InboxMailLoad.lbl12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                                RunInboxSQLOperation();
                                OpenReadBox();
                                ChangeReadStatus();
                                TalkBk.SpeakAsync("This mail is sent by, " + InboxMailLoad.textBox2.Text + "," + "  on, " + InboxMailLoad.DateTimeLBL.Text + "," + " subject, " + InboxMailLoad.textBox3.Text + "," + "  mail body, " + InboxMailLoad.richTextBox1.Text);
                                if (InboxMailLoad.AttachmentTXT.Text != String.Empty)
                                {
                                    TalkBk.SpeakAsync("There is also an attachment with this mail");
                                }
                                lblStatus.Text = " ";
                                lblStatus.Text = "12th mail opened";
                            }
                            break;
                        }
                    case "Open and read thirteenth":
                        {
                            if (InboxMailLoad.ReadBox.Visible != true && InboxMailLoad.lbl13.Text != String.Empty)
                            {
                                TalkBk.SpeakAsync("Thirteenth mail is opened, initiating readback, ");
                                InboxMailLoad.cap = InboxMailLoad.x13;
                                InboxMailLoad.rd13 = "1";
                                InboxMailLoad.ReadStatus = InboxMailLoad.rd13;
                                InboxMailLoad.lbl13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                                RunInboxSQLOperation();
                                OpenReadBox();
                                ChangeReadStatus();
                                TalkBk.SpeakAsync("This mail is sent by, " + InboxMailLoad.textBox2.Text + "," + "  on, " + InboxMailLoad.DateTimeLBL.Text + "," + " subject, " + InboxMailLoad.textBox3.Text + "," + "  mail body, " + InboxMailLoad.richTextBox1.Text);
                                if (InboxMailLoad.AttachmentTXT.Text != String.Empty)
                                {
                                    TalkBk.SpeakAsync("There is also an attachment with this mail");
                                }
                                lblStatus.Text = " ";
                                lblStatus.Text = "13th mail opened";
                            }
                            break;
                        }
                    case "Open and read fourteenth":
                        {
                            if (InboxMailLoad.ReadBox.Visible != true && InboxMailLoad.lbl14.Text != String.Empty)
                            {
                                TalkBk.SpeakAsync("Fourteenth mail is opened, initiating readback, ");
                                InboxMailLoad.cap = InboxMailLoad.x14;
                                InboxMailLoad.rd14 = "1";
                                InboxMailLoad.ReadStatus = InboxMailLoad.rd14;
                                InboxMailLoad.lbl14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                                RunInboxSQLOperation();
                                OpenReadBox();
                                ChangeReadStatus();
                                TalkBk.SpeakAsync("This mail is sent by, " + InboxMailLoad.textBox2.Text + "," + "  on, " + InboxMailLoad.DateTimeLBL.Text + "," + " subject, " + InboxMailLoad.textBox3.Text + "," + "  mail body, " + InboxMailLoad.richTextBox1.Text);
                                if (InboxMailLoad.AttachmentTXT.Text != String.Empty)
                                {
                                    TalkBk.SpeakAsync("There is also an attachment with this mail");
                                }
                                lblStatus.Text = " ";
                                lblStatus.Text = "14th mail opened";
                            }
                            break;
                        }
                    case "Open and read fifteenth":
                        {
                            if (InboxMailLoad.ReadBox.Visible != true && InboxMailLoad.lbl15.Text != String.Empty)
                            {
                                TalkBk.SpeakAsync("Fifteenth mail is opened, initiating readback, ");
                                InboxMailLoad.cap = InboxMailLoad.x15;
                                InboxMailLoad.rd15 = "1";
                                InboxMailLoad.ReadStatus = InboxMailLoad.rd15;
                                InboxMailLoad.lbl15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                                RunInboxSQLOperation();
                                OpenReadBox();
                                ChangeReadStatus();
                                TalkBk.SpeakAsync("This mail is sent by, " + InboxMailLoad.textBox2.Text + "," + "  on, " + InboxMailLoad.DateTimeLBL.Text + "," + " subject, " + InboxMailLoad.textBox3.Text + "," + "  mail body, " + InboxMailLoad.richTextBox1.Text);
                                if (InboxMailLoad.AttachmentTXT.Text != String.Empty)
                                {
                                    TalkBk.SpeakAsync("There is also an attachment with this mail");
                                }
                                lblStatus.Text = " ";
                                lblStatus.Text = "15th mail opened";
                            }
                            break;
                        }
                    case "Delete this mail":
                        {
                            if (InboxMailLoad.ReadBox.Visible != false)
                            {
                                //TalkBk.Pause();
                                //confirmEng.RecognizeAsync(RecognizeMode.Multiple);
                                InboxMailDelete();
                                InboxLBLRefresh();
                                CountUserMail_Inbox();
                                inboxMail();
                                ResetMailCount();
                                InboxMailLoad.page = 1;
                                InboxMailLoad.pageLbl.Text = InboxMailLoad.page.ToString();
                                GoBacktoInbox();
                                if (confAct == 1)
                                {
                                    TalkBk.SpeakAsync("Mail has been deleted");
                                }
                                else if (confAct == 0)
                                {
                                    TalkBk.SpeakAsync("Operation canceled");
                                }
                                lblStatus.Text = " ";
                                lblStatus.Text = "Mail deleting";
                            }
                            break;
                        }
                    case "Reply to tihs":
                        {
                            if (InboxMailLoad.ReadBox.Visible != false)
                            {
                                InboxMailReply();
                                uniqPermission2 = 11;
                                InboxOperation.RecognizeAsyncStop();
                                selectionENG1.RecognizeAsync(RecognizeMode.Multiple);
                                TalkBk.SpeakAsync("Compose box opened and address has been inserted");
                                lblStatus.Text = " ";
                                lblStatus.Text = "Reply initiating";
                            }
                            break;
                        }
                    case "Forward this":
                        {
                            if (InboxMailLoad.ReadBox.Visible != false)
                            {
                                InboxMailForward();
                                uniqPermission2 = 11;
                                InboxOperation.RecognizeAsyncStop();
                                selectionENG1.RecognizeAsync(RecognizeMode.Multiple);
                                TalkBk.SpeakAsync("Compose box opened and subject, mail body, attachment has been inserted, insert mail address");
                                lblStatus.Text = " ";
                                lblStatus.Text = "Forward initiating";
                            }
                            break;
                        }
                    case "How many unread mails are there":
                        {
                            if (InboxUnreadMailslbl.Visible != true)
                            {
                                TalkBk.SpeakAsync("There is no un read mails");
                            }
                            else if (InboxUnreadMailslbl.Visible != false)
                            {
                                TalkBk.SpeakAsync("There are, " + InboxUnreadMailslbl.Text + " un read mails");
                            }
                            lblStatus.Text = " ";
                            lblStatus.Text = "Counting unread";
                            break;
                        }
                    case "Search mail":
                        {
                            TalkBk.SpeakAsync("Keyword necessary");
                            InboxOperation.RecognizeAsyncStop();
                            InboxSearchActive.RecognizeAsync(RecognizeMode.Multiple);
                            lblStatus.Text = " ";
                            lblStatus.Text = "Search initiating";
                            break;
                        }
                    case "Clear search":
                        {
                            InboxMailLoad.searchTxt.Text = String.Empty;
                            TalkBk.SpeakAsync("Search cleared");
                            lblStatus.Text = " ";
                            lblStatus.Text = "Clearing....";
                            break;
                        }
                    case "Reset notification":
                        {
                            if (notificationLbl.Visible == true)
                            {
                                CmndInbox();
                                UsrNotifictn.BackgroundImage = Properties.Resources._003_notification;
                                notificationLbl.Visible = false;
                                ResetMailCount();
                                NotifyUser.Start();
                                TalkBk.SpeakAsync("Notification reset");
                                lblStatus.Text = " ";
                                lblStatus.Text = "Resetting";
                            }
                            break;
                        }
                    case "Select unread mails":
                        {
                            if (InboxUnreadMailslbl.Visible != false)
                            {
                                CheckInboxTm.Stop();
                                InboxLBLRefresh();
                                InboxUnread();
                                TalkBk.SpeakAsync("Unread mails selected");
                                lblStatus.Text = " ";
                                lblStatus.Text = "U.M. selected";
                                resetUnreadCmnd = 1;
                            }
                            break;
                        }
                    case "Deselect unread mails":
                        {
                            if (resetUnreadCmnd == 1)
                            {
                                CheckInboxTm.Start();
                                TalkBk.SpeakAsync("Unread mails de selected");
                                lblStatus.Text = " ";
                                lblStatus.Text = "U.M. deselected";
                                resetUnreadCmnd = 0;
                            }
                            break;
                        }
                    case "Scroll next":
                        {
                            if (InboxMailLoad.lbl15.Text != String.Empty)
                            {
                                CheckInboxTm.Stop();
                                InboxMailLoad.Mcount = 0;
                                InboxMailLoad.page = InboxMailLoad.page + 1;
                                InboxMailLoad.pageLbl.Text = InboxMailLoad.page.ToString();
                                InboxLBLRefresh();
                                inbx = inbx - 15;
                                inboxMail();
                                TalkBk.SpeakAsync("Page " + InboxMailLoad.pageLbl.Text + " is showing");
                            }
                            else
                            {
                                TalkBk.SpeakAsync("Can not scroll to next, page limit reached");
                            }
                            break;
                        }
                    case "Scroll back":
                        {
                            if (InboxMailLoad.pageLbl.Text != "1")
                            {
                                InboxMailLoad.Mcount = 0;
                                InboxMailLoad.page = InboxMailLoad.page - 1;
                                InboxMailLoad.pageLbl.Text = InboxMailLoad.page.ToString();
                                InboxLBLRefresh();
                                inbx = inbx + 15;
                                inboxMail();
                                TalkBk.SpeakAsync("Page " + InboxMailLoad.pageLbl.Text + " is showing");
                                if (InboxMailLoad.pageLbl.Text == "1")
                                {
                                    CheckInboxTm.Start();
                                }
                            }
                            else
                            {
                                TalkBk.SpeakAsync("Can not scroll back, page limit reached");
                            }
                            break;
                        }
                }
            }
        }

        private void InboxMailForward()
        {
            if (InboxMailLoad.cap != null)
            {
                try
                {
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }
                    cmd.Connection = con;
                    cmd.CommandText = "Select Subject,Body,Attachment From Inbox where Serial='" + InboxMailLoad.cap + "'";
                    cmd.ExecuteNonQuery();
                    cmd.Clone();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        InboxMailLoad.F_Subject = sdr[0].ToString();
                        InboxMailLoad.F_Body = sdr[1].ToString();
                        InboxMailLoad.F_Attachment = sdr[2].ToString();
                    }
                    if (panelSlide.Width == 1 && panelSlide.Height == 428)
                    {
                        panelSlide.Width = 379;
                        panelSlide.Height = 428;
                        subjectTxt.Text = InboxMailLoad.F_Subject;
                        attachTxt.Text = InboxMailLoad.F_Attachment;
                        bodyTxt.Text = InboxMailLoad.F_Body;
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    con.Close();
                    //MessageBox.Show(ex.Message);
                }
            }
        }

        private void InboxMailReply()
        {
            if (InboxMailLoad.cap != null)
            {
                try
                {
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }
                    cmd.Connection = con;
                    cmd.CommandText = "Select [From] From Inbox where Serial='" + InboxMailLoad.cap + "'";
                    cmd.ExecuteNonQuery();
                    cmd.Clone();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        InboxMailLoad.Mail_Reply = sdr[0].ToString();
                    }
                    if (panelSlide.Width == 1 && panelSlide.Height == 428)
                    {
                        panelSlide.Width = 379;
                        panelSlide.Height = 428;
                        addressTxt.Text = InboxMailLoad.Mail_Reply;
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    con.Close();
                    //MessageBox.Show(ex.Message);
                }
            }
        }

        private void InboxMailDelete()
        {
            confMsg = new SoundPlayer("Notify.wav");
            confMsg.Play();
            cf = new Confirmation();
            TalkBk.SpeakAsync("Are you really want to delete this mail?");
            confirmEng.RecognizeAsync(RecognizeMode.Multiple);
            cf.ShowDialog();
            if (confAct == 1)
            {
                confirmEng.RecognizeAsyncStop();
                InboxMailLoad.Mcount = 0;
                if (InboxMailLoad.cap != null)
                {
                    try
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }
                        cmd.Connection = con;
                        cmd.CommandText = "Delete Inbox where Serial='" + InboxMailLoad.cap + "'";
                        cmd.ExecuteNonQuery();
                        cmd.Clone();
                        con.Close();
                        
                    }
                    catch (Exception ex)
                    {
                        con.Close();
                        //MessageBox.Show(ex.Message);
                    }
                }
            }
            else if (confAct == 0)
            {
                try
                {
                    confirmEng.RecognizeAsyncStop();
                    InboxMailLoad.cap = null;
                }
                catch (Exception ex)
                {
                    //error......
                }
            }

        }

        private void TypeOperation1()
        {
            try
            {
                typeENG1.LoadGrammar(new DictationGrammar());
                typeENG1.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(typeENG1_SpeechRecognized);
                typeENG1.SetInputToDefaultAudioDevice();
            }
            catch (Exception Ex)
            {
                //Error....................
            }
        }

        void typeENG1_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            switch (j)
            {
                case 1:
                    {
                        addressTxt.Text += (e.Result.Text + "@email.com");
                        TalkBk.SpeakAsync("Text entered");
                        break;
                    }
                case 2:
                    {
                        if (caseSet1 == 0)
                        {
                            temp1 = (e.Result.Text.ToString());
                            char[] a = new char[200];
                            a = temp1.ToCharArray();
                            a[0] = char.ToUpper(a[0]);
                            string s = new string(a);
                            temp1 = s;
                            subjectTxt.Text += ("" + temp1);
                            TalkBk.SpeakAsync("Text entered");
                        }
                        else if (caseSet1 == 1)
                        {
                            temp1 = (e.Result.Text.ToUpper()).ToString();
                            subjectTxt.Text += ("" + temp1);
                            TalkBk.SpeakAsync("Text entered");
                        }
                        else if (caseSet1 == 2)
                        {
                            temp1 = (e.Result.Text.ToLower()).ToString();
                            subjectTxt.Text += ("" + temp1);
                            TalkBk.SpeakAsync("Text entered");
                        }
                        temp1 = String.Empty;
                        break;
                    }
                case 3:
                    {
                        if (caseSet1 == 0)
                        {
                            temp1 = (e.Result.Text.ToString());
                            char[] a = new char[200];
                            a = temp1.ToCharArray();
                            a[0] = char.ToUpper(a[0]);
                            string s = new string(a);
                            temp1 = s;
                            bodyTxt.Text += ("" + temp1);
                            TalkBk.SpeakAsync("Text entered");
                        }
                        else if (caseSet1 == 1)
                        {
                            temp1 = (e.Result.Text.ToUpper()).ToString();
                            bodyTxt.Text += ("" + temp1);
                            TalkBk.SpeakAsync("Text entered");
                        }
                        else if (caseSet1 == 2)
                        {
                            temp1 = (e.Result.Text.ToLower()).ToString();
                            bodyTxt.Text += ("" + temp1);
                            TalkBk.SpeakAsync("Text entered");
                        }
                        temp1 = String.Empty;
                        break;
                    }
                case 4:
                    {
                        typeENG1.RecognizeAsyncStop();
                        break;
                    }
            }
        }

        private void typeCast1()
        {
            charCase1.Add(new string[] { "Set uppercase", "Set lowercase", "Set normalcast" });
            GrammarBuilder gb33 = new GrammarBuilder();
            gb33.Append(charCase1);
            Grammar g33 = new Grammar(gb33);
            try
            {
                charCaseENG1.LoadGrammar(g33);
                charCaseENG1.SetInputToDefaultAudioDevice();
                charCaseENG1.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(charCaseENG1_SpeechRecognized);
            }
            catch (Exception ex)
            {
                //...............
            }
        }

        void charCaseENG1_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (e.Result.Text.Equals("Set normalcast") && e.Result.Text != "Set lowercase" && e.Result.Text != "Set uppercase" && e.Result.Text != "Dictation on" && e.Result.Text != "Dictation off")
            {
                caseSet1 = 0;
                TalkBk.SpeakAsync("Normalcast on");
            }
            else if (e.Result.Text.Equals("Set uppercase") && e.Result.Text != "Set lowercase" && e.Result.Text != "Set normalcast" && e.Result.Text != "Dictation on" && e.Result.Text != "Dictation off")
            {
                caseSet1 = 1;
                TalkBk.SpeakAsync("Uppercase on");
            }
            else if (e.Result.Text.Equals("Set lowercase") && e.Result.Text != "Set uppercase" && e.Result.Text != "Set normalcast" && e.Result.Text != "Dictation on" && e.Result.Text != "Dictation off")
            {
                caseSet1 = 2;
                TalkBk.SpeakAsync("Lowercase on");
            }
        }

        private void DictationOperation1()
        {
            switchONoff1.Add(new string[] { "Dictation on", "Dictation off" });
            GrammarBuilder gb22 = new GrammarBuilder();
            gb22.Append(switchONoff1);
            Grammar g22 = new Grammar(gb22);
            try
            {
                switchOnoffENG1.LoadGrammar(g22);
                switchOnoffENG1.SetInputToDefaultAudioDevice();
                switchOnoffENG1.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(switchOnoffENG1_SpeechRecognized);

            }
            catch (Exception ex)
            {
                //Error........................
            }
        }

        void switchOnoffENG1_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            switch (e.Result.Text.ToString())
            {
                case "Dictation on":
                    {
                        charCaseENG1.RecognizeAsyncStop();
                        typeENG1.RecognizeAsync(RecognizeMode.Multiple);
                        TalkBk.SpeakAsync("Dictation enable");
                        break;
                    }
                case "Dictation off":
                    {
                        j = 4;
                        charCaseENG1.RecognizeAsyncStop();
                        switchOnoffENG1.RecognizeAsyncStop();
                        selectionENG1.RecognizeAsync(RecognizeMode.Multiple);
                        TalkBk.SpeakAsync("Dictation disable");
                        break;
                    }
            }
        }

        private void SelectOperation1()
        {
            selection1.Add(new string[] { "Select address", "Select subject", "Add attachment"
                , "Select body", "Save as draft", "Send this", "Clear address", "Clear subject"
                , "Clear attachment", "Clear body", "Cancel that", "Read back address"
                , "Read back subject", "Read back mail body", "Read back this mail"
                , "That's all for now" });
            GrammarBuilder gb11 = new GrammarBuilder();
            gb11.Append(selection1);
            Grammar g11 = new Grammar(gb11);
            try
            {
                selectionENG1.LoadGrammar(g11);
                selectionENG1.SetInputToDefaultAudioDevice();
                selectionENG1.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(selectionENG1_SpeechRecognized);
            }
            catch (Exception ex)
            {
                //Error........
            }
        }

        void selectionENG1_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            switch (e.Result.Text.ToString())
            {
                case "Select address":
                    {
                        selectionENG1.RecognizeAsyncStop();
                        switchOnoffENG1.RecognizeAsync(RecognizeMode.Multiple);
                        TalkBk.SpeakAsync("Address selected");
                        lblStatus.Text = " ";
                        lblStatus.Text = "Address selected";
                        j = 1;
                        break;
                    }
                case "Select subject":
                    {
                        selectionENG1.RecognizeAsyncStop();
                        switchOnoffENG1.RecognizeAsync(RecognizeMode.Multiple);
                        TalkBk.SpeakAsync("Subject selected");
                        lblStatus.Text = " ";
                        lblStatus.Text = "Subject selected";
                        j = 2;
                        charCaseENG1.RecognizeAsync(RecognizeMode.Multiple);
                        break;
                    }
                case "Add attachment":
                    {
                        attachment();
                        if (attachTxt.Text != "")
                        {
                            TalkBk.SpeakAsync("Attatchment selected");
                            lblStatus.Text = " ";
                            lblStatus.Text = "Attatchment selected";
                        }
                        else
                        {
                            TalkBk.SpeakAsync("No attatchment selected");
                        }
                        break;
                    }
                case "Select body":
                    {
                        selectionENG1.RecognizeAsyncStop();
                        switchOnoffENG1.RecognizeAsync(RecognizeMode.Multiple);
                        TalkBk.SpeakAsync("Mail body selected");
                        lblStatus.Text = " ";
                        lblStatus.Text = "Body selected";
                        j = 3;
                        charCaseENG1.RecognizeAsync(RecognizeMode.Multiple);
                        break;
                    }
                case "Save as draft":
                    {
                        lblStatus.Text = " ";
                        lblStatus.Text = "Sending mail";
                        msgSave();
                        TalkBk.SpeakAsync("Message has been saved");
                        break;
                    }
                case "Send this":
                    {
                        lblStatus.Text = " ";
                        lblStatus.Text = "Saving mail";
                        msgSend();
                        TalkBk.SpeakAsync("Message has been sent");
                        break;
                    }
                case "Clear address":
                    {
                        if (addressTxt.Text != "")
                        {
                            addressTxt.Text = String.Empty;
                            TalkBk.SpeakAsync("Address has been cleared");
                            lblStatus.Text = " ";
                            lblStatus.Text = "Address cleared";
                        }
                        break;
                    }
                case "Clear subject":
                    {
                        if (subjectTxt.Text != "")
                        {
                            subjectTxt.Text = String.Empty;
                            TalkBk.SpeakAsync("Subject has been cleared");
                            lblStatus.Text = " ";
                            lblStatus.Text = "Subject cleared";
                        }
                        break;
                    }
                case "Clear attachment":
                    {
                        if (attachTxt.Text != "")
                        {
                            attachTxt.Text = String.Empty;
                            TalkBk.SpeakAsync("Attachment has been cleared");
                            lblStatus.Text = " ";
                            lblStatus.Text = "Attachment cleared";
                        }
                        break;
                    }
                case "Clear body":
                    {
                        if (bodyTxt.Text != "")
                        {
                            bodyTxt.Text = String.Empty;
                            TalkBk.SpeakAsync("Mail body has been cleared");
                            lblStatus.Text = " ";
                            lblStatus.Text = "Body cleared";
                        }
                        break;
                    }
                case "Cancel that":
                    {
                        if (panelSlide.Width == 379 && panelSlide.Height == 428)
                        {
                            addressTxt.Text = String.Empty;
                            attachTxt.Text = String.Empty;
                            subjectTxt.Text = String.Empty;
                            bodyTxt.Text = String.Empty;
                            TalkBk.SpeakAsync("Operation canceled");
                            lblStatus.Text = " ";
                            lblStatus.Text = "Operation canceled";
                            panelSlide.Width = 1;
                            panelSlide.Height = 428;
                            selectionENG1.RecognizeAsyncStop();
                            if (uniqPermission1 == 11)
                            {
                                uniqPermission1 = 00;
                                BtnCmmnd.RecognizeAsync(RecognizeMode.Multiple);
                            }
                            if (uniqPermission2 == 11)
                            {
                                uniqPermission2 = 00;
                                InboxOperation.RecognizeAsync(RecognizeMode.Multiple);
                            }
                            if (uniqPermission3 == 11)
                            {
                                uniqPermission3 = 00;
                                SentItemsOperation.RecognizeAsync(RecognizeMode.Multiple);
                            }
                            if (uniqPermission4 == 11)
                            {
                                uniqPermission4 = 00;
                                DraftOperation.RecognizeAsync(RecognizeMode.Multiple);
                            }
                        }
                        break;
                    }
                case "Read back address":
                    {
                        if (addressTxt.Text != "")
                        {
                            TalkBk.SpeakAsync(addressTxt.Text);
                            lblStatus.Text = " ";
                            lblStatus.Text = "Reading address";
                        }
                        break;
                    }
                case "Read back subject":
                    {
                        if (subjectTxt.Text != "")
                        {
                            TalkBk.SpeakAsync(subjectTxt.Text);
                            lblStatus.Text = " ";
                            lblStatus.Text = "Reading subject";
                        }
                        break;
                    }
                case "Read back mail body":
                    {
                        if (bodyTxt.Text != "")
                        {
                            TalkBk.SpeakAsync(bodyTxt.Text);
                            lblStatus.Text = " ";
                            lblStatus.Text = "Reading mailbody";
                        }
                        break;
                    }
                case "Read back this mail":
                    {
                        if (subjectTxt.Text != "" && bodyTxt.Text != "")
                        {
                            lblStatus.Text = " ";
                            lblStatus.Text = "Reading...!";
                            TalkBk.SpeakAsync("Address is, " + addressTxt.Text + ", Subject is, " + subjectTxt.Text + ", Mail body is, " + bodyTxt.Text);
                            if (attachTxt.Text != "")
                            {
                                TalkBk.SpeakAsync("There is an attachment with this mail");
                            }
                            else
                            {
                                TalkBk.SpeakAsync("There is no attachment with this mail");
                            }
                        }
                        break;
                    }
                case "That's all for now":
                    {
                        TalkBk.SpeakAsync("Okay, I understand");
                        lblStatus.Text = " ";
                        lblStatus.Text = "Hmmm...!";
                        selectionENG1.RecognizeAsyncStop();
                        if (uniqPermission1 == 11)
                        {
                            uniqPermission1 = 00;
                            BtnCmmnd.RecognizeAsync(RecognizeMode.Multiple);
                        }
                        if (uniqPermission2 == 11)
                        {
                            uniqPermission2 = 00;
                            InboxOperation.RecognizeAsync(RecognizeMode.Multiple);
                        }
                        if (uniqPermission3 == 11)
                        {
                            uniqPermission3 = 00;
                            SentItemsOperation.RecognizeAsync(RecognizeMode.Multiple);
                        }
                        if (uniqPermission4 == 11)
                        {
                            uniqPermission4 = 00;
                            DraftOperation.RecognizeAsync(RecognizeMode.Multiple);
                        }
                        break;
                    }
            }
        }

        private void msgSend()
        {
            if (addressTxt.Text != String.Empty)
            {
                try
                {
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }
                    string readStatus = "0";
                    cmd.Connection = con;
                    cmd.Parameters.Clear();
                    CurrentDateTime();
                    if (imgAvil == 0)
                    {
                        cmd.CommandText = "insert into Inbox ([To],[From],Subject,Body,TimeDate,ReadStatus) values ('" + addressTxt.Text + "','" + currentUser + "','" + subjectTxt.Text + "','" + bodyTxt.Text + "','" + cDateTime + "','" + readStatus + "')";
                    }
                    else if (imgAvil == 1)
                    {
                        cmd.CommandText = "insert into Inbox ([To],[From],Subject,Body,TimeDate,ReadStatus,Attachment) values ('" + addressTxt.Text + "','" + currentUser + "','" + subjectTxt.Text + "','" + bodyTxt.Text + "','" + cDateTime + "','" + readStatus + "',@img)";
                        cmd.Parameters.Add(new SqlParameter("@img", img));
                    }
                    cmd.ExecuteNonQuery();
                    cmd.Clone();
                    cmd1.Connection = con;
                    cmd1.Parameters.Clear();
                    if (imgAvil == 0)
                    {
                        cmd1.CommandText = "insert into SentItems ([From],[To],Subject,Body,TimeDate) values ('" + currentUser + "','" + addressTxt.Text + "','" + subjectTxt.Text + "','" + bodyTxt.Text + "','" + cDateTime + "')";
                    }
                    else if (imgAvil == 1)
                    {
                        cmd1.CommandText = "insert into SentItems ([From],[To],Subject,Body,TimeDate,Attachment) values ('" + currentUser + "','" + addressTxt.Text + "','" + subjectTxt.Text + "','" + bodyTxt.Text + "','" + cDateTime + "',@img)";
                        cmd1.Parameters.Add(new SqlParameter("@img", img));
                        imgAvil = 0;
                    }
                    cmd1.ExecuteNonQuery();
                    cmd1.Clone();
                    //MessageBox.Show("Your mail has been sent!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    con.Close();

                    
                    addressTxt.Text = String.Empty;
                    attachTxt.Text = String.Empty;
                    subjectTxt.Text = String.Empty;
                    bodyTxt.Text = String.Empty;
                    img = null;
                    CountUserMail_SM();
                    sentItemsMails();
                }
                catch (Exception ex)
                {
                    con.Close();
                }
            }
            else
            {
                TalkBk.SpeakAsync("No address to send");
            }
        }

        private void CurrentDateTime()
        {
            cDateTime = DateTime.Now.ToLongDateString() + " at " + DateTime.Now.ToShortTimeString();
        }

        private void msgSave()
        {
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                cmd.Connection = con;
                cmd.Parameters.Clear();
                CurrentDateTime();
                if (imgAvil == 0)
                {
                    cmd.CommandText = "insert into Draft (Mail_ID,Subject,Body,User_ID,TimeDate) values ('" + addressTxt.Text + "','" + subjectTxt.Text + "','" + bodyTxt.Text + "','" + currentUser + "','" + cDateTime + "')";
                }
                else if (imgAvil == 1)
                {
                    cmd.CommandText = "insert into Draft (Mail_ID,Subject,Body,User_ID,TimeDate,Attachment) values ('" + addressTxt.Text + "','" + subjectTxt.Text + "','" + bodyTxt.Text + "','" + currentUser + "','" + cDateTime + "',@img)";
                    cmd.Parameters.Add(new SqlParameter("@img", img));
                    imgAvil = 0;
                }

                cmd.ExecuteNonQuery();
                cmd.Clone();
                //MessageBox.Show("Your mail has been saved!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();

                
                addressTxt.Text = String.Empty;
                attachTxt.Text = String.Empty;
                subjectTxt.Text = String.Empty;
                bodyTxt.Text = String.Empty;
                img = null;
                CountUserMail_Drft();
                draftMails(); 
            }
            catch (Exception ex)
            {
                con.Close();
            }
        }

        private void attachment()
        {
            browseOpt.Filter = "JPG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png|GIF Files (*.gif)|*.gif|All Files (*.*)|*.*";
            if (browseOpt.ShowDialog() == DialogResult.OK)
            {
                if (attachTxt.Text != "")
                {
                    attachTxt.Text = String.Empty;
                }
                attachTxt.Text = browseOpt.FileName.ToString();
                imgLoc = browseOpt.FileName.ToString();
                FileStream fs = new FileStream(imgLoc, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                img = br.ReadBytes((int)fs.Length);
                imgAvil = 1;
            }
        }

        private void TypeOperation()
        {
            try
            {
                typeENG.LoadGrammar(new DictationGrammar());
                typeENG.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(typeENG_SpeechRecognized);
                typeENG.SetInputToDefaultAudioDevice();
            }
            catch (Exception Ex)
            {
                //Error....................
            }
        }

        void typeENG_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (LogInPage.Visible != false)
            {
                switch (i)
                {
                    case 1:
                        {
                            temp = (e.Result.Text.ToLower()).ToString();
                            LogInPage.usrnameTxt.Text += ("" + temp);
                            //LogInPage.usrnameTxt.Text += (e.Result.Text + "@email.com");
                            TalkBk.SpeakAsync("Text entered");
                            //NeedToInsert = 4;
                            break;
                        }
                    case 2:
                        {
                            if (caseSet == 0)
                            {
                                temp = (e.Result.Text.Normalize()).ToString();
                                LogInPage.passwordTxt.Text += ("" + temp);
                                TalkBk.SpeakAsync("Text entered");
                                //NeedToInsert1 = 5;
                            }
                            else if (caseSet == 1)
                            {
                                temp = (e.Result.Text.ToUpper()).ToString();
                                LogInPage.passwordTxt.Text += ("" + temp);
                                TalkBk.SpeakAsync("Text entered");
                                //NeedToInsert1 = 5;
                            }
                            else if (caseSet == 2)
                            {
                                temp = (e.Result.Text.ToLower()).ToString();
                                LogInPage.passwordTxt.Text += ("" + temp);
                                TalkBk.SpeakAsync("Text entered");
                                //NeedToInsert1 = 5;
                            }
                            temp = String.Empty;
                            //NeedToInsert1 = 5;
                            //WaitToFinish.Start();
                            break;
                        }
                    case 3:
                        {
                            typeENG.RecognizeAsyncStop();
                            break;
                        }
                }
            }
        }

        private void typeCast()
        {
            charCase.Add(new string[] { "Set uppercase", "Set lowercase" });
            GrammarBuilder gb3 = new GrammarBuilder();
            gb3.Append(charCase);
            Grammar g3 = new Grammar(gb3);
            try
            {
                charCaseENG.LoadGrammar(g3);
                charCaseENG.SetInputToDefaultAudioDevice();
                charCaseENG.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(charCaseENG_SpeechRecognized);
                //charCaseENG.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch (Exception ex)
            {
                //...............
            }
        }

        void charCaseENG_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (LogInPage.Visible != false)
            {
                if (e.Result.Text.Equals("Set uppercase") && e.Result.Text != "Set lowercase" && e.Result.Text != "Set normalcast" && e.Result.Text != "Dictation on" && e.Result.Text != "Dictation off")
                {
                    caseSet = 1;
                    TalkBk.SpeakAsync("Uppercase on");
                    if (NeedToInsert1 != 3)
                    {
                        NeedToInsert1 = 3;
                    }
                }
                else if (e.Result.Text.Equals("Set lowercase") && e.Result.Text != "Set uppercase" && e.Result.Text != "Set normalcast" && e.Result.Text != "Dictation on" && e.Result.Text != "Dictation off")
                {
                    caseSet = 2;
                    TalkBk.SpeakAsync("Lowercase on");
                    if (NeedToInsert1 != 3)
                    {
                        NeedToInsert1 = 3;
                    }
                }
            }
        }

        private void DictationOperation()
        {
            switchONoff.Add(new string[] { "Dictation on", "Dictation off" });
            GrammarBuilder gb2 = new GrammarBuilder();
            gb2.Append(switchONoff);
            Grammar g2 = new Grammar(gb2);
            try
            {
                switchOnoffENG.LoadGrammar(g2);
                switchOnoffENG.SetInputToDefaultAudioDevice();
                switchOnoffENG.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(switchOnoffENG_SpeechRecognized);

            }
            catch (Exception ex)
            {
                //Error........................
            }
        }

        void switchOnoffENG_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            switch (e.Result.Text.ToString())
            {
                case "Dictation on":
                    {
                        FirstPriority = 1;
                        if (LogInPage.Visible != false)
                        {
                            if (LoginAssistant == 1)
                            {
                                NeedToInsert = 3;
                            }
                            else if (LoginAssistant == 2)
                            {
                                NeedToInsert1 = 4;
                            }
                            charCaseENG.RecognizeAsyncStop();
                            typeENG.RecognizeAsync(RecognizeMode.Multiple);
                            TalkBk.SpeakAsync("Dictation enable");
                            /*if (LogInPage.usrnameTxt.Text.Equals("@email.com"))
                            {
                                LogInPage.usrnameTxt.Text = String.Empty;
                            }*/
                        }
                        break;
                    }
                case "Dictation off":
                    {
                        if (LogInPage.Visible != false && FirstPriority==1)
                        {
                            FirstPriority = 0;
                            if (i == 1)
                            {
                                LogInPage.usrnameTxt.Text += ("" + "@email.com");
                            }
                            i = 3;
                            WaitToFinish.Stop();
                            charCaseENG.RecognizeAsyncStop();
                            switchOnoffENG.RecognizeAsyncStop();
                            selectionENG.RecognizeAsync(RecognizeMode.Multiple);
                            TalkBk.SpeakAsync("Dictation disable");

                            if (LoginAssistant == 1)
                            {
                                if (LogInPage.usrnameTxt.Text.Equals(String.Empty))
                                {
                                    NeedToInsert = 1;
                                }
                                else if (!LogInPage.usrnameTxt.Text.Equals(String.Empty))
                                {
                                    NeedToInsert = 5;
                                }
                            }
                            else if (LoginAssistant == 2)
                            {
                                if (LogInPage.passwordTxt.Text.Equals(String.Empty))
                                {
                                    NeedToInsert1 = 1;
                                }
                                else if (!LogInPage.passwordTxt.Text.Equals(String.Empty))
                                {
                                    NeedToInsert1 = 6;
                                }
                            }
                            
                        }
                        break;
                    }
            }
        }

        private void SelectOperation()
        {
            selection.Add(new string[] { "Username", "Password", "Go next", "Readback username"
                , "Readback password", "Clear username", "Clear password", "Logout"
                , "Remember this", "Don't remember this" });
            GrammarBuilder gb1 = new GrammarBuilder();
            gb1.Append(selection);
            Grammar g1 = new Grammar(gb1);
            try
            {
                selectionENG.LoadGrammar(g1);
                selectionENG.SetInputToDefaultAudioDevice();
                selectionENG.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(selectionENG_SpeechRecognized);
                //selectionENG.RecognizeAsync(RecognizeMode.Multiple);

            }
            catch (Exception ex)
            {
                //Error........
            }
        }

        void selectionENG_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            switch (e.Result.Text.ToString())
            {
                case "Username":
                    {
                        if (LogInPage.Visible != false && LogInPage.pnlLogin.Visible != false && LogInPage.pnlSuccessLogin.Visible!=true)
                        {
                            NeedToInsert = 2;
                            BtnCmmnd.RecognizeAsyncStop();
                            selectionENG.RecognizeAsyncStop();
                            switchOnoffENG.RecognizeAsync(RecognizeMode.Multiple);
                            TalkBk.SpeakAsync("Username selected");
                            i = 1;
                            ignorCmd = 1;

                        }

                        break;
                    }
                case "Password":
                    {
                        if (LogInPage.Visible != false && LogInPage.pnlLogin.Visible != false && LogInPage.pnlSuccessLogin.Visible != true)
                        {
                            NeedToInsert1 = 2;
                            BtnCmmnd.RecognizeAsyncStop();
                            selectionENG.RecognizeAsyncStop();
                            switchOnoffENG.RecognizeAsync(RecognizeMode.Multiple);
                            TalkBk.SpeakAsync("Password selected");
                            i = 2;
                            ignorCmd = 1;
                            charCaseENG.RecognizeAsync(RecognizeMode.Multiple);

                        }

                        break;
                    }
                case "Go next":
                    {
                        if (LogInPage.Visible != false && LogInPage.pnlLogin.Visible != false && LogInPage.pnlSuccessLogin.Visible!=true)
                        {
                            if (LogInPage.usrnameTxt.Text != "" && LogInPage.passwordTxt.Text != "")
                            {
                                LoginAssistant = 0;
                                log();
                                ClearMails();
                                CheckInboxTm.Start();
                                lblStatus.Text = " ";
                                lblStatus.Text = "Mail Login";
                                getInfo();
                                CheckUserExist();
                                NotifyUser.Start();
                                CheckForUnread.Start();
                                if (onlyWrk == 1)
                                {
                                    AfterSuccessfulLogin();
                                    onlyWrk = 0;
                                }
                            }
                            else if (LogInPage.usrnameTxt.Text.Equals(String.Empty) && LogInPage.passwordTxt.Text.Equals(String.Empty))
                            {
                                TalkBk.SpeakAsync("Username and Password fields empty");
                            }
                        }
                        break;
                    }
                case "Readback username":
                    {
                        if (LogInPage.Visible != false && LogInPage.pnlLogin.Visible != false && LogInPage.pnlSuccessLogin.Visible != true)
                        {
                            read_username();
                        }
                        break;
                    }
                case "Readback password":
                    {
                        if (LogInPage.Visible != false && LogInPage.pnlLogin.Visible != false && LogInPage.pnlSuccessLogin.Visible != true)
                        {
                            read_password();
                        }
                        break;
                    }
                case "Clear username":
                    {
                        if (LogInPage.Visible != false && LogInPage.pnlLogin.Visible != false && LogInPage.pnlSuccessLogin.Visible != true)
                        {
                            if (LogInPage.usrnameTxt.Text!="")
                            {
                                LogInPage.usrnameTxt.Text = String.Empty;
                                TalkBk.SpeakAsync("Username field entry cleared");
                                TryCase1 = 999;
                                LoginAssistant = 1;
                                NeedToInsert = 1;
                            }
                            else if (LogInPage.usrnameTxt.Text.Equals(String.Empty))
                            {
                                TalkBk.SpeakAsync("Operation can not be done, no entry found!");
                            }
                        }
                        break;
                    }
                case "Clear password":
                    {
                        if (LogInPage.Visible != false && LogInPage.pnlLogin.Visible != false && LogInPage.pnlSuccessLogin.Visible != true)
                        {
                            if (LogInPage.passwordTxt.Text!="")
                            {
                                LogInPage.passwordTxt.Text = String.Empty;
                                TalkBk.SpeakAsync("Password field entry cleared");
                                TryCase2 = 999;
                                LoginAssistant = 2;
                                NeedToInsert1 = 1;
                            }
                            else if (LogInPage.passwordTxt.Text.Equals(String.Empty))
                            {
                                TalkBk.SpeakAsync("Operation can not be done, no entry found!");
                            }
                        }
                        break;
                    }
                case "Logout":
                    {
                        if (LogInPage.Visible != false && LogInPage.pnlSuccessLogin.Visible!=false && UserAccountSettings.Visible != true)
                        {
                            if (LogInPage.checkRemember.CheckState.Equals(CheckState.Checked))
                            {
                                LogInPage.pnlSuccessLogin.Visible = false;
                                LogInPage.pnlLogin.Visible = true;
                                LogInPage.checkRemember.Visible = true;
                                LogInPage.showHidePassBtn.Visible = true;
                                menuListBtn.Enabled = false;
                                CheckInboxTm.Stop();
                                NotifyUser.Stop();
                                CheckForUnread.Stop();
                                clearInfo();
                                ClearMails();
                                UserAccountSettings.emailID.Text = String.Empty;
                                UserAccountSettings.addNametxt.Text = String.Empty;
                                UserAccountSettings.addPic.Image = null;

                                //Closing the Slide Panel and/or menulist when logout
                                panelSlide.Width = 1;
                                panelSlide.Height = 428;
                                //-----------------------
                                topMenuSlide.Width = 1;
                                topMenuSlide.Height = 59;
                                //--------------------------
                                TalkBk.SpeakAsync("Logout successfull");
                                lblStatus.Text = " ";
                                lblStatus.Text = "Logout successfull";
                                statusTimer.Interval = 10000;
                                
                            }
                            else if (LogInPage.checkRemember.CheckState.Equals(CheckState.Unchecked))
                            {
                                LogInPage.pnlSuccessLogin.Visible = false;
                                LogInPage.pnlLogin.Visible = true;
                                LogInPage.usrnameTxt.Text = String.Empty;
                                LogInPage.passwordTxt.Text = String.Empty;
                                LogInPage.checkRemember.Visible = true;
                                LogInPage.showHidePassBtn.Visible = true;
                                menuListBtn.Enabled = false;
                                CheckInboxTm.Stop();
                                NotifyUser.Stop();
                                CheckForUnread.Stop();
                                clearInfo();
                                ClearMails();
                                UserAccountSettings.emailID.Text = String.Empty;
                                UserAccountSettings.addNametxt.Text = String.Empty;
                                UserAccountSettings.addPic.Image = null;

                                //Closing the Slide Panel and/or menulist when logout
                                panelSlide.Width = 1;
                                panelSlide.Height = 428;
                                //-----------------------
                                topMenuSlide.Width = 1;
                                topMenuSlide.Height = 59;
                                //--------------------------
                                TalkBk.SpeakAsync("Logout successfull");
                                lblStatus.Text = " ";
                                lblStatus.Text = "Logout successfull";
                                statusTimer.Interval = 10000;
                            }
                            ignorCmd = -1;
                        }
                        break;
                    }
                case "Remember this":
                    {
                        if (LogInPage.usrnameTxt.Text != "" && LogInPage.passwordTxt.Text != "" && LogInPage.pnlLogin.Visible != false && LogInPage.pnlSuccessLogin.Visible != true)
                        {
                            //LogInPage.checkRemember.CheckState = CheckState.Checked;
                            IwillRemember = 1;
                            LoginAssistant = 4;
                            TalkBk.SpeakAsync("okay! I will remember this username and password");
                        }
                        else if (LogInPage.usrnameTxt.Text.Equals(String.Empty) && LogInPage.passwordTxt.Text.Equals(String.Empty) && LogInPage.pnlLogin.Visible != false && LogInPage.pnlSuccessLogin.Visible != true)
                        {
                            TalkBk.SpeakAsync("Operation can not be done, no entry found!");
                        }
                        break;
                    }
                case "Don't remember this":
                    {
                        if (LogInPage.usrnameTxt.Text != "" && LogInPage.passwordTxt.Text != "" && LogInPage.pnlLogin.Visible != false && LogInPage.pnlSuccessLogin.Visible != true)
                        {
                            IwillRemember = 999;
                            LoginAssistant = 4;
                            LogInPage.checkRemember.CheckState = CheckState.Unchecked;
                            TalkBk.SpeakAsync("Sure! I will stop remembering this username and password");
                        }
                        else if (LogInPage.usrnameTxt.Text.Equals(String.Empty) && LogInPage.passwordTxt.Text.Equals(String.Empty) && LogInPage.pnlLogin.Visible != false && LogInPage.pnlSuccessLogin.Visible != true)
                        {
                            TalkBk.SpeakAsync("Operation can not be done, no entry found!");
                        }
                        break;
                    }

            }
        }

        private void read_password()
        {
            if (LogInPage.passwordTxt.Text != "")
            {
                TalkBk.SpeakAsync("Current password is, ");
                TalkBk.SpeakAsync(LogInPage.passwordTxt.Text);
            }
            else if (LogInPage.passwordTxt.Text == "")
            {
                TalkBk.SpeakAsync("Password field is empty");
            }
            TryCase2 = 2;
        }

        private void read_username()
        {
            if (LogInPage.usrnameTxt.Text != "")
            {
                TalkBk.SpeakAsync("Current username is, ");
                TalkBk.SpeakAsync(LogInPage.usrnameTxt.Text);
            }
            else if (LogInPage.usrnameTxt.Text == "")
            {
                TalkBk.SpeakAsync("Username field is empty");
            }
            TryCase1 = 2;
        }

        private void log()
        {
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                SqlDataAdapter As = new SqlDataAdapter("Select Count(*) From User_Info where Mail_ID='" + LogInPage.usrnameTxt.Text + "'", con);
                DataTable dt = new DataTable();
                As.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")
                {
                    UsrNm = 1;
                }
                else
                {
                    UsrNm = 0;
                }
                SqlDataAdapter As1 = new SqlDataAdapter("Select Count(*) From User_Info where Mail_ID='" + LogInPage.usrnameTxt.Text + "' and Usr_Pass='" + LogInPage.passwordTxt.Text + "'", con);
                DataTable dt1 = new DataTable();
                As1.Fill(dt1);
                if (dt1.Rows[0][0].ToString() == "1")
                {
                    UsrPs = 1;
                }
                else
                {
                    UsrPs = 0;
                }
                ProcedToLogin();
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
            }
        }

        private void ProcedToLogin()
        {
            if (UsrNm == 1 && UsrPs == 1)
            {
                LoginAssistant = 999;
                LogHelpAssistant.Stop();
                if (IwillRemember == 1 && IwillRemember != 999)
                {
                    LogInPage.checkRemember.CheckState = CheckState.Checked;
                    IwillRemember = 999;
                }
                TalkBk.SpeakAsync("login successfull");
                statusTimer.Interval = 1500;
                LogInPage.pnlSuccessLogin.Visible = true;
                LogInPage.lblUsrNm.Text = LogInPage.usrnameTxt.Text.ToString();
                LogInPage.chkLbl.Visible = false;
                LogInPage.checkRemember.Visible = false;
                LogInPage.showHidePassBtn.Visible = false;
                LogInPage.showHidePassBtn.BackgroundImage = Properties.Resources.hidePass;
                LogInPage.passwordTxt.PasswordChar = '\u25CF';

                if (ignorCmd == 1)
                {
                    BtnCmmnd.RecognizeAsync(RecognizeMode.Multiple);
                }
                menuListBtn.Enabled = true;

                //opening the topSlideMenu after login
                topMenuSlide.Width = 627;
                topMenuSlide.Height = 59;
                //-----------------------
                lblStatus.Text = " ";
                lblStatus.Text = "Login successfull!";
            }
            else if (UsrNm == 1 && UsrPs == 0)
            {
                LogInPage.chkLbl.Text = "Incorrect password!";
                LogInPage.chkLbl.Visible = true;
                TalkBk.SpeakAsync("Incorrect password inserted");
                LoginAssistant = 6;
                TryCase2 = 1;

            }
            else if (UsrNm == 0 && UsrPs == 0)
            {
                LogInPage.chkLbl.Text = "Incorrect username!";
                LogInPage.chkLbl.Visible = true;
                TalkBk.SpeakAsync("Incorrect username inserted");
                LoginAssistant = 5;
                TryCase1 = 1;
                
            }
        }

        void BtnCmmnd_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            switch (e.Result.Text.ToString())
            {
                case "Select login":
                    {
                        CmndLogin();
                        lblStatus.Text = " ";
                        lblStatus.Text = "Login selected";
                        TalkBk.SpeakAsync("Login tab visible");
                        if (LogInPage.usrnameTxt.Text != String.Empty && LogInPage.passwordTxt.Text != String.Empty)
                        {
                            if (IfSaidNo == 1 && LogInPage.checkRemember.CheckState == CheckState.Checked && LogInPage.pnlSuccessLogin.Visible != true)
                            {
                                TalkBk.SpeakAsync("username and password found, you can proceed to login");
                                //IfSaidNo = 0;
                            }
                        }
                        else
                        {
                            TalkBk.SpeakAsync("username and password fields are empty");
                        }
                        if (UserAsstOptChoose1 == 2)
                        {
                            UserAsstOptChoose1 = 0;
                            AfterSuccessfulLogin();
                        }
                        break;
                    }
                case "Open compose tab":
                    {

                        if (menuListBtn.Enabled != true)
                        {
                            TalkBk.SpeakAsync("You need to login first");
                        }
                        else if (menuListBtn.Enabled != false && panelSlide.Width == 1 && panelSlide.Height == 428)
                        {

                            if (InboxMailLoad.Visible != false || SentMailsLoad.Visible != false || DraftMailsLoad.Visible != false)
                            {
                                CmndCompose();
                                lblStatus.Text = " ";
                                lblStatus.Text = "CompBox opened";
                                TalkBk.SpeakAsync("Compose tab opened");
                                BtnCmmnd.RecognizeAsyncStop();
                                if (UserAsstOptChoose1 == 1)
                                {
                                    UserAsstCompoHelp();
                                }
                                else
                                {
                                    selectionENG1.RecognizeAsync(RecognizeMode.Multiple);
                                }
                                uniqPermission1 = 11;
                            }
                            else
                            {
                                TalkBk.SpeakAsync("Select inbox, sentitems, or draftbox first");
                            }
                        }

                        break;
                    }
                case "Close compose tab":
                    {
                        if (panelSlide.Width == 379 && panelSlide.Height == 428 && menuListBtn.Enabled == true)
                        {
                            CmndCompose();
                            lblStatus.Text = " ";
                            lblStatus.Text = "CompBox closed";
                            TalkBk.SpeakAsync("Compose tab closed");
                        }
                        break;
                    }
                case "Select inbox":
                    {
                        if (menuListBtn.Enabled != true)
                        {
                            TalkBk.SpeakAsync("You need to login first");
                        }
                        else if (menuListBtn.Enabled != false)
                        {
                            CmndInbox();
                            lblStatus.Text = " ";
                            lblStatus.Text = "Inbox opened";
                            TalkBk.SpeakAsync("Inbox opened");
                            UsrNotifictn.BackgroundImage = Properties.Resources._003_notification;
                            notificationLbl.Visible = false;
                            ResetMailCount();
                            NotifyUser.Start();
                            //sp.Stop();
                            UsRAsstFallBk();
                        }
                        break;
                    }
                case "Select sent items":
                    {
                        if (menuListBtn.Enabled != true)
                        {
                            TalkBk.SpeakAsync("You need to login first");
                        }
                        else if (menuListBtn.Enabled != false)
                        {
                            CmndSentMails();
                            lblStatus.Text = " ";
                            lblStatus.Text = "SentItems opened";
                            TalkBk.SpeakAsync("Sent items opened");
                        }
                        break;
                    }
                case "Select draft":
                    {
                        if (menuListBtn.Enabled != true)
                        {
                            TalkBk.SpeakAsync("You need to login first");
                        }
                        else if (menuListBtn.Enabled != false)
                        {
                            CmndDraft();
                            lblStatus.Text = " ";
                            lblStatus.Text = "Draftbox opened";
                            TalkBk.SpeakAsync("Draftbox opened");
                        }
                        break;
                    }
                case "Select settings":
                    {
                        CmndSettings();
                        if (menuListBtn.Enabled != false)
                        {
                            lblStatus.Text = " ";
                            lblStatus.Text = "Settings opened";
                        }
                        TalkBk.SpeakAsync("Settings tab opened");
                        break;
                    }
                case "Select home tab":
                    {
                        CmndHome();
                        if (menuListBtn.Enabled != false)
                        {
                            lblStatus.Text = " ";
                            lblStatus.Text = "HomeTab opened";
                        }
                        TalkBk.SpeakAsync("Home tab visible");
                        break;
                    }
                case "What time is it now?":
                    {
                        TalkBk.SpeakAsync("It is now ," + DateTime.Now.ToShortTimeString());
                        break;
                    }
                case "What is the date today?":
                    {
                        TalkBk.SpeakAsync("It is ," + DateTime.Now.ToLongDateString());
                        break;
                    }
                case "That's all for now":
                    {
                        EventHandler handler = OnTerminated;
                        if (handler != null)
                        {
                            handler(this, new EventArgs());
                        }
                        BtnCmmnd.RecognizeAsyncStop();
                        selectionENG.RecognizeAsyncStop();
                        TalkBk.SpeakAsync("Okay, I understand");
                        lblStatus.Text = " ";
                        lblStatus.Text = "Hmmm...!";
                        statusTimer.Interval = 10000;
                        statusTimer.Stop();
                        break;
                    }
                case "Open account settings":
                    {
                        UASOpen();
                        if (menuListBtn.Enabled != false)
                        {
                            lblStatus.Text = " ";
                            lblStatus.Text = "A.S Opened";
                            TalkBk.SpeakAsync("Account settings opened");
                        }
                        
                        break;
                    }
                case "Close account settings":
                    {
                        UASClose();
                        if (menuListBtn.Enabled != false)
                        { 
                            lblStatus.Text = " ";
                            lblStatus.Text = "A.S Closed";
                            TalkBk.SpeakAsync("Account settings Closed");
                        }
                        
                        break;
                    }
                case "Reset notification":
                    {
                        if (notificationLbl.Visible == true && menuListBtn.Enabled != false)
                        {
                            CmndInbox();
                            UsrNotifictn.BackgroundImage = Properties.Resources._003_notification;
                            notificationLbl.Visible = false;
                            ResetMailCount();
                            NotifyUser.Start();
                            TalkBk.SpeakAsync("Notification reset");
                            lblStatus.Text = " ";
                            lblStatus.Text = "Resetting";
                        }
                        break;
                    }
                case "Enable inbox":
                    {
                        if (menuListBtn.Enabled != false && InboxMailLoad.Visible != false)
                        {
                            TalkBk.SpeakAsync("Inbox operation enabled");
                            BtnCmmnd.RecognizeAsyncStop();
                            InboxOperation.RecognizeAsync(RecognizeMode.Multiple);
                            lblStatus.Text = " ";
                            lblStatus.Text = "I.O. enabled";
                        }
                        break;
                    }
                case "Enable sentitems":
                    {
                        if (menuListBtn.Enabled != false && SentMailsLoad.Visible != false)
                        {
                            TalkBk.SpeakAsync("Sent items operation enabled");
                            BtnCmmnd.RecognizeAsyncStop();
                            SentItemsOperation.RecognizeAsync(RecognizeMode.Multiple);
                            lblStatus.Text = " ";
                            lblStatus.Text = "S.I.O. enabled";
                        }
                        break;
                    }
                case "Enable draft":
                    {
                        if (menuListBtn.Enabled != false && DraftMailsLoad.Visible != false)
                        {
                            TalkBk.SpeakAsync("Draft operation enabled");
                            BtnCmmnd.RecognizeAsyncStop();
                            DraftOperation.RecognizeAsync(RecognizeMode.Multiple);
                            lblStatus.Text = " ";
                            lblStatus.Text = "D.O enabled";
                        }
                        break;
                    }
                case "Select unread mails":
                    {
                        if (InboxUnreadMailslbl.Visible != false && menuListBtn.Enabled != false)
                        {
                            CheckInboxTm.Stop();
                            InboxLBLRefresh();
                            InboxUnread();
                            TalkBk.SpeakAsync("Unread mails selected");
                            lblStatus.Text = " ";
                            lblStatus.Text = "U.M. selected";
                        }
                        break;
                    }
                case "Deselect unread mails":
                    {
                        if (InboxUnreadMailslbl.Visible != false && menuListBtn.Enabled != false)
                        {
                            CheckInboxTm.Start();
                            TalkBk.SpeakAsync("Unread mails de selected");
                            lblStatus.Text = " ";
                            lblStatus.Text = "U.M. deselected";
                        }
                        break;
                    }
            }
        }

        private void UserAsstCompoHelp()
        {
                UserAsstOptChoose1 = 0;
                TalkBk.SpeakAsync("Do you really want to write a new mail? say 'yes' or 'no'");

                UserRSP4.Add(new string[] { "Yes", "No" });
                GrammarBuilder GB = new GrammarBuilder();
                GB.Append(UserRSP4);
                Grammar gr = new Grammar(GB);
                try
                {
                    UserRSPeng4.LoadGrammar(gr);
                    UserRSPeng4.SetInputToDefaultAudioDevice();
                    UserRSPeng4.RecognizeAsync(RecognizeMode.Multiple);
                    UserRSPeng4.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(UserRSPeng4_SpeechRecognized);

                }
                catch (Exception ex)
                {
                    //Error handle method
                }    
        }

        void UserRSPeng4_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            switch (e.Result.Text.ToString())
            {
                case "Yes":
                    {
                        TalkBk.SpeakAsync("Okay");
                        UserRSPeng4.RecognizeAsyncStop();
                        selectionENG1.RecognizeAsync(RecognizeMode.Multiple);
                        //Need to add assist functionality
                        break;
                    }
                case "No":
                    {
                        TalkBk.SpeakAsync("Alright");
                        UserRSPeng4.RecognizeAsyncStop();
                        if (panelSlide.Width == 379 && panelSlide.Height == 428 && menuListBtn.Enabled == true)
                        {
                            CmndCompose();
                            lblStatus.Text = " ";
                            lblStatus.Text = "CompBox closed";
                            TalkBk.SpeakAsync("Compose tab closed and inbox selected");
                        }
                        UserAsstOptChoose = 1;
                        UsRAsstFallBk();
                        ShutUp = 1;
                        uniqPermission5 = 1;
                        //BtnCmmnd.RecognizeAsync(RecognizeMode.Multiple);
                        break;
                    }
            }
        }

        private void UsRAsstFallBk()
        {
            if (UserAsstOptChoose == 1)
            {
                UserAsstOptChoose = 0;
                TalkBk.SpeakAsync("Here you have three options available, ");
                TalkBk.SpeakAsync("Option one, Write a new mail");
                TalkBk.SpeakAsync("Option two, Do inbox operations");
                TalkBk.SpeakAsync("Option three, Go back to login tab");
                TalkBk.SpeakAsync("Say 'choose option', with the following number of option you want");

                UserRSP3.Add(new string[] { "choose option 1", "choose option 2", "choose option 3" });
                GrammarBuilder GB = new GrammarBuilder();
                GB.Append(UserRSP3);
                Grammar gr = new Grammar(GB);
                try
                {
                    UserRSPeng3.LoadGrammar(gr);
                    UserRSPeng3.SetInputToDefaultAudioDevice();
                    UserRSPeng3.RecognizeAsync(RecognizeMode.Multiple);
                    UserRSPeng3.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(UserRSPeng3_SpeechRecognized);

                }
                catch (Exception ex)
                {
                    //Error handle method
                }
            } 
        }

        void UserRSPeng3_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {

            if (e.Result.Text.Equals("choose option 1"))
            {
                
                UserAsstOptChoose1 = 1;
                UserRSPeng3.RecognizeAsyncStop();
                if (ShutUp == 1)
                {
                    TalkBk.SpeakAsync("okay, say 'Open compose tab'");
                    ShutUp++;
                }
                if (uniqPermission5 == 1)
                {
                    uniqPermission5 = 0;
                    BtnCmmnd.RecognizeAsync(RecognizeMode.Multiple);
                }

            }
            else if (e.Result.Text.Equals("choose option 2"))
            {
                UserRSPeng3.RecognizeAsyncStop();
                if (ShutUp == 1)
                {
                    TalkBk.SpeakAsync("okay, say 'Enable inbox'");
                    ShutUp++;
                }
                if (uniqPermission5 == 1)
                {
                    uniqPermission5 = 0;
                    BtnCmmnd.RecognizeAsync(RecognizeMode.Multiple);
                }
            }
            else if (e.Result.Text.Equals("choose option 3"))
            {
                UserRSPeng3.RecognizeAsyncStop();
                if (ShutUp == 1)
                {
                    TalkBk.SpeakAsync("okay, say 'Select login'");
                    ShutUp++;
                }
                if (uniqPermission5 == 1)
                {
                    uniqPermission5 = 0;
                    BtnCmmnd.RecognizeAsync(RecognizeMode.Multiple);
                }
            }
        }

        private void LogChechk()
        {
            //LogInPage.Visible = true;
            //btnLogin.ForeColor = ColorTranslator.FromHtml("#00aaff");
            homePage.Visible = true;
            LogInPage.Visible = false;
            InboxMailLoad.Visible = false;
            SentMailsLoad.Visible = false;
            DraftMailsLoad.Visible = false;
            UI_Settings.Visible = false;

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            CmndLogin();
        }
        private void btnInbox_Click(object sender, EventArgs e)
        {
            CmndInbox();
            UsrNotifictn.BackgroundImage = Properties.Resources._003_notification;
            notificationLbl.Visible = false;
            ResetMailCount();
            NotifyUser.Start();
            //sp.Stop();
        }
        private void btnCompose_Click(object sender, EventArgs e)
        {
            if (panelSlide.Width == 379 && panelSlide.Height == 428 && menuListBtn.Enabled == true && homePage.Visible == false && UI_Settings.Visible == false && LogInPage.Visible == false && UserAccountSettings.Visible == false)
            {
                selectionENG.RecognizeAsyncStop();
                selectionENG1.RecognizeAsyncStop();
            }
            CmndCompose();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            CmndSentMails();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            CmndDraft();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            CmndSettings();
        }
        private void HomeBtn_Click(object sender, EventArgs e)
        {
            CmndHome();
        }

        void LogInPage_OnButtonClickClosed(object sender, EventArgs e)
        {
            menuListBtn.Enabled = false;
            CheckInboxTm.Stop();
            NotifyUser.Stop();
            CheckForUnread.Stop();
            clearInfo();
            ClearMails();
            UserAccountSettings.emailID.Text = String.Empty;
            UserAccountSettings.addNametxt.Text = String.Empty;
            UserAccountSettings.addPic.Image = null;
            //Closing the Slide Panel and/or menulist when logout
            panelSlide.Width = 1;
            panelSlide.Height = 428;
            //-----------------------
            topMenuSlide.Width = 1;
            topMenuSlide.Height = 59;
            //--------------------------

        }

        private void ClearMails()
        {
            //Clearing inbox
            InboxMailLoad.lbl1.Text = String.Empty;
            InboxMailLoad.lbl2.Text = String.Empty;
            InboxMailLoad.lbl3.Text = String.Empty;
            InboxMailLoad.lbl4.Text = String.Empty;
            InboxMailLoad.lbl5.Text = String.Empty;
            InboxMailLoad.lbl6.Text = String.Empty;
            InboxMailLoad.lbl7.Text = String.Empty;
            InboxMailLoad.lbl8.Text = String.Empty;
            InboxMailLoad.lbl9.Text = String.Empty;
            InboxMailLoad.lbl10.Text = String.Empty;
            InboxMailLoad.lbl11.Text = String.Empty;
            InboxMailLoad.lbl12.Text = String.Empty;
            InboxMailLoad.lbl13.Text = String.Empty;
            InboxMailLoad.lbl14.Text = String.Empty;
            InboxMailLoad.lbl15.Text = String.Empty;
            //Clearing sent items
            SentMailsLoad.lbl1.Text = String.Empty;
            SentMailsLoad.lbl2.Text = String.Empty;
            SentMailsLoad.lbl3.Text = String.Empty;
            SentMailsLoad.lbl4.Text = String.Empty;
            SentMailsLoad.lbl5.Text = String.Empty;
            SentMailsLoad.lbl6.Text = String.Empty;
            SentMailsLoad.lbl7.Text = String.Empty;
            SentMailsLoad.lbl8.Text = String.Empty;
            SentMailsLoad.lbl9.Text = String.Empty;
            SentMailsLoad.lbl10.Text = String.Empty;
            SentMailsLoad.lbl11.Text = String.Empty;
            SentMailsLoad.lbl12.Text = String.Empty;
            SentMailsLoad.lbl13.Text = String.Empty;
            SentMailsLoad.lbl14.Text = String.Empty;
            SentMailsLoad.lbl15.Text = String.Empty;
            //Clearing draft
            DraftMailsLoad.lbl1.Text = String.Empty;
            DraftMailsLoad.lbl2.Text = String.Empty;
            DraftMailsLoad.lbl3.Text = String.Empty;
            DraftMailsLoad.lbl4.Text = String.Empty;
            DraftMailsLoad.lbl5.Text = String.Empty;
            DraftMailsLoad.lbl6.Text = String.Empty;
            DraftMailsLoad.lbl7.Text = String.Empty;
            DraftMailsLoad.lbl8.Text = String.Empty;
            DraftMailsLoad.lbl9.Text = String.Empty;
            DraftMailsLoad.lbl10.Text = String.Empty;
            DraftMailsLoad.lbl11.Text = String.Empty;
            DraftMailsLoad.lbl12.Text = String.Empty;
            DraftMailsLoad.lbl13.Text = String.Empty;
            DraftMailsLoad.lbl14.Text = String.Empty;
            DraftMailsLoad.lbl15.Text = String.Empty;
        }

        private void clearInfo()
        {
            label3.Text = String.Empty;
            label9.Text = String.Empty;
            pictureBox3.Image = null;
        }

        void LogInPage_OnButtonClicked(object sender, EventArgs e)
        {
            menuListBtn.Enabled = true;
            ClearMails();
            CheckInboxTm.Start();
            getInfo();
            CheckUserExist();
            NotifyUser.Start();
            CheckForUnread.Start();

            //opening the topSlideMenu after login
            topMenuSlide.Width = 627;
            topMenuSlide.Height = 59;
            //-----------------------
        }

        private void CheckUserExist()
        {
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                SqlDataAdapter As = new SqlDataAdapter("Select Count(*) From Inbox_Notify where [User]='" + currentUser + "'", con);
                DataTable dt = new DataTable();
                As.Fill(dt);

                if (dt.Rows[0][0].ToString() != "1")
                {
                    con.Close();
                    CreateUser();
                }
                else //if (dt.Rows[0][0].ToString() == "1")
                {
                    con.Close();
                }
                
            }
            catch (Exception ex)
            {
                con.Close();
            }
        }

        private void CreateUser()
        {
            int temp = 0;
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                cmd.Connection = con;
                cmd.CommandText = "insert into Inbox_Notify ([User],Mail_Count) values ('" + currentUser + "','" + temp + "')";
                cmd.ExecuteNonQuery();
                cmd.Clone();
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
            }
        }

        private void getInfo()
        {
            string user = LogInPage.lblUsrNm.Text.ToString();
            currentUser = user;
            label9.Text = user;
            UserAccountSettings.emailID.Text = user;
            InboxMailLoad.CurrentUser = user;
            SentMailsLoad.CurrentUser = user;
            DraftMailsLoad.CurrentUser = user;

            UserAccountSettings.addNametxt.Text = String.Empty;
            UserAccountSettings.addPic.Image = null;

            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                cmd.Connection = con;
                cmd.CommandText = "select Usr_Name,Usr_Image from User_Info where Mail_ID='" + currentUser + "'";
                cmd.ExecuteNonQuery();
                cmd.Clone();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    label3.Text = sdr[0].ToString();
                    UserAccountSettings.addNametxt.Text = sdr[0].ToString();
                    byte[] img = (byte[])(sdr[1]);
                    if (img == null)
                    {
                        pictureBox3.Image = null;
                        UserAccountSettings.addPic.Image = null;
                    }
                    else
                    {
                        MemoryStream ms = new MemoryStream(img);
                        pictureBox3.Image = Image.FromStream(ms);
                        UserAccountSettings.addPic.Image = Image.FromStream(ms);
                    }

                }
                con.Close();
                //inboxMail();
                //sentItemsMails();
                //draftMails();
            }
            catch (Exception ex)
            {
                con.Close();
            }
        }

        //TitleBar mouse Control Events start
        private void TitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            TogMove = 1;
            MValX = e.X;
            MValY = e.Y;
        }

        private void TitleBar_MouseUp(object sender, MouseEventArgs e)
        {
            TogMove = 0;
        }

        private void TitleBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (TogMove == 1)
            {
                this.SetDesktopLocation(MousePosition.X - MValX, MousePosition.Y - MValY);
                this.Update();
            }
        }
        //TitleBar mouse Control Events Stop

        private void CmndLogin()
        {
            //Button style...........................................
            btnLogin.ForeColor = ColorTranslator.FromHtml("#00aaff");
            btnInbox.ForeColor = ColorTranslator.FromHtml("#ffffff");
            btnCompose.ForeColor = ColorTranslator.FromHtml("#ffffff");
            btnSentMails.ForeColor = ColorTranslator.FromHtml("#ffffff");
            btnDraft.ForeColor = ColorTranslator.FromHtml("#ffffff");
            btnSettings.ForeColor = ColorTranslator.FromHtml("#ffffff");
            //Button style...........................................

         
            LogInPage.Visible = true;
            InboxMailLoad.Visible = false;
            SentMailsLoad.Visible = false;
            DraftMailsLoad.Visible = false;
            UI_Settings.Visible = false;
            homePage.Visible = false;
            UserAccountSettings.Visible = false;

            //Closing the compose box if open?------------------------
            if (panelSlide.Width == 379 && panelSlide.Height == 428 && menuListBtn.Enabled == true)
            {
                panelSlide.Width = 1;
                panelSlide.Height = 428;
            }//---------------------------------------------------------

            //Opening the top menu------------------------------------
            if (topMenuSlide.Width == 1 && topMenuSlide.Height == 59 && menuListBtn.Enabled == true)
            {
                topMenuSlide.Width = 627;
                topMenuSlide.Height = 59;
            }//------------------------------------------------------
        }


        private void CmndInbox()
        {
            //Button Style...........................................
            btnInbox.ForeColor = ColorTranslator.FromHtml("#00aaff");
            btnLogin.ForeColor = ColorTranslator.FromHtml("#ffffff");
            btnCompose.ForeColor = ColorTranslator.FromHtml("#ffffff");
            btnSentMails.ForeColor = ColorTranslator.FromHtml("#ffffff");
            btnDraft.ForeColor = ColorTranslator.FromHtml("#ffffff");
            btnSettings.ForeColor = ColorTranslator.FromHtml("#ffffff");
            //Button Style...........................................
            if (menuListBtn.Enabled != false)
            {
                CountUserMail_Inbox();
                inboxMail();
                InboxMailLoad.lblLocation.Text = "Inbox Mails";
                InboxMailLoad.Visible = true;
                LogInPage.Visible = false;
                SentMailsLoad.Visible = false;
                DraftMailsLoad.Visible = false;
                UI_Settings.Visible = false;
                homePage.Visible = false;
                UserAccountSettings.Visible = false;

            }
            //Closing the compose box if open?------------------------
            if (panelSlide.Width == 379 && panelSlide.Height == 428 && menuListBtn.Enabled == true)
            {
                panelSlide.Width = 1;
                panelSlide.Height = 428;
            }//---------------------------------------------------------

            //Opening the top menu------------------------------------
            if (topMenuSlide.Width == 1 && topMenuSlide.Height == 59 && menuListBtn.Enabled == true)
            {
                topMenuSlide.Width = 627;
                topMenuSlide.Height = 59;
            }//------------------------------------------------------
        }

        private void inboxMail()
        {
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                SqlDataAdapter sda = new SqlDataAdapter("Select [From],Subject,Body,Attachment,Serial,ReadStatus From Inbox where [To]='" + currentUser + "'", con);
                InboxData = new DataTable();
                sda.Fill(InboxData);
                dataGridView.DataSource = InboxData;
                int index = inbx;
                DataGridViewRow row = new DataGridViewRow();
                //----------------------------------------------
                row = this.dataGridView.Rows[index];
                InboxMailLoad.lbl1.Text = "From: " + row.Cells["From"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                InboxMailLoad.x1 = row.Cells["Serial"].Value.ToString();
                InboxMailLoad.rd1 = row.Cells["ReadStatus"].Value.ToString();
                if (InboxMailLoad.rd1 == "0")
                {
                    InboxMailLoad.lbl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
                else if (InboxMailLoad.rd1 == "1")
                {
                    InboxMailLoad.lbl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }

                row = this.dataGridView.Rows[index -= 1];
                InboxMailLoad.lbl2.Text = "From: " + row.Cells["From"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                InboxMailLoad.x2 = row.Cells["Serial"].Value.ToString();
                InboxMailLoad.rd2 = row.Cells["ReadStatus"].Value.ToString();
                if (InboxMailLoad.rd2 == "0")
                {
                    InboxMailLoad.lbl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
                else if (InboxMailLoad.rd2 == "1")
                {
                    InboxMailLoad.lbl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }

                row = this.dataGridView.Rows[index -= 1];
                InboxMailLoad.lbl3.Text = "From: " + row.Cells["From"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                InboxMailLoad.x3 = row.Cells["Serial"].Value.ToString();
                InboxMailLoad.rd3 = row.Cells["ReadStatus"].Value.ToString();
                if (InboxMailLoad.rd3 == "0")
                {
                    InboxMailLoad.lbl3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
                else if (InboxMailLoad.rd3 == "1")
                {
                    InboxMailLoad.lbl3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }

                row = this.dataGridView.Rows[index -= 1];
                InboxMailLoad.lbl4.Text = "From: " + row.Cells["From"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                InboxMailLoad.x4 = row.Cells["Serial"].Value.ToString();
                InboxMailLoad.rd4 = row.Cells["ReadStatus"].Value.ToString();
                if (InboxMailLoad.rd4 == "0")
                {
                    InboxMailLoad.lbl4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
                else if (InboxMailLoad.rd4 == "1")
                {
                    InboxMailLoad.lbl4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }

                row = this.dataGridView.Rows[index -= 1];
                InboxMailLoad.lbl5.Text = "From: " + row.Cells["From"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                InboxMailLoad.x5 = row.Cells["Serial"].Value.ToString();
                InboxMailLoad.rd5 = row.Cells["ReadStatus"].Value.ToString();
                if (InboxMailLoad.rd5 == "0")
                {
                    InboxMailLoad.lbl5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
                else if (InboxMailLoad.rd5 == "1")
                {
                    InboxMailLoad.lbl5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }

                row = this.dataGridView.Rows[index -= 1];
                InboxMailLoad.lbl6.Text = "From: " + row.Cells["From"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                InboxMailLoad.x6 = row.Cells["Serial"].Value.ToString();
                InboxMailLoad.rd6 = row.Cells["ReadStatus"].Value.ToString();
                if (InboxMailLoad.rd6 == "0")
                {
                    InboxMailLoad.lbl6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
                else if (InboxMailLoad.rd6 == "1")
                {
                    InboxMailLoad.lbl6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }

                row = this.dataGridView.Rows[index -= 1];
                InboxMailLoad.lbl7.Text = "From: " + row.Cells["From"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                InboxMailLoad.x7 = row.Cells["Serial"].Value.ToString();
                InboxMailLoad.rd7 = row.Cells["ReadStatus"].Value.ToString();
                if (InboxMailLoad.rd7 == "0")
                {
                    InboxMailLoad.lbl7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
                else if (InboxMailLoad.rd7 == "1")
                {
                    InboxMailLoad.lbl7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }

                row = this.dataGridView.Rows[index -= 1];
                InboxMailLoad.lbl8.Text = "From: " + row.Cells["From"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                InboxMailLoad.x8 = row.Cells["Serial"].Value.ToString();
                InboxMailLoad.rd8 = row.Cells["ReadStatus"].Value.ToString();
                if (InboxMailLoad.rd8 == "0")
                {
                    InboxMailLoad.lbl8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
                else if (InboxMailLoad.rd8 == "1")
                {
                    InboxMailLoad.lbl8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }

                row = this.dataGridView.Rows[index -= 1];
                InboxMailLoad.lbl9.Text = "From: " + row.Cells["From"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                InboxMailLoad.x9 = row.Cells["Serial"].Value.ToString();
                InboxMailLoad.rd9 = row.Cells["ReadStatus"].Value.ToString();
                if (InboxMailLoad.rd9 == "0")
                {
                    InboxMailLoad.lbl9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
                else if (InboxMailLoad.rd9 == "1")
                {
                    InboxMailLoad.lbl9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }

                row = this.dataGridView.Rows[index -= 1];
                InboxMailLoad.lbl10.Text = "From: " + row.Cells["From"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                InboxMailLoad.x10 = row.Cells["Serial"].Value.ToString();
                InboxMailLoad.rd10 = row.Cells["ReadStatus"].Value.ToString();
                if (InboxMailLoad.rd10 == "0")
                {
                    InboxMailLoad.lbl10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
                else if (InboxMailLoad.rd10 == "1")
                {
                    InboxMailLoad.lbl10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }

                row = this.dataGridView.Rows[index -= 1];
                InboxMailLoad.lbl11.Text = "From: " + row.Cells["From"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                InboxMailLoad.x11 = row.Cells["Serial"].Value.ToString();
                InboxMailLoad.rd11 = row.Cells["ReadStatus"].Value.ToString();
                if (InboxMailLoad.rd11 == "0")
                {
                    InboxMailLoad.lbl11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
                else if (InboxMailLoad.rd11 == "1")
                {
                    InboxMailLoad.lbl11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }

                row = this.dataGridView.Rows[index -= 1];
                InboxMailLoad.lbl12.Text = "From: " + row.Cells["From"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                InboxMailLoad.x12 = row.Cells["Serial"].Value.ToString();
                InboxMailLoad.rd12 = row.Cells["ReadStatus"].Value.ToString();
                if (InboxMailLoad.rd12 == "0")
                {
                    InboxMailLoad.lbl12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
                else if (InboxMailLoad.rd12 == "1")
                {
                    InboxMailLoad.lbl12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }

                row = this.dataGridView.Rows[index -= 1];
                InboxMailLoad.lbl13.Text = "From: " + row.Cells["From"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                InboxMailLoad.x13 = row.Cells["Serial"].Value.ToString();
                InboxMailLoad.rd13 = row.Cells["ReadStatus"].Value.ToString();
                if (InboxMailLoad.rd13 == "0")
                {
                    InboxMailLoad.lbl13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
                else if (InboxMailLoad.rd13 == "1")
                {
                    InboxMailLoad.lbl13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }

                row = this.dataGridView.Rows[index -= 1];
                InboxMailLoad.lbl14.Text = "From: " + row.Cells["From"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                InboxMailLoad.x14 = row.Cells["Serial"].Value.ToString();
                InboxMailLoad.rd14 = row.Cells["ReadStatus"].Value.ToString();
                if (InboxMailLoad.rd14 == "0")
                {
                    InboxMailLoad.lbl14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
                else if (InboxMailLoad.rd14 == "1")
                {
                    InboxMailLoad.lbl14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }

                row = this.dataGridView.Rows[index -= 1];
                InboxMailLoad.lbl15.Text = "From: " + row.Cells["From"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                InboxMailLoad.x15 = row.Cells["Serial"].Value.ToString();
                InboxMailLoad.rd15 = row.Cells["ReadStatus"].Value.ToString();
                if (InboxMailLoad.rd15 == "0")
                {
                    InboxMailLoad.lbl15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
                else if (InboxMailLoad.rd15 == "1")
                {
                    InboxMailLoad.lbl15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
                //--------------------------------------------------
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
                //MessageBox.Show(ex.Message);
            }
        }

        private void CountUserMail_Inbox()
        {
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                SqlCommand sc = new SqlCommand("Select Count([To]) from Inbox where [To]='" + currentUser + "'", con);
                ii = Convert.ToInt32(sc.ExecuteScalar());
                inbx = ii - 1;
                InboxMailLoad.amounttxt.Text = ii.ToString();
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
                //MessageBox.Show(ex.Message);
            }
        }


        private void CmndCompose()
        {
            
            //Button Style..........................................
            btnCompose.ForeColor = ColorTranslator.FromHtml("#00aaff");
            btnLogin.ForeColor = ColorTranslator.FromHtml("#ffffff");
            btnInbox.ForeColor = ColorTranslator.FromHtml("#ffffff");
            btnSentMails.ForeColor = ColorTranslator.FromHtml("#ffffff");
            btnDraft.ForeColor = ColorTranslator.FromHtml("#ffffff");
            btnSettings.ForeColor = ColorTranslator.FromHtml("#ffffff");
            //Button Style..........................................

            if (panelSlide.Width == 1 && panelSlide.Height == 428 && menuListBtn.Enabled == true && homePage.Visible == false && UI_Settings.Visible == false && LogInPage.Visible == false && UserAccountSettings.Visible == false)
            {
                panelSlide.Width = 379;
                panelSlide.Height = 428;
            }
            else if (panelSlide.Width == 379 && panelSlide.Height == 428 && menuListBtn.Enabled == true && homePage.Visible == false && UI_Settings.Visible == false && LogInPage.Visible == false && UserAccountSettings.Visible == false)
            {
                btnCompose.ForeColor = ColorTranslator.FromHtml("#ffffff");
                panelSlide.Width = 1;
                panelSlide.Height = 428;
            }
        }

        private void CmndSentMails()
        {
            //button style---------------------------------------
            btnSentMails.ForeColor = ColorTranslator.FromHtml("#00aaff");
            btnLogin.ForeColor = ColorTranslator.FromHtml("#ffffff");
            btnInbox.ForeColor = ColorTranslator.FromHtml("#ffffff");
            btnCompose.ForeColor = ColorTranslator.FromHtml("#ffffff");
            btnDraft.ForeColor = ColorTranslator.FromHtml("#ffffff");
            btnSettings.ForeColor = ColorTranslator.FromHtml("#ffffff");
            //button style---------------------------------------

            if (menuListBtn.Enabled != false)
            {
                CountUserMail_SM();
                sentItemsMails();   
                SentMailsLoad.lblLocation.Text = "Sent Mails";
                SentMailsLoad.Visible = true;
                LogInPage.Visible = false;
                InboxMailLoad.Visible = false;
                DraftMailsLoad.Visible = false;
                UI_Settings.Visible = false;
                homePage.Visible = false;
                UserAccountSettings.Visible = false;

            }
            //Closing the compose box if open?------------------------
            if (panelSlide.Width == 379 && panelSlide.Height == 428 && menuListBtn.Enabled == true)
            {
                panelSlide.Width = 1;
                panelSlide.Height = 428;
            }//---------------------------------------------------------

            //Opening the top menu------------------------------------
            if (topMenuSlide.Width == 1 && topMenuSlide.Height == 59 && menuListBtn.Enabled == true)
            {
                topMenuSlide.Width = 627;
                topMenuSlide.Height = 59;
            }//------------------------------------------------------
        }

        private void sentItemsMails()
        {
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                SqlDataAdapter sda = new SqlDataAdapter("Select [To],Subject,Body,Attachment,Serial From SentItems where [From]='" + currentUser + "'", con);
                SentData = new DataTable();
                sda.Fill(SentData);
                dataGridView.DataSource = SentData;
                int index = sntm;
                DataGridViewRow row = new DataGridViewRow();
                //----------------------------------------------
                row = this.dataGridView.Rows[index];
                SentMailsLoad.lbl1.Text = "To: " + row.Cells["To"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                SentMailsLoad.x1 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index -= 1];
                SentMailsLoad.lbl2.Text = "To: " + row.Cells["To"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                SentMailsLoad.x2 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index -= 1];
                SentMailsLoad.lbl3.Text = "To: " + row.Cells["To"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                SentMailsLoad.x3 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index -= 1];
                SentMailsLoad.lbl4.Text = "To: " + row.Cells["To"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                SentMailsLoad.x4 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index -= 1];
                SentMailsLoad.lbl5.Text = "To: " + row.Cells["To"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                SentMailsLoad.x5 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index -= 1];
                SentMailsLoad.lbl6.Text = "To: " + row.Cells["To"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                SentMailsLoad.x6 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index -= 1];
                SentMailsLoad.lbl7.Text = "To: " + row.Cells["To"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                SentMailsLoad.x7 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index -= 1];
                SentMailsLoad.lbl8.Text = "To: " + row.Cells["To"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                SentMailsLoad.x8 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index -= 1];
                SentMailsLoad.lbl9.Text = "To: " + row.Cells["To"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                SentMailsLoad.x9 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index -= 1];
                SentMailsLoad.lbl10.Text = "To: " + row.Cells["To"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                SentMailsLoad.x10 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index -= 1];
                SentMailsLoad.lbl11.Text = "To: " + row.Cells["To"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                SentMailsLoad.x11 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index -= 1];
                SentMailsLoad.lbl12.Text = "To: " + row.Cells["To"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                SentMailsLoad.x12 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index -= 1];
                SentMailsLoad.lbl13.Text = "To: " + row.Cells["To"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                SentMailsLoad.x13 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index -= 1];
                SentMailsLoad.lbl14.Text = "To: " + row.Cells["To"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                SentMailsLoad.x14 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index -= 1];
                SentMailsLoad.lbl15.Text = "To: " + row.Cells["To"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                SentMailsLoad.x15 = row.Cells["Serial"].Value.ToString();
                //--------------------------------------------------
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
                //MessageBox.Show(ex.Message);
            }
        }

        private void CountUserMail_SM()
        {
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                SqlCommand sc = new SqlCommand("Select Count([From]) from SentItems where [From]='" + currentUser + "'", con);
                ss = Convert.ToInt32(sc.ExecuteScalar());
                sntm = ss - 1;
                SentMailsLoad.amounttxt.Text = ss.ToString();
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
                //MessageBox.Show(ex.Message);
            }
        }

        private void CmndDraft()
        {
            //Button Style----------------------------------------
            btnDraft.ForeColor = ColorTranslator.FromHtml("#00aaff");
            btnLogin.ForeColor = ColorTranslator.FromHtml("#ffffff");
            btnInbox.ForeColor = ColorTranslator.FromHtml("#ffffff");
            btnCompose.ForeColor = ColorTranslator.FromHtml("#ffffff");
            btnSentMails.ForeColor = ColorTranslator.FromHtml("#ffffff");
            btnSettings.ForeColor = ColorTranslator.FromHtml("#ffffff");
            //Button Style----------------------------------------

            if (menuListBtn.Enabled != false)
            {
                CountUserMail_Drft();
                draftMails();
                DraftMailsLoad.lblLocation.Text = "Drafts";
                DraftMailsLoad.Visible = true;
                LogInPage.Visible = false;
                SentMailsLoad.Visible = false;
                InboxMailLoad.Visible = false;
                UI_Settings.Visible = false;
                homePage.Visible = false;
                UserAccountSettings.Visible = false;
            }
            //Closing the compose box if open?------------------------
            if (panelSlide.Width == 379 && panelSlide.Height == 428 && menuListBtn.Enabled == true)
            {
                panelSlide.Width = 1;
                panelSlide.Height = 428;
            }//---------------------------------------------------------

            //Opening the top menu------------------------------------
            if (topMenuSlide.Width == 1 && topMenuSlide.Height == 59 && menuListBtn.Enabled == true)
            {
                topMenuSlide.Width = 627;
                topMenuSlide.Height = 59;
            }//------------------------------------------------------ 
        }

        private void draftMails()
        {
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                SqlDataAdapter sda = new SqlDataAdapter("Select Mail_ID,Subject,Body,Attachment,Serial From Draft where User_ID='" + currentUser + "'", con);
                DraftData = new DataTable();
                sda.Fill(DraftData);
                dataGridView.DataSource = DraftData;
                int index = drft;
                DataGridViewRow row = new DataGridViewRow();
                //----------------------------------------------

                row = this.dataGridView.Rows[index];
                DraftMailsLoad.lbl1.Text = "Address: " + row.Cells["Mail_ID"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                DraftMailsLoad.x1 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index -= 1];
                DraftMailsLoad.lbl2.Text = "Address: " + row.Cells["Mail_ID"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                DraftMailsLoad.x2 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index -= 1];
                DraftMailsLoad.lbl3.Text = "Address: " + row.Cells["Mail_ID"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                DraftMailsLoad.x3 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index -= 1];
                DraftMailsLoad.lbl4.Text = "Address: " + row.Cells["Mail_ID"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                DraftMailsLoad.x4 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index -= 1];
                DraftMailsLoad.lbl5.Text = "Address: " + row.Cells["Mail_ID"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                DraftMailsLoad.x5 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index -= 1];
                DraftMailsLoad.lbl6.Text = "Address: " + row.Cells["Mail_ID"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                DraftMailsLoad.x6 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index -= 1];
                DraftMailsLoad.lbl7.Text = "Address: " + row.Cells["Mail_ID"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                DraftMailsLoad.x7 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index -= 1];
                DraftMailsLoad.lbl8.Text = "Address: " + row.Cells["Mail_ID"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                DraftMailsLoad.x8 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index -= 1];
                DraftMailsLoad.lbl9.Text = "Address: " + row.Cells["Mail_ID"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                DraftMailsLoad.x9 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index -= 1];
                DraftMailsLoad.lbl10.Text = "Address: " + row.Cells["Mail_ID"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                DraftMailsLoad.x10 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index -= 1];
                DraftMailsLoad.lbl11.Text = "Address: " + row.Cells["Mail_ID"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                DraftMailsLoad.x11 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index -= 1];
                DraftMailsLoad.lbl12.Text = "Address: " + row.Cells["Mail_ID"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                DraftMailsLoad.x12 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index -= 1];
                DraftMailsLoad.lbl13.Text = "Address: " + row.Cells["Mail_ID"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                DraftMailsLoad.x13 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index -= 1];
                DraftMailsLoad.lbl14.Text = "Address: " + row.Cells["Mail_ID"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                DraftMailsLoad.x14 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index -= 1];
                DraftMailsLoad.lbl15.Text = "Address: " + row.Cells["Mail_ID"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                DraftMailsLoad.x15 = row.Cells["Serial"].Value.ToString();
                //--------------------------------------------------
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
                //MessageBox.Show(ex.Message);
            }
        }

        private void CountUserMail_Drft()
        {
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                SqlCommand sc = new SqlCommand("Select Count(User_ID) from Draft where User_ID='" + currentUser + "'", con);
                dd = Convert.ToInt32(sc.ExecuteScalar());
                drft = dd - 1;
                DraftMailsLoad.amounttxt.Text = dd.ToString();
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
                //MessageBox.Show(ex.Message);
            }
        }

        private void CmndSettings()
        {
            //Button Style--------------------------------------------
            btnSettings.ForeColor = ColorTranslator.FromHtml("#00aaff");
            btnLogin.ForeColor = ColorTranslator.FromHtml("#ffffff");
            btnInbox.ForeColor = ColorTranslator.FromHtml("#ffffff");
            btnCompose.ForeColor = ColorTranslator.FromHtml("#ffffff");
            btnSentMails.ForeColor = ColorTranslator.FromHtml("#ffffff");
            btnDraft.ForeColor = ColorTranslator.FromHtml("#ffffff");
            //Button Style--------------------------------------------
           
            UI_Settings.Visible = true;
            DraftMailsLoad.Visible = false;
            LogInPage.Visible = false;
            SentMailsLoad.Visible = false;
            InboxMailLoad.Visible = false;
            homePage.Visible = false;
            UserAccountSettings.Visible = false;

            //Closing the compose box if open?------------------------
            if (panelSlide.Width == 379 && panelSlide.Height == 428 && menuListBtn.Enabled == true)
            {
                panelSlide.Width = 1;
                panelSlide.Height = 428;
            }//---------------------------------------------------------

            //Opening the top menu------------------------------------
            if (topMenuSlide.Width == 1 && topMenuSlide.Height == 59 && menuListBtn.Enabled == true)
            {
                topMenuSlide.Width = 627;
                topMenuSlide.Height = 59;
            }//------------------------------------------------------
        }

        private void CmndHome()
        {
            
            homePage.Visible = true;
            LogInPage.Visible = false;
            InboxMailLoad.Visible = false;
            SentMailsLoad.Visible = false;
            DraftMailsLoad.Visible = false;
            UI_Settings.Visible = false;
            UserAccountSettings.Visible = false;
            //Closing the compose box if open?------------------------
            if (panelSlide.Width == 379 && panelSlide.Height == 428 && menuListBtn.Enabled == true)
            {
                panelSlide.Width = 1;
                panelSlide.Height = 428;
            }//---------------------------------------------------------

            //Closing the top menu------------------------------------
            if (topMenuSlide.Width == 627 && topMenuSlide.Height == 59 && menuListBtn.Enabled == true)
            {
                topMenuSlide.Width = 1;
                topMenuSlide.Height = 59;
            }//Closing the top menu------------------------------------

            btnSettings.ForeColor = ColorTranslator.FromHtml("#ffffff");
            btnLogin.ForeColor = ColorTranslator.FromHtml("#ffffff");
            btnInbox.ForeColor = ColorTranslator.FromHtml("#ffffff");
            btnCompose.ForeColor = ColorTranslator.FromHtml("#ffffff");
            btnSentMails.ForeColor = ColorTranslator.FromHtml("#ffffff");
            btnDraft.ForeColor = ColorTranslator.FromHtml("#ffffff");
        }

        private void voiceBoxMain_Load(object sender, EventArgs e)
        {
            timeDate.Start();
            panelSlide.BringToFront();
            topMenuSlide.BringToFront();
            AnimationTimer.Start();
            statusTimer.Start();
            statusTimer.Interval = 10000;

        }

        private void timeDate_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToShortTimeString();
            lblDate.Text = DateTime.Now.ToString("MMM : dd : yyyy");
            lblDay.Text = DateTime.Now.ToString("dddd");
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //TitleBar mouse control start
        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            _dragging = true;
            _start_point = new Point(e.X, e.Y);

        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            _dragging = false;
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (_dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this._start_point.X, p.Y - this._start_point.Y);
            }
        }
        //TitleBar mouse control stop
        private void minimizeBtn_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (topMenuSlide.Width == 1 && topMenuSlide.Height == 59)
            {
                topMenuSlide.Width = 627;
                topMenuSlide.Height = 59;
            }
            else if (topMenuSlide.Width == 627 && topMenuSlide.Height == 59)
            {
                topMenuSlide.Width = 1;
                topMenuSlide.Height = 59;
            }

        }

        private void GotoSleepBtn_Click(object sender, EventArgs e)
        {
            statusTimer.Stop();
            selectionENG1.RecognizeAsyncStop();
            BtnCmmnd.RecognizeAsyncStop();
            selectionENG.RecognizeAsyncStop();
            EventHandler handler = OnGotoSleepBtnClicked;
            if (handler != null)
            {
                handler(this, new EventArgs());
            }
            this.Hide();

        }

        private void label3_Click(object sender, EventArgs e)
        {
            
            LogInPage.Visible = true;
            InboxMailLoad.Visible = false;
            SentMailsLoad.Visible = false;
            DraftMailsLoad.Visible = false;
            UI_Settings.Visible = false;
            homePage.Visible = false;
            UserAccountSettings.Visible = false;
            //Closing the compose box if open?------------------------
            if (panelSlide.Width == 379 && panelSlide.Height == 428 && menuListBtn.Enabled == true)
            {
                panelSlide.Width = 1;
                panelSlide.Height = 428;
            }//---------------------------------------------------------
            btnSettings.ForeColor = ColorTranslator.FromHtml("#ffffff");
            btnLogin.ForeColor = ColorTranslator.FromHtml("#ffffff");
            btnInbox.ForeColor = ColorTranslator.FromHtml("#ffffff");
            btnCompose.ForeColor = ColorTranslator.FromHtml("#ffffff");
            btnSentMails.ForeColor = ColorTranslator.FromHtml("#ffffff");
            btnDraft.ForeColor = ColorTranslator.FromHtml("#ffffff");

        }

        private void label9_Click(object sender, EventArgs e)
        {
            
            LogInPage.Visible = true;
            InboxMailLoad.Visible = false;
            SentMailsLoad.Visible = false;
            DraftMailsLoad.Visible = false;
            UI_Settings.Visible = false;
            homePage.Visible = false;
            UserAccountSettings.Visible = false;
            //Closing the compose box if open?------------------------
            if (panelSlide.Width == 379 && panelSlide.Height == 428 && menuListBtn.Enabled == true)
            {
                panelSlide.Width = 1;
                panelSlide.Height = 428;
            }//---------------------------------------------------------
            btnSettings.ForeColor = ColorTranslator.FromHtml("#ffffff");
            btnLogin.ForeColor = ColorTranslator.FromHtml("#ffffff");
            btnInbox.ForeColor = ColorTranslator.FromHtml("#ffffff");
            btnCompose.ForeColor = ColorTranslator.FromHtml("#ffffff");
            btnSentMails.ForeColor = ColorTranslator.FromHtml("#ffffff");
            btnDraft.ForeColor = ColorTranslator.FromHtml("#ffffff");

        }

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            animi();
        }

        private void animi()
        {
            switch (animation)
            {
                case 0:
                    AnimationTimer.Interval = 1500;
                    animation += 1;
                    break;
                case 1:
                    AnimationTimer.Interval = 75;
                    this.pictureBox4.Image = Properties.Resources.pass1;
                    this.pictureBox5.Image = Properties.Resources.SBI_0;
                    talkback();
                    tkb = 1;
                    animation += 1;
                    break;
                case 2:

                    this.pictureBox4.Image = Properties.Resources.pass2;
                    animation += 1;
                    break;
                case 3:
                    AnimationTimer.Interval = 65;
                    this.pictureBox4.Image = Properties.Resources.pass3;
                    animation += 1;
                    break;
                case 4:

                    this.pictureBox4.Image = Properties.Resources.pass4;
                    animation += 1;
                    break;
                case 5:
                    AnimationTimer.Interval = 60;
                    this.pictureBox4.Image = Properties.Resources.pass5;
                    animation += 1;
                    break;
                case 6:

                    this.pictureBox4.Image = Properties.Resources.pass6;
                    animation += 1;
                    break;
                case 7:
                    AnimationTimer.Interval = 55;
                    this.pictureBox4.Image = Properties.Resources.pass7;
                    animation += 1;
                    break;
                case 8:

                    this.pictureBox4.Image = Properties.Resources.pass8;
                    animation += 1;
                    break;
                case 9:
                    AnimationTimer.Interval = 50;
                    this.pictureBox4.Image = Properties.Resources.pass9;
                    animation += 1;
                    break;
                case 10:

                    this.pictureBox4.Image = Properties.Resources.pass10;
                    animation += 1;
                    break;
                case 11:
                    AnimationTimer.Interval = 45;
                    this.pictureBox4.Image = Properties.Resources.pass11;
                    animation += 1;
                    break;
                case 12:

                    this.pictureBox4.Image = Properties.Resources.pass12;
                    animation += 1;
                    break;
                case 13:
                    AnimationTimer.Interval = 40;
                    this.pictureBox4.Image = Properties.Resources.pass13;
                    animation += 1;
                    break;
                case 14:

                    this.pictureBox4.Image = Properties.Resources.pass14;
                    animation += 1;
                    break;
                case 15:
                    AnimationTimer.Interval = 35;
                    this.pictureBox4.Image = Properties.Resources.pass15;
                    animation += 1;
                    break;
                case 16:

                    this.pictureBox4.Image = Properties.Resources.pass16;
                    animation += 1;
                    break;
                case 17:
                    AnimationTimer.Interval = 30;
                    this.pictureBox4.Image = Properties.Resources.pass17;
                    animation += 1;
                    break;
                case 18:

                    this.pictureBox4.Image = Properties.Resources.pass18;
                    animation += 1;
                    break;
                case 19:

                    this.pictureBox4.Image = Properties.Resources.pass19;
                    animation += 1;
                    break;
                case 20:
                    AnimationTimer.Interval = 25;
                    this.pictureBox4.Image = Properties.Resources.pass20;
                    animation += 1;
                    break;
                case 21:

                    this.pictureBox4.Image = Properties.Resources.pass21;
                    animation += 1;
                    break;
                case 22:
                    this.pictureBox5.Image = Properties.Resources.SBI_1;
                    this.pictureBox4.Image = Properties.Resources.pass22;
                    animation += 1;
                    break;
                case 23:
                    AnimationTimer.Interval = 20;
                    this.pictureBox5.Image = Properties.Resources.SBI_2;
                    this.pictureBox4.Image = Properties.Resources.pass23;
                    animation += 1;
                    break;
                case 24:
                    this.pictureBox5.Image = Properties.Resources.SBI_3;
                    this.pictureBox4.Image = Properties.Resources.pass24;
                    animation += 1;
                    break;
                case 25:
                    this.pictureBox5.Image = Properties.Resources.SBI_4;
                    this.pictureBox4.Image = Properties.Resources.pass25;
                    animation += 1;
                    break;
                case 26:
                    AnimationTimer.Interval = 25;
                    this.pictureBox5.Image = Properties.Resources.SBI_5;
                    this.pictureBox4.Image = Properties.Resources.pass26;
                    animation += 1;
                    break;
                case 27:
                    AnimationTimer.Interval = 30;
                    this.pictureBox5.Image = Properties.Resources.SBI_6;
                    this.pictureBox4.Image = Properties.Resources.pass27;
                    animation += 1;
                    break;
                case 28:
                    AnimationTimer.Interval = 35;
                    this.pictureBox5.Image = Properties.Resources.SBI_7;
                    this.pictureBox4.Image = Properties.Resources.pass28;
                    animation += 1;
                    break;
                case 29:
                    AnimationTimer.Interval = 40;
                    this.pictureBox5.Image = Properties.Resources.SBI_8;
                    this.pictureBox4.Image = Properties.Resources.pass29;
                    animation += 1;
                    break;
                case 30:
                    AnimationTimer.Interval = 45;
                    this.pictureBox5.Image = Properties.Resources.SBI_9;
                    this.pictureBox4.Image = Properties.Resources.pass30;
                    animation += 1;
                    break;
                case 31:
                    AnimationTimer.Interval = 50;
                    this.pictureBox5.Image = Properties.Resources.SBI_10;
                    this.pictureBox4.Image = Properties.Resources.pass31;
                    animation += 1;
                    break;
                case 32:
                    AnimationTimer.Interval = 55;
                    this.pictureBox5.Image = Properties.Resources.SBI_11;
                    this.pictureBox4.Image = Properties.Resources.pass32;
                    animation += 1;
                    break;
                case 33:
                    AnimationTimer.Interval = 60;
                    this.pictureBox4.Image = Properties.Resources.pass1;
                    AnimationTimer.Stop();
                    animation += 1;
                    animationIdel = 0;
                    break;
            }

            switch (animationIdel)
            {
                case 0:

                    AnimationTimer.Start();
                    AnimationTimer.Interval = 3000;
                    animationIdel += 1;
                    
                    break;


                case 1:

                    AnimationTimer.Interval = 90;
                    this.pictureBox5.Image = Properties.Resources.SBActive;
                    this.pictureBox4.Image = Properties.Resources.pass_1;
                    animationIdel += 1;
                    if (state == true && this.Visible)
                    {
                        if (SkipTut == 0 && HelpAssist == 1)
                        {
                            SkipTut = 999;
                            TalkBk.SpeakAsync("Do you need me to help you out with voice commands?”, say yes or no");
                            RecEngSetup();
                        }
                        else if (SkipTut == 0 && HelpAssist == 0)
                        {
                            //RecEngSetup();
                            TalkBk.SpeakAsync("You can proceed now");
                            BtnCmmnd.RecognizeAsync(RecognizeMode.Multiple);
                            selectionENG.RecognizeAsync(RecognizeMode.Multiple);
                        }
                    }
                    break;

                case 2:
                    this.pictureBox4.Image = Properties.Resources.pass_2;
                    animationIdel += 1;
                    break;

                case 3:
                    this.pictureBox4.Image = Properties.Resources.pass_3;
                    animationIdel += 1;
                    break;

                case 4:
                    this.pictureBox4.Image = Properties.Resources.pass_4;
                    animationIdel += 1;
                    break;

                case 5:
                    this.pictureBox4.Image = Properties.Resources.pass_5;
                    animationIdel += 1;
                    break;

                case 6:
                    this.pictureBox4.Image = Properties.Resources.pass_6;
                    animationIdel += 1;
                    break;

                case 7:
                    this.pictureBox4.Image = Properties.Resources.pass_7;
                    animationIdel += 1;
                    break;

                case 8:
                    this.pictureBox4.Image = Properties.Resources.pass_8;
                    animationIdel += 1;
                    break;

                case 9:
                    this.pictureBox4.Image = Properties.Resources.pass_9;
                    animationIdel += 1;
                    break;

                case 10:
                    this.pictureBox4.Image = Properties.Resources.pass_8;
                    animationIdel += 1;
                    break;

                case 11:
                    this.pictureBox4.Image = Properties.Resources.pass_7;
                    animationIdel += 1;
                    break;

                case 12:
                    this.pictureBox4.Image = Properties.Resources.pass_6;
                    animationIdel += 1;
                    break;

                case 13:
                    this.pictureBox4.Image = Properties.Resources.pass_5;
                    animationIdel += 1;
                    break;

                case 14:
                    this.pictureBox4.Image = Properties.Resources.pass_4;
                    animationIdel += 1;
                    break;

                case 15:
                    this.pictureBox4.Image = Properties.Resources.pass_3;
                    animationIdel += 1;
                    break;

                case 16:
                    this.pictureBox4.Image = Properties.Resources.pass_2;
                    animationIdel = 2;
                    break;

            }
        }

        private void RecEngSetup()
        {
            UserRSP.Add(new string[] { "Yes", "No" });
            GrammarBuilder GB = new GrammarBuilder();
            GB.Append(UserRSP);
            Grammar gr = new Grammar(GB);
            try
            {
                UserRSPeng.LoadGrammar(gr);
                UserRSPeng.SetInputToDefaultAudioDevice();
                UserRSPeng.RecognizeAsync(RecognizeMode.Multiple);
                UserRSPeng.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(UserRSPeng_SpeechRecognized);

            }
            catch (Exception ex)
            {
                //Error handle method
            }
        }

        void UserRSPeng_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            switch (e.Result.Text.ToString())
            {
                case "Yes":
                    {
                        TalkBk.SpeakAsync("Okay!");
                        lblStatus.Text = "Login needed!";
                        UserRSPeng.RecognizeAsyncStop();
                        selectionENG.RecognizeAsync(RecognizeMode.Multiple);
                        break;
                    }
                case "No":
                    {
                        TalkBk.SpeakAsync("Alright!");
                        UserRSPeng.RecognizeAsyncStop();
                        IfSaidNo = 1;
                        BtnCmmnd.RecognizeAsync(RecognizeMode.Multiple);
                        selectionENG.RecognizeAsync(RecognizeMode.Multiple);
                        break;
                    }
            }
        }

        private void voiceBoxMain_VisibleChanged(object sender, EventArgs e)
        {
            
            if (animation == 34 && this.Visible == true)
            {
                animation = 0;
                animationIdel = -1;
                this.pictureBox4.Image = Properties.Resources.pass_1;
                this.pictureBox5.Image = Properties.Resources.SBI_0;
                AnimationTimer.Start();
                lblStatus.Text = " ";
                statusTimer.Start();
                statusTimer.Interval = 10000;
                lblStatus.Visible = false;

            }
        }

        private void talkback()
        {
            if (tkb == 0 && state == true && this.Visible)
            {
                TalkBk.SpeakAsync("System initializing, please wait...");
                //BtnCmmnd.RecognizeAsync(RecognizeMode.Multiple);
                //selectionENG.RecognizeAsync(RecognizeMode.Multiple);    
            }
            else if (tkb == 1 && state == true && this.Visible)
            {
                statusTimer.Interval = 10000;
                TalkBk.SpeakAsync("Welcome back again!");
                BtnCmmnd.RecognizeAsync(RecognizeMode.Multiple);
                selectionENG.RecognizeAsync(RecognizeMode.Multiple);
            }
        }

        private void statusTimer_Tick(object sender, EventArgs e)
        {
            if (menuListBtn.Enabled != true)
            {
                
                //lblStatus.Text = "Login needed!";
                lblStatus.Visible = true;
                statusTimer.Interval = 100;
            }
            else if (menuListBtn.Enabled != false)
            {
                lblStatus.Text = " ";
                lblStatus.Visible = true;
                statusTimer.Interval = 5000;
            }
            
        }

        private void lblStatus_TextChanged(object sender, EventArgs e)
        {
            if (lblStatus.Text == "Login needed!" && state == true && this.Visible)
            {
                LogInPage.Visible = true;
                homePage.Visible = false;
                InboxMailLoad.Visible = false;
                SentMailsLoad.Visible = false;
                DraftMailsLoad.Visible = false;
                UI_Settings.Visible = false;

                TalkBk.SpeakAsync("Login required, ");
                LoginAssistant = 1;
                LogHelpAssistant.Start();
                if (LogInPage.usrnameTxt.Text.Equals(String.Empty) && LogInPage.passwordTxt.Text.Equals(String.Empty))
                {
                    TalkBk.SpeakAsync("need username and password!");
                    NeedToInsert = 1;
                }
                else if (LogInPage.usrnameTxt.Text != String.Empty && LogInPage.passwordTxt.Text != String.Empty)
                {
                    TalkBk.SpeakAsync("username and password found!");
                    LoginAssistant = 4;
                }

                //BtnCmmnd.RecognizeAsync(RecognizeMode.Multiple);
                //selectionENG.RecognizeAsync(RecognizeMode.Multiple);
            }
        }

        private void btnAttatch_Click(object sender, EventArgs e)
        {
            attachment();
        }

        private void btnAttatchCncl_Click(object sender, EventArgs e)
        {
            if (attachTxt.Text != "")
            {
                attachTxt.Text = String.Empty;
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            msgSend();
            //btnCompose.ForeColor = ColorTranslator.FromHtml("#ffffff");
            panelSlide.Width = 1;
            panelSlide.Height = 428;
            InfoS = new SoundPlayer("Info.wav");
            CustomMessageBox mb = new CustomMessageBox();
            InfoS.Play();
            mb.CustomMessageTxt.Text = "Message has been sent!";
            mb.ShowDialog();
            
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            msgSave();
            //btnCompose.ForeColor = ColorTranslator.FromHtml("#ffffff");
            panelSlide.Width = 1;
            panelSlide.Height = 428;
            InfoS = new SoundPlayer("Info.wav");
            CustomMessageBox mb = new CustomMessageBox();
            InfoS.Play();
            mb.CustomMessageTxt.Text = "Message has been saved!";
            mb.ShowDialog();
          
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (attachTxt.Text != String.Empty)
            {
                btnAttatchCncl.Enabled = true;
            }
            else if (attachTxt.Text.Equals(String.Empty))
            {
                btnAttatchCncl.Enabled = false;
            }
        }

        private void userAcSetngs_Click(object sender, EventArgs e)
        {
            if (UserAccountSettings.Visible == false)
            {
                UASOpen();
            }
            else if (UserAccountSettings.Visible != false)
            {
                UASClose();
            }
        }

        private void UASClose()
        {
            if (menuListBtn.Enabled != false)
            {
                UserAccountSettings.SendToBack();
                UserAccountSettings.Visible = false;

                //Closing the compose box if open?------------------------
                if (panelSlide.Width == 379 && panelSlide.Height == 428 && menuListBtn.Enabled == true)
                {
                    panelSlide.Width = 1;
                    panelSlide.Height = 428;
                }//---------------------------------------------------------
            }
        }

        private void UASOpen()
        {
            if (menuListBtn.Enabled != false)
            {
                UserAccountSettings.BringToFront();
                UserAccountSettings.Visible = true;

                //Closing the compose box if open?------------------------
                if (panelSlide.Width == 379 && panelSlide.Height == 428 && menuListBtn.Enabled == true)
                {
                    panelSlide.Width = 1;
                    panelSlide.Height = 428;
                }//---------------------------------------------------------
            }
        }

        private void CheckInboxTm_Tick(object sender, EventArgs e)
        {
            CountUserMail_Inbox();
            inboxMail();
        }

        private void UsrNotifictn_Click(object sender, EventArgs e)
        {
            CmndInbox();
            UsrNotifictn.BackgroundImage = Properties.Resources._003_notification;
            notificationLbl.Visible = false;
            ResetMailCount();
            NotifyUser.Start();
            //sp.Stop();
        }

        private void ResetMailCount()
        {
            SaveCurrentMailCount();
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                cmd.Connection = con;
                cmd.CommandText = "update Inbox_Notify set Mail_Count='" + LatestCount + "' where [User]='" + currentUser + "'";
                cmd.ExecuteNonQuery();
                cmd.Clone();
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
            }
        }

        private void SaveCurrentMailCount()
        {
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                SqlCommand sc = new SqlCommand("Select Count([To]) from Inbox where [To]='" + currentUser + "'", con);
                LatestCount = Convert.ToInt32(sc.ExecuteScalar());
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
                //MessageBox.Show(ex.Message);
            }
        }

        private void NotifyUser_Tick(object sender, EventArgs e)
        {
            countOld();
            countNew();

            if (NewRecord > OldRecord)
            {
                NotifyUser.Stop();
                //MessageBox.Show("New message arrived!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UsrNotifictn.BackgroundImage = Properties.Resources._003_notificationA;
                notificationLbl.Visible = true;
                NotifyS = new SoundPlayer("Notify.wav");
                NotifyS.Play();
                if (state == true && this.Visible)
                {
                    TalkBk.SpeakAsync("New mail arrived!!");
                    lblStatus.Text = " ";
                    lblStatus.Text = "New mail!!";
                }
            }
        }

        private void countNew()
        {
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                SqlCommand sc = new SqlCommand("Select Count([To]) from Inbox where [To]='" + currentUser + "'", con);
                NewRecord = Convert.ToInt32(sc.ExecuteScalar());
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
                //MessageBox.Show(ex.Message);
            }
        }

        private void countOld()
        {
            string temp;
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                cmd.Connection = con;
                cmd.CommandText = "Select Mail_Count From Inbox_Notify where [User]='" + currentUser + "'";
                cmd.ExecuteNonQuery();
                cmd.Clone();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    temp = sdr[0].ToString();
                    OldRecord = Convert.ToInt32(temp);
                }
                con.Close();
                
            }
            catch (Exception ex)
            {
                con.Close();
            }
        }

        private void CheckForUnread_Tick(object sender, EventArgs e)
        {
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                string rs = "0";
                SqlDataAdapter As = new SqlDataAdapter("Select Count(*) From Inbox where [To]='" + currentUser + "' and ReadStatus='" + rs + "'", con);
                DataTable dt = new DataTable();
                As.Fill(dt);
                InboxUnreadMailslbl.Text = dt.Rows[0][0].ToString();
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
            }
        }

        private void InboxUnreadMailslbl_TextChanged(object sender, EventArgs e)
        {
            if (InboxUnreadMailslbl.Text == "0")
            {
                InboxUnreadMailslbl.Visible = false;
                UnreadMassg.BackgroundImage = Properties.Resources._002_messages_silhouette;
            }
            else if (InboxUnreadMailslbl.Text != "0")
            {
                InboxUnreadMailslbl.Visible = true;
                UnreadMassg.BackgroundImage = Properties.Resources._002_messages_silhouetteA;
            }
        }

        private void UnreadMassg_Click(object sender, EventArgs e)
        {
            
            if (InboxUnreadMailslbl.Visible != false)
            {
                if (unreadTogg == 0)
                {
                    unreadTogg = 1;
                    CheckInboxTm.Stop();
                    InboxLBLRefresh();
                    InboxUnread();
                }
                else if (unreadTogg == 1)
                {
                    unreadTogg = 0;
                    CheckInboxTm.Start();
                }
            }
        }

        private void InboxUnread()
        {
            InboxMailLoad.lblLocation.Text = "Inbox Mails";
            InboxMailLoad.Visible = true;
            LogInPage.Visible = false;
            SentMailsLoad.Visible = false;
            DraftMailsLoad.Visible = false;
            UI_Settings.Visible = false;
            homePage.Visible = false;
            UserAccountSettings.Visible = false;
            string RS = "0";
            try
            {
                DataView dv = new DataView(InboxData);
                dv.RowFilter = string.Format("ReadStatus LIKE '%{0}%'", RS);
                dataGridView.DataSource = dv;
                int index = 0;
                DataGridViewRow row = new DataGridViewRow();
                //----------------------------------------------
                row = this.dataGridView.Rows[index];
                InboxMailLoad.lbl1.Text = "From: " + row.Cells["From"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                InboxMailLoad.x1 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index += 1];
                InboxMailLoad.lbl2.Text = "From: " + row.Cells["From"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                InboxMailLoad.x2 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index += 1];
                InboxMailLoad.lbl3.Text = "From: " + row.Cells["From"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                InboxMailLoad.x3 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index += 1];
                InboxMailLoad.lbl4.Text = "From: " + row.Cells["From"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                InboxMailLoad.x4 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index += 1];
                InboxMailLoad.lbl5.Text = "From: " + row.Cells["From"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                InboxMailLoad.x5 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index += 1];
                InboxMailLoad.lbl6.Text = "From: " + row.Cells["From"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                InboxMailLoad.x6 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index += 1];
                InboxMailLoad.lbl7.Text = "From: " + row.Cells["From"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                InboxMailLoad.x7 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index += 1];
                InboxMailLoad.lbl8.Text = "From: " + row.Cells["From"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                InboxMailLoad.x8 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index += 1];
                InboxMailLoad.lbl9.Text = "From: " + row.Cells["From"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                InboxMailLoad.x9 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index += 1];
                InboxMailLoad.lbl10.Text = "From: " + row.Cells["From"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                InboxMailLoad.x10 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index += 1];
                InboxMailLoad.lbl11.Text = "From: " + row.Cells["From"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                InboxMailLoad.x11 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index += 1];
                InboxMailLoad.lbl12.Text = "From: " + row.Cells["From"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                InboxMailLoad.x12 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index += 1];
                InboxMailLoad.lbl13.Text = "From: " + row.Cells["From"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                InboxMailLoad.x13 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index += 1];
                InboxMailLoad.lbl14.Text = "From: " + row.Cells["From"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                InboxMailLoad.x14 = row.Cells["Serial"].Value.ToString();

                row = this.dataGridView.Rows[index += 1];
                InboxMailLoad.lbl15.Text = "From: " + row.Cells["From"].Value.ToString() + "||" + " Subject: " + row.Cells["Subject"].Value.ToString() + "||" + " Body: " + row.Cells["Body"].Value.ToString();
                InboxMailLoad.x15 = row.Cells["Serial"].Value.ToString();
                //--------------------------------------------------
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
        }

        private void InboxLBLRefresh()
        {
            InboxMailLoad.lbl1.Text = String.Empty;
            InboxMailLoad.lbl2.Text = String.Empty;
            InboxMailLoad.lbl3.Text = String.Empty;
            InboxMailLoad.lbl4.Text = String.Empty;
            InboxMailLoad.lbl5.Text = String.Empty;
            InboxMailLoad.lbl6.Text = String.Empty;
            InboxMailLoad.lbl7.Text = String.Empty;
            InboxMailLoad.lbl8.Text = String.Empty;
            InboxMailLoad.lbl9.Text = String.Empty;
            InboxMailLoad.lbl10.Text = String.Empty;
            InboxMailLoad.lbl11.Text = String.Empty;
            InboxMailLoad.lbl12.Text = String.Empty;
            InboxMailLoad.lbl13.Text = String.Empty;
            InboxMailLoad.lbl14.Text = String.Empty;
            InboxMailLoad.lbl15.Text = String.Empty;
        }

        private void LogHelpAssistant_Tick(object sender, EventArgs e)
        {
            switch (LoginAssistant)
            {
                case 1:
                    {
                        if (NeedToInsert == 1)
                        {
                            TalkBk.SpeakAsync("Say 'username'");
                            NeedToInsert = 0;
                        }
                        else if (NeedToInsert == 2)
                        {
                            TalkBk.SpeakAsync("Say 'dictation on'");
                            NeedToInsert = 0;
                        }
                        else if (NeedToInsert == 3)
                        {
                            TalkBk.SpeakAsync("Now speakout your username");
                            NeedToInsert = 0;
                            WaitToFinish.Start();
                        }
                        else if (NeedToInsert == 4)
                        {
                            TalkBk.SpeakAsync("Say 'dictation off");
                            NeedToInsert = 0;
                        }
                        else if (NeedToInsert == 5)
                        {
                            NeedToInsert1 = 1;
                            NeedToInsert = 999;
                            LoginAssistant = 2;
                            
                        }
                        break;
                    }
                case 2:
                    {
                        if (NeedToInsert1 == 1)
                        {
                            TalkBk.SpeakAsync("Say 'password'");
                            NeedToInsert1 = 0;
                        }
                        else if (NeedToInsert1 == 2)
                        {
                            NeedToInsert1 = 0;
                            //LogHelpAssistant.Interval = 11000;
                            TalkBk.SpeakAsync("If you want all the letter to be uppercase, say 'set uppercase'. or if you want all the letter to be lowercase, say 'set lowercase'. or if you want me to detect the lettercase, say 'dictation on'");
                        }
                        else if (NeedToInsert1 == 3)
                        {
                            TalkBk.SpeakAsync("Say 'dictation on'");
                            NeedToInsert1 = 0;
                        }
                        else if (NeedToInsert1 == 4)
                        {
                            TalkBk.SpeakAsync("Now speakout your password");
                            NeedToInsert1 = 0;
                            WaitToFinish.Start();
                        }
                        else if (NeedToInsert1 == 5)
                        {
                            TalkBk.SpeakAsync("Say 'dictation off'");
                            NeedToInsert1 = 0;
                        }
                        else if (NeedToInsert1 == 6)
                        {
                            NeedToInsert1 = 999;
                            LoginAssistant = 3;
                        }
                        break;
                    }
                case 3:
                    {
                        TalkBk.SpeakAsync("say 'remember this' to use this username and password in future login, or 'don't remember this' and I will not save this username and password,");
                        LoginAssistant = 0;
                        break;
                    }
                case 4:
                    {
                        TalkBk.SpeakAsync("Say 'go next' to login");
                        LoginAssistant = 0;
                        onlyWrk = 1;
                        //AfterSuccessfulLogin();
                        break;
                    }
                case 0:
                    {
                        //??
                        break;
                    }
                case 5:
                    {
                        if (TryCase1 == 1)
                        {
                            TalkBk.SpeakAsync("Say 'readback username' to re check current username");
                            TryCase1 = 0;
                        }
                        else if (TryCase1 == 2)
                        {
                            TalkBk.SpeakAsync("Do you wish to try again with this username? say 'yes' or 'no'");
                            TryCase1 = 0;
                            WaitingForUserResponse();
                        }
                        else if (TryCase1 == 3)
                        {
                            TalkBk.SpeakAsync("Say 'clear username'");
                            TryCase1 = 0;
                        }
                        break;
                    }
                case 6:
                    {
                        if (TryCase2 == 1)
                        {
                            TalkBk.SpeakAsync("Say 'readback password' to re check current password");
                            TryCase2 = 0;
                        }
                        else if (TryCase2 == 2)
                        {
                            TalkBk.SpeakAsync("Do you wish to try again with this password? say 'yes' or 'no'");
                            TryCase2 = 0;
                            WaitingForUserResponse();
                        }
                        else if (TryCase2 == 3)
                        {
                            TalkBk.SpeakAsync("Say 'clear password'");
                            TryCase2 = 0;
                        }
                        break;
                    }

            }
        }

        private void AfterSuccessfulLogin()
        {
            if (LogInPage.Visible != false && LogInPage.pnlSuccessLogin.Visible != false)
            {
                selectionENG.RecognizeAsyncStop();
                TalkBk.SpeakAsync("Now you have the following options available");
                TalkBk.SpeakAsync("inbox, 1");
                TalkBk.SpeakAsync("sentitems, 2");
                TalkBk.SpeakAsync("draftbox, 3");
                TalkBk.SpeakAsync("logout, 4");
                TalkBk.SpeakAsync("Say 'choose option', with the following number of option you want");

                UserRSP2.Add(new string[] { "choose option 1", "choose option 2", "choose option 3", "choose option 4" });
                GrammarBuilder GB = new GrammarBuilder();
                GB.Append(UserRSP2);
                Grammar gr = new Grammar(GB);
                try
                {
                    UserRSPeng2.LoadGrammar(gr);
                    UserRSPeng2.SetInputToDefaultAudioDevice();
                    UserRSPeng2.RecognizeAsync(RecognizeMode.Multiple);
                    UserRSPeng2.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(UserRSPeng2_SpeechRecognized);

                }
                catch (Exception ex)
                {
                    //Error handle method
                }
            } 
        }

        void UserRSPeng2_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            switch (e.Result.Text.ToString())
            {
                case "choose option 1":
                    {
                        //selectionENG.RecognizeAsync(RecognizeMode.Multiple);
                        BtnCmmnd.RecognizeAsync(RecognizeMode.Multiple);
                        UserRSPeng2.RecognizeAsyncStop();
                        TalkBk.SpeakAsync("okay, say 'select inbox'");
                        UserAsstOptChoose = 1;
                        break;
                    }
                case "choose option 2":
                    {
                        //selectionENG.RecognizeAsync(RecognizeMode.Multiple);
                        BtnCmmnd.RecognizeAsync(RecognizeMode.Multiple);
                        UserRSPeng2.RecognizeAsyncStop();
                        TalkBk.SpeakAsync("okay, say 'select sentitems'");
                        break;
                    }
                case "choose option 3":
                    {
                        //selectionENG.RecognizeAsync(RecognizeMode.Multiple);
                        BtnCmmnd.RecognizeAsync(RecognizeMode.Multiple);
                        UserRSPeng2.RecognizeAsyncStop();
                        TalkBk.SpeakAsync("okay, say 'select draft'");
                        break;
                    }
                case "choose option 4":
                    {
                        selectionENG.RecognizeAsync(RecognizeMode.Multiple);
                        TalkBk.SpeakAsync("okay, say 'logout'");
                        break;
                    }
            }
        }

        private void WaitingForUserResponse()
        {
            UserRSP1.Add(new string[] { "Yes", "No" });
            GrammarBuilder GB = new GrammarBuilder();
            GB.Append(UserRSP1);
            Grammar gr = new Grammar(GB);
            try
            {
                UserRSPeng1.LoadGrammar(gr);
                UserRSPeng1.SetInputToDefaultAudioDevice();
                UserRSPeng1.RecognizeAsync(RecognizeMode.Multiple);
                UserRSPeng1.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(UserRSPeng1_SpeechRecognized);

            }
            catch (Exception ex)
            {
                //Error handle method
            }
        }

        void UserRSPeng1_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            switch (e.Result.Text.ToString())
            {
                case "Yes":
                    {
                        UserRSPeng1.RecognizeAsyncStop();
                        //TalkBk.SpeakAsync("Alright!");
                        if (LoginAssistant == 5)
                        {
                            LoginAssistant = 4;
                            TryCase1 = 999;
                        }
                        else if (LoginAssistant == 6)
                        {
                            LoginAssistant = 4;
                            TryCase2 = 999;
                        }
                        
                        break;
                    }
                case "No":
                    {
                        UserRSPeng1.RecognizeAsyncStop();
                        if (LoginAssistant == 5)
                        {
                            TryCase1 = 3;
                            LogInPage.passwordTxt.Text = String.Empty;
                        }
                        else if (LoginAssistant == 6)
                        {
                            TryCase2 = 3;                         
                        }
                        
                        break;
                    }
            }
        }

        private void WaitToFinish_Tick(object sender, EventArgs e)
        {
            if (LoginAssistant == 2)
            {
                NeedToInsert1 = 5;
            }
            else if (LoginAssistant == 1)
            {
                NeedToInsert = 4;
            }
        }
    }
}
