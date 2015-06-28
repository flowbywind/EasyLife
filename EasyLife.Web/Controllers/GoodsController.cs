using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyLife.Web.Controllers
{
    public class GoodsController : Controller
    {
        private readonly IGoodsService _goodsService;

        public GoodsController(IGoodsService goodsService)
        {
            _goodsService = goodsService;
        }


        //
        // GET: /Goods/
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Goods/List/5
        public ActionResult List(int id, int? pageNumber, int? pageSize)
        {
            pageNumber = pageNumber ?? 1;
            pageSize = pageSize ?? 2;
            var model = _goodsService.GetGoodsByMerchantID(id, pageNumber.Value, pageNumber.Value);
            ViewBag.MerchantID = id;
            return View(model);
        }

        //
        // GET: /Goods/Details/5
        public ActionResult Details(int id)
        {
            var model = _goodsService.GetGoodsByID(id);
            return View(model);
        }

        //
        // GET: /Goods/Create
        public ActionResult Create(int id)
        {
            ViewData["merchant_id"] = id;
            return View("Index");
        }

        //
        // POST: /Goods/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                var goods = new GoodsDto
                {
                    name = collection["Name"],
                    goods_pic = collection["GoodsPic"],
                    price = collection["Price"].ToDecimal(),
                    discount = collection["Discount"].ToDecimal(),
                    discount_price = collection["DiscountPrice"].ToDecimal(),
                    save_money = collection["SaveMoney"].ToDecimal(),
                    tag_id = collection["CategoryId"].ToInt(),
                    status = collection["Status"].ToInt(),
                    merchant_id = collection["MerchantId"].ToInt(),
                };
                _goodsService.CreateGoods(goods);
                 return RedirectToAction("List",goods.merchant_id);
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Goods/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _goodsService.GetGoodsByID(id);
            ViewData["merchant_id"] = model.merchant_id;
            return View(model);
        }

        //
        // POST: /Goods/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                var goods = new GoodsDto
                {
                    name = collection["Name"],
                    goods_pic = collection["GoodsPic"],
                    price = collection["Price"].ToDecimal(),
                    discount = collection["Discount"].ToDecimal(),
                    discount_price = collection["DiscountPrice"].ToDecimal(),
                    save_money = collection["SaveMoney"].ToDecimal(),
                    tag_id = collection["CategoryId"].ToInt(),
                    status = collection["Status"].ToInt(),
                    merchant_id = collection["MerchantId"].ToInt()
                };
                _goodsService.UpdateGoodsById(goods, id);
                return RedirectToAction("List", goods.merchant_id);
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Goods/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Goods/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
