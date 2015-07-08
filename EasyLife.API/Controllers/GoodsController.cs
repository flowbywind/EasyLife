
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;
using PagedList;
namespace EasyLife.API.Controllers
{
    public class GoodsController : BaseApiController
    {
        // GET api/goods
         private readonly IGoodsService GoodsService;
         public GoodsController(IGoodsService goodsService)
        {
            GoodsService = goodsService;
        }
         [HttpGet]
         [HttpPost]
         [Route("Goods/QueryGoods")]
         public JsonResult<IPagedList<GoodsDto>> QueryGoods(int merchantId, int? tagId, int pageSize, int pageNumber)
        {
            var result = GoodsService.QueryGoods(merchantId,tagId, pageNumber,pageSize);
            return Json(result);
        }

      
    }
}
