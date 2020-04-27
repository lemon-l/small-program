using System;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
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
        }

        // 定义一个IP解析的异步方法
        public async Task<string> IPAsync(IPAddress obj)
        {
            string hostname;
            try
            {
                IPHostEntry iph = Dns.GetHostEntry(obj);
                hostname = iph.HostName;
            }
            catch
            {
                hostname = "（不在线）";
            }
            await Task.Delay(100);
            return hostname;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            Stopwatch stopwatch = new Stopwatch();
            showResult.Clear();
            for (int i = int.Parse(start.Text); i <= int.Parse(end.Text); i++)
            {
                string strIP = former.Text + "." + i.ToString();
                stopwatch.Start();
                IPAddress ip = IPAddress.Parse(strIP);
                //string hostname = await IPAsync(ip);
                string hostname = await Task.Run(() => IPAsync(ip));
                stopwatch.Stop();
                this.showResult.Text += "扫描地址 ：" + strIP + "，扫描用时：" + stopwatch.ElapsedMilliseconds.ToString() + "毫秒，主机DNS名称：" + hostname + "\n";
            }
        }

        private void End_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            for(int i = int.Parse(start.Text); i <= int.Parse(end.Text); i++)
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
            }
        }
    }
}

