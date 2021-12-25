using Microsoft.AspNetCore.Mvc;
using NashSneaker.BlobServices;
using NashSneaker.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NashSneaker.Controllers
{
    public class ShoppingController : Controller
    {
        private readonly NashSneakerContext _context;
        private readonly IBlobService _blobService;

        public ShoppingController(NashSneakerContext context, IBlobService blobService)
        {
            _context = context;
            _blobService = blobService;
        }

        public async Task<IActionResult> Index(string categoryName)
        {
            if(categoryName == "All Shoes")
            {
                var productList = _context.Product.ToList();
                var imageList = _context.Image.ToList();

                // This for getting images from Azure Blob Storage
                foreach (var item in imageList)
                {
                    //item.Path = await _blobService.GetBlob(item.Path, "images");
                    // For localhost
                    item.Path = "/images/products/" + item.Path;
                }

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

                // This for getting images from Azure Blob Storage
                foreach (var item in imageList)
                {
                    //item.Path = await _blobService.GetBlob(item.Path, "images");
                    // For localhost
                    item.Path = "/images/products/" + item.Path;
                }

                if (productList.Count() > 0)
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

        public async Task<IActionResult> Detail(int id)
        {
            if (id != 0)
            {
                var product = _context.Product.Where(product => product.Id == id).SingleOrDefault();
                var imageList = _context.Image;
                var ratingList = _context.Rating;
                var sizeList = _context.Size;
                var category = _context.Category.ToList();

                // This for getting images from Azure Blob Storage
                foreach (var item in imageList)
                {
                    //item.Path = await _blobService.GetBlob(item.Path, "images");
                    // For localhost
                    item.Path = "/images/products/" + item.Path;
                }

                product.Ratings = ratingList.Where(rating => rating.Product.Id == product.Id).ToList();
                product.Images = imageList.Where(image => image.Product.Id == product.Id).ToList();
                product.Sizes = sizeList.Where(size => size.Product.Id == product.Id).OrderBy(x => x.Name).ToList();
                product.Category = category.Where(category => category.Id == product.Category.Id).SingleOrDefault();

                return View(product);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public void Rating(string userId, int productId, int level)
        {
            var user = _context.Users.SingleOrDefault(x => x.Id == userId);
            var product = _context.Product.SingleOrDefault(x => x.Id == productId);

            if(_context.Rating.Any(rating => rating.User == user && rating.Product == product))
            {
                var rating = _context.Rating.SingleOrDefault(x => x.User == user && x.Product == product);
                rating.Level = level;
            }
            else
            {
                var rating = new Rating
                {
                    User = user,
                    Product = product,
                    Level = level
                };

                _context.Rating.Add(rating);
            }

            _context.SaveChanges();
        }

        public async Task<IActionResult> Search(string keyword)
        {
            var productList = _context.Product.Where(x => x.Name.Contains(keyword) || keyword == null).ToList();
            var imageList = _context.Image;

            // This for getting images from Azure Blob Storage
            foreach (var item in imageList)
            {
                //item.Path = await _blobService.GetBlob(item.Path, "images");
                // For localhost
                item.Path = "/images/products/" + item.Path;
            }

            if (productList.Count() == 0)
            {
                productList = new List<Product>();
                productList.Add(new Product());
                productList.ElementAt(0).Category = new Category() { Name = "results for \"" + keyword + "\"" };

                return View(productList);
            }
            else
            {
                foreach (var item in productList)
                {
                    item.Images = imageList.Where(image => image.Product.Id == item.Id).ToList();
                    item.Category = new Category() { Name = "results for \"" + keyword + "\"" };
                }

                return View(productList);
            } 
        }
    }
}
