using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IService1”。
    [ServiceContract(Namespace = "WcfChatExample", CallbackContract = typeof(IService1Callback))]
    public interface IService1
    {
        [OperationContract(IsOneWay = true)]
        void Login(string userName);

        [OperationContract(IsOneWay = true)]
        void Logout(string userName);

        [OperationContract(IsOneWay = true)]
        void Talk(string userName, string message);

        // TODO: 在此添加您的服务操作
    }

    public interface IService1Callback
    {
        [OperationContract(IsOneWay = true)]
        void ShowLogin(string userName);

        [OperationContract(IsOneWay = true)]
        void ShowLogout(string userName);

        [OperationContract(IsOneWay = true)]
        void ShowTalk(string userName, string message);

        [OperationContract(IsOneWay = true)]
        void InitUsersInfo(string userName);
    }
    // 使用下面示例中说明的数据约定将复合类型添加到服务操作。
    // 可以将 XSD 文件添加到项目中。在生成项目后，可以通过命名空间“实验五.ContractType”直接使用其中定义的数据类型。
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
