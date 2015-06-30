using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyLife.AppApi.Models
{
    public class Error
    {
        public Error()
        {
        }

        public Error(ReturnCode rcode,string msg,string detail="")
        {
            code = (int) rcode;
            message = msg;
            details = detail;
        }

        public int code { get; set; }
        public string message { get; set; }
        public string details { get; set; }
    }
}