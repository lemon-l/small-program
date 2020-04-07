using System;
using System.IO;
using System.Text;

namespace File
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. 文件拷贝

            // 创建读取文件的流
            FileStream fsReader = new FileStream("Django.pdf", FileMode.Open, FileAccess.ReadWrite);
            // 创建写入文件的流
            FileStream fsWriter = new FileStream("NewDjango.pdf", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            // 创建一个缓冲区
            byte[] buffers = new byte[1024];
            int temp = 0;
            while ((temp = fsReader.Read(buffers, 0, buffers.Length)) > 0)
            {
                // 将缓冲区的内容写入
                fsWriter.Write(buffers, 0, temp);
                // 显示进度
                long len = fsWriter.Length;
                double speed = (double)len / fsReader.Length;
                Console.WriteLine("拷贝的进度为{0}%", speed * 100);
            }
            // 关闭流
            fsReader.Close();
            fsWriter.Close();
            Console.ReadLine();

            /*
            2. 文本读入

            // 构造文件流,streamreader只能操作文本，不可解析pdf、图片等文件
            FileStream fs = new FileStream("test.txt", FileMode.OpenOrCreate, FileAccess.Read);
            // 构造StreamReader对象
            StreamReader sr = new StreamReader(fs);
            // 读取文件并输出
            // 1）. string str = sr.ReadToEnd();
            // 2）.
            string strLine = "";
            do
            {
                strLine = sr.ReadLine();
                Console.WriteLine(strLine);
            } while (strLine != null);
            //Console.WriteLine(str);
            // 关闭流
            sr.Close();
            fs.Close();
            Console.ReadLine();
            */
        }
    }
}