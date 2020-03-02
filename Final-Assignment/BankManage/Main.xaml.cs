using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Windows.Shapes;

namespace BankManage
{
    /// <summary>
    /// Main.xaml 的交互逻辑
    /// </summary>
    public partial class Main : Window
    {
        public Main()
        {
            InitializeComponent();
            this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            this.SourceInitialized += MainWindow_SourceInitialized;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button item = e.Source as Button;
            if (item != null)
            {
                frame1.Source = new Uri(item.Tag.ToString(), UriKind.Relative);
            }
        }
        void MainWindow_SourceInitialized(object sender, System.EventArgs e)
        {
            //this.frame1.Source = new Uri("money/OperateRecord.xaml", UriKind.Relative);
            //启动登陆窗体
            LoginForm login = new LoginForm();
            login.ShowDialog();
            this.Title = "欢迎您，" + login.UserName;

        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("确定要退出吗？", "提示", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }

        private void Log_Off_Click(object sender, RoutedEventArgs e)
        {
            // 本来是想用线程实现的，但是老是报一些错，显示“System.InvalidOperationException:“调用线程必须为 STA,
            // 因为许多 UI 组件都需要”，网上搜了好多答案就是解决不了，于是就另外想了这种比较粗糙的方法。
            //Thread th = new Thread(delegate () { new Main().ShowDialog(); });
            //th.Start();
            this.Hide();
            Main newWindow = new Main();
            newWindow.ShowDialog();
        }
    }
}
