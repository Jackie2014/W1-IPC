using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Threading;

namespace IPDectect.Client.AutoUpdate
{
    public partial class progressForm : Form
    {
        List<FileItem> _files;
        public progressForm(List<FileItem> files)
        {
            _files = files;
            InitializeComponent();
        }

        private void progressForm_Load(object sender, EventArgs e)
        {
            Download();
        }

        private void Download()
        {
            int totalSize = 0;
            foreach (FileItem fi in _files)
            {
                totalSize += fi.FileSize;
            }

            progressBar1.Maximum = totalSize;
            progressBar1.Value = 0;

            using (WebClient downloader = new WebClient())
            {
                ServicePointManager.ServerCertificateValidationCallback =
                     ((sender, certificate, chain, sslPolicyErrors) => true);
                downloader.DownloadProgressChanged += new DownloadProgressChangedEventHandler(downloader_DownloadProgressChanged);
                downloader.DownloadDataCompleted += new DownloadDataCompletedEventHandler(downloader_DownloadDataCompleted);

                foreach (FileItem fileInfo in _files)
                {
                    string downloadUrl = Constants.Server_Download_Directory + "/" + fileInfo.FileName + "?t=" + Guid.NewGuid().ToString("N");
                    Uri uri = new Uri(downloadUrl);
                    downloader.DownloadDataAsync(uri, fileInfo);
                }
            }
        }

        private void downloader_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar1.Value = (int)e.BytesReceived;
            progressBar1.Maximum = (int)e.TotalBytesToReceive;

            this.lblPercent.Text = String.Format("已完成 {0}%  {1} 字节/{2} 字节", progressBar1.Value * 100 / progressBar1.Maximum, progressBar1.Value, progressBar1.Maximum);
        }

        private void downloader_DownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e)
        {
            //progressBar1.Value = (int)e.BytesReceived;
            //progressBar1.Maximum = (int)e.TotalBytesToReceive;
            //this.lblPercent.Text = String.Format("已完成 {0}%  {1} 字节/{2} 字节", progressBar1.Value * 100 / progressBar1.Maximum, progressBar1.Value, progressBar1.Maximum);

            byte[] fileBytes = e.Result;
            FileItem fileItem = e.UserState as FileItem;
            string currentFolder = Application.StartupPath;
            var tempFolderInfo = Directory.CreateDirectory(currentFolder + "\\" + Constants.TEMP_DIRECTORY_FOR_DOWNLOAD);

            // use a temporary download location in case something goes wrong, we don't want to 
            // corrupt the program and make it unusable without making the user manually delete files. 
            string temporaryFilePath = tempFolderInfo.FullName + "\\" + fileItem.FileName;
            System.IO.File.WriteAllBytes(temporaryFilePath, fileBytes);

            //copy file
            if (File.Exists(tempFolderInfo + "\\" + fileItem.FileName))
            {
                File.Copy(tempFolderInfo + "\\" + fileItem.FileName, currentFolder + "\\" + fileItem.FileName, true);
            }
            //Thread.Sleep(3000);
            // delete temp directory
            Directory.Delete(currentFolder + "\\" + Constants.TEMP_DIRECTORY_FOR_DOWNLOAD, true);
            this.Close();
        }
    }
}
