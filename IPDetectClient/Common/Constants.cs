using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace IPDectect.Client.Common
{
    public static class Constants
    {
        //public static string CenterServerBaseUrl = "http://localhost:1885";
        public static string CenterServerBaseUrl = "https://ip.iwangding.com/ipmonitor";
        private static string ROUTE_TARGET_SERVER = "ip.iwangding.com";
        private static int ROUTE_MAX_HOPS = 15;
        public const string PRODUCT_NAME = "IP地址定位助手";
        public static string CurrentToken = "";
        public static bool IsAdministrator = false;
        public static string AUTO_RUN_ARG = "autorun";
        public static string Register_Key_Start = "IP地址定位助手";
        public const string SEPARATE_TOKEN = "======Token======";
        public const string SEPARATE_MANAGE = "======MANAGE======";
        public const string SEPARATE_CHAR_CONDITION = "======Query Condition======";
        public const string SEPARATE_REMEMBER_ME = "======RememberMe======";
        public const string SEPARATE_StartRunSet = "======StartRunSet======";
        public const int PAGE_SIZE = 10;

        public static string LocalDataPath
        {
            get
            {
                return System.Windows.Forms.Application.StartupPath + @"\localdata.config";
            }
        }

        internal static string TraceRouteArguments
        {
            get
            {
                return String.Format("-d -w 1000 -h {0} {1}", ROUTE_MAX_HOPS, ROUTE_TARGET_SERVER);
            }
        }

        internal static string GetAssembleVersion()
        {
            Version version = Assembly.GetEntryAssembly().GetName().Version;
            return version.ToString();
        }
    }
}
