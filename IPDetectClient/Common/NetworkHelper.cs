using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace IPDectect.Client.Common
{
    internal static class NetworkHelper
    {
        public static string GetLocalIPAddress()
        {
            IPHostEntry host;
            string localIP = "";
            try
            {
                host = Dns.GetHostEntry(Dns.GetHostName());
                foreach (IPAddress ip in host.AddressList)
                {
                    if (ip.AddressFamily == AddressFamily.InterNetwork)
                    {
                        localIP = ip.ToString();
                        break;
                    }
                }
            }
            catch { }

            return localIP;
        }

        public static List<String> GetPhysicalAddresses()
        {
            List<String> result = new List<string>(); 
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet
                    || nic.NetworkInterfaceType == NetworkInterfaceType.Wireless80211)
                {
                    
                    if (nic.OperationalStatus == OperationalStatus.Up)
                    {
                        string macAddress = nic.GetPhysicalAddress().ToString();
                        if (!String.IsNullOrEmpty(macAddress))
                        {
                            result.Add(macAddress);
                        }
                    }
                }
            }

            return result;
        }
    }
}
