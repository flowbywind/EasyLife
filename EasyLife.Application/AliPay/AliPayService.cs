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
        /// <summary>
        ///请求交易字符串
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 客户端交易异步通知
        /// </summary>
        /// <param name="sArray"></param>
        /// <returns></returns>
        public string Notify(SortedDictionary<string, string> sArray)
        {
            if (sArray.Count > 0)//判断是否有带返回参数
            {
                Notify aliNotify = new Notify();
                bool verifyResult = aliNotify.Verify(sArray,sArray["notify_id"], sArray["sign"]);

                if (verifyResult)//验证成功
                {
                    /////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    //请在这里加上商户的业务逻辑程序代码


                    //——请根据您的业务逻辑来编写程序（以下代码仅作参考）——
                    //获取支付宝的通知返回参数，可参考技术文档中服务器异步通知参数列表

                    //商户订单号

                    string out_trade_no = sArray["out_trade_no"];

                    //支付宝交易号

                    string trade_no = sArray["trade_no"];

                    //交易状态
                    string trade_status = sArray["trade_status"];


                    if (sArray["trade_status"] == "TRADE_FINISHED")
                    {
                        //判断该笔订单是否在商户网站中已经做过处理
                        //如果没有做过处理，根据订单号（out_trade_no）在商户网站的订单系统中查到该笔订单的详细，并执行商户的业务程序
                        //如果有做过处理，不执行商户的业务程序

                        //注意：
                        //退款日期超过可退款期限后（如三个月可退款），支付宝系统发送该交易状态通知
                    }
                    else if (sArray["trade_status"] == "TRADE_SUCCESS")
                    {
                        //判断该笔订单是否在商户网站中已经做过处理
                        //如果没有做过处理，根据订单号（out_trade_no）在商户网站的订单系统中查到该笔订单的详细，并执行商户的业务程序
                        //如果有做过处理，不执行商户的业务程序

                        //注意：
                        //付款完成后，支付宝系统发送该交易状态通知
                    }
                    else
                    {
                    }

                    //——请根据您的业务逻辑来编写程序（以上代码仅作参考）——

                    return "success";  //请不要修改或删除

                    /////////////////////////////////////////////////////////////////////////////////////////////////////////////
                }
                else//验证失败
                {
                    return "fail";
                }
            }
            else
            {
                return "无通知参数";
            }
        }
    }
}
