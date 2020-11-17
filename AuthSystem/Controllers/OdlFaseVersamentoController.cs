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
    public class OdlFaseVersamentoController : Controller
    {
        private readonly NContext _context;

        public OdlFaseVersamentoController(NContext context)
        {
            _context = context;
        }

        // GET: OdlFaseVersamentoes
        public async Task<IActionResult> Index()
        {
            var nContext = _context.OdlFaseVersamenti.Include(o => o.Articoli).Include(o => o.AspNetUsers).Include(o => o.MacchinaFisiche).Include(o => o.Odl).Include(o => o.OdlFasi);
            return View(await nContext.ToListAsync());
        }

        // GET: OdlFaseVersamentoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var odlFaseVersamento = await _context.OdlFaseVersamenti
                .Include(o => o.Articoli)
                .Include(o => o.AspNetUsers)
                .Include(o => o.MacchinaFisiche)
                .Include(o => o.Odl)
                .Include(o => o.OdlFasi)
                .FirstOrDefaultAsync(m => m.IdVersamento == id);
            if (odlFaseVersamento == null)
            {
                return NotFound();
            }

            return View(odlFaseVersamento);
        }

        // GET: OdlFaseVersamentoes/Create
        public IActionResult Create()
        {
            ViewData["CodiceArticolo"] = new SelectList(_context.Articoli, "CodiceArticolo", "CodiceArticolo");
            ViewData["IdAspNetUsers"] = new SelectList(_context.AspNetUsers, "Id", "Id");
            ViewData["CodiceMacchinaFisica"] = new SelectList(_context.MacchinaFisica, "CodiceMacchinaFisica", "CodiceMacchinaFisica");
            ViewData["CodiceOdl"] = new SelectList(_context.Odls, "CodiceOdl", "CodiceOdl");
            ViewData["IdFaseODL"] = new SelectList(_context.OdlFasi, "IdFaseOdl", "IdFaseOdl");
            return View();
        }

        // POST: OdlFaseVersamentoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdVersamento,CodiceArticolo,CodiceOdl,IdFaseODL,CodiceMacchinaFisica,IdAspNetUsers,DataInizio,DataFine,TempoLavoroNetto,PezziBuoni,PezziScartati")] OdlFaseVersamento odlFaseVersamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(odlFaseVersamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CodiceArticolo"] = new SelectList(_context.Articoli, "CodiceArticolo", "CodiceArticolo", odlFaseVersamento.CodiceArticolo);
            ViewData["IdAspNetUsers"] = new SelectList(_context.AspNetUsers, "Id", "Id", odlFaseVersamento.IdAspNetUsers);
            ViewData["CodiceMacchinaFisica"] = new SelectList(_context.MacchinaFisica, "CodiceMacchinaFisica", "CodiceMacchinaFisica", odlFaseVersamento.CodiceMacchinaFisica);
            ViewData["CodiceOdl"] = new SelectList(_context.Odls, "CodiceOdl", "CodiceOdl", odlFaseVersamento.CodiceOdl);
            ViewData["IdFaseODL"] = new SelectList(_context.OdlFasi, "IdFaseOdl", "IdFaseOdl", odlFaseVersamento.IdFaseODL);
            return View(odlFaseVersamento);
        }

        // GET: OdlFaseVersamentoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var odlFaseVersamento = await _context.OdlFaseVersamenti.FindAsync(id);
            if (odlFaseVersamento == null)
            {
                return NotFound();
            }
            ViewData["CodiceArticolo"] = new SelectList(_context.Articoli, "CodiceArticolo", "CodiceArticolo", odlFaseVersamento.CodiceArticolo);
            ViewData["IdAspNetUsers"] = new SelectList(_context.AspNetUsers, "Id", "Id", odlFaseVersamento.IdAspNetUsers);
            ViewData["CodiceMacchinaFisica"] = new SelectList(_context.MacchinaFisica, "CodiceMacchinaFisica", "CodiceMacchinaFisica", odlFaseVersamento.CodiceMacchinaFisica);
            ViewData["CodiceOdl"] = new SelectList(_context.Odls, "CodiceOdl", "CodiceOdl", odlFaseVersamento.CodiceOdl);
            ViewData["IdFaseODL"] = new SelectList(_context.OdlFasi, "IdFaseOdl", "IdFaseOdl", odlFaseVersamento.IdFaseODL);
            return View(odlFaseVersamento);
        }

        // POST: OdlFaseVersamentoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdVersamento,CodiceArticolo,CodiceOdl,IdFaseODL,CodiceMacchinaFisica,IdAspNetUsers,DataInizio,DataFine,TempoLavoroNetto,PezziBuoni,PezziScartati")] OdlFaseVersamento odlFaseVersamento)
        {
            if (id != odlFaseVersamento.IdVersamento)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(odlFaseVersamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OdlFaseVersamentoExists(odlFaseVersamento.IdVersamento))
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
            ViewData["CodiceArticolo"] = new SelectList(_context.Articoli, "CodiceArticolo", "CodiceArticolo", odlFaseVersamento.CodiceArticolo);
            ViewData["IdAspNetUsers"] = new SelectList(_context.AspNetUsers, "Id", "Id", odlFaseVersamento.IdAspNetUsers);
            ViewData["CodiceMacchinaFisica"] = new SelectList(_context.MacchinaFisica, "CodiceMacchinaFisica", "CodiceMacchinaFisica", odlFaseVersamento.CodiceMacchinaFisica);
            ViewData["CodiceOdl"] = new SelectList(_context.Odls, "CodiceOdl", "CodiceOdl", odlFaseVersamento.CodiceOdl);
            ViewData["IdFaseODL"] = new SelectList(_context.OdlFasi, "IdFaseOdl", "IdFaseOdl", odlFaseVersamento.IdFaseODL);
            return View(odlFaseVersamento);
        }

        // GET: OdlFaseVersamentoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var odlFaseVersamento = await _context.OdlFaseVersamenti
                .Include(o => o.Articoli)
                .Include(o => o.AspNetUsers)
                .Include(o => o.MacchinaFisiche)
                .Include(o => o.Odl)
                .Include(o => o.OdlFasi)
                .FirstOrDefaultAsync(m => m.IdVersamento == id);
            if (odlFaseVersamento == null)
            {
                return NotFound();
            }

            return View(odlFaseVersamento);
        }

        // POST: OdlFaseVersamentoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var odlFaseVersamento = await _context.OdlFaseVersamenti.FindAsync(id);
            _context.OdlFaseVersamenti.Remove(odlFaseVersamento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OdlFaseVersamentoExists(int id)
        {
            return _context.OdlFaseVersamenti.Any(e => e.IdVersamento == id);
        }
    }
}
