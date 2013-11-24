using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.ComponentModel;
using System.Diagnostics;
using IPDectect.Client.Models;

namespace IPDectect.Client.Common
{
    public class IPScan
    {
        private static List<string> TCPPING_EXCEPTION_FLAG = new List<string> { "Socket is not connected", "/tcp -  -" };
        private static List<string> PING_EXCEPTION_FLAG = new List<string> { "请求超时", "Request timed out." };
        private static string TCPPING_EXECUTE_FILE = AppDomain.CurrentDomain.BaseDirectory + "tcping.exe";
        private const string RESULT_FAIL = "异常";
        private const string RESULT_SUCCESS = "正常";
        public IPScan()
        {
            PingResult = RESULT_FAIL;
            TCPPingResult = RESULT_FAIL;
            TCPPingTimes = -1;
        }

        public string IP
        {
            get;
            set;
        }

        public int TTLFaZhiSet
        {
            get;
            set;
        }

        public int TCPFaZhiSet
        {
            get;
            set;
        }

        public int TCPPortSet
        {
            get;
            set;
        }

        public string[] ExceptionKeys
        {
            get;
            set;
        }

        public string PingResult
        {
            get;
            set;
        }

        public string TCPPingResult
        {
            get;
            set;
        }

        public int TCPPingTimes
        {
            get;
            set;
        }

        public void StartIPScan()
        {
            this.TCPPingResult = TCPPing(this.IP,this.TCPPortSet);
            this.PingResult = Ping(this.IP, this.TTLFaZhiSet);
        }

        /// <summary>
        /// TCP ping
        /// </summary>
        /// <param name="ip">ip</param>
        /// <returns> </returns>
        private string TCPPing(string ip,int tcpPort)
        {
            string result = RESULT_FAIL;
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;

            p.Start();
            p.StandardInput.WriteLine(String.Format("{0} -n 1 -w 1 -s {1} {2}", TCPPING_EXECUTE_FILE, ip,tcpPort));
            p.StandardInput.WriteLine("exit");
            string output = p.StandardOutput.ReadToEnd();
            p.Close();
            p.Dispose();

            // 如果网络异常，{ "Socket is not connected", "/tcp -  -" };
            if (output.IndexOf(TCPPING_EXCEPTION_FLAG[0], StringComparison.OrdinalIgnoreCase) > -1
                || output.IndexOf(TCPPING_EXCEPTION_FLAG[1], StringComparison.OrdinalIgnoreCase) > -1)
            {
                result = RESULT_FAIL;

                int pos1 = output.IndexOf("time=") + 5;
                int pos2 = output.IndexOf("ms", pos1);
                if (pos2 - pos1 > 1)
                {
                    var strElasped = output.Substring(pos1, pos2 - pos1);
                    int time = Convert.ToInt32(Convert.ToDecimal(strElasped));
                    if (time > 0)
                    {
                        this.TCPPingTimes = time;
                    }
                }
            }
            else
            {
                result = RESULT_SUCCESS;
                int pos1 = output.IndexOf("time=") + 5;
                int pos2 = output.IndexOf("ms", pos1);
                if (pos2 - pos1 > 1)
                {
                    var strElasped = output.Substring(pos1, pos2 - pos1);
                    int time = Convert.ToInt32(Convert.ToDecimal(strElasped));
                    if (time > 0)
                    {
                        this.TCPPingTimes = time;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// icmp ping
        /// </summary>
        /// <param name="ip">ip</param>
        /// <param name="ttl">ttl value</param>
        /// <returns></returns>
        private string Ping(string ip, int ttl)
        {
            string result = RESULT_FAIL;

            for (int i = 0; i < 3; i++)
            {
                // 如果失败，再次扫描，减少TTL误报率
                if (result == RESULT_SUCCESS)
                {
                    break;
                }

                Process p = new Process();
                p.StartInfo.FileName = "cmd.exe";
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardInput = true;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.CreateNoWindow = true;

                p.Start();
                p.StandardInput.WriteLine(String.Format("ping {0} -n 1 -w 500 -i {1}", ip, ttl));
                p.StandardInput.WriteLine("exit");
                string output = p.StandardOutput.ReadToEnd();
                p.Close();
                p.Dispose();


                if (ExceptionKeys != null && ExceptionKeys.Length > 0)
                {
                    foreach (string s in ExceptionKeys)
                    {
                        if (!String.IsNullOrEmpty(s))
                        {
                            if (output.IndexOf(s, StringComparison.OrdinalIgnoreCase) > -1)
                            {
                                result = RESULT_FAIL;
                                break;
                            }
                        }

                    }
                }
                // 如果网络异常显示 "请求超时。"
                else if (output.IndexOf(PING_EXCEPTION_FLAG[0]) > -1 || output.IndexOf(PING_EXCEPTION_FLAG[1]) > -1)
                {
                    result = RESULT_FAIL;
                }
                else
                {
                    result = RESULT_SUCCESS;
                }
            }

            return result;
        }

        public static List<string> GetIPRange(IPAddress startIP, IPAddress endIP)
        {
            List<string> result = new List<string>();
            uint sIP = ipToUint(startIP.GetAddressBytes());
            uint eIP = ipToUint(endIP.GetAddressBytes());
            while (sIP <= eIP)
            {
                //yield return new IPAddress(reverseBytesArray(sIP)).ToString();
                result.Add(new IPAddress(reverseBytesArray(sIP)).ToString());
                sIP++;
            }

            return result;
        }

        /* reverse byte order in array */
        private static uint reverseBytesArray(uint ip)
        {
            byte[] bytes = BitConverter.GetBytes(ip);
            Array.Reverse(bytes, 0, bytes.Length);
            return (uint)BitConverter.ToInt32(bytes, 0);
        }
        /* Convert bytes array to 32 bit long value */
        private static uint ipToUint(byte[] ipBytes)
        {
            ByteConverter bConvert = new ByteConverter();

            uint ipUint = 0;
            int shift = 24; // indicates number of bits left for shifting
            foreach (byte b in ipBytes)
            {
                if (ipUint == 0)
                {
                    ipUint = (uint)bConvert.ConvertTo(b, typeof(uint)) << shift;
                    shift -= 8;
                    continue;

                }

                if (shift >= 8)
                    ipUint += (uint)bConvert.ConvertTo(b, typeof(uint)) << shift;

                else
                    ipUint += (uint)bConvert.ConvertTo(b, typeof(uint));
                shift -= 8;
            }
            return ipUint;
        }
    }
}
