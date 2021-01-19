using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Mvc5FuLuA.Areas.LX01.Models
{
    public class UserInfo
    {
        [Required]
        [Display(Name = "用户名")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "用户名必须为3～20个字符")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "密码")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "密码必须为6～20个字符")]
        public string UserPwd { get; set; }
    }
}