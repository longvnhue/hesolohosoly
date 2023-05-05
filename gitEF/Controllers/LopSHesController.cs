using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using gitEF.Data;
using gitEF.Models;

namespace gitEF.Controllers
{
    public class LopSHesController : Controller
    {
        private readonly QLSVDbContext _context;

        public LopSHesController(QLSVDbContext context)
        {
            _context = context;
        }

        // GET: LopSHes
        public async Task<IActionResult> Index()
        {
              return _context.LopSHes != null ? 
                          View(await _context.LopSHes.ToListAsync()) :
                          Problem("Entity set 'QLSVDbContext.LopSHes'  is null.");
        }

        // GET: LopSHes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.LopSHes == null)
            {
                return NotFound();
            }

            var lopSH = await _context.LopSHes
                .FirstOrDefaultAsync(m => m.ID_Lop == id);
            if (lopSH == null)
            {
                return NotFound();
            }

            return View(lopSH);
        }

        // GET: LopSHes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LopSHes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_Lop,NameLop,Khoa")] LopSH lopSH)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lopSH);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lopSH);
        }

        // GET: LopSHes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.LopSHes == null)
            {
                return NotFound();
            }

            var lopSH = await _context.LopSHes.FindAsync(id);
            if (lopSH == null)
            {
                return NotFound();
            }
            return View(lopSH);
        }

        // POST: LopSHes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_Lop,NameLop,Khoa")] LopSH lopSH)
        {
            if (id != lopSH.ID_Lop)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lopSH);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LopSHExists(lopSH.ID_Lop))
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
            return View(lopSH);
        }

        // GET: LopSHes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.LopSHes == null)
            {
                return NotFound();
            }

            var lopSH = await _context.LopSHes
                .FirstOrDefaultAsync(m => m.ID_Lop == id);
            if (lopSH == null)
            {
                return NotFound();
            }

            return View(lopSH);
        }

        // POST: LopSHes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.LopSHes == null)
            {
                return Problem("Entity set 'QLSVDbContext.LopSHes'  is null.");
            }
            var lopSH = await _context.LopSHes.FindAsync(id);
            if (lopSH != null)
            {
                _context.LopSHes.Remove(lopSH);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LopSHExists(int id)
        {
          return (_context.LopSHes?.Any(e => e.ID_Lop == id)).GetValueOrDefault();
        }
    }
}
