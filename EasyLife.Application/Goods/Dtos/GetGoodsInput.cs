using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Runtime.Validation;

namespace EasyLife.Goods.Dtos
{
    public class GetGoodsInput : IInputDto
    {
        public int MerchantId { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
