using Microsoft.AspNetCore.Mvc;
using NashSneaker.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NashSneaker.Controllers
{
    public class ShoppingController : Controller
    {
        private NashSneakerContext _context;

        public ShoppingController(NashSneakerContext context)
        {
            _context = context;
        }

        public IActionResult Index(string categoryName)
        {
            if(categoryName == "All Shoes")
            {
                var productList = _context.Product.ToList();
                var imageList = _context.Image;
                foreach (var item in productList)
                {
                    item.Images = imageList.Where(image => image.Product.Id == item.Id).ToList();
                    item.Category = new Category() { Name = categoryName };
                }

                return View(productList);
            }
            else
            {
                var productList = _context.Product.Where(product => product.Category.Name == categoryName).ToList();
                var imageList = _context.Image;
                var categoryList = _context.Category.ToList();

                if(productList.Count() > 0)
                {
                    foreach (var item in productList)
                    {
                        item.Images = imageList.Where(image => image.Product.Id == item.Id).ToList();
                        item.Category = categoryList.Where(category => category == item.Category).SingleOrDefault();
                    }
                }
                else
                {
                    productList = new List<Product>();
                    productList.Add(new Product());
                    productList.ElementAt(0).Category = new Category() { Name = categoryName };
                }
                
                return View(productList);
            }
        }

        public IActionResult Detail(int id, string productName)
        {
            if (productName != null && id != 0)
            {
                var product = _context.Product.Where(product => product.Id == id && product.Name == productName).SingleOrDefault();
                var imageList = _context.Image;
                var category = _context.Category.ToList();

                product.Images = imageList.Where(image => image.Product.Id == product.Id).ToList();
                product.Category = category.Where(category => category.Id == product.Category.Id).SingleOrDefault();

                return View(product);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
