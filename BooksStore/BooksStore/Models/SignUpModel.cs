using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BooksStore.Models
{
    public class SignUpModel
    {
        [Required]
        [Display(Name = "邮箱")]
        [EmailAddress(ErrorMessage = "必须是有效的邮箱地址")]

        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "密码")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "密码必须为6～20个字符")]


        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "确认密码")]
        [Compare("Password",ErrorMessage ="Password error")]
        public string ComfirmPassword { get; set; }
    }
}