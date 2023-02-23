using API_Movie.Models.EntityFramework;
using API_Movie.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace API_Movie.Models.Data_Manager
{
    public class UtilisateurManager : IDataRepository<T_E_UTILISATEUR_UTL>
    {
        readonly FilmRatingDBContext? filmsDbContext;
        public UtilisateurManager() { }
        public UtilisateurManager(FilmRatingDBContext context)
        {
            filmsDbContext = context;
        }
        public ActionResult<IEnumerable<T_E_UTILISATEUR_UTL>> GetAll()
        {
            return filmsDbContext.UTL.ToList();
        }
        public ActionResult<T_E_UTILISATEUR_UTL> GetById(int id)
        {
            return filmsDbContext.UTL.FirstOrDefault(u => u.UtilisateurId == id);
        }
        public async Task<ActionResult<T_E_UTILISATEUR_UTL>> GetByStringAsync(string mail)
        {
            return await filmsDbContext.UTL.FirstOrDefaultAsync(u => u.Mail.ToUpper() == mail.ToUpper());
        }
        public async Task AddAsync(T_E_UTILISATEUR_UTL entity)
        {
            await filmsDbContext.UTL.AddAsync(entity);
            await filmsDbContext.SaveChangesAsync();
        }
        public void Update(T_E_UTILISATEUR_UTL utilisateur, T_E_UTILISATEUR_UTL entity)
        {
            filmsDbContext.Entry(utilisateur).State = EntityState.Modified;
            utilisateur.UtilisateurId = entity.UtilisateurId;
            utilisateur.Nom = entity.Nom;
            utilisateur.Prenom = entity.Prenom;
            utilisateur.Mail = entity.Mail;
            utilisateur.Rue = entity.Rue;
            utilisateur.CodePostal = entity.CodePostal;
            utilisateur.Ville = entity.Ville;
            utilisateur.Pays = entity.Pays;
            utilisateur.Latitude = entity.Latitude;
            utilisateur.Longitude = entity.Longitude;
            utilisateur.Pwd = entity.Pwd;
            utilisateur.Mobile = entity.Mobile;
            utilisateur.NotesUtilisateur = entity.NotesUtilisateur;
            filmsDbContext.SaveChanges();
        }
        public void Delete(T_E_UTILISATEUR_UTL utilisateur)
        {
            filmsDbContext.UTL.Remove(utilisateur);
            filmsDbContext.SaveChanges();
        }

        ActionResult<IEnumerable<T_E_UTILISATEUR_UTL>> IDataRepository<T_E_UTILISATEUR_UTL>.GetAll()
        {
            throw new NotImplementedException();
        }

        ActionResult<T_E_UTILISATEUR_UTL> IDataRepository<T_E_UTILISATEUR_UTL>.GetById(int id)
        {
            throw new NotImplementedException();
        }

        ActionResult<T_E_UTILISATEUR_UTL> IDataRepository<T_E_UTILISATEUR_UTL>.GetByString(string str)
        {
            throw new NotImplementedException();
        }
    }
}
