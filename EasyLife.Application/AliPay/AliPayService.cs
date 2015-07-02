using Com.Alipay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyLife.Application
{
    public class AliPayService : EasyLifeAppServiceBase, IAliPayService
    {
        public string AppTradeData(OrderInfoDto input)
        {
            //把请求参数打包成数组
            SortedDictionary<string, string> sParaTemp = new SortedDictionary<string, string>();
            sParaTemp.Add("partner", Config.Partner);
            sParaTemp.Add("seller_id", Config.Seller_id);
            sParaTemp.Add("out_trade_no", input.out_trade_no);
            sParaTemp.Add("subject", input.subject);
            sParaTemp.Add("body", input.body);
            sParaTemp.Add("total_fee", input.total_fee);
            sParaTemp.Add("notify_url", Config.Notify_url);
            sParaTemp.Add("service", Config.Service);
            sParaTemp.Add("payment_type", Config.Payment_type);
            sParaTemp.Add("_input_charset", Config.Input_charset.ToLower());
            sParaTemp.Add("it_b_pay", Config.It_b_pay);
            sParaTemp.Add("return_url", Config.Return_url);

            //链接字符串
            string result = Com.Alipay.Submit.BuildRequest(sParaTemp);

            return result;
        }
    }
}
