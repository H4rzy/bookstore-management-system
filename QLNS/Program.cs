using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLNS.Forms;

namespace QLNS
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            // Show login form first
            using (var loginForm = new FormLogin())
            {
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    // Login successful, show main form
                    Application.Run(new Form1());
                }
                else
                {
                    // Login failed or cancelled, exit application
                    Application.Exit();
                }
            }
        }
    }
}
