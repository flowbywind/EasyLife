using System.Web.Mvc;

namespace EasyLife.AppApi.Controllers
{
    public class GoodsController : Controller
    {
        private readonly IGoodsService GoodsService;
        public GoodsController(IGoodsService goodsService)
        {
            GoodsService = goodsService;
        }

        public ActionResult QueryGoods(int merchantId,int? tagId, int pageSize,int pageNumber)
        {
            var result = GoodsService.QueryGoods(merchantId,tagId, pageNumber, pageSize);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}
