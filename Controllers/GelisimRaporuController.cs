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
    public class GelisimRaporuController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GelisimRaporuController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/GelisimRaporu
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GelisimRaporu>>> GetGelisimRaporlari()
        {
            return await _context.GelisimRaporlari
                .Include(g => g.Ogrenci)
                .Include(g => g.Ogretmen)
                .ToListAsync();
        }

        // GET: api/GelisimRaporu/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GelisimRaporu>> GetGelisimRaporu(int id)
        {
            var gelisimRaporu = await _context.GelisimRaporlari
                .Include(g => g.Ogrenci)
                .Include(g => g.Ogretmen)
                .FirstOrDefaultAsync(g => g.Id == id);

            if (gelisimRaporu == null)
            {
                return NotFound();
            }

            return gelisimRaporu;
        }

        // GET: api/GelisimRaporu/Ogrenci/5
        [HttpGet("Ogrenci/{ogrenciId}")]
        public async Task<ActionResult<IEnumerable<GelisimRaporu>>> GetOgrenciGelisimRaporlari(int ogrenciId)
        {
            return await _context.GelisimRaporlari
                .Include(g => g.Ogrenci)
                .Include(g => g.Ogretmen)
                .Where(g => g.OgrenciId == ogrenciId)
                .ToListAsync();
        }

        // POST: api/GelisimRaporu
        [HttpPost]
        public async Task<ActionResult<GelisimRaporu>> PostGelisimRaporu(GelisimRaporu gelisimRaporu)
        {
            _context.GelisimRaporlari.Add(gelisimRaporu);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGelisimRaporu", new { id = gelisimRaporu.Id }, gelisimRaporu);
        }

        // PUT: api/GelisimRaporu/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGelisimRaporu(int id, GelisimRaporu gelisimRaporu)
        {
            if (id != gelisimRaporu.Id)
            {
                return BadRequest();
            }

            _context.Entry(gelisimRaporu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GelisimRaporuExists(id))
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

        // DELETE: api/GelisimRaporu/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGelisimRaporu(int id)
        {
            var gelisimRaporu = await _context.GelisimRaporlari.FindAsync(id);
            if (gelisimRaporu == null)
            {
                return NotFound();
            }

            _context.GelisimRaporlari.Remove(gelisimRaporu);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GelisimRaporuExists(int id)
        {
            return _context.GelisimRaporlari.Any(e => e.Id == id);
        }
    }
} 