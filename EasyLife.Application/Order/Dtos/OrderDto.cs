using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyLife.Application.Order.Dtos
{
    public  class OrderDto
    {
        /// <summary>
        /// key订单主键
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 商家ID
        /// </summary>
        public int merchant_id { get; set; }
        /// <summary>
        /// 收货人姓名
        /// </summary>
        public string member_name { get; set; }
        /// <summary>
        /// 收货人ID
        /// </summary>
        public int member_id { get; set; }
        /// <summary>
        /// 收货人地址
        /// </summary>
        public string member_address { get; set; }
        /// <summary>
        /// 收货人手机号
        /// </summary>
        public string phone { get; set; }
        /// <summary>
        /// 城市
        /// </summary>
        public string city_name { get; set; }
        /// <summary>
        /// 城市ID
        /// </summary>
        public int city_id { get; set; }
        /// <summary>
        /// 区县ID
        /// </summary>
        public int district_id { get; set; }
        /// <summary>
        /// 区县名称
        /// </summary>
        public string district_name { get; set; }
        /// <summary>
        /// 小区ID
        /// </summary>
        public int community_id { get; set; }
        /// <summary>
        /// 小区名称
        /// </summary>
        public string community_name { get; set; }
        /// <summary>
        /// 收货日期
        /// </summary>
        public DateTime get_goods_date { get; set; }
        /// <summary>
        /// 收货开始时间
        /// </summary>
        public int get_goods_begin_time { get; set; }
        /// <summary>
        /// 收货结束时间
        /// </summary>
        public int get_goods_end_time { get; set; }
        /// <summary>
        /// 订单日期
        /// </summary>
        public DateTime order_date { get; set; }
        /// <summary>
        /// 订单状态 1提交订单  5完成订单  9取消订单
        /// </summary>
        public int order_status { get; set; }
        /// <summary>
        /// 订单明细list
        /// </summary>
        public List<OrderDetailDto> OrderDetailDtos { get; set; } 

    }
}
