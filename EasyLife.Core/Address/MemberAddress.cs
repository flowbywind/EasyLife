
using System;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace EasyLife.Core.Address
{
    [Table("MemberAddress")]
    public class MemberAddress : Entity, IFullAudited
    {

        /// <summary>
        /// key 主键
        /// </summary>
        public int Id { get; set; }
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
        public string city { get; set; }
        /// <summary>
        /// 城市ID
        /// </summary>
        public int city_id { get; set; }
        /// <summary>
        /// 小区ID
        /// </summary>
        public int community_id { get; set; }
        /// <summary>
        /// 小区名称
        /// </summary>
        public string community_name { get; set; }
        /// <summary>
        /// 是否默认地址 1是 0否
        /// </summary>
        public int is_default { get; set; }
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
