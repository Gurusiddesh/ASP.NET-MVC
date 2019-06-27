using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace _16AuthorizationAndAuthentication.Models
{
    public class CollegeDbContext:DbContext
    {
        public DbSet<AppUser> AppUsers { get; set; }
    }
}