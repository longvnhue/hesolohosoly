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
    public class SinhViensController : Controller
    {
        private readonly QLSVDbContext _context;

        public SinhViensController(QLSVDbContext context)
        {
            _context = context;
        }

        // GET: SinhViens
        public async Task<IActionResult> Index()
        {
            var qLSVDbContext = _context.SVs.Include(s => s.LSH).Include(s => s.RK);
            return View(await qLSVDbContext.ToListAsync());
        }

        // GET: SinhViens/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.SVs == null)
            {
                return NotFound();
            }

            var sinhVien = await _context.SVs
                .Include(s => s.LSH)
                .Include(s => s.RK)
                .FirstOrDefaultAsync(m => m.MSSV == id);
            if (sinhVien == null)
            {
                return NotFound();
            }

            return View(sinhVien);
        }

        // GET: SinhViens/Create
        public IActionResult Create()
        {
            ViewData["ID_Lop"] = new SelectList(_context.LopSHes, "ID_Lop", "NameLop");
            ViewData["ID"] = new SelectList(_context.Ranks, "Id", "Id");
            return View();
        }

        // POST: SinhViens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MSSV,FirstName,LastName,NS,Address,DTB,Gender,ID,ID_Lop")] SinhVien sinhVien)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sinhVien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ID_Lop"] = new SelectList(_context.LopSHes, "ID_Lop", "NameLop", sinhVien.ID_Lop);
            ViewData["ID"] = new SelectList(_context.Ranks, "Id", "Id", sinhVien.ID);
            return View(sinhVien);
        }

        // GET: SinhViens/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.SVs == null)
            {
                return NotFound();
            }

            var sinhVien = await _context.SVs.FindAsync(id);
            if (sinhVien == null)
            {
                return NotFound();
            }
            ViewData["ID_Lop"] = new SelectList(_context.LopSHes, "ID_Lop", "NameLop", sinhVien.ID_Lop);
            ViewData["ID"] = new SelectList(_context.Ranks, "Id", "Id", sinhVien.ID);
            return View(sinhVien);
        }

        // POST: SinhViens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MSSV,FirstName,LastName,NS,Address,DTB,Gender,ID,ID_Lop")] SinhVien sinhVien)
        {
            if (id != sinhVien.MSSV)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sinhVien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SinhVienExists(sinhVien.MSSV))
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
            ViewData["ID_Lop"] = new SelectList(_context.LopSHes, "ID_Lop", "NameLop", sinhVien.ID_Lop);
            ViewData["ID"] = new SelectList(_context.Ranks, "Id", "Id", sinhVien.ID);
            return View(sinhVien);
        }

        // GET: SinhViens/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.SVs == null)
            {
                return NotFound();
            }

            var sinhVien = await _context.SVs
                .Include(s => s.LSH)
                .Include(s => s.RK)
                .FirstOrDefaultAsync(m => m.MSSV == id);
            if (sinhVien == null)
            {
                return NotFound();
            }

            return View(sinhVien);
        }

        // POST: SinhViens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.SVs == null)
            {
                return Problem("Entity set 'QLSVDbContext.SVs'  is null.");
            }
            var sinhVien = await _context.SVs.FindAsync(id);
            if (sinhVien != null)
            {
                _context.SVs.Remove(sinhVien);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SinhVienExists(string id)
        {
          return (_context.SVs?.Any(e => e.MSSV == id)).GetValueOrDefault();
        }
    }
}
