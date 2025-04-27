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
    public class OgrenciController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public OgrenciController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Ogrenci
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ogrenci>>> GetOgrenciler()
        {
            return await _context.Ogrenciler.ToListAsync();
        }

        // GET: api/Ogrenci/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ogrenci>> GetOgrenci(int id)
        {
            var ogrenci = await _context.Ogrenciler.FindAsync(id);

            if (ogrenci == null)
            {
                return NotFound();
            }

            return ogrenci;
        }

        // POST: api/Ogrenci
        [HttpPost]
        public async Task<ActionResult<Ogrenci>> PostOgrenci(Ogrenci ogrenci)
        {
            _context.Ogrenciler.Add(ogrenci);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOgrenci", new { id = ogrenci.Id }, ogrenci);
        }

        // PUT: api/Ogrenci/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOgrenci(int id, Ogrenci ogrenci)
        {
            if (id != ogrenci.Id)
            {
                return BadRequest();
            }

            _context.Entry(ogrenci).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OgrenciExists(id))
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

        // DELETE: api/Ogrenci/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOgrenci(int id)
        {
            var ogrenci = await _context.Ogrenciler.FindAsync(id);
            if (ogrenci == null)
            {
                return NotFound();
            }

            _context.Ogrenciler.Remove(ogrenci);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OgrenciExists(int id)
        {
            return _context.Ogrenciler.Any(e => e.Id == id);
        }
    }
} 