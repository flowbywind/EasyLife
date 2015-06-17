
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

        /// <summary>
        /// 获取商品列表
        /// </summary>
        /// <param name="merchantId">商家ID</param>
        /// <param name="pageNumber">页码</param>
        /// <param name="pageSize">每页大小</param>
        /// <returns></returns>
        public IPagedList<GoodsDto> QueryGoods(int merchantId,int pageNumber,int pageSize)
        {
            int totalCount;
            var list = _goodsRepository.QueryGoods(merchantId, pageNumber, pageSize,out totalCount);
     
            var result = Mapper.Map<List<GoodsDto>>(list);
            if (result == null || result.Any() == false)
            {
                for (int i = 0; i < 1; i++)
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
            var pageList = new StaticPagedList<GoodsDto>(result,pageNumber,pageSize,totalCount);
            return pageList;
        }
    }
}
