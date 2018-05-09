using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Photos.Models
{
    public class FileShareItem
    {
        public List<string> Tags { get; set; }
        public List<string> FileNames { get; set; }
    }
}