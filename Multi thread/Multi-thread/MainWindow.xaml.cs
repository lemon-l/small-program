using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Multi_thread
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

        // 计数器
        int num;
        private object obj = new object();
        int count = 0;
        Stopwatch wall;

        // 根据输入实时判断是否有效
        private void End_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
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
                    this.check.Visibility = Visibility;
                }
            }
        }

        // 多线程扫描
        public void getInfo(object strIP)
        {
            string hostname;
            try
            {
                hostname = Dns.GetHostEntry(strIP.ToString()).HostName;
            }
            catch
            {
                hostname = "（不在线）";
            }
            showResult.Dispatcher.Invoke(() => this.showResult.Text += "扫描地址 ：" + strIP + "主机DNS名称：" + hostname + "\n");
            lock (obj)
            {
                num++;
            }

            if (num == count)
            {
                wall.Stop();
                showResult.Dispatcher.Invoke(() => this.showResult.Text += "总共用时: " + wall.ElapsedMilliseconds + " 毫秒");
            }
        }

        // 单线程扫描
        public string getInfo2(string strIP)
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

        // 多线程
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.showResult.Clear();
            count = int.Parse(end.Text) - int.Parse(start.Text) + 1;
            wall = Stopwatch.StartNew();
            for (int i = int.Parse(start.Text); i <= int.Parse(end.Text); i++)
            {
                string strIP = former.Text + "." + i.ToString();
                Thread t = new Thread(getInfo);
                t.Start(strIP); // 仅仅意味线程就绪
            }
        }

        // 单线程
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            for (int i = int.Parse(start.Text); i <= int.Parse(end.Text); i++)
            {
                string strIP = former.Text + "." + i.ToString();
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                string hostname = getInfo2(strIP);
                stopwatch.Stop();
                this.showResult.Text += "扫描地址 ：" + strIP + "，扫描用时：" + stopwatch.ElapsedMilliseconds.ToString() + "毫秒，主机DNS名称：" + hostname + "\n";
            }
        }
    }
}
