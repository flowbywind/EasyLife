using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyLife
{
    public class OrderInfoDto : IOutputDto
    {

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


    }
}
