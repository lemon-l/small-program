﻿using BooksStore.Models;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BooksStore.App_Start
{
    public class ApplicationSignInManager : SignInManager<ApplicationUser,string>
    {
        public ApplicationSignInManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager) : base(userManager,authenticationManager)
        {
        }
        public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options,IOwinContext context)
        {
            return new ApplicationSignInManager(context.GetUserManager<ApplicationUserManager>(), context.Authentication);
        }
       
    }
}