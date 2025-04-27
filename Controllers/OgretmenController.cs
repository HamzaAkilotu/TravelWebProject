using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AnaOkuluYS.Data;
using AnaOkuluYS.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnaOkuluYS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OgretmenController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public OgretmenController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Ogretmen
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ogretmen>>> GetOgretmenler()
        {
            return await _context.Ogretmenler.ToListAsync();
        }

        // GET: api/Ogretmen/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ogretmen>> GetOgretmen(int id)
        {
            var ogretmen = await _context.Ogretmenler.FindAsync(id);

            if (ogretmen == null)
            {
                return NotFound();
            }

            return ogretmen;
        }

        // POST: api/Ogretmen
        [HttpPost]
        public async Task<ActionResult<Ogretmen>> PostOgretmen(Ogretmen ogretmen)
        {
            _context.Ogretmenler.Add(ogretmen);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOgretmen", new { id = ogretmen.Id }, ogretmen);
        }

        // PUT: api/Ogretmen/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOgretmen(int id, Ogretmen ogretmen)
        {
            if (id != ogretmen.Id)
            {
                return BadRequest();
            }

            _context.Entry(ogretmen).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OgretmenExists(id))
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

        // DELETE: api/Ogretmen/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOgretmen(int id)
        {
            var ogretmen = await _context.Ogretmenler.FindAsync(id);
            if (ogretmen == null)
            {
                return NotFound();
            }

            _context.Ogretmenler.Remove(ogretmen);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OgretmenExists(int id)
        {
            return _context.Ogretmenler.Any(e => e.Id == id);
        }
    }
} 