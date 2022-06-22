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
                                             .Take(8)
                                             .OrderBy(n=>n.CreatedDate)
                                             .Include(n => n.Image)
                                             .ToListAsync();
            return View(data);
        }
    }
}

