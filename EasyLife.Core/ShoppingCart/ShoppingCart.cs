using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using EasyLife.Core.Enum;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyLife.Core.ShoppingCart
{
    [Table("shopping_cart")]
    public class ShoppingCart : FullAuditedEntity
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }

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
