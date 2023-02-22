using Microsoft.EntityFrameworkCore;

namespace API_Movie.Models.EntityFramework
{
    public class FilmRatingDBContext : DbContext
    {
        public static readonly ILoggerFactory Mylogs = LoggerFactory.Create(builder => builder.AddConsole());

        public FilmRatingDBContext() { }

        public virtual DbSet<T_E_FILM_FLM> FLM { get; set; }
        public virtual DbSet<T_E_UTILISATEUR_UTL> UTL { get; set; }
        public virtual DbSet<T_J_NOTATION_NOT> NOT { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLoggerFactory(Mylogs)
                    .EnableSensitiveDataLogging()
                    .UseNpgsql("Server=localhost; port=5432; Database=FilmsDB; uid=postgres; password=postgres;");
            }
        }
    }
}
