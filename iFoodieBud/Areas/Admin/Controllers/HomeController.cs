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
            this._context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Dish dish)
        {
            if (ModelState.IsValid)
            {
                
            }
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