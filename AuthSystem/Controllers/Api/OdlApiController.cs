
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
    public class OdlApiController : ControllerBase
    {
        private readonly NContext _context;

        public OdlApiController(NContext context)
        {
            _context = context;
        }

        // GET: api/OdlApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Odl>>> GetOdls()
        {
            return await _context.Odls.ToListAsync();
        }

        // GET: api/OdlApi/5
        [HttpGet("{codiceOdl}")]
        public async Task<ActionResult<Odl>> GetOdl(string codiceOdl)
        {
            var odl = await _context.Odls.FindAsync(codiceOdl);

            if (odl == null)
            {
                return NotFound();
            }

            return odl;
        }

      
    }
}
