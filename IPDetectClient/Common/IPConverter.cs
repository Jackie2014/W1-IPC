using System;
using System.Collections.Generic;
using System.Text;

namespace IPDectect.Client.Common
{
    public static class IPConverter
    {
        public static long ip2long(string ip)
        {
            long result = 0;
            string[] splits = ip.Split('.');
            int[] num = new int[4];
            if (splits.Length == 4)
            {
                for (int i = 0; i < splits.Length; i++)
                {
                    num[i] = int.Parse(splits[i]);
                }
            }
            long pow = 1;
            for (int i = num.Length - 1; i >= 0; i--)
            {
                result += num[i] * pow;
                pow *= 256;
            }

            return result;
        }
        public static string int2ip22(long num)
        {
            string binaryStr = Convert.ToString(num, 2);

            int[] ipnum = { 0, 0, 0, 0 };
            for (int i = 0; i < binaryStr.Length; i++)
            {
                ipnum[i / 8] += (binaryStr[i] - '0') == 0 ? 0 : (int)Math.Pow(2, 7 - i % 8);
            }
            StringBuilder builder = new StringBuilder(ipnum[0].ToString());
            for (int i = 1; i < 4; i++)
            {
                builder.Append(".");
                builder.Append(ipnum[i].ToString());
            }
            return builder.ToString();
        }

        /**   
         * 整数转成ip地址.   
         * @param ipLong   
         * @return   
         */
        public static string long2ip(long ipLong) {     
        //long ipLong = 1037591503;     
        long[] mask = {0x000000FF,0x0000FF00,0x00FF0000,0xFF000000};     
        long num = 0;     
        StringBuilder ipInfo = new StringBuilder();     
        for(int i=0;i<4;i++)
        {     
            num = (ipLong & mask[i])>>(i*8);     
            if(i>0) ipInfo.Insert(0,".");     
            ipInfo.Insert(0,num);     
        }     
        return ipInfo.ToString();     
    } 
    }
}
