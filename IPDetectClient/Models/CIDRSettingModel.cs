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

        public bool Selected
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

        public long IPStartNum
        {
            get;
            set;
        }

        public long IPEndNum
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

        public string TTLExceptionKeys
        {
            get;
            set;
        }
    }
}
