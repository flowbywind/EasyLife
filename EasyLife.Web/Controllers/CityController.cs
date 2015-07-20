using EasyLife.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EasyLife.Core.Enum;

namespace EasyLife.Web.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class CityController : EasyLifeControllerBase
    {
        private readonly ICityService _cityService;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="cityService"></param>
        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }

        //
        // GET: /City/
        public ActionResult Index()
        {
            ViewData["hot"] = EnumExt.GetSelectList(typeof(HotEnum));
            return View();
        }

        //
        // GET: /City/List
        public ActionResult List(int? pageNumber, int? pageSize)
        {
            pageNumber = pageNumber ?? 1;
            pageSize = pageSize ?? ConfigHelper.PageSize;
            var model = _cityService.GetList(pageNumber.Value, pageSize.Value);
            return View(model);
        }

        //
        // GET: /City/Details/5
        public ActionResult Details(int id)
        {
            var model = _cityService.GetByID(id);
            return View(model);
        }

        //
        // GET: /City/Create
        public ActionResult Create()
        {
            return RedirectToAction("Index");
        }

        //
        // POST: /City/Create
        [HttpPost]
        public ActionResult Create(CityDto input)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    _cityService.Create(input);
                    return RedirectToAction("List");
                }
                ViewData["hot"] = EnumExt.GetSelectList(typeof(StatusEnum));
                return View("index", input);
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /City/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _cityService.GetByID(id);
            ViewData["hot"] = EnumExt.GetSelectList(typeof(HotEnum));
            return View(model);
        }

        //
        // POST: /City/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CityDto input)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    _cityService.UpdateByID(input, id);
                    return RedirectToAction("List");
                }
                return View("edit", input);
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /City/Delete/5
        public ActionResult Delete(int id)
        {
            _cityService.Delete(id);
            return RedirectToAction("List");
        }

        //
        // POST: /City/Delete/5
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
