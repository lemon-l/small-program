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
    /// Deposit.xaml 的交互逻辑
    /// </summary>
    public partial class Deposit : Page
    {
        public Deposit()
        {
            InitializeComponent();
        }

        private BankEntities2 dbEntity = new BankEntities2();
        //存款
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
                    this.txtmount.Clear();
                }
                else
                {
                    Custom custom = DataOperation.GetCustom(this.txtAccount.Text);
                    if (custom == null)
                    {
                        MessageBox.Show("帐号不存在！");
                        return;
                    }
                    
                    custom.MoneyInfo.accountNo = txtAccount.Text;
                    var type = from x in dbEntity.AccountInfo
                              where x.accountNo == txtAccount.Text
                              select x;

                    foreach (var t in type)
                    {
                        if (t.accountType == "定期存款" || t.accountType == "活期存款")
                        {
                            int count1 = int.Parse(txtmount.Text);
                            if (count1 > 100)
                            {
                                custom.Diposit("存款", double.Parse(this.txtmount.Text));
                                OperateRecord page = new OperateRecord();
                                NavigationService ns = NavigationService.GetNavigationService(this);
                                ns.Navigate(page);
                            }
                            else
                            {
                                MessageBox.Show("低于最低存储金额");
                            }
                        }
                       
                    }
                    foreach (var t in type)
                    {
                        if (t.accountType == "零存整取")
                        {
                            int count1 = int.Parse(txtmount.Text);
                            if (count1 > 5)
                            {
                                custom.Diposit("存款", double.Parse(this.txtmount.Text));
                                OperateRecord page = new OperateRecord();
                                NavigationService ns = NavigationService.GetNavigationService(this);
                                ns.Navigate(page);
                            }
                            else
                            {
                                MessageBox.Show("低于最低存储金额");
                            }
                        }
                       
                    }


                }
            }
        }
        //取消存款
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            OperateRecord page = new OperateRecord();
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(page);
        }
    }
}
