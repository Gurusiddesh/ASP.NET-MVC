using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _11FileUploadDownload.Models
{
    public class FileInformation
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public byte[] Content { get; set; }
    }
}