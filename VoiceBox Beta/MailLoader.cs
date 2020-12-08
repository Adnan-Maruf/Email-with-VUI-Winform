using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Media;

namespace VoiceBox_Beta
{
    public partial class MailLoader : UserControl
    {
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\adnan\Desktop\VoiceBox Beta.Final\VoiceBox Beta\DemoEmailServer.mdf;Integrated Security=True;User Instance=True");
        SqlCommand cmd = new SqlCommand();
        public int page = 1, Mcount = 0;
        public string x1, x2, x3, x4, x5, x6, x7, x8, x9, x10, x11, x12, x13, x14, x15, Mail_Reply, CurrentUser;
        public string rd1, rd2, rd3, rd4, rd5, rd6, rd7, rd8, rd9, rd10, rd11, rd12, rd13, rd14, rd15;
        public string cap, Delete, Replay, Forward, ReadStatus;
        public string F_Subject, F_Body, F_Attachment;
        //public Image F_Attachment;
        public byte[] img = null;

        SoundPlayer InfoS;

        public event EventHandler DeleteBtnClicked;
        public event EventHandler ReplayBtnClicked;
        public event EventHandler CancleBtnClicked;
        public event EventHandler ForwardBtnClicked;
        public event EventHandler ScrollLeftBtnClicked;
        public event EventHandler ScrollRightBtnClicked;
        public event EventHandler SearchEmpty;
        public event EventHandler SearchBtnClicked;
        public event EventHandler InboxRefresh;

        public MailLoader()
        {
            InitializeComponent();
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
                cmd.CommandText = "update Inbox set ReadStatus='" + ReadStatus + "' where [To]='" + CurrentUser + "' and Serial='" + cap + "'";
                cmd.ExecuteNonQuery();
                cmd.Clone();
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
            }
        }

        private void MailForword()
        {
            if (lblLocation.Text.Equals("Inbox Mails"))
            {
                cmd.CommandText = "Select Subject,Body,Attachment From Inbox where Serial='" + Forward + "'";
            }
            else if (lblLocation.Text.Equals("Sent Mails"))
            {
                cmd.CommandText = "Select Subject,Body,Attachment From SentItems where Serial='" + Forward + "'";
            }
            else if (lblLocation.Text.Equals("Drafts"))
            {
                cmd.CommandText = "Select Subject,Body,Attachment From Draft where Serial='" + Forward + "'";
            }
        }

        private void MailReplay()
        {
            if (lblLocation.Text.Equals("Inbox Mails"))
            {
                cmd.CommandText = "Select [From] From Inbox where Serial='" + Replay + "'";
            }
        }

        private void MailDelete()
        {
            if (lblLocation.Text.Equals("Inbox Mails"))
            {
                cmd.CommandText = "Delete Inbox where Serial='" + Delete + "'";
            }
            else if (lblLocation.Text.Equals("Sent Mails"))
            {
                cmd.CommandText = "Delete SentItems where Serial='" + Delete + "'";
            }
            else if (lblLocation.Text.Equals("Drafts"))
            {
                cmd.CommandText = "Delete Draft where Serial='" + Delete + "'";
            }
        }

        private void runSqlCmnd()
        {
            if (lblLocation.Text.Equals("Inbox Mails"))
            {
                cmd.CommandText = "Select [From],Subject,Body,TimeDate,Attachment From Inbox where [To]='" + CurrentUser + "' and Serial='" + cap + "'";
            }
            else if (lblLocation.Text.Equals("Sent Mails"))
            {
                cmd.CommandText = "Select [To],Subject,Body,TimeDate,Attachment From SentItems where [From]='" + CurrentUser + "' and Serial='" + cap + "'";
            }
            else if (lblLocation.Text.Equals("Drafts"))
            {
                cmd.CommandText = "Select Mail_ID,Subject,Body,TimeDate,Attachment From Draft where User_ID='" + CurrentUser + "' and Serial='" + cap + "'";
            }
        }

        private void openReadBox()
        {
            label5.Visible = false;
            label7.Visible = false;
            amounttxt.Visible = false;
            pageLbl.Visible = false;
            ReadBox.Width = 627;
            ReadBox.Height = 473;
            ReadBox.Visible = true;
        }
        //Mouse hover start------------------------------------
        private void lbl1_MouseHover(object sender, EventArgs e)
        {
            if (chk1.Checked != true && chk1.Enabled != false)
            {
                lbl1.BackColor = ColorTranslator.FromHtml("#d9d9d9");
            }
        }

        private void lbl2_MouseHover(object sender, EventArgs e)
        {
            if (chk2.Checked != true && chk2.Enabled != false)
            {
                lbl2.BackColor = ColorTranslator.FromHtml("#d9d9d9");
            }
        }

        private void lbl3_MouseHover(object sender, EventArgs e)
        {
            if (chk3.Checked != true && chk3.Enabled != false)
            {
                lbl3.BackColor = ColorTranslator.FromHtml("#d9d9d9");
            }
        }

        private void lbl4_MouseHover(object sender, EventArgs e)
        {
            if (chk4.Checked != true && chk4.Enabled != false)
            {
                lbl4.BackColor = ColorTranslator.FromHtml("#d9d9d9");
            }
        }

        private void lbl5_MouseHover(object sender, EventArgs e)
        {
            if (chk5.Checked != true && chk5.Enabled != false)
            {
                lbl5.BackColor = ColorTranslator.FromHtml("#d9d9d9");
            }
        }

        private void lbl6_MouseHover(object sender, EventArgs e)
        {
            if (chk6.Checked != true && chk6.Enabled != false)
            {
                lbl6.BackColor = ColorTranslator.FromHtml("#d9d9d9");
            }
        }

        private void lbl7_MouseHover(object sender, EventArgs e)
        {
            if (chk7.Checked != true && chk7.Enabled != false)
            {
                lbl7.BackColor = ColorTranslator.FromHtml("#d9d9d9");
            }
        }

        private void lbl8_MouseHover(object sender, EventArgs e)
        {
            if (chk8.Checked != true && chk8.Enabled != false)
            {
                lbl8.BackColor = ColorTranslator.FromHtml("#d9d9d9");
            }
        }

        private void lbl9_MouseHover(object sender, EventArgs e)
        {
            if (chk9.Checked != true && chk9.Enabled != false)
            {
                lbl9.BackColor = ColorTranslator.FromHtml("#d9d9d9");
            }
        }

        private void lbl10_MouseHover(object sender, EventArgs e)
        {
            if (chk10.Checked != true && chk10.Enabled != false)
            {
                lbl10.BackColor = ColorTranslator.FromHtml("#d9d9d9");
            }
        }

        private void lbl11_MouseHover(object sender, EventArgs e)
        {
            if (chk11.Checked != true && chk11.Enabled != false)
            {
                lbl11.BackColor = ColorTranslator.FromHtml("#d9d9d9");
            }
        }

        private void lbl12_MouseHover(object sender, EventArgs e)
        {
            if (chk12.Checked != true && chk12.Enabled != false)
            {
                lbl12.BackColor = ColorTranslator.FromHtml("#d9d9d9");
            }
        }

        private void lbl13_MouseHover(object sender, EventArgs e)
        {
            if (chk13.Checked != true && chk13.Enabled != false)
            {
                lbl13.BackColor = ColorTranslator.FromHtml("#d9d9d9");
            }
        }

        private void lbl14_MouseHover(object sender, EventArgs e)
        {
            if (chk14.Checked != true && chk14.Enabled != false)
            {
                lbl14.BackColor = ColorTranslator.FromHtml("#d9d9d9");
            }
        }

        private void lbl15_MouseHover(object sender, EventArgs e)
        {
            if (chk15.Checked != true && chk15.Enabled != false)
            {
                lbl15.BackColor = ColorTranslator.FromHtml("#d9d9d9");
            }
        }
        //Mouse hover end------------------------------------
                            //---------\\------------//
        //mouse leave start-------------------------------------------
        private void lbl1_MouseLeave(object sender, EventArgs e)
        {
            if (chk1.Checked != true && chk1.Enabled != false)
            {
                lbl1.BackColor = ColorTranslator.FromHtml("#ffffff");
            }
        }

        private void lbl2_MouseLeave(object sender, EventArgs e)
        {
            if (chk2.Checked != true && chk2.Enabled != false)
            {
                lbl2.BackColor = ColorTranslator.FromHtml("#ffffff");
            }
        }

        private void lbl3_MouseLeave(object sender, EventArgs e)
        {
            if (chk3.Checked != true && chk3.Enabled != false)
            {
                lbl3.BackColor = ColorTranslator.FromHtml("#ffffff");
            }
        }

        private void lbl4_MouseLeave(object sender, EventArgs e)
        {
            if (chk4.Checked != true && chk4.Enabled != false)
            {
                lbl4.BackColor = ColorTranslator.FromHtml("#ffffff");
            }
        }

        private void lbl5_MouseLeave(object sender, EventArgs e)
        {
            if (chk5.Checked != true && chk5.Enabled != false)
            {
                lbl5.BackColor = ColorTranslator.FromHtml("#ffffff");
            }
        }

        private void lbl6_MouseLeave(object sender, EventArgs e)
        {
            if (chk6.Checked != true && chk6.Enabled != false)
            {
                lbl6.BackColor = ColorTranslator.FromHtml("#ffffff");
            }
        }

        private void lbl7_MouseLeave(object sender, EventArgs e)
        {
            if (chk7.Checked != true && chk7.Enabled != false)
            {
                lbl7.BackColor = ColorTranslator.FromHtml("#ffffff");
            }
        }

        private void lbl8_MouseLeave(object sender, EventArgs e)
        {
            if (chk8.Checked != true && chk8.Enabled != false)
            {
                lbl8.BackColor = ColorTranslator.FromHtml("#ffffff");
            }
        }

        private void lbl9_MouseLeave(object sender, EventArgs e)
        {
            if (chk9.Checked != true && chk9.Enabled != false)
            {
                lbl9.BackColor = ColorTranslator.FromHtml("#ffffff");
            }
        }

        private void lbl10_MouseLeave(object sender, EventArgs e)
        {
            if (chk10.Checked != true && chk10.Enabled != false)
            {
                lbl10.BackColor = ColorTranslator.FromHtml("#ffffff");
            }
        }

        private void lbl11_MouseLeave(object sender, EventArgs e)
        {
            if (chk11.Checked != true && chk11.Enabled != false)
            {
                lbl11.BackColor = ColorTranslator.FromHtml("#ffffff");
            }
        }

        private void lbl12_MouseLeave(object sender, EventArgs e)
        {
            if (chk12.Checked != true && chk12.Enabled != false)
            {
                lbl12.BackColor = ColorTranslator.FromHtml("#ffffff");
            }
        }

        private void lbl13_MouseLeave(object sender, EventArgs e)
        {
            if (chk13.Checked != true && chk13.Enabled != false)
            {
                lbl13.BackColor = ColorTranslator.FromHtml("#ffffff");
            }
        }

        private void lbl14_MouseLeave(object sender, EventArgs e)
        {
            if (chk14.Checked != true && chk14.Enabled != false)
            {
                lbl14.BackColor = ColorTranslator.FromHtml("#ffffff");
            }
        }

        private void lbl15_MouseLeave(object sender, EventArgs e)
        {
            if (chk15.Checked != true && chk15.Enabled != false)
            {
                lbl15.BackColor = ColorTranslator.FromHtml("#ffffff");
            }
        }
        //mouse leave end-------------------------------------------
                        //---------\\------------//
        //mouse click start-------------------------------------------
        private void lbl1_Click(object sender, EventArgs e)
        {
            if (lbl1.Text != String.Empty)
            {
                //ch1.Enabled = true;
                cap = x1;
                if (lblLocation.Text.Equals("Inbox Mails") && rd1=="0")
                {
                    rd1 = "1";
                    ReadStatus = rd1;
                    this.lbl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    ChangeReadStatus();
                }
                openReadBox();
                try
                {
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }
                    cmd.Connection = con;
                    runSqlCmnd();
                    cmd.ExecuteNonQuery();
                    cmd.Clone();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        textBox2.Text = sdr[0].ToString();
                        textBox3.Text = sdr[1].ToString();
                        richTextBox1.Text = sdr[2].ToString();
                        DateTimeLBL.Text = sdr[3].ToString();
                        img = (byte[])(sdr[4]);
                        if (img == null)
                        {
                            AttachmentTXT.Text = "";
                        }
                        else
                        {
                            MemoryStream ms = new MemoryStream(img);
                            AttachmentTXT.Text = Image.FromStream(ms).ToString();
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
            else
            {
                //ch1.Enabled = false;
            }
        }

        private void lbl2_Click(object sender, EventArgs e)
        {
            if (lbl2.Text != String.Empty)
            {
                //ch2.Enabled = true;
                cap = x2;
                if (lblLocation.Text.Equals("Inbox Mails") && rd2 == "0")
                {
                    rd2 = "1";
                    ReadStatus = rd2;
                    this.lbl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    ChangeReadStatus();
                }
                openReadBox();
                try
                {
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }
                    cmd.Connection = con;
                    runSqlCmnd();
                    cmd.ExecuteNonQuery();
                    cmd.Clone();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        textBox2.Text = sdr[0].ToString();
                        textBox3.Text = sdr[1].ToString();
                        richTextBox1.Text = sdr[2].ToString();
                        DateTimeLBL.Text = sdr[3].ToString();
                        img = (byte[])(sdr[4]);
                        if (img == null)
                        {
                            AttachmentTXT.Text = "";
                        }
                        else
                        {
                            MemoryStream ms = new MemoryStream(img);
                            AttachmentTXT.Text = Image.FromStream(ms).ToString();
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
            else
            {
                //ch2.Enabled = false;
            }
        }

        private void lbl3_Click(object sender, EventArgs e)
        {
            if (lbl3.Text != String.Empty)
            {
                //ch3.Enabled = true;
                cap = x3;
                if (lblLocation.Text.Equals("Inbox Mails") && rd3 == "0")
                {
                    rd3 = "1";
                    ReadStatus = rd3;
                    this.lbl3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    ChangeReadStatus();
                }
                openReadBox();
                try
                {
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }
                    cmd.Connection = con;
                    runSqlCmnd();
                    cmd.ExecuteNonQuery();
                    cmd.Clone();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        textBox2.Text = sdr[0].ToString();
                        textBox3.Text = sdr[1].ToString();
                        richTextBox1.Text = sdr[2].ToString();
                        DateTimeLBL.Text = sdr[3].ToString();
                        img = (byte[])(sdr[4]);
                        if (img == null)
                        {
                            AttachmentTXT.Text = "";
                        }
                        else
                        {
                            MemoryStream ms = new MemoryStream(img);
                            AttachmentTXT.Text = Image.FromStream(ms).ToString();
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
            else
            {
                //ch3.Enabled = false;
            }
        }

        private void lbl4_Click(object sender, EventArgs e)
        {
            if (lbl4.Text != String.Empty)
            {
                //ch4.Enabled = true;
                cap = x4;
                if (lblLocation.Text.Equals("Inbox Mails") && rd4 == "0")
                {
                    rd4 = "1";
                    ReadStatus = rd4;
                    this.lbl4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    ChangeReadStatus();
                }
                openReadBox();
                try
                {
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }
                    cmd.Connection = con;
                    runSqlCmnd();
                    cmd.ExecuteNonQuery();
                    cmd.Clone();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        textBox2.Text = sdr[0].ToString();
                        textBox3.Text = sdr[1].ToString();
                        richTextBox1.Text = sdr[2].ToString();
                        DateTimeLBL.Text = sdr[3].ToString();
                        img = (byte[])(sdr[4]);
                        if (img == null)
                        {
                            AttachmentTXT.Text = "";
                        }
                        else
                        {
                            MemoryStream ms = new MemoryStream(img);
                            AttachmentTXT.Text = Image.FromStream(ms).ToString();
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
            else
            {
                //ch4.Enabled = false;
            }
        }

        private void lbl5_Click(object sender, EventArgs e)
        {
            if (lbl5.Text != String.Empty)
            {
                //ch5.Enabled = true;
                cap = x5;
                if (lblLocation.Text.Equals("Inbox Mails") && rd5 == "0")
                {
                    rd5 = "1";
                    ReadStatus = rd5;
                    this.lbl5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    ChangeReadStatus();
                }
                openReadBox();
                try
                {
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }
                    cmd.Connection = con;
                    runSqlCmnd();
                    cmd.ExecuteNonQuery();
                    cmd.Clone();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        textBox2.Text = sdr[0].ToString();
                        textBox3.Text = sdr[1].ToString();
                        richTextBox1.Text = sdr[2].ToString();
                        DateTimeLBL.Text = sdr[3].ToString();
                        img = (byte[])(sdr[4]);
                        if (img == null)
                        {
                            AttachmentTXT.Text = "";
                        }
                        else
                        {
                            MemoryStream ms = new MemoryStream(img);
                            AttachmentTXT.Text = Image.FromStream(ms).ToString();
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
            else
            {
                //ch5.Enabled = false;
            }
        }

        private void lbl6_Click(object sender, EventArgs e)
        {
            if (lbl6.Text != String.Empty)
            {
                //ch6.Enabled = true;
                cap = x6;
                if (lblLocation.Text.Equals("Inbox Mails") && rd6 == "0")
                {
                    rd6 = "1";
                    ReadStatus = rd6;
                    this.lbl6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    ChangeReadStatus();
                }
                openReadBox();
                try
                {
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }
                    cmd.Connection = con;
                    runSqlCmnd();
                    cmd.ExecuteNonQuery();
                    cmd.Clone();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        textBox2.Text = sdr[0].ToString();
                        textBox3.Text = sdr[1].ToString();
                        richTextBox1.Text = sdr[2].ToString();
                        DateTimeLBL.Text = sdr[3].ToString();
                        img = (byte[])(sdr[4]);
                        if (img == null)
                        {
                            AttachmentTXT.Text = "";
                        }
                        else
                        {
                            MemoryStream ms = new MemoryStream(img);
                            AttachmentTXT.Text = Image.FromStream(ms).ToString();
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
            else
            {
                //ch6.Enabled = false;
            }
        }

        private void lbl7_Click(object sender, EventArgs e)
        {
            if (lbl7.Text != String.Empty)
            {
                //ch7.Enabled = true;
                cap = x7;
                if (lblLocation.Text.Equals("Inbox Mails") && rd7 == "0")
                {
                    rd7 = "1";
                    ReadStatus = rd7;
                    this.lbl7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    ChangeReadStatus();
                }
                openReadBox();
                try
                {
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }
                    cmd.Connection = con;
                    runSqlCmnd();
                    cmd.ExecuteNonQuery();
                    cmd.Clone();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        textBox2.Text = sdr[0].ToString();
                        textBox3.Text = sdr[1].ToString();
                        richTextBox1.Text = sdr[2].ToString();
                        DateTimeLBL.Text = sdr[3].ToString();
                        img = (byte[])(sdr[4]);
                        if (img == null)
                        {
                            AttachmentTXT.Text = "";
                        }
                        else
                        {
                            MemoryStream ms = new MemoryStream(img);
                            AttachmentTXT.Text = Image.FromStream(ms).ToString();
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
            else
            {
                //ch7.Enabled = false;
            }
        }

        private void lbl8_Click(object sender, EventArgs e)
        {
            if (lbl8.Text != String.Empty)
            {
                //ch8.Enabled = true;
                cap = x8;
                if (lblLocation.Text.Equals("Inbox Mails") && rd8 == "0")
                {
                    rd8 = "1";
                    ReadStatus = rd8;
                    this.lbl8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    ChangeReadStatus();
                }
                openReadBox();
                try
                {
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }
                    cmd.Connection = con;
                    runSqlCmnd();
                    cmd.ExecuteNonQuery();
                    cmd.Clone();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        textBox2.Text = sdr[0].ToString();
                        textBox3.Text = sdr[1].ToString();
                        richTextBox1.Text = sdr[2].ToString();
                        DateTimeLBL.Text = sdr[3].ToString();
                        img = (byte[])(sdr[4]);
                        if (img == null)
                        {
                            AttachmentTXT.Text = "";
                        }
                        else
                        {
                            MemoryStream ms = new MemoryStream(img);
                            AttachmentTXT.Text = Image.FromStream(ms).ToString();
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
            else
            {
                //ch8.Enabled = false;
            }
        }

        private void lbl9_Click(object sender, EventArgs e)
        {
            if (lbl9.Text != String.Empty)
            {
                //ch9.Enabled = true;
                cap = x9;
                if (lblLocation.Text.Equals("Inbox Mails") && rd9 == "0")
                {
                    rd9 = "1";
                    ReadStatus = rd9;
                    this.lbl9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    ChangeReadStatus();
                }
                openReadBox();
                try
                {
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }
                    cmd.Connection = con;
                    runSqlCmnd();
                    cmd.ExecuteNonQuery();
                    cmd.Clone();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        textBox2.Text = sdr[0].ToString();
                        textBox3.Text = sdr[1].ToString();
                        richTextBox1.Text = sdr[2].ToString();
                        DateTimeLBL.Text = sdr[3].ToString();
                        img = (byte[])(sdr[4]);
                        if (img == null)
                        {
                            AttachmentTXT.Text = "";
                        }
                        else
                        {
                            MemoryStream ms = new MemoryStream(img);
                            AttachmentTXT.Text = Image.FromStream(ms).ToString();
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
            else
            {
                //ch9.Enabled = false;
            }
        }

        private void lbl10_Click(object sender, EventArgs e)
        {
            if (lbl10.Text != String.Empty)
            {
                //ch10.Enabled = true;
                cap = x10;
                if (lblLocation.Text.Equals("Inbox Mails") && rd10 == "0")
                {
                    rd10 = "1";
                    ReadStatus = rd10;
                    this.lbl10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    ChangeReadStatus();
                }
                openReadBox();
                try
                {
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }
                    cmd.Connection = con;
                    runSqlCmnd();
                    cmd.ExecuteNonQuery();
                    cmd.Clone();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        textBox2.Text = sdr[0].ToString();
                        textBox3.Text = sdr[1].ToString();
                        richTextBox1.Text = sdr[2].ToString();
                        DateTimeLBL.Text = sdr[3].ToString();
                        img = (byte[])(sdr[4]);
                        if (img == null)
                        {
                            AttachmentTXT.Text = "";
                        }
                        else
                        {
                            MemoryStream ms = new MemoryStream(img);
                            AttachmentTXT.Text = Image.FromStream(ms).ToString();
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
            else
            {
                //ch10.Enabled = false;
            }
        }

        private void lbl11_Click(object sender, EventArgs e)
        {
            if (lbl11.Text != String.Empty)
            {
                //ch11.Enabled = true;
                cap = x11;
                if (lblLocation.Text.Equals("Inbox Mails") && rd11 == "0")
                {
                    rd11 = "1";
                    ReadStatus = rd11;
                    this.lbl11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    ChangeReadStatus();
                }
                openReadBox();
                try
                {
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }
                    cmd.Connection = con;
                    runSqlCmnd();
                    cmd.ExecuteNonQuery();
                    cmd.Clone();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        textBox2.Text = sdr[0].ToString();
                        textBox3.Text = sdr[1].ToString();
                        richTextBox1.Text = sdr[2].ToString();
                        DateTimeLBL.Text = sdr[3].ToString();
                        img = (byte[])(sdr[4]);
                        if (img == null)
                        {
                            AttachmentTXT.Text = "";
                        }
                        else
                        {
                            MemoryStream ms = new MemoryStream(img);
                            AttachmentTXT.Text = Image.FromStream(ms).ToString();
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
            else
            {
                //ch11.Enabled = false;
            }
        }

        private void lbl12_Click(object sender, EventArgs e)
        {
            if (lbl12.Text != String.Empty)
            {
                //ch12.Enabled = true;
                cap = x12;
                if (lblLocation.Text.Equals("Inbox Mails") && rd12 == "0")
                {
                    rd12 = "1";
                    ReadStatus = rd12;
                    this.lbl12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    ChangeReadStatus();
                }
                openReadBox();
                try
                {
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }
                    cmd.Connection = con;
                    runSqlCmnd();
                    cmd.ExecuteNonQuery();
                    cmd.Clone();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        textBox2.Text = sdr[0].ToString();
                        textBox3.Text = sdr[1].ToString();
                        richTextBox1.Text = sdr[2].ToString();
                        DateTimeLBL.Text = sdr[3].ToString();
                        img = (byte[])(sdr[4]);
                        if (img == null)
                        {
                            AttachmentTXT.Text = "";
                        }
                        else
                        {
                            MemoryStream ms = new MemoryStream(img);
                            AttachmentTXT.Text = Image.FromStream(ms).ToString();
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
            else
            {
                //ch12.Enabled = false;
            }
        }

        private void lbl13_Click(object sender, EventArgs e)
        {
            if (lbl13.Text != String.Empty)
            {
                //ch13.Enabled = true;
                cap = x13;
                if (lblLocation.Text.Equals("Inbox Mails") && rd13 == "0")
                {
                    rd13 = "1";
                    ReadStatus = rd13;
                    this.lbl13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    ChangeReadStatus();
                }
                openReadBox();
                try
                {
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }
                    cmd.Connection = con;
                    runSqlCmnd();
                    cmd.ExecuteNonQuery();
                    cmd.Clone();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        textBox2.Text = sdr[0].ToString();
                        textBox3.Text = sdr[1].ToString();
                        richTextBox1.Text = sdr[2].ToString();
                        DateTimeLBL.Text = sdr[3].ToString();
                        img = (byte[])(sdr[4]);
                        if (img == null)
                        {
                            AttachmentTXT.Text = "";
                        }
                        else
                        {
                            MemoryStream ms = new MemoryStream(img);
                            AttachmentTXT.Text = Image.FromStream(ms).ToString();
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
            else
            {
                //ch13.Enabled = false;
            }
        }

        private void lbl14_Click(object sender, EventArgs e)
        {
            if (lbl14.Text != String.Empty)
            {
                //ch14.Enabled = true;
                cap = x14;
                if (lblLocation.Text.Equals("Inbox Mails") && rd14 == "0")
                {
                    rd14 = "1";
                    ReadStatus = rd14;
                    this.lbl14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    ChangeReadStatus();
                }
                openReadBox();
                try
                {
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }
                    cmd.Connection = con;
                    runSqlCmnd();
                    cmd.ExecuteNonQuery();
                    cmd.Clone();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        textBox2.Text = sdr[0].ToString();
                        textBox3.Text = sdr[1].ToString();
                        richTextBox1.Text = sdr[2].ToString();
                        DateTimeLBL.Text = sdr[3].ToString();
                        img = (byte[])(sdr[4]);
                        if (img == null)
                        {
                            AttachmentTXT.Text = "";
                        }
                        else
                        {
                            MemoryStream ms = new MemoryStream(img);
                            AttachmentTXT.Text = Image.FromStream(ms).ToString();
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
            else
            {
                //ch14.Enabled = false;
            }
        }

        private void lbl15_Click(object sender, EventArgs e)
        {
            if (lbl15.Text != String.Empty)
            {
                //ch15.Enabled = true;
                cap = x15;
                if (lblLocation.Text.Equals("Inbox Mails") && rd15 == "0")
                {
                    rd15 = "1";
                    ReadStatus = rd15;
                    this.lbl15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    ChangeReadStatus();
                }
                openReadBox();
                try
                {
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }
                    cmd.Connection = con;
                    runSqlCmnd();
                    cmd.ExecuteNonQuery();
                    cmd.Clone();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        textBox2.Text = sdr[0].ToString();
                        textBox3.Text = sdr[1].ToString();
                        richTextBox1.Text = sdr[2].ToString();
                        DateTimeLBL.Text = sdr[3].ToString();
                        img = (byte[])(sdr[4]);
                        if (img == null)
                        {
                            AttachmentTXT.Text = "";
                        }
                        else
                        {
                            MemoryStream ms = new MemoryStream(img);
                            AttachmentTXT.Text = Image.FromStream(ms).ToString();
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
            else
            {
                //chk15.Enabled = false;
            }
        }
        //mouse click end-------------------------------------------}
        //CheckBox Click event Start---------------------------------------
        private void chk1_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk1.CheckState.Equals(CheckState.Checked))
            {
                lbl1.BackColor = ColorTranslator.FromHtml("#0f001a");
                lbl1.ForeColor = ColorTranslator.FromHtml("#ffffff");

                Delete = x1;
                Replay = x1;
                Forward = x1;
                chk2.CheckState = CheckState.Unchecked;
                chk3.CheckState = CheckState.Unchecked;
                chk4.CheckState = CheckState.Unchecked;
                chk5.CheckState = CheckState.Unchecked;
                chk6.CheckState = CheckState.Unchecked;
                chk7.CheckState = CheckState.Unchecked;
                chk8.CheckState = CheckState.Unchecked;
                chk9.CheckState = CheckState.Unchecked;
                chk10.CheckState = CheckState.Unchecked;
                chk11.CheckState = CheckState.Unchecked;
                chk12.CheckState = CheckState.Unchecked;
                chk13.CheckState = CheckState.Unchecked;
                chk14.CheckState = CheckState.Unchecked;
                chk15.CheckState = CheckState.Unchecked;
            }
            else if (chk1.CheckState.Equals(CheckState.Unchecked))
            {
                lbl1.BackColor = ColorTranslator.FromHtml("#ffffff");
                lbl1.ForeColor = ColorTranslator.FromHtml("#0f001a");

                Delete = null;
                Replay = null;
                Forward = null;
            }
        }

        private void chk2_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk2.CheckState.Equals(CheckState.Checked))
            {
                lbl2.BackColor = ColorTranslator.FromHtml("#0f001a");
                lbl2.ForeColor = ColorTranslator.FromHtml("#ffffff");

                Delete = x2;
                Replay = x2;
                Forward = x2;
                chk1.CheckState = CheckState.Unchecked;
                chk3.CheckState = CheckState.Unchecked;
                chk4.CheckState = CheckState.Unchecked;
                chk5.CheckState = CheckState.Unchecked;
                chk6.CheckState = CheckState.Unchecked;
                chk7.CheckState = CheckState.Unchecked;
                chk8.CheckState = CheckState.Unchecked;
                chk9.CheckState = CheckState.Unchecked;
                chk10.CheckState = CheckState.Unchecked;
                chk11.CheckState = CheckState.Unchecked;
                chk12.CheckState = CheckState.Unchecked;
                chk13.CheckState = CheckState.Unchecked;
                chk14.CheckState = CheckState.Unchecked;
                chk15.CheckState = CheckState.Unchecked;
            }
            else if (chk2.CheckState.Equals(CheckState.Unchecked))
            {
                lbl2.BackColor = ColorTranslator.FromHtml("#ffffff");
                lbl2.ForeColor = ColorTranslator.FromHtml("#0f001a");

                Delete = null;
                Replay = null;
                Forward = null;
            }
        }

        private void chk3_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk3.CheckState.Equals(CheckState.Checked))
            {
                lbl3.BackColor = ColorTranslator.FromHtml("#0f001a");
                lbl3.ForeColor = ColorTranslator.FromHtml("#ffffff");

                Delete = x3;
                Replay = x3;
                Forward = x3;
                chk1.CheckState = CheckState.Unchecked;
                chk2.CheckState = CheckState.Unchecked;
                chk4.CheckState = CheckState.Unchecked;
                chk5.CheckState = CheckState.Unchecked;
                chk6.CheckState = CheckState.Unchecked;
                chk7.CheckState = CheckState.Unchecked;
                chk8.CheckState = CheckState.Unchecked;
                chk9.CheckState = CheckState.Unchecked;
                chk10.CheckState = CheckState.Unchecked;
                chk11.CheckState = CheckState.Unchecked;
                chk12.CheckState = CheckState.Unchecked;
                chk13.CheckState = CheckState.Unchecked;
                chk14.CheckState = CheckState.Unchecked;
                chk15.CheckState = CheckState.Unchecked;
            }
            else if (chk3.CheckState.Equals(CheckState.Unchecked))
            {
                lbl3.BackColor = ColorTranslator.FromHtml("#ffffff");
                lbl3.ForeColor = ColorTranslator.FromHtml("#0f001a");

                Delete = null;
                Replay = null;
                Forward = null;
            }
        }

        private void chk4_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk4.CheckState.Equals(CheckState.Checked))
            {
                lbl4.BackColor = ColorTranslator.FromHtml("#0f001a");
                lbl4.ForeColor = ColorTranslator.FromHtml("#ffffff");

                Delete = x4;
                Replay = x4;
                Forward = x4;
                chk1.CheckState = CheckState.Unchecked;
                chk2.CheckState = CheckState.Unchecked;
                chk3.CheckState = CheckState.Unchecked;
                chk5.CheckState = CheckState.Unchecked;
                chk6.CheckState = CheckState.Unchecked;
                chk7.CheckState = CheckState.Unchecked;
                chk8.CheckState = CheckState.Unchecked;
                chk9.CheckState = CheckState.Unchecked;
                chk10.CheckState = CheckState.Unchecked;
                chk11.CheckState = CheckState.Unchecked;
                chk12.CheckState = CheckState.Unchecked;
                chk13.CheckState = CheckState.Unchecked;
                chk14.CheckState = CheckState.Unchecked;
                chk15.CheckState = CheckState.Unchecked;
            }
            else if (chk4.CheckState.Equals(CheckState.Unchecked))
            {
                lbl4.BackColor = ColorTranslator.FromHtml("#ffffff");
                lbl4.ForeColor = ColorTranslator.FromHtml("#0f001a");

                Delete = null;
                Replay = null;
                Forward = null;
            }
        }

        private void chk5_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk5.CheckState.Equals(CheckState.Checked))
            {
                lbl5.BackColor = ColorTranslator.FromHtml("#0f001a");
                lbl5.ForeColor = ColorTranslator.FromHtml("#ffffff");

                Delete = x5;
                Replay = x5;
                Forward = x5;
                chk1.CheckState = CheckState.Unchecked;
                chk2.CheckState = CheckState.Unchecked;
                chk3.CheckState = CheckState.Unchecked;
                chk4.CheckState = CheckState.Unchecked;
                chk6.CheckState = CheckState.Unchecked;
                chk7.CheckState = CheckState.Unchecked;
                chk8.CheckState = CheckState.Unchecked;
                chk9.CheckState = CheckState.Unchecked;
                chk10.CheckState = CheckState.Unchecked;
                chk11.CheckState = CheckState.Unchecked;
                chk12.CheckState = CheckState.Unchecked;
                chk13.CheckState = CheckState.Unchecked;
                chk14.CheckState = CheckState.Unchecked;
                chk15.CheckState = CheckState.Unchecked;
            }
            else if (chk5.Checked != true)
            {
                lbl5.BackColor = ColorTranslator.FromHtml("#ffffff");
                lbl5.ForeColor = ColorTranslator.FromHtml("#0f001a");

                Delete = null;
                Replay = null;
                Forward = null;
            }
        }

        private void chk6_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk6.CheckState.Equals(CheckState.Checked))
            {
                lbl6.BackColor = ColorTranslator.FromHtml("#0f001a");
                lbl6.ForeColor = ColorTranslator.FromHtml("#ffffff");

                Delete = x6;
                Replay = x6;
                Forward = x6;
                chk1.CheckState = CheckState.Unchecked;
                chk2.CheckState = CheckState.Unchecked;
                chk3.CheckState = CheckState.Unchecked;
                chk4.CheckState = CheckState.Unchecked;
                chk5.CheckState = CheckState.Unchecked;
                chk7.CheckState = CheckState.Unchecked;
                chk8.CheckState = CheckState.Unchecked;
                chk9.CheckState = CheckState.Unchecked;
                chk10.CheckState = CheckState.Unchecked;
                chk11.CheckState = CheckState.Unchecked;
                chk12.CheckState = CheckState.Unchecked;
                chk13.CheckState = CheckState.Unchecked;
                chk14.CheckState = CheckState.Unchecked;
                chk15.CheckState = CheckState.Unchecked;
            }
            else if (chk6.CheckState.Equals(CheckState.Unchecked))
            {
                lbl6.BackColor = ColorTranslator.FromHtml("#ffffff");
                lbl6.ForeColor = ColorTranslator.FromHtml("#0f001a");

                Delete = null;
                Replay = null;
                Forward = null;
            }
        }

        private void chk7_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk7.CheckState.Equals(CheckState.Checked))
            {
                lbl7.BackColor = ColorTranslator.FromHtml("#0f001a");
                lbl7.ForeColor = ColorTranslator.FromHtml("#ffffff");

                Delete = x7;
                Replay = x7;
                Forward = x7;
                chk1.CheckState = CheckState.Unchecked;
                chk2.CheckState = CheckState.Unchecked;
                chk3.CheckState = CheckState.Unchecked;
                chk4.CheckState = CheckState.Unchecked;
                chk5.CheckState = CheckState.Unchecked;
                chk6.CheckState = CheckState.Unchecked;
                chk8.CheckState = CheckState.Unchecked;
                chk9.CheckState = CheckState.Unchecked;
                chk10.CheckState = CheckState.Unchecked;
                chk11.CheckState = CheckState.Unchecked;
                chk12.CheckState = CheckState.Unchecked;
                chk13.CheckState = CheckState.Unchecked;
                chk14.CheckState = CheckState.Unchecked;
                chk15.CheckState = CheckState.Unchecked;
            }
            else if (chk7.CheckState.Equals(CheckState.Unchecked))
            {
                lbl7.BackColor = ColorTranslator.FromHtml("#ffffff");
                lbl7.ForeColor = ColorTranslator.FromHtml("#0f001a");

                Delete = null;
                Replay = null;
                Forward = null;
            }
        }

        private void chk8_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk8.CheckState.Equals(CheckState.Checked))
            {
                lbl8.BackColor = ColorTranslator.FromHtml("#0f001a");
                lbl8.ForeColor = ColorTranslator.FromHtml("#ffffff");

                Delete = x8;
                Replay = x8;
                Forward = x8;
                chk1.CheckState = CheckState.Unchecked;
                chk2.CheckState = CheckState.Unchecked;
                chk3.CheckState = CheckState.Unchecked;
                chk4.CheckState = CheckState.Unchecked;
                chk5.CheckState = CheckState.Unchecked;
                chk6.CheckState = CheckState.Unchecked;
                chk7.CheckState = CheckState.Unchecked;
                chk9.CheckState = CheckState.Unchecked;
                chk10.CheckState = CheckState.Unchecked;
                chk11.CheckState = CheckState.Unchecked;
                chk12.CheckState = CheckState.Unchecked;
                chk13.CheckState = CheckState.Unchecked;
                chk14.CheckState = CheckState.Unchecked;
                chk15.CheckState = CheckState.Unchecked;
            }
            else if (chk8.CheckState.Equals(CheckState.Unchecked))
            {
                lbl8.BackColor = ColorTranslator.FromHtml("#ffffff");
                lbl8.ForeColor = ColorTranslator.FromHtml("#0f001a");

                Delete = null;
                Replay = null;
                Forward = null;
            }
        }

        private void chk9_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk9.CheckState.Equals(CheckState.Checked))
            {
                lbl9.BackColor = ColorTranslator.FromHtml("#0f001a");
                lbl9.ForeColor = ColorTranslator.FromHtml("#ffffff");

                Delete = x9;
                Replay = x9;
                Forward = x9;
                chk1.CheckState = CheckState.Unchecked;
                chk2.CheckState = CheckState.Unchecked;
                chk3.CheckState = CheckState.Unchecked;
                chk4.CheckState = CheckState.Unchecked;
                chk5.CheckState = CheckState.Unchecked;
                chk6.CheckState = CheckState.Unchecked;
                chk7.CheckState = CheckState.Unchecked;
                chk8.CheckState = CheckState.Unchecked;
                chk10.CheckState = CheckState.Unchecked;
                chk11.CheckState = CheckState.Unchecked;
                chk12.CheckState = CheckState.Unchecked;
                chk13.CheckState = CheckState.Unchecked;
                chk14.CheckState = CheckState.Unchecked;
                chk15.CheckState = CheckState.Unchecked;
            }
            else if (chk9.CheckState.Equals(CheckState.Unchecked))
            {
                lbl9.BackColor = ColorTranslator.FromHtml("#ffffff");
                lbl9.ForeColor = ColorTranslator.FromHtml("#0f001a");

                Delete = null;
                Replay = null;
                Forward = null;
            }
        }

        private void chk10_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk10.CheckState.Equals(CheckState.Checked))
            {
                lbl10.BackColor = ColorTranslator.FromHtml("#0f001a");
                lbl10.ForeColor = ColorTranslator.FromHtml("#ffffff");

                Delete = x10;
                Replay = x10;
                Forward = x10;
                chk1.CheckState = CheckState.Unchecked;
                chk2.CheckState = CheckState.Unchecked;
                chk3.CheckState = CheckState.Unchecked;
                chk4.CheckState = CheckState.Unchecked;
                chk5.CheckState = CheckState.Unchecked;
                chk6.CheckState = CheckState.Unchecked;
                chk7.CheckState = CheckState.Unchecked;
                chk8.CheckState = CheckState.Unchecked;
                chk9.CheckState = CheckState.Unchecked;
                chk11.CheckState = CheckState.Unchecked;
                chk12.CheckState = CheckState.Unchecked;
                chk13.CheckState = CheckState.Unchecked;
                chk14.CheckState = CheckState.Unchecked;
                chk15.CheckState = CheckState.Unchecked;
            }
            else if (chk10.CheckState.Equals(CheckState.Unchecked))
            {
                lbl10.BackColor = ColorTranslator.FromHtml("#ffffff");
                lbl10.ForeColor = ColorTranslator.FromHtml("#0f001a");

                Delete = null;
                Replay = null;
                Forward = null;
            }
        }

        private void chk11_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk11.CheckState.Equals(CheckState.Checked))
            {
                lbl11.BackColor = ColorTranslator.FromHtml("#0f001a");
                lbl11.ForeColor = ColorTranslator.FromHtml("#ffffff");

                Delete = x11;
                Replay = x11;
                Forward = x11;
                chk1.CheckState = CheckState.Unchecked;
                chk2.CheckState = CheckState.Unchecked;
                chk3.CheckState = CheckState.Unchecked;
                chk4.CheckState = CheckState.Unchecked;
                chk5.CheckState = CheckState.Unchecked;
                chk6.CheckState = CheckState.Unchecked;
                chk7.CheckState = CheckState.Unchecked;
                chk8.CheckState = CheckState.Unchecked;
                chk9.CheckState = CheckState.Unchecked;
                chk10.CheckState = CheckState.Unchecked;
                chk12.CheckState = CheckState.Unchecked;
                chk13.CheckState = CheckState.Unchecked;
                chk14.CheckState = CheckState.Unchecked;
                chk15.CheckState = CheckState.Unchecked;
            }
            else if (chk11.CheckState.Equals(CheckState.Unchecked))
            {
                lbl11.BackColor = ColorTranslator.FromHtml("#ffffff");
                lbl11.ForeColor = ColorTranslator.FromHtml("#0f001a");

                Delete = null;
                Replay = null;
                Forward = null;
            }
        }

        private void chk12_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk12.CheckState.Equals(CheckState.Checked))
            {
                lbl12.BackColor = ColorTranslator.FromHtml("#0f001a");
                lbl12.ForeColor = ColorTranslator.FromHtml("#ffffff");

                Delete = x12;
                Replay = x12;
                Forward = x12;
                chk1.CheckState = CheckState.Unchecked;
                chk2.CheckState = CheckState.Unchecked;
                chk3.CheckState = CheckState.Unchecked;
                chk4.CheckState = CheckState.Unchecked;
                chk5.CheckState = CheckState.Unchecked;
                chk6.CheckState = CheckState.Unchecked;
                chk7.CheckState = CheckState.Unchecked;
                chk8.CheckState = CheckState.Unchecked;
                chk9.CheckState = CheckState.Unchecked;
                chk10.CheckState = CheckState.Unchecked;
                chk11.CheckState = CheckState.Unchecked;
                chk13.CheckState = CheckState.Unchecked;
                chk14.CheckState = CheckState.Unchecked;
                chk15.CheckState = CheckState.Unchecked;
            }
            else if (chk12.CheckState.Equals(CheckState.Unchecked))
            {
                lbl12.BackColor = ColorTranslator.FromHtml("#ffffff");
                lbl12.ForeColor = ColorTranslator.FromHtml("#0f001a");

                Delete = null;
                Replay = null;
                Forward = null;
            }
        }

        private void chk13_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk13.CheckState.Equals(CheckState.Checked))
            {
                lbl13.BackColor = ColorTranslator.FromHtml("#0f001a");
                lbl13.ForeColor = ColorTranslator.FromHtml("#ffffff");

                Delete = x13;
                Replay = x13;
                Forward = x13;
                chk1.CheckState = CheckState.Unchecked;
                chk2.CheckState = CheckState.Unchecked;
                chk3.CheckState = CheckState.Unchecked;
                chk4.CheckState = CheckState.Unchecked;
                chk5.CheckState = CheckState.Unchecked;
                chk6.CheckState = CheckState.Unchecked;
                chk7.CheckState = CheckState.Unchecked;
                chk8.CheckState = CheckState.Unchecked;
                chk9.CheckState = CheckState.Unchecked;
                chk10.CheckState = CheckState.Unchecked;
                chk11.CheckState = CheckState.Unchecked;
                chk12.CheckState = CheckState.Unchecked;
                chk14.CheckState = CheckState.Unchecked;
                chk15.CheckState = CheckState.Unchecked;
            }
            else if (chk13.CheckState.Equals(CheckState.Unchecked))
            {
                lbl13.BackColor = ColorTranslator.FromHtml("#ffffff");
                lbl13.ForeColor = ColorTranslator.FromHtml("#0f001a");

                Delete = null;
                Replay = null;
                Forward = null;
            }
        }

        private void chk14_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk14.CheckState.Equals(CheckState.Checked))
            {
                lbl14.BackColor = ColorTranslator.FromHtml("#0f001a");
                lbl14.ForeColor = ColorTranslator.FromHtml("#ffffff");

                Delete = x14;
                Replay = x14;
                Forward = x14;
                chk1.CheckState = CheckState.Unchecked;
                chk2.CheckState = CheckState.Unchecked;
                chk3.CheckState = CheckState.Unchecked;
                chk4.CheckState = CheckState.Unchecked;
                chk5.CheckState = CheckState.Unchecked;
                chk6.CheckState = CheckState.Unchecked;
                chk7.CheckState = CheckState.Unchecked;
                chk8.CheckState = CheckState.Unchecked;
                chk9.CheckState = CheckState.Unchecked;
                chk10.CheckState = CheckState.Unchecked;
                chk11.CheckState = CheckState.Unchecked;
                chk12.CheckState = CheckState.Unchecked;
                chk13.CheckState = CheckState.Unchecked;
                chk15.CheckState = CheckState.Unchecked;
            }
            else if (chk14.CheckState.Equals(CheckState.Unchecked))
            {
                lbl14.BackColor = ColorTranslator.FromHtml("#ffffff");
                lbl14.ForeColor = ColorTranslator.FromHtml("#0f001a");

                Delete = null;
                Replay = null;
                Forward = null;
            }
        }

        private void chk15_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk15.CheckState.Equals(CheckState.Checked))
            {
                lbl15.BackColor = ColorTranslator.FromHtml("#0f001a");
                lbl15.ForeColor = ColorTranslator.FromHtml("#ffffff");

                Delete = x15;
                Replay = x15;
                Forward = x15;
                chk1.CheckState = CheckState.Unchecked;
                chk2.CheckState = CheckState.Unchecked;
                chk3.CheckState = CheckState.Unchecked;
                chk4.CheckState = CheckState.Unchecked;
                chk5.CheckState = CheckState.Unchecked;
                chk6.CheckState = CheckState.Unchecked;
                chk7.CheckState = CheckState.Unchecked;
                chk8.CheckState = CheckState.Unchecked;
                chk9.CheckState = CheckState.Unchecked;
                chk10.CheckState = CheckState.Unchecked;
                chk11.CheckState = CheckState.Unchecked;
                chk12.CheckState = CheckState.Unchecked;
                chk13.CheckState = CheckState.Unchecked;
                chk14.CheckState = CheckState.Unchecked;
            }
            else if (chk15.CheckState.Equals(CheckState.Unchecked))
            {
                lbl15.BackColor = ColorTranslator.FromHtml("#ffffff");
                lbl15.ForeColor = ColorTranslator.FromHtml("#0f001a");

                Delete = null;
                Replay = null;
                Forward = null;
            }
        }
        //CheckBox Click event end---------------------------------------
        private void BtnGobacktoInbox_Click(object sender, EventArgs e)
        {
            label5.Visible = true;
            label7.Visible = true;
            amounttxt.Visible = true;
            pageLbl.Visible = true;
            ReadBox.Width = 1;
            ReadBox.Height = 466;
            ReadBox.Visible = false;
            textBox2.Text = String.Empty;
            textBox3.Text = String.Empty;
            richTextBox1.Text = String.Empty;
            AttachmentTXT.Text = String.Empty;
            img = null;
            cap = String.Empty;
            ReadStatus = String.Empty;

        }
        //-------------------------------------------------------
        private void lbl1_TextChanged(object sender, EventArgs e)
        {
            if (lbl1.Text != String.Empty)
            {
                this.lbl1.Cursor = Cursors.Hand;
                chk1.Enabled = true;
                Mcount += 1;
            }
            else if (lbl1.Text.Equals(String.Empty))
            {
                this.lbl1.Cursor = Cursors.Default;
                chk1.Enabled = false;
            }
        }

        private void lbl2_TextChanged(object sender, EventArgs e)
        {
            if (lbl2.Text != String.Empty)
            {
                this.lbl2.Cursor = Cursors.Hand;
                chk2.Enabled = true;
                Mcount += 1;
            }
            else if (lbl2.Text.Equals(String.Empty))
            {
                this.lbl2.Cursor = Cursors.Default;
                chk2.Enabled = false;
            }
        }

        private void lbl3_TextChanged(object sender, EventArgs e)
        {
            if (lbl3.Text != String.Empty)
            {
                this.lbl3.Cursor = Cursors.Hand;
                chk3.Enabled = true;
                Mcount += 1;
            }
            else if (lbl3.Text.Equals(String.Empty))
            {
                this.lbl3.Cursor = Cursors.Default;
                chk3.Enabled = false;
            }
        }

        private void lbl4_TextChanged(object sender, EventArgs e)
        {
            if (lbl4.Text != String.Empty)
            {
                this.lbl4.Cursor = Cursors.Hand;
                chk4.Enabled = true;
                Mcount += 1;
            }
            else if (lbl4.Text.Equals(String.Empty))
            {
                this.lbl4.Cursor = Cursors.Default;
                chk4.Enabled = false;
            }
        }

        private void lbl5_TextChanged(object sender, EventArgs e)
        {
            if (lbl5.Text != String.Empty)
            {
                this.lbl5.Cursor = Cursors.Hand;
                chk5.Enabled = true;
                Mcount += 1;
            }
            else if (lbl5.Text.Equals(String.Empty))
            {
                this.lbl5.Cursor = Cursors.Default;
                chk5.Enabled = false;
            }
        }

        private void lbl6_TextChanged(object sender, EventArgs e)
        {
            if (lbl6.Text != String.Empty)
            {
                this.lbl6.Cursor = Cursors.Hand;
                chk6.Enabled = true;
                Mcount += 1;
            }
            else if (lbl6.Text.Equals(String.Empty))
            {
                this.lbl6.Cursor = Cursors.Default;
                chk6.Enabled = false;
            }
        }

        private void lbl7_TextChanged(object sender, EventArgs e)
        {
            if (lbl7.Text != String.Empty)
            {
                this.lbl7.Cursor = Cursors.Hand;
                chk7.Enabled = true;
                Mcount += 1;
            }
            else if (lbl7.Text.Equals(String.Empty))
            {
                this.lbl7.Cursor = Cursors.Default;
                chk7.Enabled = false;
            }
        }

        private void lbl8_TextChanged(object sender, EventArgs e)
        {
            if (lbl8.Text != String.Empty)
            {
                this.lbl8.Cursor = Cursors.Hand;
                chk8.Enabled = true;
                Mcount += 1;
            }
            else if (lbl8.Text.Equals(String.Empty))
            {
                this.lbl8.Cursor = Cursors.Default;
                chk8.Enabled = false;
            }
        }

        private void lbl9_TextChanged(object sender, EventArgs e)
        {
            if (lbl9.Text != String.Empty)
            {
                this.lbl9.Cursor = Cursors.Hand;
                chk9.Enabled = true;
                Mcount += 1;
            }
            else if (lbl9.Text.Equals(String.Empty))
            {
                this.lbl9.Cursor = Cursors.Default;
                chk9.Enabled = false;
            }
        }

        private void lbl10_TextChanged(object sender, EventArgs e)
        {
            if (lbl10.Text != String.Empty)
            {
                this.lbl10.Cursor = Cursors.Hand;
                chk10.Enabled = true;
                Mcount += 1;
            }
            else if (lbl10.Text.Equals(String.Empty))
            {
                this.lbl10.Cursor = Cursors.Default;
                chk10.Enabled = false;
            }
        }

        private void lbl11_TextChanged(object sender, EventArgs e)
        {
            if (lbl11.Text != String.Empty)
            {
                this.lbl11.Cursor = Cursors.Hand;
                chk11.Enabled = true;
                Mcount += 1;
            }
            else if (lbl11.Text.Equals(String.Empty))
            {
                this.lbl11.Cursor = Cursors.Default;
                chk11.Enabled = false;
            }
        }

        private void lbl12_TextChanged(object sender, EventArgs e)
        {
            if (lbl12.Text != String.Empty)
            {
                this.lbl12.Cursor = Cursors.Hand;
                chk12.Enabled = true;
                Mcount += 1;
            }
            else if (lbl12.Text.Equals(String.Empty))
            {
                this.lbl12.Cursor = Cursors.Default;
                chk12.Enabled = false;
            }
        }

        private void lbl13_TextChanged(object sender, EventArgs e)
        {
            if (lbl13.Text != String.Empty)
            {
                this.lbl13.Cursor = Cursors.Hand;
                chk13.Enabled = true;
                Mcount += 1;
            }
            else if (lbl13.Text.Equals(String.Empty))
            {
                this.lbl13.Cursor = Cursors.Default;
                chk13.Enabled = false;
            }
        }

        private void lbl14_TextChanged(object sender, EventArgs e)
        {
            if (lbl14.Text != String.Empty)
            {
                this.lbl14.Cursor = Cursors.Hand;
                chk14.Enabled = true;
                Mcount += 1;
            }
            else if (lbl14.Text.Equals(String.Empty))
            {
                this.lbl14.Cursor = Cursors.Default;
                chk14.Enabled = false;
            }
        }

        private void lbl15_TextChanged(object sender, EventArgs e)
        {
            if (lbl15.Text != String.Empty)
            {
                this.lbl15.Cursor = Cursors.Hand;
                chk15.Enabled = true;
                Mcount += 1;
                ScrollRight.Enabled = true;
            }
            else if (lbl15.Text.Equals(String.Empty))
            {
                this.lbl15.Cursor = Cursors.Default;
                chk15.Enabled = false;
                ScrollRight.Enabled = false;
            }
        }

        private void AttachmentTXT_TextChanged(object sender, EventArgs e)
        {
            if (AttachmentTXT.Text != String.Empty)
            {
                this.AttachmentTXT.Cursor = Cursors.Hand;
                label4.Visible = true;
            }
            else if (AttachmentTXT.Text == String.Empty)
            {
                this.AttachmentTXT.Cursor = Cursors.Default;
                label4.Visible = false;
            }
        }
        //------------------------------------------------------------
        private void MailLoader_Load(object sender, EventArgs e)
        {
            if (lblLocation.Text != "Inbox Mails")
            {
                btnReply.Enabled = false;
            }
            else if (lblLocation.Text == "Inbox Mails")
            {
                btnReply.Enabled = true;
            }

            //-------------------------
            pageLbl.Text = page.ToString();
            if (lbl15.Text == String.Empty)
            {
                ScrollRight.Enabled = false;
            }
            else if (lbl15.Text != String.Empty)
            {
                ScrollRight.Enabled = true;
            }
        }

        private void ScrollLeft_Click(object sender, EventArgs e)
        {
            Mcount = 0;
            page = page - 1;
            pageLbl.Text = page.ToString();
            lblRefresh();
            EventHandler handler = ScrollLeftBtnClicked;
            if (handler != null)
            {
                handler(this, new EventArgs());
            }
        }

        private void pageLbl_TextChanged(object sender, EventArgs e)
        {
            if (pageLbl.Text == "1")
            {
                ScrollLeft.Enabled = false;
            }
            else
            {
                ScrollLeft.Enabled = true;
            }
        }

        private void ScrollRight_Click(object sender, EventArgs e)
        {
            Mcount = 0;
            page = page + 1;
            pageLbl.Text = page.ToString();
            lblRefresh();
            EventHandler handler = ScrollRightBtnClicked;
            if (handler != null)
            {
                handler(this, new EventArgs());
            }
        }

        private void lblRefresh()
        {
            lbl1.Text = "";
            lbl2.Text = "";
            lbl3.Text = "";
            lbl4.Text = "";
            lbl5.Text = "";
            lbl6.Text = "";
            lbl7.Text = "";
            lbl8.Text = "";
            lbl9.Text = "";
            lbl10.Text = "";
            lbl11.Text = "";
            lbl12.Text = "";
            lbl13.Text = "";
            lbl14.Text = "";
            lbl15.Text = "";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            UnchackAll();
            Mail_Reply = null;
            EventHandler handler = CancleBtnClicked;
            if (handler != null)
            {
                handler(this, new EventArgs());
            }
        }

        private void UnchackAll()
        {
            chk1.CheckState = CheckState.Unchecked;
            chk2.CheckState = CheckState.Unchecked;
            chk3.CheckState = CheckState.Unchecked;
            chk4.CheckState = CheckState.Unchecked;
            chk5.CheckState = CheckState.Unchecked;
            chk6.CheckState = CheckState.Unchecked;
            chk7.CheckState = CheckState.Unchecked;
            chk8.CheckState = CheckState.Unchecked;
            chk9.CheckState = CheckState.Unchecked;
            chk10.CheckState = CheckState.Unchecked;
            chk11.CheckState = CheckState.Unchecked;
            chk12.CheckState = CheckState.Unchecked;
            chk13.CheckState = CheckState.Unchecked;
            chk14.CheckState = CheckState.Unchecked;
            chk15.CheckState = CheckState.Unchecked;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Mcount = 0;
            if (Delete != null)
            {
                try
                {
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }
                    cmd.Connection = con;
                    MailDelete();
                    cmd.ExecuteNonQuery();
                    cmd.Clone();
                    ClearLbl();
                    lblRefresh();
                    UnchackAll();
                    page = 1;
                    pageLbl.Text = page.ToString();
                    EventHandler handler = DeleteBtnClicked;
                    if (handler != null)
                    {
                        handler(this, new EventArgs());
                    }
                    //MessageBox.Show("Delete Successfull", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    con.Close();
                }
                catch (Exception ex)
                {
                    con.Close();
                    //MessageBox.Show(ex.Message);
                }
            }
        }

        private void ClearLbl()
        {
            if (Delete == x1)
            {
                lbl1.Text = "";
            }
            else if (Delete == x2)
            {
                lbl2.Text = "";
            }
            else if (Delete == x3)
            {
                lbl3.Text = "";
            }
            else if (Delete == x4)
            {
                lbl4.Text = "";
            }
            else if (Delete == x5)
            {
                lbl5.Text = "";
            }
            else if (Delete == x6)
            {
                lbl6.Text = "";
            }
            else if (Delete == x7)
            {
                lbl7.Text = "";
            }
            else if (Delete == x8)
            {
                lbl8.Text = "";
            }
            else if (Delete == x9)
            {
                lbl9.Text = "";
            }
            else if (Delete == x10)
            {
                lbl10.Text = "";
            }
            else if (Delete == x11)
            {
                lbl11.Text = "";
            }
            else if (Delete == x12)
            {
                lbl12.Text = "";
            }
            else if (Delete == x13)
            {
                lbl13.Text = "";
            }
            else if (Delete == x14)
            {
                lbl14.Text = "";
            }
            else if (Delete == x15)
            {
                lbl15.Text = "";
            }
        }

        private void btnReply_Click(object sender, EventArgs e)
        {
            if (Replay != null)
            {
                try
                {
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }
                    cmd.Connection = con;
                    MailReplay();
                    cmd.ExecuteNonQuery();
                    cmd.Clone();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        Mail_Reply = sdr[0].ToString();
                    }
                    EventHandler handler = ReplayBtnClicked;
                    if (handler != null)
                    {
                        handler(this, new EventArgs());
                    }
                    con.Close();
                    Replay = null;
                }
                catch (Exception ex)
                {
                    con.Close();
                    //MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            if (Forward != null)
            {
                try
                {
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }
                    cmd.Connection = con;
                    MailForword();
                    cmd.ExecuteNonQuery();
                    cmd.Clone();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        F_Subject = sdr[0].ToString();
                        F_Body = sdr[1].ToString();
                        F_Attachment = sdr[2].ToString();
                        /*byte[] imgg = (byte[])(sdr[2]);
                        if (imgg != null)
                        {
                            MemoryStream ms = new MemoryStream(imgg);
                            F_Attachment = Image.FromStream(ms);
                        }
                        else if(imgg==null)
                        {
                            F_Attachment = null;
                        }*/

                    }
                    EventHandler handler = ForwardBtnClicked;
                    if (handler != null)
                    {
                        handler(this, new EventArgs());
                    }
                    con.Close();
                    Forward = null;
                }
                catch (Exception ex)
                {
                    con.Close();
                    //MessageBox.Show(ex.Message);
                }
            }
        }

        private void searchTxt_TextChanged(object sender, EventArgs e)
        {
            Mcount = 0;
            if (searchTxt.Text.Equals(String.Empty))
            {
                searchBtn.Enabled = false;
                if (pageLbl.Text == "1")
                {
                    ScrollLeft.Enabled = false;
                }
                else
                {
                    ScrollLeft.Enabled = true;
                }

                if (lbl15.Text != String.Empty)
                {
                    ScrollRight.Enabled = true;
                }
                else
                {
                    ScrollRight.Enabled = false;
                }
                page = 1;
                pageLbl.Text = page.ToString();
                lblRefresh();
                EventHandler handler = SearchEmpty;
                if (handler != null)
                {
                    handler(this, new EventArgs());
                }
            }
            else if (searchTxt.Text != String.Empty)
            {
                searchBtn.Enabled = true;
                ScrollLeft.Enabled = false;
                ScrollRight.Enabled = false;
            }
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            Mcount = 0;
            if (searchTxt.Text != String.Empty)
            {
                lblRefresh();
                EventHandler handler = SearchBtnClicked;
                if (handler != null)
                {
                    handler(this, new EventArgs());
                }
            }
        }

        private void AttachmentTXT_Click(object sender, EventArgs e)
        {
            saveFile.Filter = "JPG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png|GIF Files (*.gif)|*.gif|All Files (*.*)|*.*";
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                Image file;
                MemoryStream ms = new MemoryStream(img);
                file = Image.FromStream(ms);
                file.Save(saveFile.FileName);
                InfoS = new SoundPlayer("Info.wav");
                CustomMessageBox mb = new CustomMessageBox();
                InfoS.Play();
                mb.CustomMessageTxt.Text = "File saved successfull!";
                mb.ShowDialog();
            }
        }

        private void amounttxt_TextChanged(object sender, EventArgs e)
        {
            Mcount = 0;
            lblRefresh();
            EventHandler handler = InboxRefresh;
            if (handler != null)
            {
                handler(this, new EventArgs());
            }
        }
      
  
     }
       
                        //---------\\------------//
}

