using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using EasyLife.Core.Enum;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyLife.Core
{
    [Table("city")]
    public class City : Entity, IFullAudited
    {
        public City()
        {
            CreationTime = DateTime.Now;
            hot = HotEnum.Yes;
        }
        /// <summary>
        /// 城市名称
        /// </summary>
        [MaxLength(50)]
        public virtual string city_name { get; set; }

        /// <summary>
        /// 城市名称拼音
        /// </summary>
        [MaxLength(20)]
        public virtual string pin_yin { get; set; }

        /// <summary>
        /// 是否最热
        /// </summary>
        public virtual HotEnum hot { get; set; }

        /// <summary>
        /// 所属父城市ID
        /// </summary>
        public virtual int? parent_id { get; set; }

        /// <summary>
        /// 首字母
        /// </summary>
        [MaxLength(10)]
        public virtual string first_char { get; set; }

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
