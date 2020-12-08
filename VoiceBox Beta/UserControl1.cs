using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;


namespace VoiceBox_Beta
{
    public partial class ucLogIn : UserControl
    {
        int ShowHide = 0, logState = 0, UsrNm, UsrPs;

        public event EventHandler OnButtonClicked;
        public event EventHandler OnButtonClickClosed;
        

        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\adnan\Desktop\VoiceBox Beta.Final\VoiceBox Beta\DemoEmailServer.mdf;Integrated Security=True;User Instance=True");


        public ucLogIn()
        {
            InitializeComponent();
            checking();
        }

        private void checking()
        {
            string usr, pas;
            string filename = @"C:\Users\adnan\Desktop\VoiceBox Beta.Final\Log\User_Info.txt";
            if (File.Exists(filename))
            {
                string[] lines = File.ReadAllLines(filename);
                usr = lines[2].ToString();
                pas = lines[4].ToString();
                if (usr!=String.Empty && pas!=String.Empty)
                {
                    usrnameTxt.Text = usr;
                    passwordTxt.Text = pas;
                    checkRemember.CheckState = CheckState.Checked;
                }
                else if (usr == String.Empty && pas == String.Empty)
                {
                    usrnameTxt.Text = String.Empty;
                    passwordTxt.Text = String.Empty;
                    checkRemember.CheckState = CheckState.Unchecked;
                }
            }
        }
        private void btnLogIn_Click(object sender, EventArgs e)
        {
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                SqlDataAdapter As = new SqlDataAdapter("Select Count(*) From User_Info where Mail_ID='" + usrnameTxt.Text + "'", con);
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
                SqlDataAdapter As1 = new SqlDataAdapter("Select Count(*) From User_Info where Mail_ID='" + usrnameTxt.Text + "' and Usr_Pass='" + passwordTxt.Text + "'", con);
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
                pnlSuccessLogin.Visible = true;
                lblUsrNm.Text = usrnameTxt.Text.ToString();
                chkLbl.Visible = false;
                checkRemember.Visible = false;
                showHidePassBtn.Visible = false;
                showHidePassBtn.BackgroundImage = Properties.Resources.hidePass;
                passwordTxt.PasswordChar = '\u25CF';
                logState = 1;

                //sending Event
                EventHandler handler = OnButtonClicked;
                if (handler != null)
                {
                    handler(this, new EventArgs());
                }
            }
            else if (UsrNm == 1 && UsrPs == 0)
            {
                chkLbl.Text = "Incorrect password!";
                chkLbl.Visible = true;
            }
            else if (UsrNm == 0 && UsrPs == 0)
            {
                chkLbl.Text = "Incorrect username!";
                chkLbl.Visible = true;
            }
        }

        private void ucLogIn_Load(object sender, EventArgs e)
        {
            if (logState == 0)
            {
                pnlLogin.Visible = true;
                pnlSuccessLogin.Visible = false;
                
                
            }
            else if(logState == 1)
            {
                pnlSuccessLogin.Visible = true;
                chkLbl.Visible = false;
                checkRemember.Visible = false;
                showHidePassBtn.Visible = false;
                
            }      
            
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (checkRemember.CheckState.Equals(CheckState.Checked))
            {
                pnlSuccessLogin.Visible = false;
                pnlLogin.Visible = true;
                checkRemember.Visible = true;
                showHidePassBtn.Visible = true;
                logState = 0;
            }
            else if (checkRemember.CheckState.Equals(CheckState.Unchecked))
            {
                usrnameTxt.Text = "";
                passwordTxt.Text = "";
                pnlSuccessLogin.Visible = false;
                pnlLogin.Visible = true;
                checkRemember.Visible = true;
                showHidePassBtn.Visible = true;
                logState = 0;
            }

            //Sending Event..........
            EventHandler handler1 = OnButtonClickClosed;
            if (handler1 != null)
            {
                handler1(this, new EventArgs());
            }

        }

        private void passwordTxt_TextChanged(object sender, EventArgs e)
        {
            if (passwordTxt.Text != String.Empty)
            {
                showHidePassBtn.Enabled = true;
            }
            else if (passwordTxt.Text.Equals(String.Empty))
            {
                showHidePassBtn.Enabled = false;
                showHidePassBtn.BackgroundImage = Properties.Resources.hidePass;
            }
        }

        private void showHidePassBtn_Click(object sender, EventArgs e)
        {
            if (ShowHide == 0)
            {
                showHidePassBtn.BackgroundImage = Properties.Resources.showPass;
                passwordTxt.PasswordChar = '\0';
                ShowHide = 1;
            }
            else if (ShowHide == 1)
            {
                showHidePassBtn.BackgroundImage = Properties.Resources.hidePass;
                passwordTxt.PasswordChar = '\u25CF';
                ShowHide = 0;
            }
        }

        private void checkRemember_CheckStateChanged(object sender, EventArgs e)
        {
            if (usrnameTxt.Text != "" && passwordTxt.Text != "")
            {
                string us, ps;
                us = usrnameTxt.Text.ToString();
                ps = passwordTxt.Text.ToString();

                if (checkRemember.CheckState.Equals(CheckState.Checked))
                {
                    string Txt2 = "[UserInfo]\r\nus:\r\n" + us + "\r\nps:\r\n" + ps + "\r\n-.-";
                    TextWriter txt2 = new StreamWriter("C:\\Users\\adnan\\Desktop\\VoiceBox Beta.Final\\Log\\User_Info.txt");
                    txt2.Write(Txt2);
                    txt2.Close();
                }
                else if (checkRemember.CheckState.Equals(CheckState.Unchecked))
                {
                    string Txt2 = "[UserInfo]\r\nus:\r\n\r\nps:\r\n\r\n-.-";
                    TextWriter txt2 = new StreamWriter("C:\\Users\\adnan\\Desktop\\VoiceBox Beta.Final\\Log\\User_Info.txt");
                    txt2.Write(Txt2);
                    txt2.Close();
                }
            }
        }
    }
}
