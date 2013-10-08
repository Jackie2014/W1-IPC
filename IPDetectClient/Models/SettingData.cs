using System;
using System.Collections.Generic;
using System.Text;

namespace IPDectect.Client.Models
{
    public class SettingData
    {
        public bool EnableStartupRun
        {
            get;
            set;
        }

        public int StartupRunTimes
        {
            get;
            set;
        }

        public bool EnableAutoRun
        {
            get;
            set;
        }


        public int ExecuteInterval
        {
            get;
            set;
        }

        public int AutoRequestServerTimes
        {
            get;
            set;
        }

        public bool EnableMannulRun
        {
            get;
            set;
        }


        public int MannulRequestServerTimes
        {
            get;
            set;
        }
    }
}
