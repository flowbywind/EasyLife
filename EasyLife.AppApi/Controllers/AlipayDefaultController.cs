using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyLife.AppApi.Controllers
{
    public class AlipayDefaultController : Controller
    {
        //
        // GET: /AlipayDefault/
        public ActionResult Default(string trade_no, string total_fee)
        {
            return json();
        }
	}
}