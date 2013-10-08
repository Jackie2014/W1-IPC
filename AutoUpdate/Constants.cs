using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace IPDectect.Client.AutoUpdate
{
    internal class Constants
    {
        #region

        internal static string CenterServerBaseUrl = "http://ip.iwangding.com/ipmonitor";
        internal static readonly string Latest_Local_Version_FileName = "version";
        internal static readonly string TEMP_DIRECTORY_FOR_DOWNLOAD = "tmp";

        // It's always nice to ask before downloading
        internal static readonly bool Should_Prompt_For_Upgrade = false;

        // This is more or less a constant. But you could change this to read from 
        // a reg key that the user can set from an options menu or something. Options are nice. 
        internal static readonly bool Disable_Automatic_Checking = false;

        // Your version number. A series of numbers separated by periods.
        internal static readonly Regex Version_Number_Regex = new Regex(@"([0-9]+\.)*[0-9]+");

        // The name of the local file where the binaries are saved and read from. 
        internal static readonly string App_Assembly_FilePath = "main.exe";

        internal static string Server_Download_Directory
        {
            get
            {
                string rootPath = CenterServerBaseUrl;
                if (!rootPath.EndsWith("/"))
                {
                    rootPath += "/";
                }

                return rootPath + "download";
            }
        }

        // The URL that returns the version number of the latest release.
        internal static string Latest_Version_ServerVersionUrl
        {
            get
            {
                return Server_Download_Directory + "/version.txt?t=" + Guid.NewGuid().ToString("N");
            }
        }

        #endregion
    }
}
