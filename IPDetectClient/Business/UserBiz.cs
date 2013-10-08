using IPDectect.Client.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using IPDectect.Client.Models;

namespace IPDectect.Client.Business
{
    public class UserBiz
    {
        public static bool Login(string userName, string password)
        {
            if (String.IsNullOrEmpty(userName) || String.IsNullOrEmpty(password))
            {
                return false;
            }
   
            string md5Passord = MD5Helper.GetMd5Hash(password);
            string macAddress = "";

            List<string> addresses = NetworkHelper.GetPhysicalAddresses();
            if (addresses != null && addresses.Count > 0)
            {
                macAddress = addresses[0];
            }

            //JSONObject loginObject = new JSONObject();
            //loginObject.Add("UserName",userName);
            //loginObject.Add("Password", md5Passord);
            //loginObject.Add("MacAddress", macAddress);
            LoginRequest loginRequest = new LoginRequest();
            loginRequest.UserName = userName;
            loginRequest.Password = md5Passord;

            string postData = JSON.Serialize(loginRequest); //JSONConvert.SerializeObject(loginObject);

            try
            {
                string url = Constants.CenterServerBaseUrl + "/apis/v1/token";
                string returnData = HttpCommunicatior.Post(url, "POST", postData);
                //JSONObject loginResponseObject = JSONConvert.DeserializeObject(returnData);
                LoginResponse response = JSON.Deserialize<LoginResponse>(returnData);
                //string token = loginResponseObject["Token"] as String;
                if (response == null || String.IsNullOrEmpty(response.Token))
                {
                    throw new Exception("认证失败，服务器返回了一个无效的Token。");
                }

                Constants.CurrentToken = response.Token;
                DataManager.Save(Constants.SEPARATE_TOKEN, response.Token);
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
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return true;
        }
    }
}
