using BankManage.common;
using BankManage.money;
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

namespace BankManage.other
{
    /// <summary>
    /// Loan.xaml 的交互逻辑
    /// </summary>
    public partial class Loan : Page
    {
        public Loan()
        {
            InitializeComponent();
        }

        private BankEntities2 dbEntity = new BankEntities2();

        double rate;
        public double RateMoney(double a)
        {
            if (a <= 1 && a > 0)
            { rate = 0.001; return rate; }
            else if (a > 1 && a <= 3)
            { rate = 0.003; return rate; }
            else
            { rate = 0.005; return rate; }
        }

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
                    this.txtMoney.Clear();
                    this.txtDate.Clear();
                }
                else
                {
                    double sumMoney = RateMoney(int.Parse(txtDate.Text[0].ToString())) * int.Parse(txtDate.Text[0].ToString()) * double.Parse(txtMoney.Text) + double.Parse(txtMoney.Text);
                    string str = string.Format("{0}年后的今天您将要连带利息还款{1}元", txtDate.Text[0].ToString(), sumMoney);
                    MessageBox.Show(str, "提示");
                    Custom custom = DataOperation.GetCustom(this.txtAccount.Text);
                    custom.Loan(double.Parse(this.txtMoney.Text));
                    OperateRecord page = new OperateRecord();
                    NavigationService ns = NavigationService.GetNavigationService(this);
                    ns.Navigate(page);
                }
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.txtAccount.Clear();
            this.txtMoney.Clear();
            this.txtDate.Clear();
        }
    }
}
