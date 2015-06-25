using System.Web.Mvc;

namespace EasyLife.Web.Controllers
{
    public class TagController : Controller
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
        public ActionResult List(int id, int? pageNumber, int? pageSize)
        {
            pageNumber = pageNumber ?? 1;
            pageSize = pageSize ?? 2;
            var model = _tagService.GetTagsByMerchantID(id, pageNumber.Value, pageNumber.Value);
            ViewBag.MerchantID = id;
            return View(model);
        }

        //
        // GET: /Tag/Details/5
        public ActionResult Details(int id)
        {
            var model = _tagService.GetTagByID(id);
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
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                var tag = new TagInfo
                {
                    tag_name = collection["tag_name"],
                    tag_code = collection["tag_code"],
                    merchant_id = collection["merchant_id"].ToInt()
                };
                _tagService.CreateTag(tag);
                return RedirectToAction("List", tag.merchant_id);
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
            var model = _tagService.GetTagByID(id);
            return View(model);
        }

        //
        // POST: /Tag/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                var tag = new TagInfo
                {
                    tag_name = collection["tag_name"],
                    tag_code = collection["tag_code"],
                    merchant_id = collection["merchant_id"].ToInt()
                };
                _tagService.UpdateTagById(tag, id);
                return RedirectToAction("List");
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
