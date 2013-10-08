using IPDectect.Client.Common;
using IPDectect.Client.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace IPDectect.Client.Business
{
    public class MonitorBiz
    {
        public MonitorDataResponse RetriveClientIP(MonitorData data)
        {
            if (data == null)
                return null;

            //if (data.ExpectedOperator.StartsWith("中国"))
            //{
            //    data.ExpectedOperator = data.ExpectedOperator.Replace("中国", "");
            //}

            string postData = JSON.Serialize(data);
            MonitorDataResponse result = new MonitorDataResponse();
            try
            {
                string returnData = HttpCommunicatior.Post(Constants.CenterServerBaseUrl + "/apis/v1/monitordata", "POST", postData);

                result = JSON.Deserialize<MonitorDataResponse>(returnData);
                if (String.IsNullOrEmpty(result.RealOperator))
                {
                    result.RealOperator = "未知";
                }
                return result;
            }
            catch (WebException ex)
            {
                HttpWebResponse response = (HttpWebResponse)ex.Response;

                if (response != null && response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw new Exception("无效的token或token已过期，请重新登录!");
                }
                else
                {
                    throw;
                }
            }
        }

        public List<RouteItem> SubmitRouteDataToServer(List<RouteItem> routeItems, int parentUID)
        {
            // submit route info to server.
            if (routeItems == null || routeItems.Count == 0 || parentUID <= 0)
            {
                return routeItems;
            }

            foreach (var item in routeItems)
            {
                if (item != null)
                {
                    item.ParentUID = parentUID;
                }
            }

            string postData = JSON.Serialize(routeItems);

            try
            {
                string returnData = HttpCommunicatior.Post(Constants.CenterServerBaseUrl + "/apis/v1/monitordata/route", "POST", postData);

                RouteDataResponse[] response = JSON.Deserialize<RouteDataResponse[]>(returnData);
                if (response != null && response.Length > 0)
                {
                    foreach (var r in response)
                    {
                        if (r == null)
                        {
                            continue;
                        }

                        //Update RealOperator to RouteList.
                        if (r.SeqNo > 0 && !String.IsNullOrEmpty(r.IPBelongTo))
                        {
                            foreach (var m in routeItems)
                            {
                                if (m == null)
                                {
                                    continue;
                                }

                                if (m.SeqNo == r.SeqNo)
                                {
                                    m.IPBelongTo = r.IPBelongTo;
                                    m.IPBelongToProvince = r.IPBelongToProvince;
                                    m.IPBelongToCity = r.IPBelongToCity;
                                    break;
                                }
                            }
                        }
                    }
                }

                return routeItems;
            }
            catch (WebException ex)
            {
                HttpWebResponse response = (HttpWebResponse)ex.Response;

                if (response != null && response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw new Exception("无效的token或token已过期，请重新登录!");
                }
                else
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// current user all operate logs
        /// <returns></returns>
        public List<ClientIPResponse> LogQuery()
        {
            List<ClientIPResponse> result = new List<ClientIPResponse>();
            try
            {
                string returnData = HttpCommunicatior.Post(Constants.CenterServerBaseUrl + "/apis/v1/monitordata/logs","POST","{}");

                ClientIPResponse[] response = JSON.Deserialize<ClientIPResponse[]>(returnData);
                if (response != null && response.Length > 0)
                {
                    result = new List<ClientIPResponse>(response);
                }

                return result;
            }
            catch (WebException ex)
            {
                HttpWebResponse response = (HttpWebResponse)ex.Response;

                if (response != null && response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw new Exception("无效的token或token已过期，请重新登录!");
                }
                else
                {
                    throw;
                }
            }
        }

        public void SaveRetriveConditionToLocal(MonitorData data)
        {
            string serializedText = JSON.Serialize(data);

            if (String.IsNullOrEmpty(serializedText))
            {
                return;
            }

            DataManager.Save(Constants.SEPARATE_CHAR_CONDITION, serializedText);
        }

        public MonitorData ReadRetriveCondition()
        {
            MonitorData data = null;
            try
            {
                //string path = System.Windows.Forms.Application.StartupPath + @"\condition.txt";
                string conditionData = DataManager.Read(Constants.SEPARATE_CHAR_CONDITION);
                //using (StreamReader sr = new StreamReader(path))
                //{
                //    conditionData = sr.ReadToEnd();
                //}

                if (!String.IsNullOrEmpty(conditionData))
                {
                    data = JSON.Deserialize<MonitorData>(conditionData);
                }
            }
            catch (Exception ex)
            {

            }
            return data;
        }
    }
}
