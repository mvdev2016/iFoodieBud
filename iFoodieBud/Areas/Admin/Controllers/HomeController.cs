using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iFoodieBud.Infrastructure;
using iFoodieBud.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace iFoodieBud.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly DbContextiFoodieBud _context;
        public HomeController(DbContextiFoodieBud context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Dish dish)
        {
            if (ModelState.IsValid)
            {
                dish.Slug = dish.Slug
                    .TrimEnd()
                    .TrimStart()
                    .Replace(" ", "");
                var slug = _context.Dishes.FirstOrDefaultAsync(s => s.Slug == dish.Slug);
                if (slug != null)
                {
                    ModelState.AddModelError("", "The Dish Name Already Exist!");
                    return View(dish);
                }

                _context.Add(dish);
                await _context.SaveChangesAsync();
                return RedirectToAction("Create");

            }
            return View(dish);
        }



      [HttpGet]
        public async Task<IActionResult> Create() {
            return View();
        }

       

        public async Task<IActionResult> Details(int id) {
            Dish dish = await _context.Dishes
                    .FirstOrDefaultAsync(d => d.DishId == id);
            if (dish == null)
            {
                return NotFound();
            }

            return View(dish);
        }

      


    }
}