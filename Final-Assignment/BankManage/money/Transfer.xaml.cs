using BankManage.common;
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

namespace BankManage.money
{
    /// <summary>
    /// Transfer.xaml 的交互逻辑
    /// </summary>
    public partial class Transfer : Page
    {
        private BankEntities2 dbEntity = new BankEntities2();
        public Transfer()
        {
            InitializeComponent();
        }

        // 转账
        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            if(txtAccount.Text == "" || selfId.Text == "" || othersId.Text == "" || txtPassword.Password == "" || txtmount.Text == "")
            { MessageBox.Show("红色*标注的为必填内容"); }
            else
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
                        this.selfId.Clear();
                        this.othersId.Clear();
                    }
                    else
                    {
                        Custom custom = DataOperation.GetCustom(this.txtAccount.Text);
                        if (custom.AccountInfo.accountPass != this.txtPassword.Password)
                        {
                            MessageBox.Show("密码不正确");
                            return;
                        }
                        else if (custom.AccountInfo.IdCard != this.selfId.Text)
                        {
                            MessageBox.Show("账户不存在此银行卡");
                            return;
                        }
                        else if (custom.MoneyInfo.balance - double.Parse(txtmount.Text) < 0)
                        {
                            MessageBox.Show("账户余额不足");
                        }
                        else
                        {
                            custom.Transfer(double.Parse(this.txtmount.Text));
                        }
                        OperateRecord page = new OperateRecord();
                        NavigationService ns = NavigationService.GetNavigationService(this);
                        ns.Navigate(page);
                    }
                }
            }         
        }

        // 取消转账
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            OperateRecord page = new OperateRecord();
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(page);
        }



        //// 检查两个卡号是不是相同的
        //private bool check_same()
        //{
        //    if (selfId.Text == othersId.Text && selfId.Text != "" && othersId.Text != "") { return false; }
        //    else { return true; }
        //}

        //// 检查是否存在这样的银行卡
        //private bool check_id()
        //{

        //    using (EmployeeEntities db = new EmployeeEntities())
        //    {
        //        var t = from x in db.AccountInfo
        //                where x.IdCard == othersId.Text
        //                select x;
        //        if (t.Count() == 0 && selfId.Text != "" && othersId.Text != "") { return false; }
        //        else { return true; }
        //    }
        //}

        //// 检查密码是否正确
        //private void check_password()
        //{
        //    using (EmployeeEntities db = new EmployeeEntities())
        //    {
        //        var t = from x in db.AccountInfo
        //                where x.IdCard == selfId.Text && x.accountPass == txtPassword.Password
        //                select x;
        //        if (t.Count() != 0)
        //        {
        //            Tip1.Content = "验证成功";
        //        }
        //        else { Tip2.Content = " 密码错误"; }

        //    }
        //}

        //// 检查账户余额
        //private void check_balance()
        //{
        //    var z = from m in dbEntity.AccountInfo
        //            from n in dbEntity.MoneyInfo
        //            where m.accountNo == n.accountNo && m.IdCard == selfId.Text && n.balance > double.Parse(txtmount.Text)
        //            select n;
        //    var a = from i in dbEntity.AccountInfo
        //            from j in dbEntity.MoneyInfo
        //            where i.IdCard == selfId.Text
        //            select j;
        //    if (z.Count() == 0)
        //    {
        //        Tip2.Content = "账户余额不足";
        //    }
        //    else
        //    {
        //        double bal1 = 0;
        //        foreach (var q in a)
        //        {
        //            bal1 = q.balance;
        //        }
        //        Tip2.Content = "您的账户余额为" + bal1;
        //    }
        //}

        //private void TxtPassword_PasswordChanged(object sender, RoutedEventArgs e)
        //{
        //    check_password();
        //}

        //private void TxtMount_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    check_balance();
        //}



        //private void btnOk_Click(object sender, RoutedEventArgs e)
        //{
        //    if (check_same() == false)
        //    {
        //        MessageBox.Show("自己不能给自己转账，请重新输入！","提示");
        //    }
        //    else if (check_id() == false)
        //    {
        //        MessageBox.Show("不存在这样的卡号，请重新输入", "提示");
        //    }
        //    else if(selfId.Text == "" || othersId.Text == "" || txtPassword.Password == "" || txtMount.Text == "")
        //    {
        //        MessageBox.Show("红色*标记的为必填内容", "提示");
        //    }
        //    else
        //    {
        //        using (EmployeeEntities db = new EmployeeEntities())
        //        {
        //            var a = from i in db.AccountInfo
        //                    from j in db.MoneyInfo
        //                    where i.IdCard == selfId.Text
        //                    select j;

        //            var b = from i in db.AccountInfo
        //                    from j in db.MoneyInfo
        //                    where i.IdCard == othersId.Text
        //                    select j;

        //            foreach (var m in a)
        //            {
        //                m.balance -= float.Parse(txtMount.Text);
        //            }

        //            foreach (var n in b)
        //            {
        //                n.balance += float.Parse(txtMount.Text);
        //            }
        //        }
        //        MessageBox.Show("转账成功", "提示");
        //        OperateRecord page = new OperateRecord();
        //        NavigationService ns = NavigationService.GetNavigationService(this);
        //        ns.Navigate(page);
        //    }
        //}

        //private void btnCancel_Click(object sender, RoutedEventArgs e)
        //{
        //    OperateRecord page = new OperateRecord();
        //    NavigationService ns = NavigationService.GetNavigationService(this);
        //    ns.Navigate(page);
        //}     
    }
}
