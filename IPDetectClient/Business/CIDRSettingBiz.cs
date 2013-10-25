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
    }
}
