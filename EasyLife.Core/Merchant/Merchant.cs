using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using EasyLife.Core.Enum;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyLife.Core
{
    [Table("merchant")]
    public class Merchant : Entity, IFullAudited
    {
        /// <summary>
        /// 商户名称
        /// </summary>
        [MaxLength(50)]
        public virtual string merchant_name { get; set; }

        /// <summary>
        /// 银行名称
        /// </summary>
        [MaxLength(50)]
        public virtual string bank { get; set; }
        /// <summary>
        /// 账号
        /// </summary>
        [MaxLength(50)]
        public virtual string account { get; set; }

        /// <summary>
        /// 城市导航
        /// </summary>
        [ForeignKey("city_id")]
        public virtual City City { get; set; }
        /// <summary>
        /// 所属城市信息
        /// </summary>
        public virtual int city_id { get; set; }

        /// <summary>
        /// 行业导航
        /// </summary>
        [ForeignKey("cat_id")]
        public virtual Category Category { get; set; }
        /// <summary>
        /// 所属行业ID
        /// </summary>
        public virtual int cat_id { get; set; }

        /// <summary>
        /// 联系人
        /// </summary>
        [MaxLength(50)]
        public virtual string contact_name { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        [MaxLength(50)]
        public virtual string phone { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        [MaxLength(50)]
        public virtual string email { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public virtual StatusEnum status { get; set; }

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
