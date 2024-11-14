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
    
    public partial class Admin : Form
    {
        
        public Admin()
        {
            InitializeComponent();
            Account.username = "hospital_admin";
            Account.password = "Oracle123";
            Account.connectString = @"Data Source=(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = "
                 + Account.host + ")(PORT = " + Account.port + "))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = "
                 + Account.sid + ")));Password=" + Account.password + ";User ID=" + Account.username;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Priviledge fr = new Priviledge();
            fr.Show();            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Role fr = new Role();
            fr.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            User fr = new User();
            fr.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }
    }
}
