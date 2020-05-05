using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using iFoodieBud.Infrastructure;
using iFoodieBud.Models;

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

        // GET: Admin/Home
        public async Task<IActionResult> Index()
        {
            var dbContextiFoodieBud = _context.Dishes.Include(d => d.DietLabel).Include(d => d.HealthLabel);
            return View(await dbContextiFoodieBud.ToListAsync());
        }

        // GET: Admin/Home/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dish = await _context.Dishes
                .Include(d => d.DietLabel)
                .Include(d => d.HealthLabel)
                .FirstOrDefaultAsync(m => m.DishId == id);
            if (dish == null)
            {
                return NotFound();
            }

            return View(dish);
        }

        // GET: Admin/Home/Create
        public async Task<IActionResult> Create()
        {

            List<DietLabel> dietLabels = await  _context
                 .DietLabels
                 .OrderBy(d => d.Name).ToListAsync() ;

            List<HealthLabel> healthLabels = await _context
                 .HealthLabels
                 .OrderBy(d => d.Name)
                 .ToListAsync();



            ViewData["DietLabelId"] = new SelectList(dietLabels, "DietLabelId", "Name");
            ViewData["HealthLabelId"] = new SelectList(healthLabels, "HealthLabelId", "Name");
            return View();
        }

        // POST: Admin/Home/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DishId,Name,Description,Slug,Image,Calories,DietLabelId,HealthLabelId")] Dish dish)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dish);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DietLabelId"] = new SelectList(_context.DietLabels, "DietLabelId", "DietLabelId", dish.DietLabelId);
            ViewData["HealthLabelId"] = new SelectList(_context.HealthLabels, "HealthLabelId", "HealthLabelId", dish.HealthLabelId);
            return View(dish);
        }

        // GET: Admin/Home/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dish = await _context.Dishes.FindAsync(id);
            if (dish == null)
            {
                return NotFound();
            }
            ViewData["DietLabelId"] = new SelectList(_context.DietLabels, "DietLabelId", "DietLabelId", dish.DietLabelId);
            ViewData["HealthLabelId"] = new SelectList(_context.HealthLabels, "HealthLabelId", "HealthLabelId", dish.HealthLabelId);
            return View(dish);
        }

        // POST: Admin/Home/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DishId,Name,Description,Slug,Image,Calories,DietLabelId,HealthLabelId")] Dish dish)
        {
            if (id != dish.DishId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dish);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DishExists(dish.DishId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["DietLabelId"] = new SelectList(_context.DietLabels, "DietLabelId", "DietLabelId", dish.DietLabelId);
            ViewData["HealthLabelId"] = new SelectList(_context.HealthLabels, "HealthLabelId", "HealthLabelId", dish.HealthLabelId);
            return View(dish);
        }

        // GET: Admin/Home/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dish = await _context.Dishes
                .Include(d => d.DietLabel)
                .Include(d => d.HealthLabel)
                .FirstOrDefaultAsync(m => m.DishId == id);
            if (dish == null)
            {
                return NotFound();
            }

            return View(dish);
        }

        // POST: Admin/Home/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dish = await _context.Dishes.FindAsync(id);
            _context.Dishes.Remove(dish);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DishExists(int id)
        {
            return _context.Dishes.Any(e => e.DishId == id);
        }
    }
}
