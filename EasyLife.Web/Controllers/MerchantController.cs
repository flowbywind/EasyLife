using EasyLife.Application;
using EasyLife.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyLife.Web.Controllers
{
    public class MerchantController : EasyLifeControllerBase
    {
        private readonly IMerchantService _merchantService;
        private readonly ICategoryService _categoryService;
        private readonly ICityService _cityService;


        public MerchantController(IMerchantService merchantService, ICategoryService categoryService, ICityService cityService)
        {
            _merchantService = merchantService;
            _categoryService = categoryService;
            _cityService = cityService;
        }

        //
        // GET: /Merchant/
        public ActionResult Index()
        {
            initViewData();
            return View();
        }

        public ActionResult List(int? pageNumber, int? pageSize)
        {
            pageNumber = pageNumber ?? 1;
            pageSize = pageSize ?? ConfigHelper.PageSize;
            var model = _merchantService.GetList(pageNumber.Value, pageSize.Value);
            return View(model);
        }

        //
        // GET: /Merchant/Details/5
        public ActionResult Details(int id)
        {
            var model = _merchantService.GetByID(id);
            return View(model);
        }

        //
        // GET: /Merchant/Create
        public ActionResult Create()
        {
            return RedirectToAction("Index");
        }

        //
        // POST: /Merchant/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MerchantDto input)
        {
            // TODO: Add insert logic here
            if (ModelState.IsValid)
            {
                _merchantService.Create(input);
                return RedirectToAction("List");
            }
            ViewData["status"] = EnumExt.GetSelectList(typeof(StatusEnum));
            return RedirectToAction("Index", input);
        }

        //
        // GET: /Merchant/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _merchantService.GetByID(id);
            initViewData(model.city_id, model.cat_id);
            return View(model);
        }

        /// <summary>
        /// 初始化参数
        /// </summary>
        private void initViewData(int city_id = 0, int cat_id = 0)
        {
            ViewData["status"] = EnumExt.GetSelectList(typeof(StatusEnum));
            var citys = _cityService.GetList().Citys;
            ViewData["city_id"] = from a in citys
                                  select new SelectListItem
                                  {
                                      Text = a.city_name,
                                      Value = a.Id.ToString(),
                                      Selected = city_id == a.Id
                                  };
            var categorys = _categoryService.GetList().Categorys;
            ViewData["cat_id"] = from a in categorys
                                 select new SelectListItem
                                 {
                                     Text = a.cat_name,
                                     Value = a.Id.ToString(),
                                     Selected = cat_id == a.Id
                                 };
        }

        //
        // POST: /Merchant/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MerchantDto input)
        {
            // TODO: Add update logic here
            if (ModelState.IsValid)
            {
                _merchantService.Update(input, id);
                return RedirectToAction("List");
            }
            initViewData(input.city_id, input.cat_id);
            return View("edit", input);
        }

        //
        // GET: /Merchant/Delete/5
        public ActionResult Delete(int id)
        {
            return RedirectToAction("List");
        }

        //
        // POST: /Merchant/Delete/5
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
