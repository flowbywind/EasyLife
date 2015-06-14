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

        public MerchantController(IMerchantService merchantService)
        {
            _merchantService = merchantService;
        }

        //
        // GET: /Merchant/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            var model = _merchantService.GetMerchants();
            return View(model);
        }

        //
        // GET: /Merchant/Details/5
        public ActionResult Details(int id)
        {
            var model = _merchantService.GetMerchantID(id);
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
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                var merchant = new CreateMerchantInput
                {
                    merchant_name = collection["merchant_name"],
                    bank = collection["bank"],
                    account = collection["account"],
                    city_id = Convert.ToInt32(collection["city_id"]),
                    cat_id = Convert.ToInt32(collection["cat_id"]),
                    contact_name = collection["contact_name"],
                    phone = collection["phone"],
                    email = collection["email"],
                    status = (Status)Convert.ToInt32(collection["status"])
                };
                _merchantService.CreateMerchant(merchant);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Merchant/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _merchantService.GetMerchantID(id);
            return View(model);
        }

        //
        // POST: /Merchant/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                // TODO: Add insert logic here
                var merchant = new CreateMerchantInput
                {
                    merchant_name = collection["merchant_name"],
                    bank = collection["bank"],
                    account = collection["account"],
                    city_id = Convert.ToInt32(collection["city_id"]),
                    cat_id = Convert.ToInt32(collection["cat_id"]),
                    contact_name = collection["contact_name"],
                    phone = collection["phone"],
                    email = collection["email"],
                    status = (Status)Convert.ToInt32(collection["status"])
                };
                _merchantService.UpdateMerchant(merchant, id);
                return RedirectToAction("list");
            }
            catch
            {
                return View();
            }
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
