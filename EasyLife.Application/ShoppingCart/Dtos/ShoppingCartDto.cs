using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyLife.Application.ShoppingCart.Dtos
{
    public class ShoppingCartDto
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// 商品ID
        /// </summary>
        public int goods_id { get; set; }

        /// <summary>
        /// 商品数量
        /// </summary>
        public int count { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        public int user_id { get; set; }

        /// <summary>
        /// 商家ID
        /// </summary>
        public int merchant_id { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public int status { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        public virtual string goods_name { get; set; }

        /// <summary>
        /// 商品图片
        /// </summary>
        public virtual string goods_pic { get; set; }

        /// <summary>
        /// 价格
        /// </summary>
        public virtual decimal price { get; set; }

        /// <summary>
        /// 折扣
        /// </summary>
        public virtual decimal discount { get; set; }

        /// <summary>
        /// 折扣价
        /// </summary>
        public virtual decimal discount_price { get; set; }

        /// <summary>
        /// 节省
        /// </summary>
        public virtual decimal save_money { get; set; }

      
    }
}
