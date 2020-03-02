using System;
using System.Diagnostics;
using System.Net;
using System.Windows;
using System.Windows.Media;


namespace IP地址解析
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //this.former.Text = "192.168.1";
            //this.start.Text = "7";
            //this.end.Text = "10";
        }

        public string getInfo(string strIP)
        {
            string hostname;
            try
            {
                IPHostEntry iph = Dns.GetHostEntry(strIP);
                hostname = iph.HostName;
            }
            catch
            {
                hostname = "（不在线）";
            }
            return hostname;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            for (int i = int.Parse(start.Text); i <= int.Parse(end.Text); i++)
            {
                string strIP = former.Text + "." + i.ToString();
                try
                {
                    IPAddress ip = IPAddress.Parse(strIP);
                    
                }
                catch
                {
                    this.check.Background = Brushes.Red;
                    this.check.Content = "IP地址有错，请更正!";
                    this.check.Foreground = Brushes.White;
                }
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                string hostname = getInfo(strIP);
                stopwatch.Stop();
                this.showResult.Text += "扫描地址 ：" + strIP + "，扫描用时：" + stopwatch.ElapsedMilliseconds.ToString() + "毫秒，主机DNS名称：" + hostname + "\n";
            }
        }
    }
}

