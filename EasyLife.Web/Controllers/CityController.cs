using EasyLife.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyLife.Web.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class CityController : Controller
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
            return View();
        }

        //
        // GET: /City/List
        public ActionResult List()
        {
            var model = _cityService.GetCitys();
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
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                var city = new CityDto
                {
                    city_name = collection["city_name"],
                    pin_yin = collection["pin_yin"],
                    //first_char = collection["first_char"]
                };
                _cityService.Create(city);
                return RedirectToAction("List");
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
            return View(model);
        }

        //
        // POST: /City/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                CityDto input = new CityDto
                {
                    city_name = collection["city_name"],
                    pin_yin = collection["pin_yin"],
                    //first_char = collection["first_char"]
                };
                _cityService.UpdateByID(input, id);
                return RedirectToAction("List");
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
