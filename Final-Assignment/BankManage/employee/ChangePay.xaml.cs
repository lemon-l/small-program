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
    /// ChangePay.xaml 的交互逻辑
    /// </summary>
    public partial class ChangePay : Page
    {
        public ChangePay()
        {
            InitializeComponent();
            BankEntities2 context2 = new BankEntities2();
            var Infosalary = from t in context2.Salary
                             select t;
            this.datagrid.ItemsSource = Infosalary.ToList();
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var q = from T in context.EmployeeInfo
                    select T;
            this.datagrid.ItemsSource = q.ToList();
        }
    }
}

