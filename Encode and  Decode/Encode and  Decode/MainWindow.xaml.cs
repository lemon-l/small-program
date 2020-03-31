using System;
using System.Text;
using System.Windows;

namespace Encode_and__Decode
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

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            string content = TextBox1.Text;
            this.TextBox2.Text = Encode(content, Encoding.ASCII);
            this.TextBox3.Text = Encode(content, Encoding.UTF8);
            this.TextBox4.Text = Encode(content, Encoding.Unicode);
        }

        string t = "";
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (EncodingInfo ei in Encoding.GetEncodings())
            {
                Encoding en = ei.GetEncoding();
                t += "编码名称：" + ei.Name + " 说明：" + en.EncodingName + "\n";
            }
            MessageBox.Show(t);
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            string content = TextBox1.Text;
            this.TextBox2.Text = Decode(content, Encoding.ASCII);
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            string content = TextBox1.Text;
            this.TextBox3.Text = Decode(content, Encoding.UTF8);
        }

        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            string content = TextBox1.Text;
            string unicode = this.TextBox4.Text;
            this.TextBox4.Text = Decode(content, Encoding.Unicode);
        }

        // 编码
        private string Encode(string s, Encoding encoding)
        {

            //将字符串编码为字节数组
            byte[] bytes = encoding.GetBytes(s);
            //显示结果
            string encodeResult = BitConverter.ToString(bytes);
            return encodeResult;
        }

        // 解码
        private string Decode(string s, Encoding encoding)
        {
            byte[] bytes = encoding.GetBytes(s);
            //将字节数组解码为字符串
            string str = encoding.GetString(bytes);
            //显示结果
            return str;
        }
    }
}
