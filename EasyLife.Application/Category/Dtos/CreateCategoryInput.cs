using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace EasyLife
{
    public class CreateCategoryInput : IInputDto
    {
        [Required]
        [Display(Name = "行业名称")]
        [MaxLength(50)]
        public string cat_name { get; set; }

        [Required]
        [Display(Name = "行业编码")]
        [MaxLength(50)]
        public string cat_code { get; set; }

        public override string ToString()
        {
            return string.Format("[CreateCategoryInput > cat_name = {0}, cat_code = {1}]", cat_name, cat_code);
        }
    }
}
