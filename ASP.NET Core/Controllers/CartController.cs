using Microsoft.AspNetCore.Mvc;
using NashSneaker.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NashSneaker.Controllers
{
    public class CartController : Controller
    {
        private NashSneakerContext _context;

        public CartController(NashSneakerContext context)
        {
            _context = context;
        }

        public IActionResult Index(string userId)
        {
            var user = _context.Users.SingleOrDefault(user => user.Id == userId);
            var product = _context.Product.ToList();
            var image = _context.Image.ToList();
            var cart = _context.Cart.SingleOrDefault(cart => cart.User == user);
            var cartDetailList = _context.CartDetail.Where(detail => detail.Cart.User == user).ToList();

            return View(cart);
        }

        public JsonResult AddItemToCart(string userId, int productId, int quantity)
        {
            var user = _context.Users.SingleOrDefault(x => x.Id == userId);
            var product = _context.Product.SingleOrDefault(x => x.Id == productId);

            if (_context.Cart.Any(cart => cart.User == user))
            {
                var cart = _context.Cart.SingleOrDefault(x => x.User == user);

                if(_context.CartDetail.Any(detail => detail.Cart == cart && detail.Product == product))
                {
                    var cartDetail = _context.CartDetail.SingleOrDefault(detail => detail.Cart == cart && detail.Product == product);
                    
                    cartDetail.Quantity += quantity;
                }
                else
                {
                    var cartDetail = new CartDetail
                    {
                        Product = product,
                        Cart = cart,
                        Quantity = quantity
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
                    Quantity = quantity
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

            _context.SaveChanges();

            return Json(new { Success = true, cartCounter = counter });
        }
    }
}
