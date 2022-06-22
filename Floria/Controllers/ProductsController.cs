using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Floria.Controllers
{
    public class ProductsController : Controller
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            var data = await _context.Products.Where(n => !n.IsDeleted)
                                             .OrderByDescending(n=>n.CreatedDate)
                                             .Take(8)
                                             .Include(n => n.Image)
                                             .ToListAsync();
            return View(data);
        }

        public async Task<IActionResult> LoadMore()
        {
            var data = await _context.Products.Where(n => !n.IsDeleted)
                                             .OrderByDescending(n => n.CreatedDate)
                                             .Skip(8)
                                             .Take(8)
                                             .Include(n => n.Image)
                                             .ToListAsync();
            return Json(data);
        }

    }
}

