using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace _08ModelValidations.Models
{
    public class EmployeeDbContext:DbContext
    {
        public DbSet<Employee> Employees { get; set; }
    }
}