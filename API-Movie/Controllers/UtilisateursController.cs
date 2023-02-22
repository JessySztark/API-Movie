using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_Movie.Models.EntityFramework;

namespace API_Movie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtilisateursController : ControllerBase
    {
        private readonly FilmRatingDBContext _context;

        public UtilisateursController(FilmRatingDBContext context)
        {
            _context = context;
        }

        // GET: api/Utilisateurs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<T_E_UTILISATEUR_UTL>>> GetUTL()
        {
            return await _context.UTL.ToListAsync();
        }

        // GET: api/Utilisateurs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<T_E_UTILISATEUR_UTL>> GetT_E_UTILISATEUR_UTL(int id)
        {
            var t_E_UTILISATEUR_UTL = await _context.UTL.FindAsync(id);

            if (t_E_UTILISATEUR_UTL == null)
            {
                return NotFound();
            }

            return t_E_UTILISATEUR_UTL;
        }

        // PUT: api/Utilisateurs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutT_E_UTILISATEUR_UTL(int id, T_E_UTILISATEUR_UTL t_E_UTILISATEUR_UTL)
        {
            if (id != t_E_UTILISATEUR_UTL.UtilisateurId)
            {
                return BadRequest();
            }

            _context.Entry(t_E_UTILISATEUR_UTL).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!T_E_UTILISATEUR_UTLExists(id))
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

        // POST: api/Utilisateurs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<T_E_UTILISATEUR_UTL>> PostT_E_UTILISATEUR_UTL(T_E_UTILISATEUR_UTL t_E_UTILISATEUR_UTL)
        {
            _context.UTL.Add(t_E_UTILISATEUR_UTL);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetT_E_UTILISATEUR_UTL", new { id = t_E_UTILISATEUR_UTL.UtilisateurId }, t_E_UTILISATEUR_UTL);
        }

        // DELETE: api/Utilisateurs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteT_E_UTILISATEUR_UTL(int id)
        {
            var t_E_UTILISATEUR_UTL = await _context.UTL.FindAsync(id);
            if (t_E_UTILISATEUR_UTL == null)
            {
                return NotFound();
            }

            _context.UTL.Remove(t_E_UTILISATEUR_UTL);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool T_E_UTILISATEUR_UTLExists(int id)
        {
            return _context.UTL.Any(e => e.UtilisateurId == id);
        }
    }
}
