using System;
using System.IO;
using System.Collections.Generic;

namespace WcfService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“Service1”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 Service1.svc 或 Service1.svc.cs，然后开始调试。
    public class Service1 : IService1
    {
        public static List<string> filesInfo;
        public static string path;
        public List<string> GetFilesInfo()
        {
            if (filesInfo == null)
            {
                filesInfo = new List<string>();
                path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DownloadFiles");
                DirectoryInfo dir = new DirectoryInfo(path);
                FileInfo[] fi = dir.GetFiles();
                foreach (var i in fi)
                {
                    filesInfo.Add(string.Format("{0},{1}", i.Name, i.Length));
                }
            }

            return filesInfo;
        }

        public Stream GetDownloadsStream(string FileName)
        {
            string filePath = Path.Combine(path, FileName);
            try
            {
                FileStream imageFile = File.OpenRead(filePath);
                return imageFile;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
