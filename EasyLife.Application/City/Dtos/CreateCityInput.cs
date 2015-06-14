using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace EasyLife
{
   public class CreateCityInput:IInputDto
    {
       [Required]
       [Display(Name = "城市名称")]
       [MaxLength(50)]
        public string city_name { get; set; }
       [Required]
       [Display(Name = "城市拼音")]
       [MaxLength(50)]
        public string pin_yin { get; set; }

       //[Required]
       //[Display(Name = "首字母")]
       //[MaxLength(50)]
       // public string first_char { get; set; }
    }
}
