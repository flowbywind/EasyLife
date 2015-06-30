using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using EasyLife.Core.Enum;

namespace EasyLife.Core
{
    [Table("goods")]
    public class Goods : Entity, IFullAudited
    {
        /// <summary>
        /// 商品名称
        /// </summary>
        [MaxLength(50)]
        public virtual string name { get; set; }

        /// <summary>
        /// 商品图片
        /// </summary>
        [MaxLength(500)]
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

        /// <summary>
        /// 衣物种类
        /// </summary>
        public virtual int tag_id { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public virtual StatusEnum status { get; set; }

        /// <summary>
        /// 商家ID
        /// </summary>
        public virtual int merchant_id { get; set; }

        /// <summary>
        /// 创建人ID
        /// </summary>
        [Column("creator_user_id")]
        public virtual long? CreatorUserId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Column("creation_time")]
        public virtual DateTime CreationTime { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        [Column("last_modification_time")]
        public virtual DateTime? LastModificationTime { get; set; }

        /// <summary>
        /// 修改人
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
