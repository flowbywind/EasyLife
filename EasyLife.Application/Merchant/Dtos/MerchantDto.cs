using System;
using Abp.Application.Services.Dto;

namespace EasyLife
{
    public class MerchantDto : EntityDto
    {
        public string merchant_name { get; set; }
        public string bank { get; set; }
        public string account { get; set; }
        public virtual int? city_id { get; set; }
        public virtual int? cat_id { get; set; }
        public virtual string contact_name { get; set; }
        public virtual string phone { get; set; }
        public virtual string email { get; set; }
        public virtual Status status { get; set; }
    }
}
