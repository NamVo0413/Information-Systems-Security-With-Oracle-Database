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
    public partial class Priviledge : Form
    {
        public Priviledge()
        {
            InitializeComponent();
        }

        private void admin_GridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OracleConnection conn = new OracleConnection();
            conn.ConnectionString = Account.connectString;

            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = "proc_GrantForUser";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("n_pri", OracleDbType.Varchar2);
            cmd.Parameters["n_pri"].Direction = ParameterDirection.Input;
            cmd.Parameters["n_pri"].Value = textBox1.Text;

            cmd.Parameters.Add("n_obj", OracleDbType.Varchar2);
            cmd.Parameters["n_obj"].Direction = ParameterDirection.Input;
            cmd.Parameters["n_obj"].Value = textBox2.Text;

            cmd.Parameters.Add("n_user", OracleDbType.Varchar2);
            cmd.Parameters["n_user"].Direction = ParameterDirection.Input;
            cmd.Parameters["n_user"].Value = textBox3.Text;

            cmd.Parameters.Add("n_flag", OracleDbType.Char);
            cmd.Parameters["n_flag"].Direction = ParameterDirection.Input;

            if (checkBox1.Checked)
                cmd.Parameters["n_flag"].Value = DBNull.Value;
            else cmd.Parameters["n_flag"].Value = 'N';
            cmd.Connection = conn;

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Success!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Priviledge_Load(object sender, EventArgs e)
        {
            OracleConnection conn = new OracleConnection();
            conn.ConnectionString = Account.connectString;

            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = "select DISTINCT GRANTED_ROLE from DBA_ROLE_PRIVS";


            cmd.Connection = conn;

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                admin_GridView.DataSource = dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OracleConnection conn = new OracleConnection();
            conn.ConnectionString = Account.connectString;
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = "proc_GrantForRole";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("n_pri", OracleDbType.Varchar2);
            cmd.Parameters["n_pri"].Direction = ParameterDirection.Input;
            cmd.Parameters["n_pri"].Value = textBox1.Text;

            cmd.Parameters.Add("n_obj", OracleDbType.Varchar2);
            cmd.Parameters["n_obj"].Direction = ParameterDirection.Input;
            cmd.Parameters["n_obj"].Value = textBox2.Text;

            cmd.Parameters.Add("n_user", OracleDbType.Varchar2);
            cmd.Parameters["n_user"].Direction = ParameterDirection.Input;
            cmd.Parameters["n_user"].Value = textBox3.Text;

            cmd.Connection = conn;

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Success!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            OracleConnection conn = new OracleConnection();
            conn.ConnectionString = Account.connectString;

            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = "proc_RevokeAll";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("n_revoke", OracleDbType.Varchar2);
            cmd.Parameters["n_revoke"].Direction = ParameterDirection.Input;
            cmd.Parameters["n_revoke"].Value = textBox3.Text;

            cmd.Connection = conn;

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Success!");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OracleConnection conn = new OracleConnection();
            conn.ConnectionString = Account.connectString;

            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = "select DISTINCT GRANTED_ROLE from DBA_ROLE_PRIVS";


            cmd.Connection = conn;

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                admin_GridView.DataSource = dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OracleConnection conn = new OracleConnection();
            conn.ConnectionString = Account.connectString;

            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = "proc_RevokeFromUser";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("n_pri", OracleDbType.Varchar2);
            cmd.Parameters["n_pri"].Direction = ParameterDirection.Input;
            cmd.Parameters["n_pri"].Value = textBox1.Text;

            cmd.Parameters.Add("n_obj", OracleDbType.Varchar2);
            cmd.Parameters["n_obj"].Direction = ParameterDirection.Input;
            cmd.Parameters["n_obj"].Value = textBox2.Text;

            cmd.Parameters.Add("n_user", OracleDbType.Varchar2);
            cmd.Parameters["n_user"].Direction = ParameterDirection.Input;
            cmd.Parameters["n_user"].Value = textBox3.Text;

            cmd.Connection = conn;

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Success!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
