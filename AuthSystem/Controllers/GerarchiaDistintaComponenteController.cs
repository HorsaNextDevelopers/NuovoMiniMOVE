using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AuthSystem.Models;

namespace AuthSystem.Controllers
{
    public class GerarchiaDistintaComponenteController : Controller
    {
        private readonly NContext _context;

        public GerarchiaDistintaComponenteController(NContext context)
        {
            _context = context;
        }

        // GET: GerarchiaDistintaComponente
        public async Task<IActionResult> Index()
        {
            var nContext = _context.GerarchiaDistintaComponenti.Include(g => g.DistintaComponenti);
            return View(await nContext.ToListAsync());
        }

        // GET: GerarchiaDistintaComponente/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gerarchiaDistintaComponente = await _context.GerarchiaDistintaComponenti
                .Include(g => g.DistintaComponenti)
                .FirstOrDefaultAsync(m => m.CodiceComponentePadre == id);
            if (gerarchiaDistintaComponente == null)
            {
                return NotFound();
            }

            return View(gerarchiaDistintaComponente);
        }

        // GET: GerarchiaDistintaComponente/Create
        public IActionResult Create()
        {
            ViewData["CodiceComponente"] = new SelectList(_context.DistintaComponenti, "CodiceComponente", "CodiceComponente");
            return View();
        }

        // POST: GerarchiaDistintaComponente/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodiceComponente,CodiceComponentePadre")] GerarchiaDistintaComponente gerarchiaDistintaComponente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gerarchiaDistintaComponente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CodiceComponente"] = new SelectList(_context.DistintaComponenti, "CodiceComponente", "CodiceComponente", gerarchiaDistintaComponente.CodiceComponente);
            return View(gerarchiaDistintaComponente);
        }

        // GET: GerarchiaDistintaComponente/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gerarchiaDistintaComponente = await _context.GerarchiaDistintaComponenti.FindAsync(id);
            if (gerarchiaDistintaComponente == null)
            {
                return NotFound();
            }
            ViewData["CodiceComponente"] = new SelectList(_context.DistintaComponenti, "CodiceComponente", "CodiceComponente", gerarchiaDistintaComponente.CodiceComponente);
            return View(gerarchiaDistintaComponente);
        }

        // POST: GerarchiaDistintaComponente/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("CodiceComponente,CodiceComponentePadre")] GerarchiaDistintaComponente gerarchiaDistintaComponente)
        {
            if (id != gerarchiaDistintaComponente.CodiceComponentePadre)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gerarchiaDistintaComponente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GerarchiaDistintaComponenteExists(gerarchiaDistintaComponente.CodiceComponentePadre))
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
            ViewData["CodiceComponente"] = new SelectList(_context.DistintaComponenti, "CodiceComponente", "CodiceComponente", gerarchiaDistintaComponente.CodiceComponente);
            return View(gerarchiaDistintaComponente);
        }

        // GET: GerarchiaDistintaComponente/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gerarchiaDistintaComponente = await _context.GerarchiaDistintaComponenti
                .Include(g => g.DistintaComponenti)
                .FirstOrDefaultAsync(m => m.CodiceComponentePadre == id);
            if (gerarchiaDistintaComponente == null)
            {
                return NotFound();
            }

            return View(gerarchiaDistintaComponente);
        }

        // POST: GerarchiaDistintaComponente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var gerarchiaDistintaComponente = await _context.GerarchiaDistintaComponenti.FindAsync(id);
            _context.GerarchiaDistintaComponenti.Remove(gerarchiaDistintaComponente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GerarchiaDistintaComponenteExists(string id)
        {
            return _context.GerarchiaDistintaComponenti.Any(e => e.CodiceComponentePadre == id);
        }
    }
}
