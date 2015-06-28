using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using PagedList;

namespace EasyLife
{
    public class GoodsService : EasyLifeAppServiceBase, IGoodsService
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
        public IPagedList<GoodsDto> QueryGoods(int merchantId, int pageNumber, int pageSize)
        {
            int totalCount;
            var list = _goodsRepository.QueryGoods(merchantId, pageNumber, pageSize, out totalCount);

            var result = Mapper.Map<List<GoodsDto>>(list);
            if (result == null || result.Any() == false)
            {
                for (int i = 0; i < 1; i++)
                {
                    result.Add(new GoodsDto()
                    {
                        GoodsPic = "Images/profile_small.jpg",
                        CategoryId = 1,
                        Discount = (decimal)0.8,
                        DiscountPrice = (decimal)5.3,
                        Id = i,
                        MerchantId = 1,
                        Name = "上衣",
                        Price = (decimal)8.8,
                        SaveMoney = (decimal)2.3,
                        Status = 1
                    });
                }
            }
            var pageList = new StaticPagedList<GoodsDto>(result, pageNumber, pageSize, totalCount);
            return pageList;
        }

        public void CreateGoods(GoodsDto input)
        {
            var goods = new Goods
            {
                Name = input.Name,
                GoodsPic = input.GoodsPic,
                Price = input.Price,
                Discount = input.Discount,
                DiscountPrice = input.Discount,
                SaveMoney = input.SaveMoney,
                CategoryId = input.CategoryId,
                Status = input.Status,
                MerchantId = input.MerchantId
            };
            _goodsRepository.Insert(goods);
        }

        public GoodsList GetGoodsByMerchantID(int merchantid)
        {
            var model = _goodsRepository.GetAll().Where(a => a.MerchantId == merchantid);
            return new GoodsList
            {
                GoodsDtos = Mapper.Map<List<GoodsDto>>(model)
            };
        }

        public IPagedList<GoodsDto> GetGoodsByMerchantID(int merchantid, int pageNumber, int pageSize)
        {
            int totalCount = 0;
            var list = _goodsRepository.QueryGoods(merchantid, pageNumber, pageSize, out totalCount);
            var result = Mapper.Map<List<GoodsDto>>(list);
            var pagelist = new StaticPagedList<GoodsDto>(result, pageNumber, pageSize, totalCount);
            return pagelist;
        }

        public Goods GetGoodsByID(int id)
        {
            return _goodsRepository.Get(id);

        }

        public void UpdateGoodsById(GoodsDto input, int id)
        {
            var model = _goodsRepository.Get(id);

            model.Name = input.Name;
            model.GoodsPic = input.GoodsPic;
            model.Price = input.Price;
            model.Discount = input.Discount;
            model.DiscountPrice = input.Discount;
            model.SaveMoney = input.SaveMoney;
            model.CategoryId = input.CategoryId;
            model.Status = input.Status;
            model.MerchantId = input.MerchantId;
            _goodsRepository.Update(model);
        }

        public void DeleteGoods(int id)
        {
            var model = _goodsRepository.Get(id);
            model.IsDeleted = true;
            _goodsRepository.Update(model);
        }
    }
}
