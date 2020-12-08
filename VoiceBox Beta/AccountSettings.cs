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
    public partial class AccountSettings : UserControl
    {
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\adnan\Desktop\VoiceBox Beta.Final\VoiceBox Beta\DemoEmailServer.mdf;Integrated Security=True;User Instance=True");
        SqlCommand cmd = new SqlCommand();
        string imgLoc;
        byte[] img = null;
        int changePic = 0;

        public event EventHandler NameChanged;

        public AccountSettings()
        {
            InitializeComponent();
        }

        private void emailID_TextChanged(object sender, EventArgs e)
        {
            InitializeUser();
        }

        private void InitializeUser()
        {
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                cmd.Connection = con;
                cmd.CommandText = "select Usr_Name,Usr_Image from User_Info where Mail_ID='" + emailID.Text + "'";
                cmd.ExecuteNonQuery();
                cmd.Clone();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    this.addNametxt.Text = sdr[0].ToString();
                    byte[] img = (byte[])(sdr[1]);
                    if (img == null)
                    {
                        addPic.Image = null;
                    }
                    else
                    {
                        MemoryStream ms = new MemoryStream(img);
                        addPic.Image = Image.FromStream(ms);
                    }
                }
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
                //------------------
            }
        }

        private void addPic_MouseClick(object sender, MouseEventArgs e)
        {
            openFileDialog1.Filter = "JPG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png|GIF Files (*.gif)|*.gif|All Files (*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                changePic = 1;
                addPic.Image = Image.FromFile(openFileDialog1.FileName);
                imgLoc = openFileDialog1.FileName.ToString();
                FileStream fs = new FileStream(imgLoc, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                img = br.ReadBytes((int)fs.Length);
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                cmd.Connection = con;
                //cmd.CommandText = "update User_Info set Usr_Name='" + addNametxt.Text + "', Usr_Image=@img where Mail_ID='" + emailID.Text + "'";
                cmd.CommandText = "update User_Info set Usr_Name='" + addNametxt.Text + "' where Mail_ID='" + emailID.Text + "'";
                if (changePic == 1)
                {
                    cmd.Parameters.Clear();
                    cmd.CommandText = "update User_Info set Usr_Image=@img where Mail_ID='" + emailID.Text + "'";
                    cmd.Parameters.Add(new SqlParameter("@img", img));
                    changePic = 0;
                }

                cmd.ExecuteNonQuery();
                cmd.Clone();

                //MessageBox.Show("Save successfull!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();
                EventHandler handler = NameChanged;
                if (handler != null)
                {
                    handler(this, new EventArgs());
                }
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.Message);
            }
        }
    }
}
