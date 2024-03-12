using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetCSharp.Data;
using ProjetCSharp.Models;

namespace ProjetCSharp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NombreVentesController : ControllerBase
    {
        private readonly ProjetCSharpContext _context;

        public NombreVentesController(ProjetCSharpContext context)
        {
            _context = context;
        }

        // GET: api/NombreVentes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NombreVentes>>> GetNombreVentes()
        {
            return await _context.NombreVentes.ToListAsync();
        }

        // GET: api/NombreVentes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NombreVentes>> GetNombreVentes(int id)
        {
            var nombreVentes = await _context.NombreVentes.FindAsync(id);

            if (nombreVentes == null)
            {
                return NotFound();
            }

            return nombreVentes;
        }

        // PUT: api/NombreVentes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNombreVentes(int id, NombreVentes nombreVentes)
        {
            if (id != nombreVentes.Id)
            {
                return BadRequest();
            }

            _context.Entry(nombreVentes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NombreVentesExists(id))
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

        // POST: api/NombreVentes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<NombreVentes>> PostNombreVentes(NombreVentes nombreVentes)
        {
            _context.NombreVentes.Add(nombreVentes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNombreVentes", new { id = nombreVentes.Id }, nombreVentes);
        }

        // DELETE: api/NombreVentes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNombreVentes(int id)
        {
            var nombreVentes = await _context.NombreVentes.FindAsync(id);
            if (nombreVentes == null)
            {
                return NotFound();
            }

            _context.NombreVentes.Remove(nombreVentes);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NombreVentesExists(int id)
        {
            return _context.NombreVentes.Any(e => e.Id == id);
        }
    }
}
