using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace EasyLife
{
    [Table("goods")]
    public class Goods : Entity, IFullAudited
    {
        /// <summary>
        /// 商品ID
        /// </summary>
        [Key]
        public new int Id
        {
            get;
            set;
        }

        /// <summary>
        /// 商品名称
        /// </summary>
        [Column("name")]
        [MaxLength(150)]
        public string name
        {
            get;
            set;
        }

        /// <summary>
        /// 商品图片
        /// </summary>
        [Column("goods_pic")]
        [MaxLength(150)]
        public string goods_pic
        {
            get;
            set;
        }

        /// <summary>
        /// 价格
        /// </summary>
        [Column("price")]
        public decimal price
        {
            get;
            set;
        }

        /// <summary>
        /// 折扣
        /// </summary>
        [Column("discount")]
        public decimal discount
        {
            get;
            set;
        }

        /// <summary>
        /// 折扣价
        /// </summary>
        [Column("discount_price")]
        public decimal discount_price
        {
            get;
            set;
        }

        /// <summary>
        /// 节省
        /// </summary>
        [Column("save_money")]
        public decimal save_money
        {
            get;
            set;
        }

        /// <summary>
        /// 衣物种类
        /// </summary>
        [Column("category_id")]
        public int category_id
        {
            get;
            set;
        }

        /// <summary>
        /// 状态
        /// </summary>
        [Column("status")]
        public int status
        {
            get;
            set;
        }

        /// <summary>
        /// 商家ID
        /// </summary>
        [Column("merchant_id")]
        public int merchant_id
        {
            get;
            set;
        }

        /// <summary>
        /// 创建人ID
        /// </summary>
        [Column("creator_userId")]
        public virtual long? CreatorUserId
        {
            get;
            set;
        }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Column("creation_time")]
        public virtual DateTime CreationTime
        {
            get;
            set;
        }

        /// <summary>
        /// 修改时间
        /// </summary>
        [Column("last_modification_time")]
        public virtual DateTime? LastModificationTime
        {
            get;
            set;
        }

        /// <summary>
        /// 修改人
        /// </summary>
        [Column("last_modifier_userId")]
        public virtual long? LastModifierUserId
        {
            get;
            set;
        }

        /// <summary>
        /// 删除人
        /// </summary>
        [Column("deleter_userId")]
        public virtual long? DeleterUserId
        {
            get;
            set;
        }

        /// <summary>
        /// 删除时间
        /// </summary>
        [Column("deletion_time")]
        public virtual DateTime? DeletionTime
        {
            get;
            set;
        }

        /// <summary>
        /// 是否删除
        /// </summary>
        [Column("is_deleted")]
        public virtual bool IsDeleted
        {
            get;
            set;
        }
    }
}
