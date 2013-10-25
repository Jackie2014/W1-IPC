using System;
using System.Collections.Generic;
using System.Text;

namespace IPDectect.Client.Models
{
    public class IPScanResult
    {
        public string IP
        {
            get;
            set;
        }

        public int PingTTLSet
        {
            get;
            set;
        }

        public int PingResult
        {
            get;
            set;
        }

        public int TCPPingTimes
        {
            get;
            set;
        }
    }
}
