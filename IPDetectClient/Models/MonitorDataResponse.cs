using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Web;

namespace IPDectect.Client.Models
{
 
    public class MonitorDataResponse
    {
        /// <summary>
        /// ID of record
        /// </summary>
        public int UID
        {
            get;
            set;
        }

        /// <summary>
        /// 客户端公有IP
        /// </summary>
        public string IP
        {
            get;
            set;
        }

        /// <summary>
        /// 监测结果的运营商。
        /// </summary>
        public string RealOperator
        {
            get;
            set;
        }

        /// <summary>
        /// 监测结果的运营商province。
        /// </summary>
        public string RealOperatorProvince
        {
            get;
            set;
        }

        /// <summary>
        /// 监测结果的运营商city。
        /// </summary>
        public string RealOperatorCity
        {
            get;
            set;
        }
    }
}