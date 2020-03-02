using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using BankManage;

namespace BankManage.common
{
    public class DataOperation
    {
        public static readonly string[] AccountType = { "活期存款", "定期存款", "零存整取" };
        /// <summary>
        /// 获取操作员姓名
        /// </summary>
        /// <param name="id">操作员编号</param>
        /// <returns></returns>
        public static string GetOperateName(string id)
        {
            using (BankEntities2 c = new BankEntities2())
            {
                var q = from t in c.EmployeeInfo
                         where t.EmployeeNo == id
                         select t;
                if (q != null && q.Count()>=1)
                {
                    return q.First().EmployeeName;
                }
                else
                {
                    return "";
                }
            }
        }

        /// <summary>
        /// 根据存款类型创建存款用户
        /// </summary>
        /// <param name="accountType">存款类型</param>
        /// <returns></returns>
        public static Custom CreateCustom(string accountType)
        {
            Custom custom = null;
            switch (accountType)
            {
        //定期1年,
        //定期3年,
        //定期5年,
        //活期,
        //零存整取1年,
        //零存整取3年,
        //零存整取5年
                case "活期存款":
                    custom = new CustomChecking();
                    break;
                case "定期1年":
                    custom = new CustomFixed();
                    break;
                case "定期3年":
                    custom = new CustomFixed3();
                    break;
                case "定期5年":
                    custom = new CustomFixed5();
                    break;
                case "零存整取1年":
                    custom = new CustomFixedL();
                    break;
                case "零存整取3年":
                    custom = new CustomFixedL3();
                    break;
                case "零存整取5年":
                    custom = new CustomFixedl5();
                    break;
            }
            custom.AccountInfo.accountType = accountType;
            return custom;
        }

        /// <summary>
        /// 获取存款用户信息,并初始化余额
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <returns></returns>
        public static Custom GetCustom(string accountNumber)
        {
            Custom custom = null;
            BankEntities2 c = new BankEntities2();
            try
            {
                var query= from t in c.AccountInfo
                         where t.accountNo == accountNumber
                         select t;
                if (query.Count() > 0)
                {
                    var q = query.Single();
                    custom = CreateCustom(q.accountType);
                    custom.AccountInfo.accountNo = accountNumber;
                    custom.AccountInfo.accountName = q.accountName;
                    custom.AccountInfo.accountPass = q.accountPass;
                    custom.AccountInfo.IdCard = q.IdCard;
                }
            }
            catch
            {
                return null;
            }
            var qt = from t in c.MoneyInfo
                      where t.accountNo == accountNumber
                      select t;
            if (qt != null && qt.Count() > 0)
            {
                custom.AccountBalance = qt.Sum(x => x.dealMoney);
            }
            return custom;
        }

        /// <summary>
        /// 获取指定类别的利率
        /// </summary>
        /// <param name="rateType">利率类别</param>
        /// <returns>对应类别的利率值</returns>
        public static double GetRate(RateType rateType)
        {
            string type = rateType.ToString();
            BankEntities2 c = new BankEntities2();
            var q = (from t in c.RateInfo
                     where t.rationType == type
                     select t.rationValue).Single();
            return q.Value;
        }
    }
}
