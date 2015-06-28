using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyLife.Web.Controllers
{
    public class MemberController : Controller
    {
        private readonly IMemberService _memberService;
        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }
        //
        // GET: /Member/
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Member/List/5
        public ActionResult List(int id, int? pageNumber, int? pageSize)
        {
            pageNumber = pageNumber ?? 1;
            pageSize = pageSize ?? 2;
            var model = _memberService.GetMembersByMerchantID(id, pageNumber.Value, pageNumber.Value);
            ViewBag.MerchantID = id;
            return View(model);
        }

        //
        // GET: /Member/Details/5
        public ActionResult Details(int id)
        {
            var model = _memberService.GetMemberByID(id);
            return View(model);
        }

        //
        // GET: /Member/Create
        public ActionResult Create(int id)
        {
            ViewData["merchant_id"] = id;
            return View("Index");
        }

        //
        // POST: /Member/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                var member = new MemberInfo
                {
                    member_name = collection["member_name"],
                    member_sex = collection["member_sex"],
                    member_birthday = collection["member_birthday"],
                    member_phone = collection["member_phone"],
                    member_address = collection["member_address"],
                    merchant_id = collection["merchant_id"].ToInt()
                };
                _memberService.CreateMember(member);
                return RedirectToAction("List",member.merchant_id);
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
            var model = _memberService.GetMemberByID (id);
            ViewData["merchant_id"] = model.merchant_id;
            return View(model);
        }

        //
        // POST: /Member/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                var member = new MemberInfo
                {
                    member_name = collection["member_name"],
                    member_sex = collection["member_sex"],
                    member_birthday = collection["member_birthday"],
                    member_phone = collection["member_phone"],
                    member_address = collection["member_address"],
                    merchant_id = collection["merchant_id"].ToInt()
                };
                _memberService.UpdateMemberById(member,id);
                return RedirectToAction("List", member.merchant_id);
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
