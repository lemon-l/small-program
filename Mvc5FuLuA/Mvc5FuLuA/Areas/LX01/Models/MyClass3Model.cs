using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvc5FuLuA.Areas.LX01.Models
{
    public class MyClass3Model
    {
        /// <summary>学号</summary>
        public List<string> StudentID { get; set; }

        ///<summary>姓名</summary>
        public List<string> StudentName { get; set; }

        ///<summary>性别</summary>
        public List<string> StudentGender { get; set; }

        ///<summary>年龄</summary>
        public List<int> StudentAge { get; set; }

        //设置默认选项
        public MyClass3Model()
        {
            StudentID = new List<string>
            {
                {"1812050001"},{"1812050002"},{"1812050003" },{"1812050004"}
            };

            StudentName = new List<string>
            {
                {"kris Wu" }, {"lemonl"}, {"Cardi B"}, {"kanye west"}
            };

            StudentGender = new List<string>
            {
                {"男" }, {"女"}, {"女"}, {"男"}
            };

            StudentAge = new List<int>
            {
                {30 }, {20}, {32}, {40}
            };
        }
    }
}