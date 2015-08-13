using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;

namespace EasyLife.Core.Order
{
    [Table("order")]
    public class Order:FullAuditedEntity
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 商家ID
        /// </summary>
        public int merchant_id { get; set; }
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
        public string city_name { get; set; }
        /// <summary>
        /// 城市ID
        /// </summary>
        public int city_id { get; set; }
        /// <summary>
        /// 区县ID
        /// </summary>
        public int district_id { get; set; }
        /// <summary>
        /// 区县名称
        /// </summary>
        public string district_name { get; set; }
        /// <summary>
        /// 小区ID
        /// </summary>
        public int community_id { get; set; }
        /// <summary>
        /// 小区名称
        /// </summary>
        public string community_name { get; set; }
        /// <summary>
        /// 收货日期
        /// </summary>
        public DateTime get_goods_date { get; set; }
        /// <summary>
        /// 收货开始时间
        /// </summary>
        public int get_goods_begin_time { get; set; }
        /// <summary>
        /// 收货结束时间
        /// </summary>
        public int get_goods_end_time { get; set; }
        /// <summary>
        /// 订单状态 1提交订单  5完成订单  9取消订单
        /// </summary>
        public int order_status { get; set; }
        /// <summary>
        /// 订单日期
        /// </summary>
        public DateTime order_date { get; set; }
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

        /// <summary>
        /// 订单明细
        /// </summary>
        [NotMapped]
        public List<OrderDetail> OrderDetails { get; set; } 
   
    }
}
