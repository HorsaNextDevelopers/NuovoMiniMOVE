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
    public class DistintaComponenteController : Controller
    {
        private readonly NContext _context;

        public DistintaComponenteController(NContext context)
        {
            _context = context;
        }

        // GET: DistintaComponente
        public async Task<IActionResult> Index()
        {
            var nContext = _context.DistintaComponenti.Include(d => d.Articoli);
            return View(await nContext.ToListAsync());
        }

        // GET: DistintaComponente/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var distintaComponente = await _context.DistintaComponenti
                .Include(d => d.Articoli)
                .FirstOrDefaultAsync(m => m.CodiceComponente == id);
            if (distintaComponente == null)
            {
                return NotFound();
            }

            return View(distintaComponente);
        }

        // GET: DistintaComponente/Create
        public IActionResult Create()
        {
            ViewData["CodiceArticolo"] = new SelectList(_context.Articoli, "CodiceArticolo", "CodiceArticolo");
            return View();
        }

        // POST: DistintaComponente/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodiceArticolo,CodiceComponente,Descrizione,Quantita")] DistintaComponente distintaComponente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(distintaComponente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CodiceArticolo"] = new SelectList(_context.Articoli, "CodiceArticolo", "CodiceArticolo", distintaComponente.CodiceArticolo);
            return View(distintaComponente);
        }

        // GET: DistintaComponente/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var distintaComponente = await _context.DistintaComponenti.FindAsync(id);
            if (distintaComponente == null)
            {
                return NotFound();
            }
            ViewData["CodiceArticolo"] = new SelectList(_context.Articoli, "CodiceArticolo", "CodiceArticolo", distintaComponente.CodiceArticolo);
            return View(distintaComponente);
        }

        // POST: DistintaComponente/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("CodiceArticolo,CodiceComponente,Descrizione,Quantita")] DistintaComponente distintaComponente)
        {
            if (id != distintaComponente.CodiceComponente)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(distintaComponente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DistintaComponenteExists(distintaComponente.CodiceComponente))
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
            ViewData["CodiceArticolo"] = new SelectList(_context.Articoli, "CodiceArticolo", "CodiceArticolo", distintaComponente.CodiceArticolo);
            return View(distintaComponente);
        }

        // GET: DistintaComponente/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var distintaComponente = await _context.DistintaComponenti
                .Include(d => d.Articoli)
                .FirstOrDefaultAsync(m => m.CodiceComponente == id);
            if (distintaComponente == null)
            {
                return NotFound();
            }

            return View(distintaComponente);
        }

        // POST: DistintaComponente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var distintaComponente = await _context.DistintaComponenti.FindAsync(id);
            _context.DistintaComponenti.Remove(distintaComponente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DistintaComponenteExists(string id)
        {
            return _context.DistintaComponenti.Any(e => e.CodiceComponente == id);
        }
    }
}
