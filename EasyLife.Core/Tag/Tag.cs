﻿using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using EasyLife.Core.Enum;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace EasyLife.Core
{
    [Table("tag")]
    public class Tag : Entity, IFullAudited
    {
        /// <summary>
        /// 分类名称
        /// </summary>
        [MaxLength(50)]
        public virtual string tag_name { get; set; }

        /// <summary>
        /// 分类编码
        /// </summary>
        [MaxLength(50)]
        public virtual string tag_code { get; set; }

        /// <summary>
        ///商户ID 
        /// </summary>
        public virtual int merchant_id { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public virtual StatusEnum status { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        [MaxLength(50)]
        public virtual string icon { get; set; }

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
