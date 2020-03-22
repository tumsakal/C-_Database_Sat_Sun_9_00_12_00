using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//
using System.Data.SqlClient;

namespace OfficeInventoryApp
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            //1: connection infomation
            SqlConnectionStringBuilder conn_builder = new SqlConnectionStringBuilder();
            //server address/ip
            conn_builder.DataSource = "DESKTOP-BC11FLP";
            //database name
            conn_builder.InitialCatalog = "OfficeDb";
            //username
            conn_builder.UserID = "sa";
            //password
            conn_builder.Password = "12344321";
            //get connection text
            String connection_string = conn_builder.ConnectionString;//conn_builder.ToString();
            //MessageBox.Show(connection_string);
            //2: connect to database
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connection_string;
            conn.Open();
            //MessageBox.Show("Connection open succesfully.");
            //3:command sql server
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            //cmd.CommandText = "SELECT modified_date, staff_id FROM [User] WHERE staff_username = '" + txtUsername.Text.Trim() + "' AND staff_password = '" + txtPassword.Text.Trim() + "'";
            cmd.CommandText = $"SELECT modified_date, staff_id FROM [User] WHERE staff_username = '{txtUsername.Text.Trim()}' AND staff_password = '{txtPassword.Text.Trim()}'";
            //run command
            SqlDataReader data_reader = cmd.ExecuteReader();//2 rows
            if (data_reader.HasRows == true)
            {
                if (data_reader.Read() == true)
                {
                    int id_column_index = 1;
                    string staff_identity = data_reader.GetInt32(id_column_index).ToString();
                    int mod_date_index = 0;
                    DateTime modified_date = data_reader.GetDateTime(mod_date_index);
                    //MessageBox.Show("Staff Id is " + staff_identity + "\n Register at " + modified_date.ToShortDateString());
                    //close form login
                    this.DialogResult = DialogResult.OK;
                }
                conn.Close();
            }
            else
            {
                conn.Close();
                this.DialogResult = DialogResult.No;
            }
        }
    }
}
