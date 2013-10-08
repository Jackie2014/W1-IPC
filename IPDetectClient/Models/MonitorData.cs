using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Web;

namespace IPDectect.Client.Models
{
    public class MonitorData
    {
        public string ClientProvince { get; set; }

        public string ClientCity { get; set; }

        public string ClientDistinct { get; set; }

        public string ClientDetailAddress { get; set; }

        public string ExpectedOperator { get; set; }

        public string ExpectedOperatorProvice { get; set; }

        public string ExpectedOperatorCity { get; set; }

        public string ClientRecordor { get; set; }

        public string ClientPrivateIP { get; set; }
    }

    //public class MonitorRetriveCondition : MonitorData
    //{
    //    public string OperatorProvince { get; set; }

    //    public string OperatorCity { get; set; }
    //}
}