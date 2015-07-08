
using EasyLife.AppApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyLife.AppApi.Controllers
{
    public class AliPayController : Controller
    {
        //
        private readonly IAliPayService AliPayService;
        public AliPayController(IAliPayService aliPayService)
        {
            AliPayService = aliPayService;
        }

        /// <summary>
        /// 交易字符串
        /// </summary>
        /// <param name="input">订单实体</param>
        /// <returns></returns>
        public ActionResult AppTradeData(OrderInfoDto input)
        {
            string tradeData = AliPayService.AppTradeData(input);

            ReturnResult<string> result = new ReturnResult<string>();

            result.result = tradeData;

            result.success = true;

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 交易支付通知
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        public ActionResult Notify(FormCollection collection)
        {
            int i = 0;
            SortedDictionary<string, string> sArray = new SortedDictionary<string, string>();

            String[] requestItem = collection.AllKeys;

            for (i = 0; i < requestItem.Length; i++)
            {
                sArray.Add(requestItem[i], Request.Form[requestItem[i]]);
            }

            ReturnResult<string> result = new ReturnResult<string>();

            string tradeData = AliPayService.Notify(sArray);

            result.result = tradeData;

            result.success = true;

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}