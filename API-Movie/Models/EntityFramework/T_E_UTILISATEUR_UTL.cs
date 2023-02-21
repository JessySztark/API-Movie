using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;
using Microsoft.EntityFrameworkCore;

namespace API_Movie.Models.EntityFramework
{
    [Table("T_E_UTILISATEUR_UTL")]
    public class T_E_UTILISATEUR_UTL
    {
        private int utl_id;
        private String? utl_nom;
        private String? utl_prenom;
        private String? utl_mobile;
        private String? utl_mail;
        private String? utl_pwd = null!;
        private String? utl_rue;
        private String? utl_cp;
        private String? utl_ville;
        private String? utl_pays;
        private float? utl_latitude;
        private float? utl_longitude;
        private DateTime utl_datecreation;

        public T_E_UTILISATEUR_UTL()
        {
            NotesUtilisateur = new HashSet<T_J_NOTATION_NOT>();
        }

        [Key]
        [Column("utl_id", TypeName = "int")]
        public int UtilisateurId
        {
            get { return utl_id; }
            set { utl_id = value; }
        }

        [Column("utl_nom", TypeName = "varchar")]
        [StringLength(50)]
        public String? Nom
        {
            get { return utl_nom; }
            set { utl_nom = value; }
        }

        [Column("utl_prenom", TypeName = "varchar")]
        [StringLength(50)]
        public String? Prenom
        {
            get { return utl_prenom; }
            set { utl_prenom = value; }
        }

        [Column("utl_mobile", TypeName = "char(10)")]
        public String? Mobile
        {
            get { return utl_mobile; }
            set { utl_mobile = value; }
        }

        [Column("utl_mail", TypeName = "varchar")]
        [StringLength(100)]
        public String? Mail
        {
            get { return utl_mail; }
            set { utl_mail = value; }
        }

        [Column("utl_pwd", TypeName = "varchar")]
        [StringLength(64)]
        public String? Pwd
        {
            get { return utl_pwd; }
            set { utl_pwd = value; }
        }

        [Column("utl_rue", TypeName = "varchar")]
        [StringLength(200)]
        public String? Rue
        {
            get { return utl_rue; }
            set { utl_rue = value; }
        }

        [Column("utl_cp", TypeName = "char(5)")]
        public String? CodePostal
        {
            get { return utl_cp; }
            set { utl_cp = value; }
        }

        [Column("utl_ville", TypeName = "varchar")]
        [StringLength(50)]
        public String? Ville
        {
            get { return utl_ville; }
            set { utl_ville = value; }
        }

        [Column("utl_pays", TypeName = "varchar")]
        [StringLength(50)]
        public String? Pays
        {
            get { return utl_pays; }
            set { utl_pays = value; }
        }

        [Column("utl_latitude", TypeName = "real")]
        public float? Latitude
        {
            get { return utl_latitude; }
            set { utl_latitude = value; }
        }

        [Column("utl_longitude", TypeName = "real")]
        public float? Longitude
        {
            get { return utl_longitude; }
            set { utl_longitude = value; }
        }

        [Column("utl_datecreation", TypeName = "date")]
        public DateTime DateCreation
        {
            get { return utl_datecreation; }
            set { utl_datecreation = value; }
        }

        public virtual ICollection<T_J_NOTATION_NOT> NotesUtilisateur { get; set; }

        protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<T_E_UTILISATEUR_UTL>(entity =>
            {
                entity.HasIndex(u => u.Mail).IsUnique();

                entity.Property(u => u.DateCreation).HasDefaultValue("now()");

                entity.Property(u => u.Pays).HasDefaultValue("France");
            });
        }
    }
}
