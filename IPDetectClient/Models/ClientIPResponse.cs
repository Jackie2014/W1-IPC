using System;
using System.Collections.Generic;
using System.Text;

namespace IPDectect.Client.Models
{
    public class ClientIPResponse
    {
        public int ID
        {
            get;
            set;
        }

        public string ClientIP
        {
            get;
            set;
        }

        public string ClientRecordor
        {
            get;
            set;
        }

        public string ClientProvince
        {
            get;
            set;
        }

        public string ClientCity
        {
            get;
            set;
        }
        public string ClientDistinct
        {
            get;
            set;
        }
        public string ClientAddress
        {
            get;
            set;
        }

        public string ClientDetailAddress
        {
            get
            {
                return String.Format("{0}{1}{2}{3}", ClientProvince, ClientCity, ClientDistinct, ClientAddress);
            }
        }

        public string ExpectedISP
        {
            get;
            set;
        }

        public string ExpectedISPProvince
        {
            get;
            set;
        }

        public string ExpectedISPCity
        {
            get;
            set;
        }

        public string RealISP
        {
            get;
            set;
        }

        public string RealISPProvince
        {
            get;
            set;
        }

        public string RealISPCity
        {
            get;
            set;
        }

        public string UserName
        {
            get;
            set;
        }
        public string CreatedDate
        {
            get;
            set;
        }

        public string Status
        {
            get;
            set;
        }

        public string StatusForDisplay
        {
            get;
            set;
        }

        //public enum IPMonitorStatus
        //{
        //    Pending = 0,
        //    Normal = 1,
        //    Unknown = 2,
        //    Exception = 3
        //}
    }
}
