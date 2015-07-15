using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EasyLife.Core.Enum;
using EasyLife.Application;

namespace EasyLife.Web.Controllers
{
    public class MemberController : EasyLifeControllerBase
    {
        private readonly IMemberService _memberService;
        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }
        //
        // GET: /Member/
        public ActionResult Index(int id)
        {
            ViewData["sex"] = EnumExt.GetSelectList(typeof(SexEnum));
            ViewData["status"] = EnumExt.GetSelectList(typeof(StatusEnum));
            ViewData["merchant_id"] = id;
            return View();
        }

        //
        // GET: /Member/List/5
        public ActionResult List(int id, int? pageNumber, int? pageSize)
        {
            pageNumber = pageNumber ?? 1;
            pageSize = pageSize ?? 2;
            var model = _memberService.GetByMerchantID(id, pageNumber.Value, pageNumber.Value);
            ViewBag.MerchantID = id;
            return View(model);
        }

        //
        // GET: /Member/Details/5
        public ActionResult Details(int id)
        {
            var model = _memberService.GetByID(id);
            ViewData["merchant_id"] = model.merchant_id;
            ViewData["sex"] = EnumExt.GetSelectList(typeof(SexEnum));
            ViewData["status"] = EnumExt.GetSelectList(typeof(StatusEnum));
            return View(model);
        }

        //
        // GET: /Member/Create
        public ActionResult Create(int id)
        {
            ViewData["merchant_id"] = id;
            ViewData["sex"] = EnumExt.GetSelectList(typeof(SexEnum));
            ViewData["status"] = EnumExt.GetSelectList(typeof(StatusEnum));
            return View("Index");
        }

        //
        // POST: /Member/Create
        [HttpPost]
        public ActionResult Create(MemberDto input)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    _memberService.Create(input);
                    return RedirectToAction("List", new { id = input.merchant_id });
                }
                ViewData["merchant_id"] = input.merchant_id;
                ViewData["sex"] = EnumExt.GetSelectList(typeof(SexEnum));
                ViewData["status"] = EnumExt.GetSelectList(typeof(StatusEnum));
                return View("index", input);

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
            var model = _memberService.GetByID(id);
            ViewData["merchant_id"] = model.merchant_id;
            ViewData["sex"] = EnumExt.GetSelectList(typeof(SexEnum));
            ViewData["status"] = EnumExt.GetSelectList(typeof(StatusEnum));
            return View(model);
        }

        //
        // POST: /Member/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, MemberDto input)
        {
            try
            {
                // TODO: Add update logic here

                _memberService.UpdateById(input, id);
                return RedirectToAction("List", input.merchant_id);
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
