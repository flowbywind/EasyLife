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

        public ActionResult QueryGoods(int merchantId,int pageSize,int pageNumber)
        {
           var result =   GoodsService.QueryGoods(1,1,1);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Query()
        {
            var result = GoodsService.QueryGoods(1, 1, 1);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult QueryGoodsInput(int merchantId, int pageSize, int pageNumber)
        {
            var result = GoodsService.QueryGoods(1, 1, 1);
            return Json(result, JsonRequestBehavior.AllowGet);
        } 

    }
}
