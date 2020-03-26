using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpaceShooter.Data;

namespace SpaceShooter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HighscoresController : ControllerBase
    {
        private readonly HighscoreContext _context;

        public HighscoresController(HighscoreContext context)
        {
            _context = context;
        }

        // GET: api/Highscores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Highscore>>> GetHighscores()
        {
            return await _context.Highscores.OrderByDescending(h => h.Score).Take(10).ToListAsync();
        }

        // GET: api/Highscores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Highscore>> GetHighscore(int id)
        {
            var highscore = await _context.Highscores.FindAsync(id);

            if (highscore == null)
            {
                return NotFound();
            }

            return highscore;
        }

        // POST: api/Highscores
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Highscore>> PostHighscore(Highscore highscore)
        {
            _context.Highscores.Add(highscore);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHighscore", new { id = highscore.HighscoreId }, highscore);
        }

        // DELETE: api/Highscores/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Highscore>> DeleteHighscore(int id)
        {
            var highscore = await _context.Highscores.FindAsync(id);
            if (highscore == null)
            {
                return NotFound();
            }

            _context.Highscores.Remove(highscore);
            await _context.SaveChangesAsync();

            return highscore;
        }

        private bool HighscoreExists(int id)
        {
            return _context.Highscores.Any(e => e.HighscoreId == id);
        }
    }
}
