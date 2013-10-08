#region Header

/**
 *  Accela Inspector
 *  File: MD5Helper.cs
 *
 *  Accela, Inc.
 *  Copyright (C): 2011
 *
 *  Description:
 *  MD5Helper
 *
 *  Notes:
 * $Id: MD5Util.cs 131314 2011-10-28 16:07:41Z ACHIEVO\jackie.yu $.
 *  Revision History
 *  Date,                  Who,                 What
 *  28/10/2011             Jackie Yu            Created
 */

#endregion Header

using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace IPDectect.Client.Common
{
    public class MD5Helper
    {
        /// <summary>
        /// Hash an input string and return the hash as a 32 character hexadecimal string.
        /// </summary>
        /// <param name="input">input string content to be hash.</param>
        /// <returns>hash value.</returns>
        public static string GetMd5Hash(string input)
        {
            // Create a new instance of the MD5CryptoServiceProvider object.
            MD5 md5Hasher = MD5.Create();

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hasher.ComputeHash(Encoding.Unicode.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        /// <summary>
        /// Verify a hash against a string.
        /// </summary>
        /// <param name="input">input content string.</param>
        /// <param name="hash">the compire hash value.</param>
        /// <returns>true/false</returns>
        public static bool VerifyMd5Hash(string input, string hash)
        {
            // Hash the input.
            string hashOfInput = GetMd5Hash(input);

            // Create a StringComparer an comare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            return 0 == comparer.Compare(hashOfInput, hash);
        }
    }
}
