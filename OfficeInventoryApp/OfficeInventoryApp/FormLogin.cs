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
            // info
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "bongsna";
            builder.InitialCatalog = "MyOfficeIventoryDb";
            builder.UserID = "sa";
            builder.Password = "123";
            string connection_string = builder.ConnectionString;
            // connect
            SqlConnection conn = new SqlConnection(connection_string);
            conn.Open();
            // command
            /*string sql_command_txt = " SELECT * FROM [USER] WHERE staff_username ='" + txtUsername.Text.Trim() + "' AND staff_password = '" + txtPassword.Text.Trim() + "'";*/
            string sql_command_txt = $" SELECT staff_id FROM [USER] WHERE staff_username ='{txtUsername.Text.Trim()}' ANd staff_password ='{txtPassword.Text.Trim()}'";
            SqlCommand cmd = new SqlCommand(sql_command_txt, conn);
            // reader
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows == true)
            {
                if (reader.Read() == true)
                {
                    int id_colum_index = 0;
                    string staff_Indenity = reader.GetInt32(id_colum_index).ToString();
                    /*
                    int mo_date_index = 0;
                    DateTime modifi_date = reader.GetDateTime(mo_date_index);                   
                    */
                    this.DialogResult = DialogResult.OK;
                }
            }
            else
            {
                this.DialogResult = DialogResult.No;
                conn.Close();
            }

        }
    }
}
