using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyLife.AppApi.Models
{
    public class Error
    {
        public int code { get; set; }
        public string message { get; set; }
        public string details { get; set; }
    }
}