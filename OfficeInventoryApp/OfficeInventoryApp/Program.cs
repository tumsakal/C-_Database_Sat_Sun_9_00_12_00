using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OfficeInventoryApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Check Login
            FormLogin login = new FormLogin();
            DialogResult login_result = login.ShowDialog();
            //if login true
            if (login_result == DialogResult.OK)
            {
                Form1 frm = new Form1();
                Application.Run(frm);
            }
        }
    }
}
