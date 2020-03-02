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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BankManage
{
    /// <summary>
    /// help.xaml 的交互逻辑
    /// </summary>
    public partial class help : Page
    {
        public help()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("暂无更新版本！");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string str = "member-1：界面，帮助，反馈（新增），增加员工，零存整取，优化系统" + '\n' +
                          "me：忘记密码，转账，贷款，登录设置，密保设置，账户挂失，贷款" + '\n' +
                          "member-2：职员管理，职员信息删除更改，工资调整" + '\n' +
                          "member-3：零存整取，利率设置";
            MessageBox.Show(str);
        }
    }
}
