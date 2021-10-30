using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NashSneaker.Data;
using NashSneaker.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace NashSneaker.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<User> _userManager;
        private NashSneakerContext _context;

        public HomeController(ILogger<HomeController> logger, UserManager<User> userManager, NashSneakerContext context)
        {
            _logger = logger;
            _userManager = userManager;
            _context = context;
        }

        public IActionResult Index()
        {
            int counter = 0;
            var userId = _userManager.GetUserId(User);
            var _cart = _context.Cart.SingleOrDefault(cart => cart.User.Id == userId);
            var _product = _context.Product.ToList();
            var cartDetailList = _context.CartDetail.Where(detail => detail.Cart.User.Id == userId).ToList();

            foreach (var item in cartDetailList)
            {
                counter += item.Quantity;
            }

            HttpContext.Session.SetInt32("CartCounter", counter);

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
