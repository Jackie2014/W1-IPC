using System;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Threading;
//using IPDectect.Client.Common;

namespace IPDectect.Client.AutoUpdate
{
	public class Program
	{
		[STAThread]
		public static void Main(string[] args)
		{
            try
            {
                //1. check whether exist new update
                List<FileItem> downloadFiles = null;
                bool needToDownload = DownloadService.NeedToDownload(out downloadFiles);

                //2. if there exist new version, start progress form to Download the latest file 
                if (needToDownload)
                {
                    progressForm form = new progressForm(downloadFiles);
                    Application.Run(form);
                    StartMainAndExitAutoUpdate(args);
                }
                else
                {
                    //3. if no new version, start main.exe directly then exist current application.
                    StartMainAndExitAutoUpdate(args);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误");
            }
		}

        private static void StartMainAndExitAutoUpdate(string[] args)
        {
            string arg = null;
            if(args != null && args.Length > 0)
            {
                arg = args[0];
            }
            string mainPath = String.Format("{0}\\{1}",Application.StartupPath , Constants.App_Assembly_FilePath);
            if (!File.Exists(mainPath))
            {
                MessageBox.Show("本地不存在main.exe，无法启动程序。", "错误");
            }
            else
            {
                System.Diagnostics.Process.Start(mainPath, arg);
            }

            Application.Exit();
        }
	}
}