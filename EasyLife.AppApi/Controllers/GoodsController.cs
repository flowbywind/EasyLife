using System.Web.Mvc;
using EasyLife.AppApi.Models;
using PagedList;

namespace EasyLife.AppApi.Controllers
{
    public class GoodsController : Controller
    {
        private readonly IGoodsService GoodsService;
        public GoodsController(IGoodsService goodsService)
        {
            GoodsService = goodsService;
        }

        /// <summary>
        /// 获取商品信息
        /// </summary>
        /// <param name="merchantId">商机ID</param>
        /// <param name="tagId">衣物种类</param>
        /// <param name="pageSize">页码</param>
        /// <param name="pageNumber">每页大小</param>
        /// <returns></returns>
        public ActionResult QueryGoods(int merchantId,int? tagId, int pageSize,int pageNumber)
        {
            var list = GoodsService.QueryGoods(merchantId,tagId, pageNumber, pageSize);
            ReturnResult<PagedList.IPagedList<GoodsDto>> result=new ReturnResult<IPagedList<GoodsDto>>();
            result.result = list;
            result.success = true;
            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}
