using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace EasyLife
{
    public class CityDto : IInputDto
    {
        public int id { get; set; }
            
        public string city_name { get; set; }
        public string pin_yin { get; set; }
        //public string hot { get; set; }
        //public int parent_id { get; set; }
        //public int first_char { get; set; }
    }
}
