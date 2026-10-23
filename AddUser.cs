using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WFA_IGNOUAMS
{
    public partial class AddUser : WFA_IGNOUAMS.InhiritableForm
    {
        public AddUser()
        {
            InitializeComponent();
        }

        private void BT_Cancel_Click(object sender, EventArgs e)
        {
            TB_Fullname.Text = "";
            TB_Email.Text = "";
            TB_Mobile.Text = "";
            TB_Username.Text = "";
            TB_Password.Text = "";
            TB_ConfPassword.Text = "";
            
        }

        private void BT_Submit_Click(object sender, EventArgs e)
        {
            if (TB_Password.Text.Equals(TB_ConfPassword.Text))
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = LIbrary.MYConnectionstring;
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;

                    cmd.CommandText = @"Select * from Tbl_User where Username='" + TB_Username.Text +
                                     "' and Password = '" + TB_Password.Text + "';";
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        MessageBox.Show(TB_Username.Text + " Already exist with the given password.");
                    }
                    else
                    {
                        reader.Close();
                        cmd.CommandText = @"INSERT INTO Tbl_User 
                                    (Fullname, Email, Mobile, UserType, Username, Password)
                                    VALUES 
                                    ('" + TB_Fullname.Text + "','" + TB_Email.Text + "','" + TB_Mobile.Text + "','"
                                    + Combo_Usertype.Text + "','" + TB_Username.Text + "','"
                                    + TB_Password.Text + "')";
                        int row_affected = cmd.ExecuteNonQuery();
                        if (row_affected > 0)
                        {
                            MessageBox.Show("Data Inserted successfully!");
                            TB_Fullname.Text = "";
                            TB_Email.Text = "";
                            TB_Mobile.Text = "";
                            TB_Username.Text = "";
                            TB_Password.Text = "";
                            TB_ConfPassword.Text = "";
                        }

                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Something went wrong Please try again!");
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    { 
                        con.Close();
                    }
                    
                }

            }
            else 
            {
                MessageBox.Show("Password and Confirm Password Not Match!");
            }
        }
    }
}
