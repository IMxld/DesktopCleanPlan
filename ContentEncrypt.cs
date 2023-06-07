using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace DesktopCleanPlan
{
    internal class ContentEncrypt
    {
        private static byte[] KEY = ASCIIEncoding.ASCII.GetBytes("IMxldSet");
        private static byte[] IV = ASCIIEncoding.ASCII.GetBytes("IMxldSet");

        /// <summary>
        /// 字符串加密
        /// </summary>
        /// <param name="text">要加密的字符串</param>
        /// <returns>加密后的字符串</returns>
        public static string Encrypt(string text)
        {
            DESCryptoServiceProvider dsp = new DESCryptoServiceProvider();
            using (MemoryStream ms = new MemoryStream())
            {
                CryptoStream cryptoStream = new CryptoStream(ms, dsp.CreateEncryptor(KEY, IV), CryptoStreamMode.Write);
                StreamWriter sw = new StreamWriter(cryptoStream);
                sw.Write(text);
                sw.Flush();
                cryptoStream.FlushFinalBlock();
                ms.Flush();
                return Convert.ToBase64String(ms.GetBuffer(), 0, (int)ms.Length);
            }
        }

        /// <summary>
        /// 字符串解密
        /// </summary>
        /// <param name="text">密文</param>
        /// <returns>解密后的明文</returns>
        public static string Decrypt(string text)
        {
            DESCryptoServiceProvider dsp = new DESCryptoServiceProvider();
            byte[] buffer = Convert.FromBase64String(text);

            using (MemoryStream ms = new MemoryStream())
            {
                CryptoStream cryptoStream = new CryptoStream(ms, dsp.CreateDecryptor(KEY, IV), CryptoStreamMode.Write);
                cryptoStream.Write(buffer, 0, buffer.Length);
                cryptoStream.FlushFinalBlock();
                return ASCIIEncoding.UTF8.GetString(ms.ToArray());
            }
        }
    }
}
