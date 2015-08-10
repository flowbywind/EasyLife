
using System.Security.Policy;

namespace EasyLife.Application.Address.Dtos
{
    public class AddressDto
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
    }
}
