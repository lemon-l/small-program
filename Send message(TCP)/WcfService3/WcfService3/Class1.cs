using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfService3
{
    public class User
    {
        public string UserName { get; set; }
        public readonly IService1CallBack callback;

        public User(string userName, IService1CallBack callback)
        {
            this.UserName = userName;
            this.callback = callback;
        }
    }

}
