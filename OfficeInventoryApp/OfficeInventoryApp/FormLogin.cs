using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace OfficeInventoryApp
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "ACER";
                builder.InitialCatalog = "OfficeDb";
                builder.UserID = "sa";
                builder.Password = "123";
                string connection_String = builder.ConnectionString;
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = connection_String;
                conn.Open();
                //Create Command
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = $"SELECT modified_date, staff_id FROM [User] WHERE staff_username='{txtUsername.Text.Trim()}'+ staff_password='{txtPassword.Text.Trim()}'";
                //Run Command


                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows == true)
                {
                    if (reader.Read() == true)
                    {
                        int id_index = 1;
                        string staff_identity = reader.GetInt32(id_index).ToString();
                        int date_index = 0;
                        DateTime modified_date = reader.GetDateTime(date_index);
                        MessageBox.Show("Staff ID " + staff_identity + "\n Register at " + modified_date.ToShortDateString());
                        this.DialogResult = DialogResult.OK;
                    }
                conn.Close();
                }
                else
                {
                    conn.Close();
                    this.DialogResult = DialogResult.No;
                }
            }catch(Exception ex)
            {
                MessageBox.Show("Connection Fail" + ex);
            }
        }
    }
}
