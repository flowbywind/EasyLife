using System.Collections.Generic;
using System.Linq;
using Abp.AutoMapper;
using AutoMapper;
using Castle.Core.Internal;
using PagedList;
using EasyLife;
using Abp.Application.Services;

namespace EasyLife
{
    public interface IGoodsService : IApplicationService
    {
        void CreateGoods(GoodsDto input);

        GoodsList GetGoodsByMerchantID(int merchantid);

        IPagedList<GoodsDto> GetGoodsByMerchantID(int merchantid, int pageNumber, int pageSize);

        Goods  GetGoodsByID(int id);

        void UpdateGoodsById(GoodsDto input, int id);

        void DeleteGoods(int id);

        IPagedList<GoodsDto> QueryGoods(int merchantId,int pageNumber, int pageSize);
    }
}
