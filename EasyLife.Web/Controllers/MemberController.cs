﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyLife.Web.Controllers
{
    public class MemberController : Controller
    {
        //
        // GET: /Member/
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Member/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Member/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Member/Create
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
        // GET: /Member/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Member/Edit/5
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
        // GET: /Member/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Member/Delete/5
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
