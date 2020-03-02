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

namespace BankManage.employee
{
    /// <summary>
    /// EmployeeBase.xaml 的交互逻辑
    /// </summary>
    public partial class EmployeeBase : Page
    {
       
        public EmployeeBase()
        {
            InitializeComponent();
            BankEntities2 content = new BankEntities2();
           
            var InforManger = from t1 in content.EmployeeInfo
                              select t1;
            this.datagrid.ItemsSource = InforManger.ToList();
        }

       
        BankEntities2 context = new BankEntities2();
        private void ShowResult()
        {
            
            if (context != null)
            {
                context.Dispose();
                context = new BankEntities2();
            }
            
            var q = from T in context.EmployeeInfo
                    select T;
            this.datagrid.ItemsSource = q.ToList();
        }
        
        private void click2(object sender, RoutedEventArgs e)
        {
          
            var item = datagrid.SelectedItem as EmployeeInfo;
            if (item == null)
            {
                MessageBox.Show("请先选择要删除的信息！");
                return;
            }
            MessageBoxResult result = MessageBox.Show("您确定要删除该信息吗？", "删除确认", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                context = new BankEntities2();
                var q = from t in context.EmployeeInfo
                        where t.EmployeeNo == item.EmployeeNo
                        select t;
                if (q != null)
                {
                    try
                    {
                        context.EmployeeInfo.Remove(q.FirstOrDefault());
                        int i = context.SaveChanges();
                        MessageBox.Show(string.Format("成功删除", i));
                    }
                    catch
                    {
                        MessageBox.Show("删除失败！");
                    }
                }
            }
            ShowResult();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            add a = new add();
            a.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var q = from T in context.EmployeeInfo
                    select T;
            this.datagrid.ItemsSource = q.ToList();
        }
    }
}
