using System.Web;
using System.Text;
using System.IO;
using System.Net;
using System;
using System.Collections.Generic;

namespace Com.Alipay
{
    /// <summary>
    /// 类名：Config
    /// 功能：基础配置类
    /// 详细：设置帐户有关信息及返回路径
    /// 版本：3.3
    /// 日期：2012-07-05
    /// 说明：
    /// 以下代码只是为了方便商户测试而提供的样例代码，商户可以根据自己网站的需要，按照技术文档编写,并非一定要使用该代码。
    /// 该代码仅供学习和研究支付宝接口使用，只是提供一个参考。
    /// 
    /// 如何获取安全校验码和合作身份者ID
    /// 1.用您的签约支付宝账号登录支付宝网站(www.alipay.com)
    /// 2.点击“商家服务”(https://b.alipay.com/order/myOrder.htm)
    /// 3.点击“查询合作者身份(PID)”、“查询安全校验码(Key)”
    /// </summary>
    public class Config
    {
        #region 字段
        private static string partner = "";
        private static string seller_id = "";
        private static string seller_email = "";
        private static string key = "";
        private static string private_key = "";
        private static string public_key = "";
        private static string input_charset = "";
        private static string sign_type = "";
        private static string notify_url = "";
        private static string service = "";
        private static string payment_type = "";
        private static string it_b_pay = "";
        private static string return_url = "";


        #endregion

        static Config()
        {
            //↓↓↓↓↓↓↓↓↓↓请在这里配置您的基本信息↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓

            //合作身份者ID，以2088开头由16位纯数字组成的字符串
            partner = "";

            // 签约卖家支付宝账号
            seller_id = "";

            //收款支付宝账号
            seller_email = "";

            //交易安全检验码，由数字和字母组成的32位字符串
            key = "asdfghjkl1234qwertyuiop87MHGF90O";

            //商户的私钥
            private_key = @"MIICdwIBADANBgkqhkiG9w0BAQEFAASCAmEwggJdAgEAAoGBAKSZSSEdPhv77O5ocnLNGXeQ21qJDArC1+yId+9/pY5bXkZk5vCB49EpfMwNukLv6AJqofThZPNOs1t015fdEYIUnkIc2QVxRwa0xTeFP6N8D4WQXRWs4fNG27JK5kP45s+9KlJtx5hs7G97aMczehIWpHaO6j9inOmjlU8l62KZAgMBAAECgYEAmK3TRtMwRJb33OGnn9OeFumYfy92qxi3X6Hq1o6qDBW2qkd4bImfv+ni6AinyOVuaadt2Y+lq4dKGcCVJzoZvPm1VKxD2y7xKa8/vEbPRiRTt0qnPq9T7UJkpDsiXf/zOMfWdjc3uA1bPnQ65RWHSJ7zAE+Gd7xnyCE5MEyijLECQQDVYqQWDqOVLZ5lJUuIfUIrhv26GvuoTX8v60+opCz4/Mdfh6JlefICVD6SAaYvufXBHVFY26JicNlR62ZOiBoNAkEAxXhsuEnNJNQcQHEVTPZoulbMbTV1VZIDQ1zjG8fvu8sv6IBYcR5+EsC8n3/6RkW8/iCJDzxE++VHzhoSQSoDvQJBAM6/63J/rpndAIrJ7vyJOPLJsc9/U3SH2gMJAT7KC9UXvuldlsixtf3xuEpplKbLjEUXbfklnZm586a+6XqPvoUCQDFotltOLARBBmihYuEE7qNhQHk63QbyJ9rdDP5Qgo2Mg4o7QuXa6VSr4QZPsUGQBX/YiDLFs8ULU3IgV9zyNEkCQADAYR8DctYzg0eBGdcOrDA5Szc62pYrS2wk89wUxyL4FyDL3omkVMKvtu5tccy7Xht2ikJZRqefZ3dS7ASm8/4=";

            //支付宝的公钥，无需修改该值
            public_key = @"MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQCkmUkhHT4b++zuaHJyzRl3kNtaiQwKwtfsiHfvf6WOW15GZObwgePRKXzMDbpC7+gCaqH04WTzTrNbdNeX3RGCFJ5CHNkFcUcGtMU3hT+jfA+FkF0VrOHzRtuySuZD+ObPvSpSbceYbOxve2jHM3oSFqR2juo/Ypzpo5VPJetimQIDAQAB";

            //↑↑↑↑↑↑↑↑↑↑请在这里配置您的基本信息↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑



            //字符编码格式 目前支持 gbk 或 utf-8
            input_charset = "utf-8";

            //签名方式，选择项：RSA、DSA、MD5
            sign_type = "MD5";

            // 服务器异步通知页面路径
            notify_url = "AliPay/Notify";

            // 服务接口名称， 固定值
            service = "mobile.securitypay.pay";

            // 支付类型， 固定值
            payment_type = "1";

            // 设置未付款交易的超时时间
            // 默认30分钟，一旦超时，该笔交易就会自动被关闭。
            // 取值范围：1m～15d。
            // m-分钟，h-小时，d-天，1c-当天（无论交易何时创建，都在0点关闭）。
            // 该参数数值不接受小数点，如1.5h，可转换为90m。
            it_b_pay = "30m";

            // 支付宝处理完请求后，当前页面跳转到商户指定页面的路径，可空
            return_url = "m.alipay.com";
        }

        #region 属性
        /// <summary>
        /// 获取或设置合作者身份ID
        /// </summary>
        public static string Partner
        {
            get { return partner; }
            set { partner = value; }
        }

        /// <summary>
        /// 签约卖家支付宝账号
        /// </summary>
        public static string Seller_id
        {
            get { return Config.seller_id; }
            set { Config.seller_id = value; }
        }

        /// <summary>
        /// 获取或设置合作者身份ID
        /// </summary>
        public static string Seller_email
        {
            get { return seller_email; }
            set { seller_email = value; }
        }

       /// <summary>
        /// 交易安全检验码，由数字和字母组成的32位字符串
       /// </summary>
        public static string Key
        {
            get { return Config.key; }
            set { Config.key = value; }
        }

        /// <summary>
        /// 获取或设置商户的私钥
        /// </summary>
        public static string Private_key
        {
            get { return private_key; }
            set { private_key = value; }
        }

        /// <summary>
        /// 获取或设置支付宝的公钥
        /// </summary>
        public static string Public_key
        {
            get { return public_key; }
            set { public_key = value; }
        }

        /// <summary>
        /// 获取字符编码格式
        /// </summary>
        public static string Input_charset
        {
            get { return input_charset; }
        }

        /// <summary>
        /// 获取签名方式
        /// </summary>
        public static string Sign_type
        {
            get { return sign_type; }
        }

        /// <summary>
        /// 服务器异步通知页面路径
        /// </summary>
        public static string Notify_url
        {
            get { return Config.notify_url; }
            set { Config.notify_url = value; }
        }

        /// <summary>
        /// 服务接口名称， 固定值
        /// </summary>
        public static string Service
        {
            get { return Config.service; }
            set { Config.service = value; }
        }

        /// <summary>
        /// 支付类型， 固定值
        /// </summary>
        public static string Payment_type
        {
            get { return Config.payment_type; }
            set { Config.payment_type = value; }
        }

        /// <summary>
        ///设置未付款交易的超时时间
        ///默认30分钟，一旦超时，该笔交易就会自动被关闭。
        /// 取值范围：1m～15d。
        /// m-分钟，h-小时，d-天，1c-当天（无论交易何时创建，都在0点关闭）。
        /// 该参数数值不接受小数点，如1.5h，可转换为90m。
        /// </summary>
        public static string It_b_pay
        {
            get { return Config.it_b_pay; }
            set { Config.it_b_pay = value; }
        }

        /// <summary>
        /// 支付宝处理完请求后，当前页面跳转到商户指定页面的路径，可空
        /// </summary>
        public static string Return_url
        {
            get { return Config.return_url; }
            set { Config.return_url = value; }
        }

        #endregion
    }
}