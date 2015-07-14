using EasyLife.Application;
using EasyLife.Core.Enum;
using System.Web.Mvc;

namespace EasyLife.Web.Controllers
{
    public class CategoryController : EasyLifeControllerBase
    {

        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        //
        // GET: /Category/
        public ActionResult Index()
        {
            ViewData["status"] = EnumExt.GetSelectList(typeof(StatusEnum));
            return View();
        }

        //
        // GET: /Category/List
        public ActionResult List(int? pageNumber, int? pageSize)
        {
            pageNumber = pageNumber ?? 1;
            pageSize = pageSize ?? ConfigHelper.PageSize;
            var model = _categoryService.GetList(pageNumber.Value, pageSize.Value);
            return View(model);
        }

        //
        // GET: /Category/Details/5
        public ActionResult Details(int id)
        {
            var model = _categoryService.GetByID(id);
            return View(model);
        }

        //
        // GET: /Category/Create
        public ActionResult Create()
        {
            return RedirectToAction("Index");
        }

        //
        // POST: /Category/Create
        [HttpPost]
        public ActionResult Create(CategoryDto input)
        {

            // TODO: Add insert logic here
            if (ModelState.IsValid)
            {
                _categoryService.Create(input);
                return RedirectToAction("List");
            }
            ViewData["status"] = EnumExt.GetSelectList(typeof(StatusEnum));
            return RedirectToAction("Index", input);

        }

        //
        // GET: /Category/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _categoryService.GetByID(id);
            ViewData["status"] = EnumExt.GetSelectList(typeof(StatusEnum));
            return View(model);
        }

        //
        // POST: /Category/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CategoryDto input)
        {

            // TODO: Add update logic here
            _categoryService.UpdateByID(input, id);
            return RedirectToAction("List");
        }

        //
        // GET: /Category/Delete/5
        public ActionResult Delete(int id)
        {
            _categoryService.Delete(id);
            return RedirectToAction("List");
        }

        //
        // POST: /Category/Delete/5
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
