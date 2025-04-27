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
    public class EtkinlikKatilimController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EtkinlikKatilimController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/EtkinlikKatilim
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EtkinlikKatilim>>> GetEtkinlikKatilimlari()
        {
            return await _context.EtkinlikKatilimlari
                .Include(k => k.Etkinlik)
                .Include(k => k.Ogrenci)
                .ToListAsync();
        }

        // GET: api/EtkinlikKatilim/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EtkinlikKatilim>> GetEtkinlikKatilim(int id)
        {
            var etkinlikKatilim = await _context.EtkinlikKatilimlari
                .Include(k => k.Etkinlik)
                .Include(k => k.Ogrenci)
                .FirstOrDefaultAsync(k => k.Id == id);

            if (etkinlikKatilim == null)
            {
                return NotFound();
            }

            return etkinlikKatilim;
        }

        // GET: api/EtkinlikKatilim/Etkinlik/5
        [HttpGet("Etkinlik/{etkinlikId}")]
        public async Task<ActionResult<IEnumerable<EtkinlikKatilim>>> GetEtkinlikKatilimlari(int etkinlikId)
        {
            return await _context.EtkinlikKatilimlari
                .Include(k => k.Etkinlik)
                .Include(k => k.Ogrenci)
                .Where(k => k.EtkinlikId == etkinlikId)
                .ToListAsync();
        }

        // GET: api/EtkinlikKatilim/Ogrenci/5
        [HttpGet("Ogrenci/{ogrenciId}")]
        public async Task<ActionResult<IEnumerable<EtkinlikKatilim>>> GetOgrenciKatilimlari(int ogrenciId)
        {
            return await _context.EtkinlikKatilimlari
                .Include(k => k.Etkinlik)
                .Include(k => k.Ogrenci)
                .Where(k => k.OgrenciId == ogrenciId)
                .ToListAsync();
        }

        // POST: api/EtkinlikKatilim
        [HttpPost]
        public async Task<ActionResult<EtkinlikKatilim>> PostEtkinlikKatilim(EtkinlikKatilim etkinlikKatilim)
        {
            _context.EtkinlikKatilimlari.Add(etkinlikKatilim);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEtkinlikKatilim", new { id = etkinlikKatilim.Id }, etkinlikKatilim);
        }

        // PUT: api/EtkinlikKatilim/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEtkinlikKatilim(int id, EtkinlikKatilim etkinlikKatilim)
        {
            if (id != etkinlikKatilim.Id)
            {
                return BadRequest();
            }

            _context.Entry(etkinlikKatilim).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EtkinlikKatilimExists(id))
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

        // DELETE: api/EtkinlikKatilim/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEtkinlikKatilim(int id)
        {
            var etkinlikKatilim = await _context.EtkinlikKatilimlari.FindAsync(id);
            if (etkinlikKatilim == null)
            {
                return NotFound();
            }

            _context.EtkinlikKatilimlari.Remove(etkinlikKatilim);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EtkinlikKatilimExists(int id)
        {
            return _context.EtkinlikKatilimlari.Any(e => e.Id == id);
        }
    }
} 