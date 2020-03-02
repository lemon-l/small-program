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
    /// ForgetPass.xaml 的交互逻辑
    /// </summary>
    public partial class ForgetPass : Window
    {
        //private EmployeeEntities dbEntity = new EmployeeEntities();
        public ForgetPass()
        {
            InitializeComponent();
        }

        // 检测两次密码是否相同
        private void Check_PassWord()
        {
            if (Box_Password.Password != Box_CheckPassword.Password)
            {
                TipLabel2.Content = "两次输入的密码不匹配";
            }
            else
            {
                TipLabel2.Content = "验证成功";
            }
        }

        // 检测密保问题的答案
        private void Check_Answer()
        {
            using (BankEntities2 db = new BankEntities2())
            {
                var t = from x in db.LoginInfo
                        where x.Bno == setTxt1.Text && x.SecurityAnswer == setTxt2.Text
                        select x;
                if (t.Count() != 0)
                {
                    TipLabel1.Content = "验证成功";
                }
                else
                {
                    TipLabel1.Content = "答案错误，请重新输入";
                }
            }
        }

        // 检测所有的需要验证的地方
        private Boolean Check_All()
        {
            if (TipLabel1.Content.ToString() == "验证成功" && TipLabel2.Content.ToString() == "验证成功")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void Box_CheckPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            Check_PassWord();
        }

        private void SetTxt2_TextChanged(object sender, TextChangedEventArgs e)
        {
            Check_Answer();
        }

        private void BtnSure_Click(object sender, RoutedEventArgs e)
        {
            if (Check_All())
            {
                using (BankEntities2 db = new BankEntities2())
                {
                    var a = from i in db.LoginInfo
                            where i.Bno == setTxt1.Text
                            select i;

                    foreach (var v in a)
                    {
                        v.Password = Box_Password.Password;
                    }
                    int j = db.SaveChanges();

                    string show1 = "密码重置成功，修改了" + j + "条记录";
                    MessageBox.Show(show1, "提示");
                    this.Close();
                    Main enter = new Main();
                    enter.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("请检查无误后重试！", "提示");
                //Main relogin = new Main();
                //relogin.ShowDialog();
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
