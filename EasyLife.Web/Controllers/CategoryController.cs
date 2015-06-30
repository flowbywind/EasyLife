using EasyLife.Application.Category.Dtos;
using System.Web.Mvc;

namespace EasyLife.Web.Controllers
{
    public class CategoryController : Controller
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
            return View();
        }

        //
        // GET: /Category/List
        public ActionResult List(int? pageNumber, int? pageSize)
        {
            pageNumber = pageNumber ?? 1;
            pageSize = pageSize ?? 2;
            var model = _categoryService.GetCategorys(pageNumber.Value,pageSize.Value);
            return View(model);
        }

        //
        // GET: /Category/Details/5
        public ActionResult Details(int id)
        {
            var model = _categoryService.GetCategoryByID(id);
            return View(model);
        }

        //
        // GET: /Category/Create
        public ActionResult Create()
        {
            return View("Index");
        }

        //
        // POST: /Category/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                var category = new CategoryDto
                {
                    cat_name = collection["cat_name"],
                    cat_code = collection["cat_code"]
                };
                _categoryService.CreateCategory(category);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Category/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _categoryService.GetCategoryByID(id);
            return View(model);
        }

        //
        // POST: /Category/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                CategoryDto input = new CategoryDto
                {
                    cat_name = collection["cat_name"],
                    cat_code = collection["cat_code"]
                };
                _categoryService.UpdateCategoryByID(input, id);
                return RedirectToAction("List");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Category/Delete/5
        public ActionResult Delete(int id)
        {
            _categoryService.DeleteCategory(id);
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
