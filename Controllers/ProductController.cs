using ASPTask6.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPTask6.Controllers
{
    public class ProductController : Controller
    {
        public static List<Product> Products = new()
        {
            new Product {Id = 1,Name = "Iphone",Description = "Iphone 11 XS MAX",Price = 3000,ImageUrl = "https://www.mgstore.az/image/cache/catalog/productimage/Apple%20iPhone%2011%2064GB%20White-400x400.jpg"},
            new Product {Id = 2,Name = "Samsung",Description = "Galaxy S21 Ultra",Price = 4000,ImageUrl = "https://www.mgstore.az/image/cache/catalog/productimage/Apple%20iPhone%2011%2064GB%20White-400x400.jpg"},
            new Product {Id = 3,Name = "Xiaomi",Description = "Note 9 s",Price = 3000,ImageUrl = "https://www.mgstore.az/image/cache/catalog/productimage/Apple%20iPhone%2011%2064GB%20White-400x400.jpg"},
            new Product {Id = 4,Name = "Samsung",Description = "J 5",Price = 500,ImageUrl = "https://www.mgstore.az/image/cache/catalog/productimage/Apple%20iPhone%2011%2064GB%20White-400x400.jpg"},

        };

        public IActionResult Index()
        {
            return View(Products);
        }

        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Product newProduct)
        {
            if(newProduct.Name is not null && newProduct.Price > 0)
            {
                newProduct.Id = Products.Count + 1;
                Products.Add(newProduct);
               

            }
            return RedirectToAction("Index");
        }
         
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var prod = Products.FirstOrDefault(p => p.Id == id);
            Products.Remove(prod);
            
            return RedirectToAction("Index");
        }

        public IActionResult EditProduct(int id)
        {
            var prod = Products.Find(p => p.Id == id);
            
         
            return View(prod);
        }

        [HttpPost]
        public IActionResult Edit(Product uPr)
        {
                var pr = Products.FindIndex(p => p.Id == uPr.Id);
                Products[pr] = uPr;
                return RedirectToAction("Index");
            
           
            return View(uPr);
        }
    }
}
