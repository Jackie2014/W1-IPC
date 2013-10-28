using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace IPDetectServer.Models
{
    public class CIDRSettingModel
    {
        public int Seq
        {
            get;
            set;
        }
        public string ID
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

        public int TCPPort
        {
            get;
            set;
        }

        public int TCPFaZhi
        {
            get;
            set;
        }

        public int TTLFaZhi
        {
            get;
            set;
        }
    }
}
