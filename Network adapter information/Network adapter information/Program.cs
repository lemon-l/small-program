using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network_adapter_information
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder shows = new StringBuilder();
            NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
            int count = 0;
            foreach (NetworkInterface adapter in adapters)
            {
                count++;
                shows.AppendLine("-------------------------第" + count + "个适配器信息--------------------------");
                shows.AppendLine("描述信息：" + adapter.Description);
                shows.AppendLine("名称：" + adapter.Name);
                shows.AppendLine("类型：" + adapter.NetworkInterfaceType);
                shows.AppendLine("速度" + adapter.Speed / 1000 / 1000 + "M");
                byte[] macAddress = adapter.GetPhysicalAddress().GetAddressBytes();
                shows.AppendLine("MAC地址：" + BitConverter.ToString(macAddress));
                IPInterfaceProperties adapterProperties = adapter.GetIPProperties();
                IPAddressCollection dnsServers = adapterProperties.DnsAddresses;
                if(dnsServers.Count > 0)
                {
                    foreach(IPAddress dns in dnsServers)
                    {
                        shows.AppendLine("DNS服务器IP地址：" + dns);
                    }
                }
            }
            shows.AppendLine("\n****************************流量包监测*****************************");
            IPGlobalProperties ipProperties = IPGlobalProperties.GetIPGlobalProperties();
            IPGlobalStatistics ipStatistics = ipProperties.GetIPv4GlobalStatistics();
            shows.AppendLine("本机注册域名 ：" + ipProperties.DomainName);
            shows.AppendLine("接收数据包数 ：" + ipStatistics.ReceivedPackets);
            shows.AppendLine("转发数据包数 ：" + ipStatistics.ReceivedPacketsForwarded);
            shows.AppendLine("传送数据包数 ：" + ipStatistics.ReceivedPacketsDelivered);
            shows.AppendLine("丢弃数据包数 ：" + ipStatistics.ReceivedPacketsDiscarded);
            Console.WriteLine(shows);
            Console.ReadLine();
        }
    }
}
