
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using Oracle.DataAccess;
//using Oracle.DataAccess.Client;
//using Oracle.DataAccess.Types;
using Oracle.ManagedDataAccess.Client;

namespace demo_ATBM
{
    
    public partial class ATBM : Form
    {
        static string host = "localhost";
        static int port = 1521;
        static string sid = "xepdb1";
        static string user = "admin";
        static string password = "ngocvu123";
        //OracleConnection conn = new OracleConnection();
       
        public ATBM()
        {
            InitializeComponent();
            
            try
            {
                //conn.Open();

                //connect.Enabled = false;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            //MessageBox.Show("OK");s

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OracleConnection conn = new OracleConnection();
            conn.ConnectionString = @"Data Source=(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = "
                 + host + ")(PORT = " + port + "))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = "
                 + sid + ")));Password=" + password + ";User ID=" + user;
            

            try
            {
                conn.Open();
                MessageBox.Show("Connected!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            //conn.Dispose();
            



        }

        private void button2_Click(object sender, EventArgs e)
        {
            OracleConnection conn = new OracleConnection();
            conn.ConnectionString = @"Data Source=(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = "
                 + host + ")(PORT = " + port + "))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = "
                 + sid + ")));Password=" + password + ";User ID=" + user;

            //conn.Open();
                //DataTable dt = new DataTable();
                OracleCommand cmd = new OracleCommand();
                cmd.CommandText = "proc_Users";
                cmd.CommandType = CommandType.StoredProcedure;

                
                
                cmd.Parameters.Add("c1", OracleDbType.RefCursor);
                cmd.Parameters["c1"].Direction = ParameterDirection.Output;
                cmd.Connection = conn;

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;

                
                //conn.Close();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            OracleConnection conn = new OracleConnection();
            conn.ConnectionString = @"Data Source=(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = "
                 + host + ")(PORT = " + port + "))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = "
                 + sid + ")));Password=" + password + ";User ID=" + user;

            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = "proc_Privileges";
            cmd.CommandType = CommandType.StoredProcedure;



            cmd.Parameters.Add("c2", OracleDbType.RefCursor);
            cmd.Parameters["c2"].Direction = ParameterDirection.Output;
            cmd.Connection = conn;

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;


                //conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OracleConnection conn = new OracleConnection();
            conn.ConnectionString = @"Data Source=(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = "
                 + host + ")(PORT = " + port + "))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = "
                 + sid + ")));Password=" + password + ";User ID=" + user;

            //conn.Open();
            //DataTable dt = new DataTable();
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = "proc_CreateUser";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("n_username", OracleDbType.Varchar2);
            cmd.Parameters["n_username"].Direction = ParameterDirection.Input;
            cmd.Parameters["n_username"].Value = textBox1.Text;

            cmd.Parameters.Add("n_password", OracleDbType.Varchar2);
            cmd.Parameters["n_password"].Direction = ParameterDirection.Input;
            cmd.Parameters["n_password"].Value = textBox2.Text;
            cmd.Connection = conn;

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Tạo tài khoản thành công!");
    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OracleConnection conn = new OracleConnection();
            conn.ConnectionString = @"Data Source=(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = "
                 + host + ")(PORT = " + port + "))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = "
                 + sid + ")));Password=" + password + ";User ID=" + user;

            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = "proc_DropUser";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("n_username", OracleDbType.Varchar2);
            cmd.Parameters["n_username"].Direction = ParameterDirection.Input;
            cmd.Parameters["n_username"].Value = textBox1.Text;

            //cmd.Parameters.Add("n_password", OracleDbType.Varchar2);
            //cmd.Parameters["n_password"].Direction = ParameterDirection.Input;
            //cmd.Parameters["n_password"].Value = textBox2.Text;
            cmd.Connection = conn;

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Xóa tài khoản thành công!");
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OracleConnection conn = new OracleConnection();
            conn.ConnectionString = @"Data Source=(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = "
                 + host + ")(PORT = " + port + "))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = "
                 + sid + ")));Password=" + password + ";User ID=" + user;
                    
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = "proc_AlterUser";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("n_username", OracleDbType.Varchar2);
            cmd.Parameters["n_username"].Direction = ParameterDirection.Input;
            cmd.Parameters["n_username"].Value = textBox1.Text;

            cmd.Parameters.Add("n_password", OracleDbType.Varchar2);
            cmd.Parameters["n_password"].Direction = ParameterDirection.Input;
            cmd.Parameters["n_password"].Value = textBox2.Text;
            cmd.Connection = conn;

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Đổi mật khẩu thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            OracleConnection conn = new OracleConnection();
            conn.ConnectionString = @"Data Source=(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = "
                 + host + ")(PORT = " + port + "))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = "
                 + sid + ")));Password=" + password + ";User ID=" + user;

            //conn.Open();
            //DataTable dt = new DataTable();
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = "proc_CreateRole";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("n_role", OracleDbType.Varchar2);
            cmd.Parameters["n_role"].Direction = ParameterDirection.Input;
            cmd.Parameters["n_role"].Value = textBox3.Text;

        
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

        private void button7_Click(object sender, EventArgs e)
        {
            OracleConnection conn = new OracleConnection();
            conn.ConnectionString = @"Data Source=(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = "
                 + host + ")(PORT = " + port + "))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = "
                 + sid + ")));Password=" + password + ";User ID=" + user;

            //conn.Open();
            //DataTable dt = new DataTable();
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = "proc_DropRole";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("n_role", OracleDbType.Varchar2);
            cmd.Parameters["n_role"].Direction = ParameterDirection.Input;
            cmd.Parameters["n_role"].Value = textBox3.Text;


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

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            OracleConnection conn = new OracleConnection();
            conn.ConnectionString = @"Data Source=(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = "
                 + host + ")(PORT = " + port + "))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = "
                 + sid + ")));Password=" + password + ";User ID=" + user;

            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = "proc_CheckRole";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("n_check", OracleDbType.Varchar2);
            cmd.Parameters["n_check"].Direction = ParameterDirection.Input;
            cmd.Parameters["n_check"].Value = textBox10.Text;

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
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            OracleConnection conn = new OracleConnection();
            conn.ConnectionString = @"Data Source=(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = "
                 + host + ")(PORT = " + port + "))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = "
                 + sid + ")));Password=" + password + ";User ID=" + user;

            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = "proc_GrantForUser";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("n_pri", OracleDbType.Varchar2);
            cmd.Parameters["n_pri"].Direction = ParameterDirection.Input;
            cmd.Parameters["n_pri"].Value = textBox5.Text;

            cmd.Parameters.Add("n_obj", OracleDbType.Varchar2);
            cmd.Parameters["n_obj"].Direction = ParameterDirection.Input;
            cmd.Parameters["n_obj"].Value = textBox6.Text;

            cmd.Parameters.Add("n_user", OracleDbType.Varchar2);
            cmd.Parameters["n_user"].Direction = ParameterDirection.Input;
            cmd.Parameters["n_user"].Value = textBox7.Text;

            cmd.Parameters.Add("n_flag", OracleDbType.Char);
            cmd.Parameters["n_flag"].Direction = ParameterDirection.Input;
            
                cmd.Parameters["n_flag"].Value = textBox4.Text;
            //else cmd.Parameters["n_flag"].Value = 'N';
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

        private void button12_Click(object sender, EventArgs e)
        {
            OracleConnection conn = new OracleConnection();
            conn.ConnectionString = @"Data Source=(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = "
                 + host + ")(PORT = " + port + "))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = "
                 + sid + ")));Password=" + password + ";User ID=" + user;

            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = "proc_GrantForRole";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("n_pri", OracleDbType.Varchar2);
            cmd.Parameters["n_pri"].Direction = ParameterDirection.Input;
            cmd.Parameters["n_pri"].Value = textBox5.Text;

            cmd.Parameters.Add("n_obj", OracleDbType.Varchar2);
            cmd.Parameters["n_obj"].Direction = ParameterDirection.Input;
            cmd.Parameters["n_obj"].Value = textBox6.Text;

            cmd.Parameters.Add("n_user", OracleDbType.Varchar2);
            cmd.Parameters["n_user"].Direction = ParameterDirection.Input;
            cmd.Parameters["n_user"].Value = textBox7.Text;

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

        private void button14_Click(object sender, EventArgs e)
        {
            OracleConnection conn = new OracleConnection();
            conn.ConnectionString = @"Data Source=(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = "
                 + host + ")(PORT = " + port + "))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = "
                 + sid + ")));Password=" + password + ";User ID=" + user;

            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = "proc_RevokeAll";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("n_revoke", OracleDbType.Varchar2);
            cmd.Parameters["n_revoke"].Direction = ParameterDirection.Input;
            cmd.Parameters["n_revoke"].Value = textBox10.Text;
            
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

        private void button15_Click(object sender, EventArgs e)
        {
            OracleConnection conn = new OracleConnection();
            conn.ConnectionString = @"Data Source=(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = "
                 + host + ")(PORT = " + port + "))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = "
                 + sid + ")));Password=" + password + ";User ID=" + user;

            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = "proc_CheckUserRole";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("n_check", OracleDbType.Varchar2);
            cmd.Parameters["n_check"].Direction = ParameterDirection.Input;
            cmd.Parameters["n_check"].Value = textBox10.Text;

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
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {

            OracleConnection conn = new OracleConnection();
            conn.ConnectionString = @"Data Source=(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = "
                 + host + ")(PORT = " + port + "))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = "
                 + sid + ")));Password=" + password + ";User ID=" + user;

            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = "proc_GrantRoleForUser";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("n_role", OracleDbType.Varchar2);
            cmd.Parameters["n_role"].Direction = ParameterDirection.Input;
            cmd.Parameters["n_role"].Value = textBox9.Text;

            cmd.Parameters.Add("n_user", OracleDbType.Varchar2);
            cmd.Parameters["n_user"].Direction = ParameterDirection.Input;
            cmd.Parameters["n_user"].Value = textBox8.Text;

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

        private void button13_Click(object sender, EventArgs e)
        {

            OracleConnection conn = new OracleConnection();
            conn.ConnectionString = @"Data Source=(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = "
                 + host + ")(PORT = " + port + "))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = "
                 + sid + ")));Password=" + password + ";User ID=" + user;

            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = "proc_RevokeRoleFromUser";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("n_role", OracleDbType.Varchar2);
            cmd.Parameters["n_role"].Direction = ParameterDirection.Input;
            cmd.Parameters["n_role"].Value = textBox9.Text;

            cmd.Parameters.Add("n_user", OracleDbType.Varchar2);
            cmd.Parameters["n_user"].Direction = ParameterDirection.Input;
            cmd.Parameters["n_user"].Value = textBox8.Text;

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

        private void button18_Click(object sender, EventArgs e)
        {
            OracleConnection conn = new OracleConnection();
            conn.ConnectionString = @"Data Source=(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = "
                 + host + ")(PORT = " + port + "))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = "
                 + sid + ")));Password=" + password + ";User ID=" + user;

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
                dataGridView1.DataSource = dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            OracleConnection conn = new OracleConnection();
            conn.ConnectionString = @"Data Source=(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = "
                 + host + ")(PORT = " + port + "))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = "
                 + sid + ")));Password=" + password + ";User ID=" + user;

            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = "select * from MOVIE";


            cmd.Connection = conn;

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        
        }

        private void button19_Click(object sender, EventArgs e)
        {
            OracleConnection conn = new OracleConnection();
            conn.ConnectionString = @"Data Source=(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = "
                 + host + ")(PORT = " + port + "))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = "
                 + sid + ")));Password=" + password + ";User ID=" + user;

            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = "select DISTINCT PRIVILEGE from DBA_SYS_PRIVS";


            cmd.Connection = conn;

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            OracleConnection conn = new OracleConnection();
            conn.ConnectionString = @"Data Source=(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = "
                 + host + ")(PORT = " + port + "))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = "
                 + sid + ")));Password=" + password + ";User ID=" + user;

            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = "select * from NHANVAT";


            cmd.Connection = conn;

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            OracleConnection conn = new OracleConnection();
            conn.ConnectionString = @"Data Source=(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = "
                 + host + ")(PORT = " + port + "))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = "
                 + sid + ")));Password=" + password + ";User ID=" + user;

            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = "proc_CheckPrivileges";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("n_check", OracleDbType.Varchar2);
            cmd.Parameters["n_check"].Direction = ParameterDirection.Input;
            cmd.Parameters["n_check"].Value = textBox10.Text;

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
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
    
}
