// <auto-generated />
using System;
using API_Movie.Models.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace API_Movie.Migrations
{
    [DbContext(typeof(FilmRatingDBContext))]
    partial class FilmRatingDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("API_Movie.Models.EntityFramework.T_E_FILM_FLM", b =>
                {
                    b.Property<int>("FilmId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("flm_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("FilmId"));

                    b.Property<DateTime>("DateSortie")
                        .HasColumnType("date")
                        .HasColumnName("flm_datesortie");

                    b.Property<decimal>("Duree")
                        .HasColumnType("numeric(3,0)")
                        .HasColumnName("flm_duree");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar")
                        .HasColumnName("flm_genre");

                    b.Property<string>("Resume")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("flm_resume");

                    b.Property<string>("Titre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("flm_titre");

                    b.HasKey("FilmId");

                    b.ToTable("T_E_FILM_FLM");
                });

            modelBuilder.Entity("API_Movie.Models.EntityFramework.T_E_UTILISATEUR_UTL", b =>
                {
                    b.Property<int>("UtilisateurId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("utl_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UtilisateurId"));

                    b.Property<string>("CodePostal")
                        .HasColumnType("char(5)")
                        .HasColumnName("utl_cp");

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("date")
                        .HasColumnName("utl_datecreation");

                    b.Property<float?>("Latitude")
                        .HasColumnType("real")
                        .HasColumnName("utl_latitude");

                    b.Property<float?>("Longitude")
                        .HasColumnType("real")
                        .HasColumnName("utl_longitude");

                    b.Property<string>("Mail")
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("utl_mail");

                    b.Property<string>("Mobile")
                        .HasColumnType("char(10)")
                        .HasColumnName("utl_mobile");

                    b.Property<string>("Nom")
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasColumnName("utl_nom");

                    b.Property<string>("Pays")
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasColumnName("utl_pays");

                    b.Property<string>("Prenom")
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasColumnName("utl_prenom");

                    b.Property<string>("Pwd")
                        .HasMaxLength(64)
                        .HasColumnType("varchar")
                        .HasColumnName("utl_pwd");

                    b.Property<string>("Rue")
                        .HasMaxLength(200)
                        .HasColumnType("varchar")
                        .HasColumnName("utl_rue");

                    b.Property<string>("Ville")
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasColumnName("utl_ville");

                    b.HasKey("UtilisateurId");

                    b.ToTable("T_E_UTILISATEUR_UTL");
                });

            modelBuilder.Entity("API_Movie.Models.EntityFramework.T_J_NOTATION_NOT", b =>
                {
                    b.Property<int>("UtilisateurId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UtilisateurId"));

                    b.Property<int>("FilmId")
                        .HasColumnType("integer");

                    b.Property<int>("Note")
                        .HasColumnType("int")
                        .HasColumnName("not_note");

                    b.Property<int>("T_E_FILM_FLM")
                        .HasColumnType("integer");

                    b.Property<int>("T_E_UTILISATEUR_UTL")
                        .HasColumnType("int");

                    b.HasKey("UtilisateurId");

                    b.HasIndex("T_E_FILM_FLM");

                    b.HasIndex("T_E_UTILISATEUR_UTL");

                    b.ToTable("T_J_NOTATION_NOT");
                });

            modelBuilder.Entity("API_Movie.Models.EntityFramework.T_J_NOTATION_NOT", b =>
                {
                    b.HasOne("API_Movie.Models.EntityFramework.T_E_FILM_FLM", "FilmNote")
                        .WithMany("NotesFilm")
                        .HasForeignKey("T_E_FILM_FLM")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API_Movie.Models.EntityFramework.T_E_UTILISATEUR_UTL", "UtilisateurNotant")
                        .WithMany("NotesUtilisateur")
                        .HasForeignKey("T_E_UTILISATEUR_UTL")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FilmNote");

                    b.Navigation("UtilisateurNotant");
                });

            modelBuilder.Entity("API_Movie.Models.EntityFramework.T_E_FILM_FLM", b =>
                {
                    b.Navigation("NotesFilm");
                });

            modelBuilder.Entity("API_Movie.Models.EntityFramework.T_E_UTILISATEUR_UTL", b =>
                {
                    b.Navigation("NotesUtilisateur");
                });
#pragma warning restore 612, 618
        }
    }
}
