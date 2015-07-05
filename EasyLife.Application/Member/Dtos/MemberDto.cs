using Abp.Application.Services.Dto;
using Newtonsoft.Json;

namespace EasyLife
{
    public class MemberDto : IOutputDto
    {
        public int id { get; set; }
        public string member_name { get; set; }
        public string member_sex { get; set; }
        public string member_birthday { get; set; }
        public string member_phone { get; set; }
        public string member_address { get; set; }
    }
}
