using System;
using System.ServiceModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using WpfApp1.ServiceReference1;
namespace WpfApp1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            TwoClients w1 = new TwoClients()
            {
                Left = this.Left - 130,
                Top = this.Top + 70,
            };
            w1.text.Text = "西西皮"; w1.Owner = this; w1.Show();
            TwoClients w2 = new TwoClients()
            {
                Left = this.Left + 260,
                Top = this.Top + 70,
            };
            w2.text.Text = "瓜瓜糖"; w2.Owner = this; w2.Show();
        }

        private void Btn2_Click(object sender, RoutedEventArgs e)
        {
            TwoClients w1 = new TwoClients()
            {
                Left = this.Left - 130,
                Top = this.Top + 70,
            };
            w1.text.Text = "西西皮"; w1.Owner = this; w1.Show();
        }
    }
}
