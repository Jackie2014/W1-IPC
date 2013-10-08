using System;
using System.Collections.Generic;
using System.Windows.Forms;
using IPDectect.Client.Common;

namespace IPDectect.Client
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            bool isAutoStart = false;
            if (args != null && args.Length > 0 && !String.IsNullOrEmpty(args[0]))
            {
                if (args[0].IndexOf(Constants.AUTO_RUN_ARG, StringComparison.OrdinalIgnoreCase) > -1)
                {
                    isAutoStart = true;
                }
               // MessageBox.Show(args[0] + isAutoStart);
            }

            if (isAutoStart)
            {
                string token = DataManager.Read(Constants.SEPARATE_TOKEN);
                Constants.CurrentToken = token;
                // requires login 
                if (String.IsNullOrEmpty(token))
                {
                    isAutoStart = false;
                }
            }

            if (isAutoStart)
            {
                var main = new frmMain(isAutoStart);
                
                Application.Run(main);
            }
            else
            {
                frmLogin loginForm = new frmLogin();
                var result = loginForm.ShowDialog();
                while (result != DialogResult.OK && result != DialogResult.Cancel)
                {
                    result = loginForm.ShowDialog();
                }

                if (result == DialogResult.OK)
                {
                    Application.Run(new frmMain());
                }
            }
        }
    }
}
