using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_Movie.Models.EntityFramework;
using API_Movie.Models.Data_Manager;
using API_Movie.Models.Repository;

namespace API_Movie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtilisateursController : ControllerBase
    {
        private readonly IDataRepository<T_E_UTILISATEUR_UTL> dataRepository;

        public UtilisateursController(IDataRepository<T_E_UTILISATEUR_UTL> dataRepo){
            dataRepository = dataRepo;
        }

    // GET: api/Utilisateurs
    [HttpGet]
        [ActionName("GetAllUsers")]
        public async Task<ActionResult<IEnumerable<T_E_UTILISATEUR_UTL>>> GetUTL()
        {
            return dataRepository.GetAll();
        }

        // GET: api/Utilisateurs/5
        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetById")]
        public async Task<ActionResult<T_E_UTILISATEUR_UTL>> GetT_E_UTILISATEUR_UTL_byId(int id)
        {
            var utilisateur = dataRepository.GetById(id);

            if (utilisateur == null)
            {
                return NotFound();
            }

            return utilisateur;
        }

        [HttpGet]
        [Route("[action]/{email}")]
        [ActionName("GetByEmail")]
        public async Task<ActionResult<T_E_UTILISATEUR_UTL>> GetT_E_UTILISATEUR_UTL_byEmail(string email)
        {
            var utilisateur = await dataRepository.GetByStringAsync(email);

            if (utilisateur == null)
            {
                return NotFound();
            }

            return utilisateur;
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

            var userToUpdate = dataRepository.GetById(id);
            if (userToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                dataRepository.Update(userToUpdate.Value, t_E_UTILISATEUR_UTL);
                return NoContent();
            }

            return NoContent();
        }

        // POST: api/Utilisateurs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<T_E_UTILISATEUR_UTL>> PostT_E_UTILISATEUR_UTL(T_E_UTILISATEUR_UTL t_E_UTILISATEUR_UTL)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            dataRepository.Add(t_E_UTILISATEUR_UTL);
            return CreatedAtAction("GetById", new { id = t_E_UTILISATEUR_UTL.UtilisateurId }, t_E_UTILISATEUR_UTL);
        }

        // DELETE: api/Utilisateurs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteT_E_UTILISATEUR_UTL(int id)
        {
            var utilisateur = dataRepository.GetById(id);
            if (utilisateur == null)
            {
                return NotFound();
            }

            dataRepository.Delete(utilisateur.Value);

            return NoContent();
        }
        /*
        private bool T_E_UTILISATEUR_UTLExists(int id)
        {
            return _context.UTL.Any(e => e.UtilisateurId == id);
        }*/
    }
}
