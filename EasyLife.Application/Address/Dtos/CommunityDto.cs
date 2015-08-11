using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyLife.Application.Address.Dtos
{
    public class CommunityDto
    {
        /// <summary>
        /// 城市ID
        /// </summary>
        public int city_id { get; set; }
        /// <summary>
        /// 城市名称
        /// </summary>
        public string city_name { get; set; }
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
    }
}
