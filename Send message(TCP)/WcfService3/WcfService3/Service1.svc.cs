﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfService3
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的类名“Service1”。
    public class Service1 : IService1
    {
        public void Login(string userName)
        {
            OperationContext context = OperationContext.Current;
            IService1CallBack callback = context.GetCallbackChannel<IService1CallBack>();
            User newUser = new User(userName, callback);
            string str = "";
            for (int i = 0; i < CC.Users.Count; i++)
            {
                str += CC.Users[i].UserName + "、";
            }
            newUser.callback.InitUsersInfo(str.TrimEnd('、'));
            CC.Users.Add(newUser);
            foreach (var user in CC.Users)
            {
                user.callback.ShowLogin(userName);
            }
        }
        public void Logout(string userName)
        {

        }

        public void Talk(string userName, string message)
        {
            User user = CC.GetUser(userName);
            foreach (var v in CC.Users)
            {
                v.callback.ShowTalk(userName, message);
            }
        }
        public void InitUsersInfo(string UsersInfo)
        {
            if (UsersInfo.Length == 0) return;
            string[] users = UsersInfo.Split('、');
            for (int i = 0; i < users.Length; i++)
            {
                //listBoxOnLine.Items.Add(users[i]);
            }
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
