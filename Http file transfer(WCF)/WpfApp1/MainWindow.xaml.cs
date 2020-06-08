using System.Windows;
using System.IO;
using WpfApp1.ServiceReference1;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        string[] filesInfo;
        public MainWindow()
        {
            InitializeComponent();
            Service1Client client = new Service1Client();

            filesInfo = client.GetFilesInfo();
            for (int i = 0; i < filesInfo.Length; i++)
            {
                string[] s = filesInfo[i].Split(',');
                this.listBox.Items.Add(string.Format("文件名：{0}，文件长度：{1}字节", s[0], s[1]));
            }
            client.Close();
            if (listBox.Items.Count > 0)
            {
                listBox.SelectedIndex = 0;
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Service1Client client = new Service1Client();
            string[] s = filesInfo[listBox.SelectedIndex].Split(',');
            this.txt.Text = "正在下载" + s[0];
            string filePath = System.IO.Path.Combine(System.Environment.CurrentDirectory, s[0]);
            Stream stream = client.GetDownloadsStream(s[0]);
            DownloadFile(stream, filePath);
        }

        private void DownloadFile(Stream stream, string filePath)
        {
            FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            const int bufferLen = 5000;
            byte[] buffer = new byte[bufferLen];
            int count = 0;
            int byteCount = 0;
            while ((count = stream.Read(buffer, 0, bufferLen)) > 0)
            {
                fs.Write(buffer, 0, count);
                byteCount += count;
            }
            fs.Close();
            stream.Close();
            this.txt.Text = "\n下载完成，共下载" + byteCount + "字节，文件保存到" + filePath;
        }
    }
}
