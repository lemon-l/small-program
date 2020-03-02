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
using BankManage.common;

namespace BankManage.money
{
    /// <summary>
    /// Withdraw.xaml 的交互逻辑
    /// </summary>
    public partial class Withdraw : Page
    {
        public Withdraw()
        {
            InitializeComponent();
        }

        private BankEntities2 dbEntity = new BankEntities2();
        //取款
        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            var fre = from x in dbEntity.AccountInfo
                      where x.accountNo == txtAccount.Text
                      select x;


            foreach (var i in fre)
            {
                if (i.freeze == "y")
                {
                    MessageBox.Show("此账户已被冻结", "提示");
                    this.txtAccount.Clear();
                    this.txtPassword.Clear();
                    this.txtmount.Clear();
                }
                else
                {
                    Custom custom = DataOperation.GetCustom(this.txtAccount.Text);
                    if (custom.AccountInfo.accountPass != this.txtPassword.Password)
                    {
                        MessageBox.Show("密码不正确");
                        return;
                    }
                    custom.Withdraw(double.Parse(this.txtmount.Text));
                    OperateRecord page = new OperateRecord();
                    NavigationService ns = NavigationService.GetNavigationService(this);
                    ns.Navigate(page);
                }
            }
        }
        //取消取款
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            OperateRecord page = new OperateRecord();
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(page);
        }
    }
}
