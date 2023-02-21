using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace API_Movie.Models.EntityFramework
{
    [Table("T_E_FILM_FLM")]
    public class T_E_FILM_FLM
    {
        private int flm_id;
        private String flm_titre = null!;
        private String flm_resume;
        private DateTime flm_datesortie;
        private decimal flm_duree;
        private String flm_genre;

        public T_E_FILM_FLM()
        {
            NotesFilm = new HashSet<T_J_NOTATION_NOT>();
        }

        [Key]
        [Column("flm_id")]
        public int FilmId
        {
            get { return flm_id; }
            set { flm_id = value; }
        }

        [Column("flm_titre",TypeName="varchar")]
        [StringLength(100)]
        public String Titre
        {
            get { return flm_titre; }
            set { flm_titre = value; }
        }

        [Column("flm_resume", TypeName = "text")]
        public String Resume
        {
            get { return flm_resume; }
            set { flm_resume = value; }
        }

        [Column("flm_datesortie", TypeName = "date")]
        public DateTime DateSortie
        {
            get { return flm_datesortie; }
            set { flm_datesortie = value; }
        }

        [Column("flm_duree", TypeName = "numeric(3,0)")]
        public decimal Duree
        {
            get { return flm_duree; }
            set { flm_duree = value; }
        }

        [Column("flm_genre", TypeName = "varchar")]
        [StringLength(30)]
        public String Genre
        {
            get { return flm_genre; }
            set { flm_genre = value; }
        }

        public virtual ICollection<T_J_NOTATION_NOT> NotesFilm { get; set; }
    }
}