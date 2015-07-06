using EasyLife.Application;
using EasyLife.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyLife.Web.Controllers
{
    public class MerchantController : Controller
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
            ViewData["status"] = EnumExt.GetSelectList(typeof(StatusEnum));

            var citys = _cityService.GetList().Citys;
            ViewData["city_id"] = from a in citys
                                  select new SelectListItem
                                  {
                                      Text = a.city_name,
                                      Value = a.Id.ToString()
                                  };
            var categorys = _categoryService.GetList().Categorys;
            ViewData["cat_id"] = from a in categorys
                                 select new SelectListItem
                                 {
                                     Text = a.cat_name,
                                     Value = a.Id.ToString()
                                 };
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

        [HttpPost]
        public ActionResult upload(FormCollection input)
        {
            var bb = Request["cut-base64"].ToString();
            return null;
        }


        //
        // GET: /Merchant/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _merchantService.GetByID(id);
            var citys = _cityService.GetList().Citys;
            ViewData["city_id"] = from a in citys
                                  select new SelectListItem
                                  {
                                      Text = a.city_name,
                                      Value = a.Id.ToString(),
                                      Selected = model.city_id == a.Id
                                  };
            var categorys = _categoryService.GetList().Categorys;
            ViewData["cat_id"] = from a in categorys
                                 select new SelectListItem
                                 {
                                     Text = a.cat_name,
                                     Value = a.Id.ToString(),
                                     Selected = model.cat_id == a.Id
                                 };
            ViewData["status"] = EnumExt.GetSelectList(typeof(StatusEnum));
            return View(model);
        }

        //
        // POST: /Merchant/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, MerchantDto input)
        {
            // TODO: Add update logic here
            if (ModelState.IsValid)
            {
                _merchantService.Create(input);
                return RedirectToAction("List");
            }
            return RedirectToAction("list");
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
