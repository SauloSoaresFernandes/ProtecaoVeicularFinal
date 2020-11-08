using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api;
using Api.Models;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssociadosController : ControllerBase
    {
        private readonly ProtecaoVeicularContext _context;

        public AssociadosController(ProtecaoVeicularContext context)
        {
            _context = context;
        }

        // GET: api/Associados
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Associados>>> GetAssociados()
        {
            return await _context.Associados.ToListAsync();
        }

        // GET: api/Associados/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Associados>> GetAssociados(int id)
        {
            var associados = await _context.Associados.FindAsync(id);

            if (associados == null)
            {
                return NotFound();
            }

            return associados;
        }

        // PUT: api/Associados/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAssociados(int id, Associados associados)
        {
            if (id != associados.Id)
            {
                return BadRequest();
            }

            _context.Entry(associados).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssociadosExists(id))
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

        // POST: api/Associados
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Associados>> PostAssociados(Associados associados)
        {
            _context.Associados.Add(associados);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAssociados", new { id = associados.Id }, associados);
        }

        // DELETE: api/Associados/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Associados>> DeleteAssociados(int id)
        {
            var associados = await _context.Associados.FindAsync(id);
            if (associados == null)
            {
                return NotFound();
            }

            _context.Associados.Remove(associados);
            await _context.SaveChangesAsync();

            return associados;
        }

        private bool AssociadosExists(int id)
        {
            return _context.Associados.Any(e => e.Id == id);
        }
    }
}
