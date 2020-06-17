using System;
using System.ServiceModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using WpfApp1.ServiceReference1;

namespace WpfApp1
{
    /// <summary>
    /// TwoClients.xaml 的交互逻辑
    /// </summary>
    public partial class TwoClients : Window, IService1Callback
    {
        public TwoClients()
        {
            InitializeComponent();
            this.Closing += Window_Closing;
        }

        public string UserName
        {
            get { return text.Text; }
            set { text.Text = value; }
        }

        private Service1Client client;

        public void ShowLogout(string userName)
        {
            listBoxOnLine.Items.Remove(userName);
        }

        public void ShowTalk(string userName, string message)
        {
            AddMessage("[" + userName + "]说：" + message);
        }

        public void ShowLogin(string loginUserName)
        {
            
            listBoxOnLine.Items.Add(loginUserName);
        }
        private void AddMessage(string str)
        {
            TextBlock t = new TextBlock();
            t.Text = str;
            t.Foreground = Brushes.Blue;
            listBoxOnLine_Copy.Items.Add(t);
        }

        public void InitUsersInfo(string UsersInfo)
        {
            if (UsersInfo.Length == 0) return;
            string[] users = UsersInfo.Split('、');
            for (int i = 0; i < users.Length; i++)
            {
                listBoxOnLine.Items.Add(users[i]);
            }
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            this.Cursor = Cursors.Wait;
            UserName = text.Text;
            InstanceContext context = new InstanceContext(this);
            client = new ServiceReference1.Service1Client(context);
            try
            {
                client.Login(UserName);
                btn.IsEnabled = false;
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
            this.Cursor = Cursors.Arrow;
        }

        private void Btn2_Click(object sender, RoutedEventArgs e)
        {
            UserName = text.Text;
            InstanceContext context = new InstanceContext(this);
            client = new ServiceReference1.Service1Client(context);
            client.Talk(UserName, Message.Text);
            Message.Clear();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(MessageBox.Show("确定要退出吗？","", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                e.Cancel = false;
                InstanceContext context = new InstanceContext(this);
                client = new ServiceReference1.Service1Client(context);
                client.Logout(UserName);
            }
            else
            {
                e.Cancel = true;
            }

        }
    }
}
