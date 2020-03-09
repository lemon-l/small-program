using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Windows;

namespace Task_Manager
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Data> list = new List<Data>();
        public MainWindow()
        {
            InitializeComponent();
            ReProcessInfo();
        }

        public void ReProcessInfo()
        {
            dataGrid1.ItemsSource = null;
            list.Clear();
            Process[] processes = Process.GetProcesses();
            foreach (Process p in processes)
            {
                Data data = new Data();
                data.Id = p.Id;
                data.ProcessName = p.ProcessName;
                try
                {
                    data.StartTime = p.StartTime.ToString("yyyy-M-d HH:mm:ss");
                    // data.StartTime = p.StartTime.ToLongDateString() + p.StartTime.ToLongTimeString();
                }
                catch
                {

                    data.StartTime = "";
                }
                data.MemoryAllocation = string.Format("{0,10:0}MB", p.WorkingSet64 / 1024d / 1024d);
                data.IsResponding = p.Responding == true ? "正在运行" : "失去响应";
                data.ProcessCount = p.HandleCount.ToString();
                list.Add(data);
            }
            dataGrid1.ItemsSource = list;
            count.Content += processes.Length.ToString();
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            var item = dataGrid1.SelectedItem as Data;
            if (item == null)
            {
                MessageBox.Show("请选择要终止的进程！");
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("您确定要杀死该进程吗？");
                if (result == MessageBoxResult.OK)
                {
                    Process p1 = Process.GetProcessById(item.Id);
                    try
                    {
                        // 杀死该进程
                        p1.Kill();
                        MessageBox.Show("进程关闭成功！");
                        ReProcessInfo();
                    }
                    catch
                    {
                        MessageBox.Show("无法关闭此进程！");
                    }
                }
            }
        }

        public class Data
        {
            public int Id { get; set; }
            public string ProcessName { get; set; }
            public string StartTime { get; set; }
            public string MemoryAllocation { get; set; }
            public string IsResponding { get; set; }
            public string ProcessCount { get; set; }
        }
    }
}
