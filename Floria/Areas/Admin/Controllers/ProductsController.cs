using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Data;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Floria.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _context.Products.Where(n => !n.IsDeleted)
                                              .Include(n => n.Image)
                                              .Include(n => n.Category)
                                              .OrderByDescending(n=>n.CreatedDate)
                                              .ToListAsync();
            return View(data);
        }
        public async Task<IActionResult> Details(int? id)
        {
            if(id is null)
            {
                throw new ArgumentNullException("Id");
            }
            var data = await _context.Products.Where(n => n.Id == id)
                                              .Include(n => n.Image)
                                              .Include(n => n.Category)
                                              .FirstOrDefaultAsync();

            if(data is null)
            {
                throw new NullReferenceException("Data Could Not Be Found!");
            }
            return View(data);
        }



        public async Task<IActionResult> Create()
        {
            var categories = await _context.Categories.Where(n => !n.IsDeleted).ToListAsync();
            ViewData["categories"] = categories;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create( Product product)
        {
            product.CreatedDate = DateTime.Now;

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
     
     
    }
}

