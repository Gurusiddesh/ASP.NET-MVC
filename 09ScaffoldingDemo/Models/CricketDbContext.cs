using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace _10ScaffoldingDemo.Models
{
    public class CricketDbContext:DbContext
    {
        public DbSet<Cricketer> Cricketers { get; set; }
    }
}