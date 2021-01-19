using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BooksStore.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext():base("IdentityDemo")
        {

        }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}