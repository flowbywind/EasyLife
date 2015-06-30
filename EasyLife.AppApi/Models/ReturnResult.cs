using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyLife.AppApi.Models
{
    public class ReturnResult<T>
    {
        public bool success { get; set; }
        public T result { get; set; }
        public bool unAuthorizedRequest { get; set; }
        public Error error { get; set; }
    }
}