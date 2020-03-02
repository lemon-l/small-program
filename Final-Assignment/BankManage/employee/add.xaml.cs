using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace BankManage.employee
{
    /// <summary>
    /// add.xaml 的交互逻辑
    /// </summary>
    public partial class add : Window
    {
        BankEntities2 context2 = new BankEntities2();
           
            public add()
            {
                InitializeComponent();
             
               

            }

          

            string photofilePath = "";
            //浏览照片
            private void buttonbrowse_Click(object sender, RoutedEventArgs e)
            {
                OpenFileDialog ofd = new OpenFileDialog();
                if (ofd.ShowDialog() == true)
                {
                    photofilePath = ofd.FileName;
                    //照片显示到image控件内
                    BitmapImage bi = new BitmapImage();
                    bi.BeginInit();
                    bi.UriSource = new Uri(photofilePath, UriKind.RelativeOrAbsolute);
                    bi.EndInit();
                    this.imagePhoto.Source = bi;
                }
            }
            //确定添加
            private void buttonOK_Click(object sender, RoutedEventArgs e)
            {
                EmployeeInfo emp = new EmployeeInfo();
            emp.EmployeeNo = this.txtXueHao.Text;
            emp.EmployeeName = this.txtXingMing.Text;
            emp.sex = this.radioM.IsChecked == true ? "男" : "女";
            emp.workDate = this.WorkDate.SelectedDate;
            emp.telphone = this.tel.Text;
            emp.idCard = this.card.Text;

            
                //照片(读取照片内容到字节数组bt中）
                if (photofilePath != "")
                {
                    Stream mystream = File.OpenRead(photofilePath);
                    byte[] bt = new byte[mystream.Length];
                    mystream.Read(bt, 0, (int)mystream.Length);
                    emp.photo = bt;
                }
                //添加对象
                try
                {
                    context2.EmployeeInfo.Add(emp);
                    int i = context2.SaveChanges();
                    MessageBox.Show(string.Format("成功添加{0}个员工信息", i));
                }
                catch
                {
                    MessageBox.Show("添加员工失败！");
                }
            this.Close();
               
            }
            //取消
            private void buttonOK_Copy_Click(object sender, RoutedEventArgs e)
            {
                this.card.Text = "";
                this.txtXingMing.Text = "";
                this.txtXueHao.Text = "";
                this.tel.Text = "";
                this.imagePhoto.Source = null;
            }
        }
    }
