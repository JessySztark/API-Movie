using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace API_Movie.Models.EntityFramework
{
    [Table("T_J_NOTATION_NOT")]
    public partial class T_J_NOTATION_NOT
    {
        private int utl_id;
        private int flm_id;
        private int not_note;

        [Key]
        [InverseProperty("utl_id")]
        public int UtilisateurId
        {
            get { return utl_id; }
            set { utl_id = value; }
        }

        [Key]
        [InverseProperty("flm_id")]
        public int FilmId
        {
            get { return flm_id; }
            set { flm_id = value; }
        }
        // Coucou c'est moi
        [Column("not_note", TypeName = "int")]
        [Range(0,5)]
        public int Note
        {
            get { return not_note; }
            set { not_note = value; }
        }

        [ForeignKey("T_E_UTILISATEUR_UTL")]
        [InverseProperty("NotesUtilisateur")]
        public virtual T_E_UTILISATEUR_UTL UtilisateurNotant { get; set; }

        [ForeignKey("T_E_FILM_FLM")]
        [InverseProperty("NotesFilm")]
        public virtual T_E_FILM_FLM FilmNote { get; set; }

        protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<T_J_NOTATION_NOT>(entity =>
            {
                entity.HasKey(n => new { n.FilmId, n.UtilisateurId }).HasName("pk_notation_flmid_utlid");
                
                entity.HasOne(n => n.FilmNote)
                .WithMany(f => f.NotesFilm)
                .HasForeignKey(n => n.FilmId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_not_flm");
            });

            modelBuilder.Entity<T_J_NOTATION_NOT>(entity =>
            {
                entity.HasOne(n => n.UtilisateurNotant)
                .WithMany(f => f.NotesUtilisateur)
                .HasForeignKey(n => n.UtilisateurId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_not_utl");
            });
        }
    }
}
