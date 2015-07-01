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
    public class ConfigMobile
    {
        #region 字段
        private static string partner = "";
        private static string seller_id = "";
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

        static ConfigMobile()
        {
            //↓↓↓↓↓↓↓↓↓↓请在这里配置您的基本信息↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓

            //合作身份者ID，以2088开头由16位纯数字组成的字符串
            partner = "";

            // 签约卖家支付宝账号
            seller_id = "";

            //商户的私钥
            private_key = @"";

            //支付宝的公钥，无需修改该值
            public_key = @"MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQCnxj/9qwVfgoUh/y2W89L6BkRAFljhNhgPdyPuBV64bfQNN1PjbCzkIM6qRdKBoLPXmKKMiFYnkd6rAoprih3/PrQEB/VsW8OoM8fxn67UDYuyBTqA23MML9q1+ilIZwBC2AQ2UBVOrFXfFl75p6/B5KsiNG9zpgmLCUYuLkxpLQIDAQAB";

            //↑↑↑↑↑↑↑↑↑↑请在这里配置您的基本信息↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑



            //字符编码格式 目前支持 gbk 或 utf-8
            input_charset = "utf-8";

            //签名方式，选择项：RSA、DSA、MD5
            sign_type = "RSA";

            // 服务器异步通知页面路径
            notify_url = "";

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
            get { return ConfigMobile.seller_id; }
            set { ConfigMobile.seller_id = value; }
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
            get { return ConfigMobile.notify_url; }
            set { ConfigMobile.notify_url = value; }
        }

        /// <summary>
        /// 服务接口名称， 固定值
        /// </summary>
        public static string Service
        {
            get { return ConfigMobile.service; }
            set { ConfigMobile.service = value; }
        }

        /// <summary>
        /// 支付类型， 固定值
        /// </summary>
        public static string Payment_type
        {
            get { return ConfigMobile.payment_type; }
            set { ConfigMobile.payment_type = value; }
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
            get { return ConfigMobile.it_b_pay; }
            set { ConfigMobile.it_b_pay = value; }
        }

        /// <summary>
        /// 支付宝处理完请求后，当前页面跳转到商户指定页面的路径，可空
        /// </summary>
        public static string Return_url
        {
            get { return ConfigMobile.return_url; }
            set { ConfigMobile.return_url = value; }
        }

        #endregion
    }
}