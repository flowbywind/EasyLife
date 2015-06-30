using Abp.Application.Services.Dto;
using EasyLife.Core.Enum;

namespace EasyLife
{
    public class GoodsDto : IOutputDto
    {
        /// <summary>
        /// 商品ID
        /// </summary>
        public int id
        {
            get;
            set;
        }

        /// <summary>
        /// 商品名称
        /// </summary>
        public string name
        {
            get;
            set;
        }

        /// <summary>
        /// 商品图片
        /// </summary>
        public string goods_pic
        {
            get;
            set;
        }

        /// <summary>
        /// 价格
        /// </summary>
        public decimal price
        {
            get;
            set;
        }

        /// <summary>
        /// 折扣
        /// </summary>
        public decimal discount
        {
            get;
            set;
        }

        /// <summary>
        /// 折扣价
        /// </summary>
        public decimal discount_price
        {
            get;
            set;
        }

        /// <summary>
        /// 节省
        /// </summary>
        public decimal save_money
        {
            get;
            set;
        }

        /// <summary>
        /// 衣物种类
        /// </summary>
        public int tag_id
        {
            get;
            set;
        }

        /// <summary>
        /// 状态
        /// </summary>
        public StatusEnum status
        {
            get;
            set;
        }

        /// <summary>
        /// 商家ID
        /// </summary>
        public int merchant_id
        {
            get;
            set;
        }

    }
}
