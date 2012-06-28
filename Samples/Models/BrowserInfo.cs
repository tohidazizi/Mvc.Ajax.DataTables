using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Samples.Models
{
    public class BrowserInfo
    {
        public int Id { get; set; }
        public string Engine { get; set; }
        public string Browser { get; set; }
        public string Platform { get; set; }
        public float Version { get; set; }
        public string Grade { get; set; }
    }
}
