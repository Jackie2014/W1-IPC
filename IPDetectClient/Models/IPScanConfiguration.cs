using System;
using System.Collections.Generic;
using System.Text;

namespace IPDectect.Client.Models
{
    public class IPScanConfiguration
    {

        public int Seq
        {
            get;
            set;
        }

        public bool Selected
        {
            get;
            set;
        }

        public string IPStart
        {
            get;
            set;
        }

        public string IPEnd
        {
            get;
            set;
        }

        public int IPCount
        {
            get;
            set;
        }

        public int TTLValue
        {
            get;
            set;
        }

        public int TCPValue
        {
            get;
            set;
        }


    }
}
