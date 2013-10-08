using System;
using System.Collections.Generic;
using System.Text;

namespace IPDectect.Client.Models
{
    public class RouteItem
    {
        public int ParentUID
        {
            get;
            set;
        }

        public int SeqNo
        {
            get;
            set;
        }

        public string T1
        {
            get;
            set;
        }

        public string T2
        {
            get;
            set;
        }

        public string T3
        {
            get;
            set;
        }

        public string RouteIP
        {
            get;
            set;
        }

        public string IPBelongTo
        {
            get;
            set;
        }

        public string IPBelongToProvince
        {
            get;
            set;
        }

        public string IPBelongToDisplay
        {
            get
            {
                return String.Format("{0}{1}", IPBelongToProvince, IPBelongTo);
            }
        }

        public string IPBelongToCity
        {
            get;
            set;
        }

        public DateTime RouteDate
        {
            get;
            set;
        }
    }
}
