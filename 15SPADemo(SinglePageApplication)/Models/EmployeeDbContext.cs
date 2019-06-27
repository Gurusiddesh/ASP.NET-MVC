using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace _15SPADemo_SinglePageApplication_.Models
{
    public class EmployeeDbContext:DbContext
    {
        public DbSet<Employee> Employees { get; set; }
    }
}