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
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText="SELECT modified_date, staff_id FROM [User] WHERE staff_username='""'+ staff_password='""'"+";
            }catch(Exception ex)
            {
                MessageBox.Show("Connection Fail" + ex);
            }
        }
    }
}
