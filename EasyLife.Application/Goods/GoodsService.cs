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
                        goods_pic = "Images/profile_small.jpg",
                        tag_id = 1,
                        discount = (decimal)0.8,
                        discount_price = (decimal)5.3,
                        id = i,
                        merchant_id = 1,
                        name = "上衣",
                        price = (decimal)8.8,
                        save_money = (decimal)2.3,
                        status = 1
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
                name = input.name,
                goods_pic = input.goods_pic,
                price = input.price,
                discount = input.discount,
                discount_price = input.discount,
                save_money = input.discount_price,
                tag_id = input.tag_id,
                status = input.status,
                merchant_id = input.merchant_id
            };
            _goodsRepository.Insert(goods);
        }

        public GoodsList GetGoodsByMerchantID(int merchantid)
        {
            var model = _goodsRepository.GetAll().Where(a => a.merchant_id == merchantid);
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

            model.name = input.name;
            model.goods_pic = input.goods_pic;
            model.price = input.price;
            model.discount = input.discount;
            model.discount_price = input.discount_price;
            model.save_money = input.save_money;
            model.tag_id = input.tag_id;
            model.status = input.status;
            model.merchant_id = input.merchant_id;
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
