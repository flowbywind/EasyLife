using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EasyLife.API.Controllers
{
    public class ProductController : ApiController
    {
        // GET api/product
        public IEnumerable<Product> Get()
        {
            Product product = new Product() {
                Name = "1",
                Price = 1,
                Description = "dess"
            };
            return new List<Product>(){product};
        }

        public Product Get(int id)
        {
            Product product = new Product() {
                Name = "1",
                Price = 1,
                Description = "dess"
            };
            return product;
        }
 

        public Product Post(string name, double price, string description)
        {
            Product product = new Product() {
                Name = name,
                Price = price,
                Description = description
            };
            return product;
        }

        [HttpGet]
        [HttpPost]
        [Route("Product/AddProduct")]
        public Product AddProduct(int id,string name, double price, string description)
        {
            Product foundProduct = new Product();
            if (foundProduct != null)
            {
                foundProduct.Name = name;
                foundProduct.Price = price;
                foundProduct.Description = description;
            }
            return foundProduct;
        }

        // PUT api/product/5
        public void Put(int id, [FromBody]string value)
        {
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
