using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace IPDectect.Client.Common
{
    public static class DataManager
    {
        public static void Save(string seperateLine, string data)
        {
            try
            {
                //if (String.IsNullOrEmpty(data))
                //{
                //    return;
                //}
                seperateLine = "\r\n" + seperateLine + "\r\n";
                string encrypetData = DESHelper.Encrypt(data);
                string fileContent;
                string path = Constants.LocalDataPath;

                if (File.Exists(path))
                {
                    using (StreamReader sr = new StreamReader(path))
                    {
                        fileContent = sr.ReadToEnd();
                    }

                    int start = fileContent.IndexOf(seperateLine);
                    // 如果原来有相应的值，替换
                    if (start > -1)
                    {
                        int end = fileContent.IndexOf(seperateLine, start + seperateLine.Length);
                        string oldValue = fileContent.Substring(start + seperateLine.Length, end - start -seperateLine.Length);
                        if (String.IsNullOrEmpty(oldValue))
                        {

                            string newValue = String.Format("{0}{1}{0}", seperateLine, encrypetData);
                            fileContent = fileContent.Replace(seperateLine + seperateLine, newValue);
                        }
                        else
                        {
                            fileContent = fileContent.Replace(oldValue, encrypetData);
                        }
                    }
                    // 如果没有该值，则append
                    else
                    {
                        fileContent += String.Format("{0}{1}{0}", seperateLine, encrypetData);
                    }
                }
                // 如果文件不存在，则新增
                else
                {
                    fileContent = String.Format("{0}{1}{0}", seperateLine, encrypetData);
                }

                using (StreamWriter outfile = new StreamWriter(path))
                {
                    outfile.Write(fileContent);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string Read(string seperateLine)
        {
            seperateLine = "\r\n" + seperateLine + "\r\n";
            string result = null;
            try
            {
                string path = Constants.LocalDataPath;
                string fileContent;
                using (StreamReader sr = new StreamReader(path))
                {
                    fileContent = sr.ReadToEnd();
                }

                int start = fileContent.IndexOf(seperateLine);
                // 如果原来有相应的值
                if (start > -1)
                {
                    int end = fileContent.IndexOf(seperateLine, start + seperateLine.Length);
                    result = fileContent.Substring(start + seperateLine.Length, end - start - seperateLine.Length);
                }

                if (!String.IsNullOrEmpty(result))
                {
                    result = DESHelper.Decrypt(result);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }
    }
}
