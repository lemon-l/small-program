using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// fedback.xaml 的交互逻辑
    /// </summary>
    public partial class fedback : Page
    {
        public fedback()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (this.fedback1.Text=="")
                MessageBox.Show("请留下您宝贵的意见");
            else
            {
                MessageBox.Show("发送成功！感谢您的珍贵意见。");
                fedback1.Clear();
            }      
        }  
    }
}
