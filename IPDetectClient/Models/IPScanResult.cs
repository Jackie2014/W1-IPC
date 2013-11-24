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

        public int TCPTime
        {
            get;
            set;
        }

        public string TCPResult
        {
            get;
            set;
        }

        public string TTLResult
        {
            get;
            set;
        }

        public int TCPFaZhi
        {
            get;
            set;
        }

        public string ClientIP
        {
            get;
            set;
        }
    }
}
