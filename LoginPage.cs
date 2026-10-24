using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WFA_IGNOUAMS
{
    public partial class LoginPage : Form
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void BT_Login_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=PAVAN-LAPTOP;Initial Catalog=IAMS_DB;
                                    Integrated Security=True";
            try
            { 
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = @"Select * from Tbl_User where Username= @username and Password = @pass;";
                SqlParameter username = new SqlParameter();
                username.ParameterName = "@username";
                username.DbType = DbType.String;
                username.Value = TB_Username.Text;
                cmd.Parameters.Add(username);
                
                SqlParameter pass = new SqlParameter();
                pass.ParameterName = "@pass";
                pass.DbType = DbType.String;
                pass.Value = TB_Password.Text;
                cmd.Parameters.Add(pass);

                


                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    MessageBox.Show("Login Successful!");
                    MainPage mp = new MainPage();
                    mp.Show();
                    this.Hide();
                    mp.WindowState = FormWindowState.Maximized;

                }
                else
                {
                    MessageBox.Show("User Not Found!");
                }


            }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
            
        }

        private void BT_Cancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
