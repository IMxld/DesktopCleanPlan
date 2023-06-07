using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileTest
{
    class IMxldFile
    {
        /// <summary>
        /// 向imxld文件写入数据的方法
        /// </summary>
        /// <param name="s">指定文件路径</param>
        /// <param name="ep">秘钥</param>
        /// <param name="args">要写入的数据</param>
        public static void IMxldWrite(string s = "test.imxld", string ep = "0", params string[] args)
        {
            //文件大概长这样
            //(一串秘钥)554321abcdeqwer我(因为是utf-8编码所以是三字节)55w
            //第一个5指“54321”的长度，其中5指abcde占5字节，以此类推

            //生成秘钥
            Random r = new Random();
            int pass = r.Next(1000, 100000);

            //以文件流形式读取任何文件，切记手动关闭文件以释放资源
            FileStream fs = new FileStream(s, FileMode.Open, FileAccess.Write);

            //写入秘钥
            byte[] passBytes = BitConverter.GetBytes(pass);
            fs.Write(passBytes, 0, passBytes.Length);

            //写入文件标识
            //byte[] headBytes = Encoding.UTF8.GetBytes(StrEncrypt("IMxld", pass));
            //fs.Write(headBytes, 0, headBytes.Length);

            //写入长度标识，该长度指代此后的“指代各项数据长度”的长度
            int length = args.Length;
            byte[] lengthBytes = BitConverter.GetBytes(length);
            fs.Write(lengthBytes, 0, lengthBytes.Length);

            //指代各项数据长度
            List<int> strLength = new List<int>();
            foreach (string e in args)
            {
                string encrypte = StrEncrypt(e, pass, ep);
                byte[] b = Encoding.UTF8.GetBytes(encrypte);
                byte[] lengthByte = BitConverter.GetBytes(b.Length);
                fs.Write(lengthByte, 0, lengthByte.Length);
            }

            //写入数据
            foreach (string e in args)
            {
                byte[] data = Encoding.UTF8.GetBytes(StrEncrypt(e, pass, ep));
                //Console.WriteLine(data.Length);
                fs.Write(data, 0, data.Length);
            }

            fs.Close();
            fs.Dispose();
        }

        /// <summary>
        /// 从imxld文件读取数据
        /// </summary>
        /// <param name="s">文件路径</param>
        /// <param name="ep">秘钥</param>
        public static List<string> IMxldRead(string s = "test.imxld", string ep = "0")
        {
            FileStream fs = new FileStream(s, FileMode.Open, FileAccess.Read);

            //获得秘钥
            byte[] passBytes = new byte[4];
            fs.Read(passBytes, 0, 4);
            int pass = BitConverter.ToInt32(passBytes, 0);

            //byte[] head = new byte[5];
            //int headBytes = fs.Read(head, 0, 5);
            //if (headBytes < 5) return;
            //string headStr = Encoding.UTF8.GetString(head);
            //headStr = StrDecrypt(headStr, pass);
            //if (!headStr.Equals("IMxld"))
            //{
            //    Console.WriteLine("Err01");
            //    return;
            //}
            //Console.WriteLine(headStr);

            byte[] read = new byte[4];
            int readBytes = fs.Read(read, 0, 4);
            if (readBytes < 4)
            {
                //Console.WriteLine("Err02");
                return null;
            }
            int length = BitConverter.ToInt32(read, 0);
            //Console.WriteLine(length);

            byte[] data = new byte[4];
            int[] dataArr = new int[length];
            for (int i = 0; i < length; i++)
            {
                fs.Read(data, 0, 4);
                dataArr[i] = BitConverter.ToInt32(data, 0);
                //Console.WriteLine(dataArr[i]);
            }

            List<string> res = new List<string>();
            foreach(int i in dataArr)
            {
                byte[] datas = new byte[i];
                fs.Read(datas, 0, i);
                //Console.WriteLine(Encoding.UTF8.GetString(datas));
                res.Add(StrDecrypt(Encoding.UTF8.GetString(datas), pass, ep));
            }
            //foreach(string i in res)
            //{
            //    Console.WriteLine(i);
            //}

            fs.Close();
            fs.Dispose();

            return res;
        }

        /// <summary>
        /// 字符串加密
        /// </summary>
        /// <param name="s">需要加密的字符串</param>
        /// <param name="p">公钥</param>
        /// <param name="ep">秘钥</param>
        /// <returns>解密后的字符串</returns>
        public static string StrEncrypt(string s, int p, string ep)
        {
            //Console.WriteLine(ep);
            int i = 0;
            string res = "";
            foreach(char a in s)
            {
                res += (char)(a + p + ep[i % ep.Length]);
                //Console.WriteLine(ep[i % ep.Length]);
                i += 1;
            }
            return res;
        }

        /// <summary>
        /// 字符串解密
        /// </summary>
        /// <param name="s">需要解密的字符串</param>
        /// <param name="p">公钥</param>
        /// <param name="ep">秘钥</param>
        /// <returns>解密后的字符串</returns>
        public static string StrDecrypt(string s, int p, string ep)
        {
            //Console.WriteLine(ep);
            int i = 0;
            string res = "";
            foreach(char a in s)
            {
                res += (char)(a - p - ep[i % ep.Length]);
                //Console.WriteLine(ep[i % ep.Length]);
                i += 1;
            }
            return res;
        }
    }
}