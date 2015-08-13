using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;

namespace EasyLife.Core.Order
{
    [Table("order_detail")]
    public class OrderDetail:FullAuditedEntity
    {

        /// <summary>
        /// 订单ID
        /// </summary>
        public int order_id { get; set; }

        /// <summary>
        /// 购物车Id
        /// </summary>
        public int shoppingcart_id { get; set; }

        /// <summary>
        /// 商品ID
        /// </summary>
        public int goods_id { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        public virtual string goods_name { get; set; }

        /// <summary>
        /// 商品图片
        /// </summary>
        public virtual string goods_pic { get; set; }

        /// <summary>
        /// 商品数量
        /// </summary>
        public int count { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        public int member_id { get; set; }

        /// <summary>
        /// 商家ID
        /// </summary>
        public int merchant_id { get; set; }

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
        /// <summary>
        /// 创建人
        /// </summary>
        [Column("creator_user_id")]
        public virtual long? CreatorUserId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Column("creation_time")]
        public virtual DateTime CreationTime { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        [Column("last_modification_time")]
        public virtual DateTime? LastModificationTime { get; set; }

        /// <summary>
        /// 最后修改人
        /// </summary>
        [Column("last_modifier_user_id")]
        public virtual long? LastModifierUserId { get; set; }

        /// <summary>
        /// 删除人
        /// </summary>
        [Column("deleter_user_id")]
        public virtual long? DeleterUserId { get; set; }

        /// <summary>
        /// 删除时间
        /// </summary>
        [Column("deletion_time")]
        public virtual DateTime? DeletionTime { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        [Column("is_deleted")]
        public virtual bool IsDeleted { get; set; }
    }
}
