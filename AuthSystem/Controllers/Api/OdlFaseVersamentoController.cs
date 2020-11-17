using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AuthSystem.Models;

namespace AuthSystem.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class OdlFaseVersamentoController : ControllerBase
    {
        private readonly NContext _context;

        public OdlFaseVersamentoController(NContext context)
        {
            _context = context;
        }

        // GET: api/OdlFaseVersamento
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OdlFaseVersamento>>> GetOdlFaseVersamenti()
        {
            return await _context.OdlFaseVersamenti.ToListAsync();
        }

        // GET: api/OdlFaseVersamento/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OdlFaseVersamento>> GetOdlFaseVersamento(int id)
        {
            var odlFaseVersamento = await _context.OdlFaseVersamenti.FindAsync(id);

            if (odlFaseVersamento == null)
            {
                return NotFound();
            }

            return odlFaseVersamento;
        }

        // PUT: api/OdlFaseVersamento/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOdlFaseVersamento(int id, OdlFaseVersamento odlFaseVersamento)
        {
            if (id != odlFaseVersamento.IdVersamento)
            {
                return BadRequest();
            }

            _context.Entry(odlFaseVersamento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OdlFaseVersamentoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/OdlFaseVersamento
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<OdlFaseVersamento>> PostOdlFaseVersamento(OdlFaseVersamento odlFaseVersamento)
        {
            _context.OdlFaseVersamenti.Add(odlFaseVersamento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOdlFaseVersamento", new { id = odlFaseVersamento.IdVersamento }, odlFaseVersamento);
        }

        // DELETE: api/OdlFaseVersamento/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OdlFaseVersamento>> DeleteOdlFaseVersamento(int id)
        {
            var odlFaseVersamento = await _context.OdlFaseVersamenti.FindAsync(id);
            if (odlFaseVersamento == null)
            {
                return NotFound();
            }

            _context.OdlFaseVersamenti.Remove(odlFaseVersamento);
            await _context.SaveChangesAsync();

            return odlFaseVersamento;
        }

        private bool OdlFaseVersamentoExists(int id)
        {
            return _context.OdlFaseVersamenti.Any(e => e.IdVersamento == id);
        }
    }
}
