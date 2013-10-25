using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace IPDectect.Client.Common
{
    internal static class HttpCommunicatior
    {
        public static string Post(string url, string method, string body = null)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            ServicePointManager.ServerCertificateValidationCallback = 
                ((sender, certificate, chain,sslPolicyErrors) => true);
            //request.UserAgent = Constants.PRODUCT_NAME;
            request.Method = method;
       
            request.ContentType = "application/json";
            request.Headers.Add("Authorization", Constants.CurrentToken);
            if (!String.IsNullOrEmpty(body))
            {
                byte[] byteBody = System.Text.Encoding.UTF8.GetBytes(body);
                request.ContentLength = byteBody.Length;
                Stream dataStream = request.GetRequestStream();
                dataStream.Write(byteBody, 0, byteBody.Length);
                dataStream.Close();
            }

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream data = response.GetResponseStream();
            StreamReader reader = new StreamReader(data);
            string text = reader.ReadToEnd();
            response.Close();
            return text;
        }
    }
}
