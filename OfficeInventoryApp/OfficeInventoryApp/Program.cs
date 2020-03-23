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
            // check login
            /*
            FormLogin login_form = new FormLogin();
            DialogResult login_result = login_form.ShowDialog();
            // if login successful
            if (login_result == DialogResult.OK)
            {
                Form1 main_form = new Form1();
                Application.Run(main_form);
            }
            */
            FormLogin login_form = new FormLogin();
            DialogResult login_result = login_form.ShowDialog();
            if (login_result == DialogResult.OK)
            {
                Form1 main_form = new Form1();
                Application.Run(main_form);
            }
        }
    }
}
