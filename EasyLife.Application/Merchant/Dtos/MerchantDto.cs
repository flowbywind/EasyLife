using System;
using Abp.Application.Services.Dto;

namespace EasyLife
{
    public class MerchantDto : EntityDto
    {
        public string merchant_name { get; set; }
        public string bank { get; set; }
        public string account { get; set; }
        public int? city_id { get; set; }
        public string city_name { get; set; }
        public int? cat_id { get; set; }
        public string cat_name { get; set; }
        public string contact_name { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public virtual Status status { get; set; }
    }
}
