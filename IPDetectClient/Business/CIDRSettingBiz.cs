using IPDectect.Client.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using IPDectect.Client.Models;
using IPDetectServer.Models;

namespace IPDectect.Client.Business
{
    public class CIDRSettingBiz
    {
        public static List<CIDRSettingModel> GetCIDRSettings()
        {
            List<CIDRSettingModel> result = new List<CIDRSettingModel>();
            try
            {
                string url = Constants.CenterServerBaseUrl + "/apis/v1/cidrsettings";
                string returnData = HttpCommunicatior.Post(url, "GET");

                CIDRSettingModel[] response = JSON.Deserialize<CIDRSettingModel[]>(returnData);

                result = new List<CIDRSettingModel>(response);
                
            }
            catch (WebException ex)
            {
                HttpWebResponse response = (HttpWebResponse)ex.Response;

                if (response == null)
                {
                    //"无法连接到远程服务器!"
                    throw new Exception(ex.Message);
                }

                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw new Exception("认证失败，请重新登录。");
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="scanResults"></param>
        /// <returns>成功返回空字符串，失败返回错误message.</returns>
        public static string UploadIPScanResults(List<IPScanResult> scanResults)
        {
            if (scanResults == null || scanResults.Count == 0)
            {
                return null;
            }
            try
            {
                string url = Constants.CenterServerBaseUrl + "/apis/v1/cidrsettings/scanresults";
                string postData = JSON.Serialize(scanResults);
                HttpCommunicatior.Post(url, "POST", postData);
            }
            catch (WebException ex)
            {
                HttpWebResponse response = (HttpWebResponse)ex.Response;

                if (response == null)
                {
                    //"无法连接到远程服务器!"
                    return ex.Message;
                }

                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    return "认证失败，请重新登录。";
                }
                else
                {
                    return ex.Message;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return null;
        }
    }
}
