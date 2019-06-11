using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace _11FileUploadDownload.Models
{
    public class FileUploadDbContext : DbContext
    {
        public DbSet<FileInformation> FileInformations { get; set; }
    }
}


