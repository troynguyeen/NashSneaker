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
    public class OrderingController : Controller
    {
        private readonly NashSneakerContext _context;
        private readonly IBlobService _blobService;

        public OrderingController(NashSneakerContext context, IBlobService blobService)
        {
            _context = context;
            _blobService = blobService;
        }
        public async Task<IActionResult> Index(string userId)
        {
            int counter = 0;
            var user = _context.Users.SingleOrDefault(user => user.Id == userId);
            var product = _context.Product.ToList();
            var images = _context.Image.ToList();
            var sizes = _context.Size.ToList();
            var cart = _context.Cart.SingleOrDefault(cart => cart.User == user);
            var cartDetailList = _context.CartDetail.Where(detail => detail.Cart.User == user).ToList();

            // This for getting images from Azure Blob Storage
            foreach (var item in images)
            {
                item.Path = await _blobService.GetBlob(item.Path, "images");
            }

            foreach (var item in cartDetailList)
            {
                counter += item.Quantity;
            }

            HttpContext.Session.SetInt32("CartCounter", counter);

            return View(cart);
        }

        public JsonResult PlaceOrder(string userId, string RecipientName, string PhoneNumber, string Address, int totalAmount, int shippingFee, string status, string PaymentMethod)
        {
            var user = _context.Users.SingleOrDefault(x => x.Id == userId);
            var product = _context.Product.ToList();
            var cart = _context.Cart.SingleOrDefault(x => x.User == user);
            var cartDetails = _context.CartDetail.Where(x => x.Cart.User == user).ToList();

            Order order = new Order
            {
                User = user,
                RecipientName = RecipientName,
                PhoneNumber = PhoneNumber,
                Address = Address,
                TotalAmount = totalAmount,
                ShippingFee = shippingFee,
                Status = status,
                PaymentMethod = PaymentMethod,
                CreatedDate = DateTime.Now
            };

            _context.Add(order);
            _context.SaveChanges();

            List<OrderDetail> orderDetails = new List<OrderDetail>();

            foreach(var item in cartDetails) {
                OrderDetail orderDetail = new OrderDetail
                {
                    Quantity = item.Quantity,
                    Size = item.Size,
                    Product = item.Product,
                    Order = order
                };

                _context.Add(orderDetail);
                //Delete cart detail at each loop
                _context.Remove(item);
                _context.SaveChanges();
                orderDetails.Add(orderDetail);
            }

            HttpContext.Session.SetInt32("CartCounter", 0);

            //Delete cart when finished order
            _context.Remove(cart);
            _context.SaveChanges();

            return Json(new { success = true });
        }
    }
}
