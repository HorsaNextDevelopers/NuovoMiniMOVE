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
    public class OdlFaseController : Controller
    {
        private readonly NContext _context;

        public OdlFaseController(NContext context)
        {
            _context = context;
        }

        // GET: OdlFase
        public async Task<IActionResult> Index()
        {
            var nContext = _context.OdlFasi.Include(o => o.Articoli).Include(o => o.CentriDiLavoro).Include(o => o.Odls);
            return View(await nContext.ToListAsync());
        }

        // GET: OdlFase/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var odlFase = await _context.OdlFasi
                .Include(o => o.Articoli)
                .Include(o => o.CentriDiLavoro)
                .Include(o => o.Odls)
                .FirstOrDefaultAsync(m => m.FaseOdl == id);
            if (odlFase == null)
            {
                return NotFound();
            }

            return View(odlFase);
        }

        // GET: OdlFase/Create
        public IActionResult Create()
        {
            ViewData["CodiceArticolo"] = new SelectList(_context.Articoli, "CodiceArticolo", "CodiceArticolo");
            ViewData["CodiceCentroDiLavoro"] = new SelectList(_context.CentriDiLavoro, "CodiceCentroDiLavoro", "CodiceCentroDiLavoro");
            ViewData["CodiceOdl"] = new SelectList(_context.Odls, "CodiceOdl", "CodiceOdl");
            return View();
        }

        // POST: OdlFase/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodiceOdl,CodiceArticolo,FaseOdl,CodiceCentroDiLavoro")] OdlFase odlFase)
        {
            if (ModelState.IsValid)
            {
                _context.Add(odlFase);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CodiceArticolo"] = new SelectList(_context.Articoli, "CodiceArticolo", "CodiceArticolo", odlFase.CodiceArticolo);
            ViewData["CodiceCentroDiLavoro"] = new SelectList(_context.CentriDiLavoro, "CodiceCentroDiLavoro", "CodiceCentroDiLavoro", odlFase.CodiceCentroDiLavoro);
            ViewData["CodiceOdl"] = new SelectList(_context.Odls, "CodiceOdl", "CodiceOdl", odlFase.CodiceOdl);
            return View(odlFase);
        }

        // GET: OdlFase/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var odlFase = await _context.OdlFasi.FindAsync(id);
            if (odlFase == null)
            {
                return NotFound();
            }
            ViewData["CodiceArticolo"] = new SelectList(_context.Articoli, "CodiceArticolo", "CodiceArticolo", odlFase.CodiceArticolo);
            ViewData["CodiceCentroDiLavoro"] = new SelectList(_context.CentriDiLavoro, "CodiceCentroDiLavoro", "CodiceCentroDiLavoro", odlFase.CodiceCentroDiLavoro);
            ViewData["CodiceOdl"] = new SelectList(_context.Odls, "CodiceOdl", "CodiceOdl", odlFase.CodiceOdl);
            return View(odlFase);
        }

        // POST: OdlFase/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodiceOdl,CodiceArticolo,FaseOdl,CodiceCentroDiLavoro")] OdlFase odlFase)
        {
            if (id != odlFase.FaseOdl)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(odlFase);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OdlFaseExists(odlFase.FaseOdl))
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
            ViewData["CodiceArticolo"] = new SelectList(_context.Articoli, "CodiceArticolo", "CodiceArticolo", odlFase.CodiceArticolo);
            ViewData["CodiceCentroDiLavoro"] = new SelectList(_context.CentriDiLavoro, "CodiceCentroDiLavoro", "CodiceCentroDiLavoro", odlFase.CodiceCentroDiLavoro);
            ViewData["CodiceOdl"] = new SelectList(_context.Odls, "CodiceOdl", "CodiceOdl", odlFase.CodiceOdl);
            return View(odlFase);
        }

        // GET: OdlFase/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var odlFase = await _context.OdlFasi
                .Include(o => o.Articoli)
                .Include(o => o.CentriDiLavoro)
                .Include(o => o.Odls)
                .FirstOrDefaultAsync(m => m.FaseOdl == id);
            if (odlFase == null)
            {
                return NotFound();
            }

            return View(odlFase);
        }

        // POST: OdlFase/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var odlFase = await _context.OdlFasi.FindAsync(id);
            _context.OdlFasi.Remove(odlFase);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OdlFaseExists(int id)
        {
            return _context.OdlFasi.Any(e => e.FaseOdl == id);
        }
    }
}
