using Abp.Application.Services;
using EasyLife.Goods.Dtos;
using PagedList;

namespace EasyLife
{
    public interface IGoodsService : IApplicationService
    {
        IPagedList<GoodsDto> QueryGoods(int merchantId,int pageNumber, int pageSize);
    }
}
