using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ITEC_116
{
    public partial class FormLogin : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        SqlDataReader dr;
        public string _pass, _username = "";

        public static string username = "";

        private void FormLogin_Load(object sender, EventArgs e)
        {
            this.AcceptButton = btnLogin;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                bool found = false;
                cn.Open();
                cm = new SqlCommand("Select * from users where username = @username and password = @password", cn);
                cm.Parameters.AddWithValue("@username", user.Text);
                cm.Parameters.AddWithValue("@password", psw.Text);
                dr = cm.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    
                    _username = dr["username"].ToString();
                    _pass = dr["password"].ToString();
                    found = true;
                    //Send to Home Form
                    username = dr["username"].ToString();
                }
                else
                {
                    found = false;

                }
                dr.Close();
                cn.Close();

                if (found == true)
                {

                    //Messagebox for Successful Login
                    MessageBox.Show("Welcome " + _username + "!", "Access Granted!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //Clear Textfields
                    psw.Clear();
                    user.Clear();
                    //Open Homepage and Close Login
                    FormHome home = new FormHome();
                    home.Show();
                    this.Hide();



                }



                else
                {
                    MessageBox.Show("Invalid Username or Password", "Access Denied!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void btnMinimize_Click_1(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public FormLogin()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.MyConnection());
            cn.Open();
            cn.Close();
        }
    }
}
