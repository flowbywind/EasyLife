using EasyLife.Application;
using System.Web.Mvc;

namespace EasyLife.Web.Controllers
{
    public class TagController : EasyLifeControllerBase
    {
        private readonly ITagService _tagService;

        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }
        //
        // GET: /Tag/
        public ActionResult Index()
        {

            return View();
        }

        //
        // GET: /Category/List/5
        public ActionResult AllList(int id)
        {
            var model = _tagService.GetTagsByMerchantID(id);
            ViewBag.MerchantID = id;
            return View(model);
        }
        //
        // GET: /Category/List/5
        public ActionResult List(int id, int? pageNumber, int? pageSize)
        {
            pageNumber = pageNumber ?? 1;
            pageSize = pageSize ?? ConfigHelper.PageSize;
            var model = _tagService.GetTagsByMerchantID(id, pageNumber.Value, pageSize.Value);
            ViewBag.MerchantID = id;
            return View(model);
        }

        //
        // GET: /Tag/Details/5
        public ActionResult Details(int id)
        {
            var model = _tagService.GetByID(id);
            return View(model);
        }

        //
        // GET: /Tag/Create
        public ActionResult Create(int id)
        {
            ViewData["merchant_id"] = id;
            return View("Index");
        }

        //
        // POST: /Tag/Create
        [HttpPost]
        public ActionResult Create(TagDto input)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    _tagService.Create(input);
                    return RedirectToAction("List", new { id = input.merchant_id });
                }
                ViewData["merchant_id"] = input.Id;
                return View("Index", input);
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
            var model = _tagService.GetByID(id);
            ViewData["merchant_id"] = model.merchant_id;
            return View(model);
        }

        //
        // POST: /Tag/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, TagDto input)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    _tagService.UpdateById(input, id);
                    return RedirectToAction("List", new { id=input.merchant_id});
                }
                ViewData["merchant_id"] = input.merchant_id;
                return View("edit", input);
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
                _tagService.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
