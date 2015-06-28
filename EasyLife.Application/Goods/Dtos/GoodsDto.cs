using Abp.Application.Services.Dto;

namespace EasyLife
{
    public class GoodsDto : IOutputDto
    {
        public new int Id
        {
            get;
            set;
        }

        /// <summary>
        /// 商品名称
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// 商品图片
        /// </summary>
        public string GoodsPic
        {
            get;
            set;
        }

        /// <summary>
        /// 价格
        /// </summary>
        public decimal Price
        {
            get;
            set;
        }

        /// <summary>
        /// 折扣
        /// </summary>
        public decimal Discount
        {
            get;
            set;
        }

        /// <summary>
        /// 折扣价
        /// </summary>
        public decimal DiscountPrice
        {
            get;
            set;
        }

        /// <summary>
        /// 节省
        /// </summary>
        public decimal SaveMoney
        {
            get;
            set;
        }

        /// <summary>
        /// 衣物种类
        /// </summary>
        public int CategoryId
        {
            get;
            set;
        }

        /// <summary>
        /// 状态
        /// </summary>
        public int Status
        {
            get;
            set;
        }

        /// <summary>
        /// 商家ID
        /// </summary>
        public int MerchantId
        {
            get;
            set;
        }

    }
}
