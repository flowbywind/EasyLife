using System;
using System.Collections.Generic;

using System.Web.Mvc;

namespace EasyLife.AppApi.Controllers
{
    public class ProductController : Controller
    {
        // GET api/product
        public ActionResult Get()
        {
            Product product = new Product() {
                Name = "1",
                Price = 1,
                Description = "dess"
            };
            return Json(new List<Product>(){product},JsonRequestBehavior.AllowGet);
        }


        public ActionResult GetProduct(int id)
        {
            Product product = new Product() {
                Name = "1",
                Price = 1,
                Description = "dess"
            };
            return Json(product,JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [HttpPost]
        public Product Post(string name, double price, string description)
        {
            Product product = new Product() {
                Name = name,
                Price = price,
                Description = description
            };
            return product;
        }


        public ActionResult AddProduct(int id,string name, double price, string description)
        {
            Product foundProduct = new Product();
            if (foundProduct != null)
            {
                foundProduct.Name = name;
                foundProduct.Price = price;
                foundProduct.Description = description;
            }
            return Json(foundProduct,JsonRequestBehavior.AllowGet);
        }

       
        // DELETE api/product/5
        public void Delete(int id)
        {
        }

       
    }
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}
