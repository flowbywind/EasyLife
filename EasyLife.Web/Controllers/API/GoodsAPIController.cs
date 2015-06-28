using System.Web.Mvc;

namespace EasyLife.Web.Controllers.API
{
    public class GoodsAPIController : EasyLifeControllerBase
    {
        private readonly IGoodsService GoodsService;
        public GoodsAPIController(IGoodsService goodsService)
        {
            GoodsService = goodsService;
        }

        //
        // GET: /Goods/
        //public ActionResult QueryGoods(int merchantId, int pageSize, int pageNumber)
        //{

        //    var result = GoodsService.Query(1, 1, 10);
        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}

        public ActionResult QueryGoods(EasyLife.Goods.Dtos.GetGoodsInput input)
        {
            var result = GoodsService.Query(1, 1, 10);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
	}
}