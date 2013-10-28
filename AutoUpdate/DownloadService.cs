using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO;

namespace IPDectect.Client.AutoUpdate
{
    internal class DownloadService
    {
        internal static bool NeedToDownload(out List<FileItem> fileList)
        {
		    bool needDownload = false;

            bool localAssemblyExists = File.Exists(Constants.App_Assembly_FilePath);
            string localVersion = GetLocalVersionNumber();

            if (String.IsNullOrEmpty(localVersion) || !localAssemblyExists)
            {
                needDownload = true;
            }

            string latestServertVersion = GetLatestVersionAndFileListFromServer(out fileList);

            // if no file list is in server
            if (fileList == null || fileList.Count == 0)
            {
                needDownload = false;
            }
            else
            {
                localVersion = String.IsNullOrEmpty(localVersion) ? "0.0.0.0" : localVersion;
                // compare version to decide whether need exist new version
                Version vLocal = new Version(localVersion);
                Version vRemote = new Version(latestServertVersion);
                if (vRemote.CompareTo(vLocal) <= 0)
                {
                    needDownload = false;
                }
                else
                {
                    needDownload = true;
                    SaveLocalVersionNumber(latestServertVersion);
                }
            }

            return needDownload;
		}

        /// <summary>
        /// Gets the latest version number from the server.
        /// </summary>
        public static string GetLatestVersionAndFileListFromServer(out List<FileItem> fileList)
        {
            //Uri latestVersionUri = new Uri(latestVersionUrl);
            WebClient webClient = new WebClient();
            string receivedVersionData = String.Empty;
            string version = null;
            fileList = new List<FileItem>();
            try
            {
                ServicePointManager.ServerCertificateValidationCallback =
                        ((sender, certificate, chain, sslPolicyErrors) => true);
                receivedVersionData = webClient.DownloadString(Constants.Latest_Version_ServerVersionUrl).Trim();
                //receivedData = "Version:3.0.1.1||File:accela.dll:3.1.1.2:333||File:achievo.dll:2.1.1.2:666";

                // parse version and file list
                string[] arr1 = receivedVersionData.Split(new string[] { "||" }, StringSplitOptions.RemoveEmptyEntries);

                if (arr1 != null && arr1.Length > 0)
                {
                    foreach (string item in arr1)
                    {
                        if (!String.IsNullOrEmpty(item))
                        {
                            string[] tempArray = item.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);

                            if (tempArray.Length != 2 && tempArray.Length != 4)
                            {
                                continue;
                            }

                            if (tempArray.Length == 2 && "Version".Equals(tempArray[0], StringComparison.OrdinalIgnoreCase))
                            {
                                version = tempArray[1];
                            }
                            else if (tempArray.Length == 4
                                && "File".Equals(tempArray[0], StringComparison.OrdinalIgnoreCase)
                                && !String.IsNullOrEmpty(tempArray[1])
                                && !String.IsNullOrEmpty(tempArray[2])
                                && !String.IsNullOrEmpty(tempArray[3])
                                )
                            {
                                FileItem file = new FileItem();
                                file.FileName = tempArray[1];
                                file.FileVersion = tempArray[2];
                                file.FileSize = Convert.ToInt32(tempArray[3]);
                                fileList.Add(file);
                            }
                        }
                    }
                }

                // Just in case the server returned something other than a valid version number. 
                version = Constants.Version_Number_Regex.IsMatch(version) ? version : null;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                // server or connection is having issues
            }

            return version;
        }

        internal static string GetLocalVersionNumber()
        {
            if (File.Exists(Constants.Latest_Local_Version_FileName) && File.Exists(Constants.App_Assembly_FilePath))
            {
                return File.ReadAllText(Constants.Latest_Local_Version_FileName);
            }

            return null;
        }

        internal static void SaveLocalVersionNumber(string version)
        {
            File.WriteAllText(Constants.Latest_Local_Version_FileName, version);
        }
    }
}
