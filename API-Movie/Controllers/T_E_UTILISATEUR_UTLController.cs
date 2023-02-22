using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using API_Movie.Models.EntityFramework;

namespace API_Movie.Controllers
{
    public class T_E_UTILISATEUR_UTLController : Controller
    {
        private readonly FilmRatingDBContext _context;

        public T_E_UTILISATEUR_UTLController(FilmRatingDBContext context)
        {
            _context = context;
        }

        // GET: T_E_UTILISATEUR_UTL
        public async Task<IActionResult> Index()
        {
              return View(await _context.UTL.ToListAsync());
        }

        // GET: T_E_UTILISATEUR_UTL/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.UTL == null)
            {
                return NotFound();
            }

            var t_E_UTILISATEUR_UTL = await _context.UTL
                .FirstOrDefaultAsync(m => m.UtilisateurId == id);
            if (t_E_UTILISATEUR_UTL == null)
            {
                return NotFound();
            }

            return View(t_E_UTILISATEUR_UTL);
        }

        // GET: T_E_UTILISATEUR_UTL/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: T_E_UTILISATEUR_UTL/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UtilisateurId,Nom,Prenom,Mobile,Mail,Pwd,Rue,CodePostal,Ville,Pays,Latitude,Longitude,DateCreation")] T_E_UTILISATEUR_UTL t_E_UTILISATEUR_UTL)
        {
            if (ModelState.IsValid)
            {
                _context.Add(t_E_UTILISATEUR_UTL);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(t_E_UTILISATEUR_UTL);
        }

        // GET: T_E_UTILISATEUR_UTL/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.UTL == null)
            {
                return NotFound();
            }

            var t_E_UTILISATEUR_UTL = await _context.UTL.FindAsync(id);
            if (t_E_UTILISATEUR_UTL == null)
            {
                return NotFound();
            }
            return View(t_E_UTILISATEUR_UTL);
        }

        // POST: T_E_UTILISATEUR_UTL/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UtilisateurId,Nom,Prenom,Mobile,Mail,Pwd,Rue,CodePostal,Ville,Pays,Latitude,Longitude,DateCreation")] T_E_UTILISATEUR_UTL t_E_UTILISATEUR_UTL)
        {
            if (id != t_E_UTILISATEUR_UTL.UtilisateurId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(t_E_UTILISATEUR_UTL);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!T_E_UTILISATEUR_UTLExists(t_E_UTILISATEUR_UTL.UtilisateurId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(t_E_UTILISATEUR_UTL);
        }

        // GET: T_E_UTILISATEUR_UTL/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.UTL == null)
            {
                return NotFound();
            }

            var t_E_UTILISATEUR_UTL = await _context.UTL
                .FirstOrDefaultAsync(m => m.UtilisateurId == id);
            if (t_E_UTILISATEUR_UTL == null)
            {
                return NotFound();
            }

            return View(t_E_UTILISATEUR_UTL);
        }

        // POST: T_E_UTILISATEUR_UTL/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.UTL == null)
            {
                return Problem("Entity set 'FilmRatingDBContext.UTL'  is null.");
            }
            var t_E_UTILISATEUR_UTL = await _context.UTL.FindAsync(id);
            if (t_E_UTILISATEUR_UTL != null)
            {
                _context.UTL.Remove(t_E_UTILISATEUR_UTL);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool T_E_UTILISATEUR_UTLExists(int id)
        {
          return _context.UTL.Any(e => e.UtilisateurId == id);
        }
    }
}
