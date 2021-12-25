using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NashSneaker.BlobServices;
using NashSneaker.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NashSneaker.Controllers
{
    public class CartController : Controller
    {
        private readonly NashSneakerContext _context;
        private readonly IBlobService _blobService;

        public CartController(NashSneakerContext context, IBlobService blobService)
        {
            _context = context;
            _blobService = blobService;
        }

        public async Task<IActionResult> Index(string userId)
        {
            int counter = 0;
            var user = _context.Users.SingleOrDefault(user => user.Id == userId);
            var product = _context.Product.ToList();
            var image = _context.Image.ToList();
            var cart = _context.Cart.SingleOrDefault(cart => cart.User == user);
            var cartDetailList = _context.CartDetail.Where(detail => detail.Cart.User == user).ToList();

            // This for getting images from Azure Blob Storage
            foreach (var item in image)
            {
                //item.Path = await _blobService.GetBlob(item.Path, "images");
                // For localhost
                item.Path = "/images/products/" + item.Path;
            }

            foreach (var item in cartDetailList)
            {
                counter += item.Quantity;
            }

            HttpContext.Session.SetInt32("CartCounter", counter);

            return View(cart);
        }

        public JsonResult AddItemToCart(string userId, int productId, int quantity, int size)
        {
            string message = "";
            var user = _context.Users.SingleOrDefault(x => x.Id == userId);
            var product = _context.Product.SingleOrDefault(x => x.Id == productId);

            if (_context.Cart.Any(cart => cart.User == user))
            {
                var cart = _context.Cart.SingleOrDefault(x => x.User == user);

                if(_context.CartDetail.Any(detail => detail.Cart == cart && detail.Product == product && detail.Size == size))
                {
                    var cartDetail = _context.CartDetail.SingleOrDefault(detail => detail.Cart == cart && detail.Product == product && detail.Size == size);

                    cartDetail.Quantity += quantity;

                    if (cartDetail.Quantity > 10)
                    {
                        cartDetail.Quantity = 10;
                        message = "Chỉ có thể mua tối đa mỗi loại 10 sản phẩm!";
                    }
                    
                }
                else
                {
                    var cartDetail = new CartDetail
                    {
                        Product = product,
                        Cart = cart,
                        Quantity = quantity,
                        Size = size
                    };

                    _context.CartDetail.Add(cartDetail);
                    _context.SaveChanges();
                }
            }
            else
            {
                var cart = new Cart
                {
                    User = user
                };

                var cartDetail = new CartDetail
                {
                    Product = product,
                    Cart = cart,
                    Quantity = quantity,
                    Size = size
                };

                cart.TotalAmount = (int) cartDetail.Product.Price * cartDetail.Quantity;

                _context.Cart.Add(cart);
                _context.CartDetail.Add(cartDetail);
                _context.SaveChanges();
            }

            //update cart counter
            int counter = 0;
            //update totalAmount
            int totalAmount = 0;

            var _cart = _context.Cart.SingleOrDefault(cart => cart.User == user);
            var _product = _context.Product.ToList();
            var cartDetailList = _context.CartDetail.Where(detail => detail.Cart.User == user).ToList();
            
            foreach(var item in cartDetailList)
            {
                counter += item.Quantity;
                totalAmount += (int) item.Product.Price * item.Quantity;
            }

            _cart.TotalAmount = totalAmount;

            HttpContext.Session.SetInt32("CartCounter", counter);

            _context.SaveChanges();

            return Json(new { success = true, cartCounter = counter, message = message });
        }

        public JsonResult UpdateItemInCart(string userId, int productId, int quantity, int size)
        {
            var user = _context.Users.SingleOrDefault(x => x.Id == userId);
            var product = _context.Product.SingleOrDefault(x => x.Id == productId);
            var cart = _context.Cart.SingleOrDefault(x => x.User == user);
            var cartDetail = _context.CartDetail.SingleOrDefault(x => x.Cart.User == user && x.Product == product && x.Size == size);
                
            cartDetail.Quantity = quantity;
            
            //update cart counter
            int counter = 0;
            //update totalAmount
            int totalAmount = 0;

            var _cart = _context.Cart.SingleOrDefault(cart => cart.User == user);
            var _product = _context.Product.ToList();
            var cartDetailList = _context.CartDetail.Where(detail => detail.Cart.User == user).ToList();

            foreach (var item in cartDetailList)
            {
                counter += item.Quantity;
                totalAmount += (int)item.Product.Price * item.Quantity;
            }

            _cart.TotalAmount = totalAmount;

            HttpContext.Session.SetInt32("CartCounter", counter);

            _context.SaveChanges();

            return Json(new { success = true, cartCounter = counter, totalAmount = totalAmount });
        }

        public JsonResult DeleteItemFromCart(string userId, int productId, int size)
        {
            int counter = 0;
            int totalAmount = 0;
            var user = _context.Users.SingleOrDefault(x => x.Id == userId);
            var product = _context.Product.SingleOrDefault(x => x.Id == productId);
            var cart = _context.Cart.SingleOrDefault(x => x.User == user);
            var cartDetail = _context.CartDetail.SingleOrDefault(x => x.Cart.User == user && x.Product == product && x.Size == size);

            var cartDetailList = _context.CartDetail.Where(x => x.Cart.User == user).ToList();

            if(cartDetailList.Count() > 1)
            {
                _context.CartDetail.Remove(cartDetail);
                _context.SaveChanges();

                var _cart = _context.Cart.SingleOrDefault(cart => cart.User == user);
                var _product = _context.Product.ToList();
                var _cartDetailList = _context.CartDetail.Where(x => x.Cart.User == user).ToList();

                foreach (var item in _cartDetailList)
                {
                    counter += item.Quantity;
                    totalAmount += (int)item.Product.Price * item.Quantity;
                }

                _cart.TotalAmount = totalAmount;
            }
            else
            {
                _context.CartDetail.Remove(cartDetail);
                _context.Cart.Remove(cart);
                _context.SaveChanges();
            }

            HttpContext.Session.SetInt32("CartCounter", counter);

            _context.SaveChanges();

            return Json(new { success = true, cartCounter = counter, totalAmount = totalAmount });
        }
    }
}
