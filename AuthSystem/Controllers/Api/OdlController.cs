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
    public class OdlController : ControllerBase
    {
        private readonly NContext _context;

        public OdlController(NContext context)
        {
            _context = context;
        }

        // GET: api/Odl
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Odl>>> GetOdls()
        {
            return await _context.Odls.ToListAsync();
        }

        // GET: api/Odl/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Odl>> GetOdl(string id)
        {
            var odl = await _context.Odls.FindAsync(id);

            if (odl == null)
            {
                return NotFound();
            }

            return odl;
        }

        // PUT: api/Odl/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOdl(string id, Odl odl)
        {
            if (id != odl.CodiceOdl)
            {
                return BadRequest();
            }

            _context.Entry(odl).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OdlExists(id))
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

        // POST: api/Odl
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Odl>> PostOdl(Odl odl)
        {
            _context.Odls.Add(odl);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (OdlExists(odl.CodiceOdl))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetOdl", new { id = odl.CodiceOdl }, odl);
        }

        // DELETE: api/Odl/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Odl>> DeleteOdl(string id)
        {
            var odl = await _context.Odls.FindAsync(id);
            if (odl == null)
            {
                return NotFound();
            }

            _context.Odls.Remove(odl);
            await _context.SaveChangesAsync();

            return odl;
        }

        private bool OdlExists(string id)
        {
            return _context.Odls.Any(e => e.CodiceOdl == id);
        }
    }
}
