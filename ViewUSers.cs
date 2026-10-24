using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WFA_IGNOUAMS
{
    public partial class ViewUSers : WFA_IGNOUAMS.InhiritableForm
    {
        private int Selectedid;
        public ViewUSers()
        {
            InitializeComponent();
        }

        private void ViewUSers_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'iAMS_DBDataSet.Tbl_User' table. You can move, or remove it, as needed.
            this.tbl_UserTableAdapter.Fill(this.iAMS_DBDataSet.Tbl_User);

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Selectedid = Int32.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                MessageBox.Show(Selectedid.ToString());
                TB_Fullname.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                TB_Email.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                TB_Mobile.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                TB_Username.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                TB_Password.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                Combo_Usertype.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            }


        }

        private void Bt_Update_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = LIbrary.MYConnectionstring;
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = @"UPDATE Tbl_User
                SET Fullname = @fname, Email = @email, Mobile = @mobile, UserType = @User
                ,Username = @username, Password = @pass
                WHERE id = @id";
                
                SqlParameter fname = new SqlParameter();
                fname.ParameterName = "@fname";
                fname.DbType = DbType.String;
                fname.Value = TB_Fullname.Text;

                SqlParameter emailid = new SqlParameter();
                emailid.ParameterName = "@email";
                emailid.DbType = DbType.String;
                emailid.Value = TB_Email.Text;

                SqlParameter mobile = new SqlParameter();
                mobile.ParameterName = "@mobile";
                mobile.DbType = DbType.String;
                mobile.Value = TB_Mobile.Text;

                SqlParameter user = new SqlParameter();
                user.ParameterName = "@User";
                user.DbType = DbType.String;
                user.Value = Combo_Usertype.Text;

                SqlParameter username = new SqlParameter();
                username.ParameterName = "@username";
                username.DbType = DbType.String;
                username.Value = TB_Username.Text;
                
                SqlParameter pass = new SqlParameter();
                pass.ParameterName = "@pass";
                pass.DbType = DbType.String;
                pass.Value = TB_Password.Text;

                SqlParameter id = new SqlParameter();
                id.ParameterName = "@id";
                id.DbType = DbType.Int32;
                id.Value = Selectedid;

                cmd.Parameters.Add(fname);
                cmd.Parameters.Add(emailid);
                cmd.Parameters.Add(mobile);
                cmd.Parameters.Add(user);
                cmd.Parameters.Add(username);
                cmd.Parameters.Add(pass);
                cmd.Parameters.Add(id);

                int row_affected = cmd.ExecuteNonQuery();
                    if (row_affected > 0)
                    {
                        MessageBox.Show("Data Updated successfully!");
                        TB_Fullname.Text = "";
                        TB_Email.Text = "";
                        TB_Mobile.Text = "";
                        TB_Username.Text = "";
                        TB_Password.Text = "";
                      
                    }
            }
            catch (Exception )
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
    }
}
