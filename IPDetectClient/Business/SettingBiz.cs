using System;
using System.Collections.Generic;
using System.Text;
using IPDectect.Client.Models;
using IPDectect.Client.Common;

namespace IPDectect.Client.Business
{
    public class SettingBiz
    {
        public SettingData GetSettings()
        {
            SettingData result = new SettingData();

            // default value
            result.EnableStartupRun = true;
            result.StartupRunTimes = 10;

            result.EnableAutoRun = true;
            result.ExecuteInterval = 4;
            result.AutoRequestServerTimes = 10;

            result.EnableMannulRun = true;
            result.MannulRequestServerTimes = 3;

            try
            {
                string setData = DataManager.Read(Constants.SEPARATE_StartRunSet);

                if (!String.IsNullOrEmpty(setData))
                {
                    string[] arr = setData.Split(new char[] { '\f' });
                    if (arr.Length == 7)
                    {
                        result.EnableStartupRun = Convert.ToBoolean(arr[0]);
                        result.StartupRunTimes = Convert.ToInt32(arr[1]);

                        result.EnableAutoRun = Convert.ToBoolean(arr[2]);
                        result.ExecuteInterval = Convert.ToInt32(arr[3]);
                        result.AutoRequestServerTimes = Convert.ToInt32(arr[4]);

                        result.EnableMannulRun = Convert.ToBoolean(arr[5]);
                        result.MannulRequestServerTimes = Convert.ToInt32(arr[6]);
                    }
                }
            }
            catch
            {}

            return result;
        }
    }
}
