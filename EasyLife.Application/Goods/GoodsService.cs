
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using EasyLife.Goods.Dtos;
using PagedList;

namespace EasyLife
{
    public class GoodsService : EasyLifeAppServiceBase,IGoodsService
    {
        private readonly IGoodsRepository _goodsRepository;
        public GoodsService(IGoodsRepository goodsRepository)
        {
            _goodsRepository = goodsRepository;
        }

        public IPagedList<GoodsDto> QueryGoods(int merchantId,int pageNumber,int pageSize)
        {
            int totalCount;
            var list = _goodsRepository.QueryGoods(merchantId, pageNumber, pageSize,out totalCount);
     
            var result = Mapper.Map<List<GoodsDto>>(list);
            if (result == null || result.Any() == false)
            {
                for (int i = 0; i < 10; i++)
                {
                    result.Add(new GoodsDto()
                    {
                        GoodsPic = "Images/profile_small.jpg",
                        CategoryId = 1,
                        Discount = (decimal) 0.8,
                        DiscountPrice = (decimal) 5.3,
                        Id = i,
                        MerchantId = 1,
                        Name = "上衣",
                        Price = (decimal) 8.8,
                        SaveMoney = (decimal) 2.3,
                        Status = 1
                    });
                }
            }
            return new StaticPagedList<GoodsDto>(result,pageNumber,pageSize,totalCount);
        }
    }
}
