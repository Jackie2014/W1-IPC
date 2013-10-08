using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Web;

namespace IPDectect.Client.Models
{

    public class RouteDataResponse
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

        public string IPBelongToCity
        {
            get;
            set;
        }
    }
}