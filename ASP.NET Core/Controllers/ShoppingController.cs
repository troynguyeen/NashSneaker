using Microsoft.AspNetCore.Mvc;
using NashSneaker.Areas.Identity.Data;
using NashSneaker.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NashSneaker.Controllers
{
    public class ShoppingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
