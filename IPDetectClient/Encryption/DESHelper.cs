using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace IPDectect.Client.Common
{
    public class DESHelper
    {
        private const string keyInfo = "&1G^!m}-";

        public static string Encrypt(string source)
        {
            if (string.IsNullOrEmpty(source))
            {
                return string.Empty;
            }
            byte[] sourceByte = Encoding.UTF8.GetBytes(source);
            byte[] keyByte = Encoding.UTF8.GetBytes(keyInfo);

            DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
            provider.Key = keyByte;
            provider.IV = keyByte;

            MemoryStream stream = new MemoryStream();

            CryptoStream cryptoStream = new CryptoStream(stream, provider.CreateEncryptor(), CryptoStreamMode.Write);
            cryptoStream.Write(sourceByte, 0, sourceByte.Length);
            cryptoStream.FlushFinalBlock();
            cryptoStream.Close();

            string result = Convert.ToBase64String(stream.ToArray());
            stream.Close();
            return result;
        }

        public static string Decrypt(string source)
        {
            if (string.IsNullOrEmpty(source)) {
                return string.Empty;
            }
            byte[] sourceByte = Convert.FromBase64String(source);
            byte[] keyByte = Encoding.UTF8.GetBytes(keyInfo);

            DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
            provider.Key = keyByte;
            provider.IV = keyByte;

            MemoryStream stream = new MemoryStream();

            CryptoStream cryptoStream = new CryptoStream(stream, provider.CreateDecryptor(), CryptoStreamMode.Write);
            cryptoStream.Write(sourceByte, 0, sourceByte.Length);
            cryptoStream.FlushFinalBlock();
            cryptoStream.Close();

            string result = Encoding.UTF8.GetString(stream.ToArray());
            stream.Close();

            return result;

        }
    }
}
