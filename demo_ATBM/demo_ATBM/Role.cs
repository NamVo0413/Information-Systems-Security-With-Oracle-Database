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
    public partial class Role : Form
    {
        public Role()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OracleConnection conn = new OracleConnection();
            conn.ConnectionString = Account.connectString;

            //conn.Open();
            //DataTable dt = new DataTable();
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = "proc_CreateRole";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("n_role", OracleDbType.Varchar2);
            cmd.Parameters["n_role"].Direction = ParameterDirection.Input;
            cmd.Parameters["n_role"].Value = textBox1.Text;


            cmd.Connection = conn;

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Tạo Role thành công!");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Role_Load(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            OracleConnection conn = new OracleConnection();
            conn.ConnectionString = Account.connectString;

            //conn.Open();
            //DataTable dt = new DataTable();
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = "proc_DropRole";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("n_role", OracleDbType.Varchar2);
            cmd.Parameters["n_role"].Direction = ParameterDirection.Input;
            cmd.Parameters["n_role"].Value = textBox1.Text;


            cmd.Connection = conn;

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Xóa Role thành công!");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OracleConnection conn = new OracleConnection();
            conn.ConnectionString = Account.connectString;

            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = "proc_CheckRole";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("n_check", OracleDbType.Varchar2);
            cmd.Parameters["n_check"].Direction = ParameterDirection.Input;
            cmd.Parameters["n_check"].Value = textBox1.Text;

            cmd.Parameters.Add("c2", OracleDbType.RefCursor);
            cmd.Parameters["c2"].Direction = ParameterDirection.Output;
            //cmd.Parameters["c2"].Value = textBox2.Text;
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
            cmd.CommandText = "proc_GrantRoleForUser";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("n_role", OracleDbType.Varchar2);
            cmd.Parameters["n_role"].Direction = ParameterDirection.Input;
            cmd.Parameters["n_role"].Value = textBox1.Text;

            cmd.Parameters.Add("n_user", OracleDbType.Varchar2);
            cmd.Parameters["n_user"].Direction = ParameterDirection.Input;
            cmd.Parameters["n_user"].Value = textBox2.Text;

            cmd.Connection = conn;

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thành công!");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {

            OracleConnection conn = new OracleConnection();
            conn.ConnectionString = Account.connectString;

            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = "proc_RevokeRoleFromUser";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("n_role", OracleDbType.Varchar2);
            cmd.Parameters["n_role"].Direction = ParameterDirection.Input;
            cmd.Parameters["n_role"].Value = textBox1.Text;

            cmd.Parameters.Add("n_user", OracleDbType.Varchar2);
            cmd.Parameters["n_user"].Direction = ParameterDirection.Input;
            cmd.Parameters["n_user"].Value = textBox2.Text;

            cmd.Connection = conn;

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thành công!");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
