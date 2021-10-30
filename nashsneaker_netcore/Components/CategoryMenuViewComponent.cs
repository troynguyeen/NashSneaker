using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NashSneaker.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NashSneaker.Views.Shared.Component
{
    public class CategoryMenuViewComponent : ViewComponent
    {
        private NashSneakerContext _context;

        public CategoryMenuViewComponent(NashSneakerContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categoryList = await _context.Category.ToListAsync();

            return View(categoryList);
        }
    }
}
