using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace demo_ATBM
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Account.username = textBox1.Text;
            Account.password = textBox2.Text;
            if (string.IsNullOrWhiteSpace(Account.username) || string.IsNullOrWhiteSpace(Account.password))
            {
                MessageBox.Show("Please provide Username and Password");
                return;
            }
            Account.connectString = @"Data Source=(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = "
                 + Account.host + ")(PORT = " + Account.port + "))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = "
                 + Account.sid + ")));Password=" + Account.password + ";User ID=" + Account.username;
            OracleConnection conn = new OracleConnection(Account.connectString);

            try
            {
                conn.Open();
                MessageBox.Show(Account.username + " Connected!", "Login Notify");
                if (Account.username.Contains("admin"))
                {
                    Admin fr = new Admin();
                    fr.Show();
                    this.Hide();
                }
                else if (Account.username == "NV000001")
                {
                    Admin fr = new Admin();
                    fr.Show();
                    this.Hide();
                }
                else if (Account.username == "NV000003")
                {
                    Admin fr = new Admin();
                    fr.Show();
                    this.Hide();
                }


                //MessageBox.Show("Connected", "Login Notify");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unsuccessful!", "Login Notify");
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
