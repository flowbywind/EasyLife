using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyLife.Application.AliPay.Dtos
{
    public class OrderInfoApp : IOutputDto
    {
        /// <summary>
        /// 签约合作者身份ID
        /// </summary>
        public string partner { get; set; }
        /// <summary>
        /// 签约卖家支付宝账号
        /// </summary>
        public string seller_id { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        public string out_trade_no { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string subject { get; set; }
        /// <summary>
        /// 商品详情
        /// </summary>
        public string body { get; set; }
        /// <summary>
        /// 商品金额
        /// </summary>
        public string total_fee { get; set; }
        /// <summary>
        /// 服务器异步通知页面路径
        /// </summary>
        public string notify_url { get; set; }

        private string _service = "";
        /// <summary>
        /// 服务接口名称， 固定值
        /// </summary>
        public string service
        {
            get
            {
                return _service;
            }
            set
            {
                if (value != "")

                    this._service = value;
            }
        }
        /// <summary>
        /// 支付类型， 固定值
        /// </summary>
        public string payment_type { get; set; }


    }
}
