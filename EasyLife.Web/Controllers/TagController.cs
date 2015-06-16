using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyLife.Web.Controllers
{
    public class TagController : Controller
    {
        //
        // GET: /Tag/
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Tag/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Tag/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Tag/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Tag/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Tag/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Tag/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Tag/Delete/5
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
