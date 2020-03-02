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
    /// ReportLoss.xaml 的交互逻辑
    /// </summary>
    public partial class ReportLoss : Page
    {
        public ReportLoss()
        {
            InitializeComponent();
        }

        private BankEntities2 dbEntity = new BankEntities2();

        // 检查密码
        private bool Check_PassWord()
        {
            var a = from x in dbEntity.AccountInfo
                    where x.accountNo == txtAccount.Text && x.accountPass == txtPass.Password
                    select x;
            if (a.Count() == 0) { return false; }
            else { return true; }
        }

        // 检查卡号
        private bool Check_Id()
        {
            var b = from m in dbEntity.AccountInfo
                    where m.accountNo == txtAccount.Text && m.IdCard == txtId.Text
                    select m;
            if (b.Count() == 0) { return false; }
            else { return true; }
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            if (Check_Id() == false) { MessageBox.Show("不存在此卡号", "提示"); }
            else if (Check_PassWord() == false) { MessageBox.Show("密码输入错误", "提示"); }
            else
            {
                var c = from n in dbEntity.AccountInfo
                        where n.accountNo == txtAccount.Text && n.IdCard == txtId.Text && n.accountPass == txtPass.Password
                        select n;
                foreach (var d in c)
                {
                    d.freeze = "y";
                }
                MessageBox.Show("此账户已冻结", "提示");
                txtAccount.Clear();
                txtId.Clear();
                txtPass.Clear();
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.txtAccount.Clear();
            this.txtPass.Clear();
            this.txtPass.Clear();
        }
    }
}
