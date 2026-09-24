using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RpgApi.Models.Enuns;
using RpgApi.Models;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace RpgApi.Data
{
    public class DataContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ConfigureWarnings(warnings => warnings
                .Ignore(RelationalEventId.PendingModelChangesWarning));
        }
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {

        }

       
        public DbSet<Armas> TB_ARMAS { get; set; }

        public DbSet<Personagem> TB_PERSONAGENS { get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
       
            modelBuilder.Entity<Armas>().ToTable("TB_ARMAS");

           
            modelBuilder.Entity<Armas>().HasData
            (
                new Armas() { Id = 1, Nome = "Graveto", Dano = 10, Classe = ClasseEnumArmas.Fraca},
                new Armas() { Id = 2, Nome = "Espada de Madeira", Dano = 20, Classe = ClasseEnumArmas.Fraca},
                new Armas() { Id = 3, Nome = "Espada de Ferro", Dano = 40, Classe = ClasseEnumArmas.Media},
                new Armas() { Id = 4, Nome = "Espada da Realeza", Dano = 60, Classe = ClasseEnumArmas.Media},
                new Armas() { Id = 5, Nome = "Espada Encantada", Dano = 100, Classe = ClasseEnumArmas.Forte},
                new Armas() { Id = 6, Nome = "Chinelo da Mãe", Dano = 999, Classe = ClasseEnumArmas.Secreta}
            );

           
            modelBuilder.Entity<Personagem>().ToTable("TB_PERSONAGENS");

            modelBuilder.Entity<Personagem>().HasData
            (
                new Personagem() { Id = 1, Nome = "Frodo", PontosVida = 100, Forca = 17, Defesa = 23, Inteligencia = 33, Classe = ClasseEnum.Cavaleiro },
                new Personagem() { Id = 2, Nome = "Sam", PontosVida = 100, Forca = 15, Defesa = 25, Inteligencia = 30, Classe = ClasseEnum.Cavaleiro },
                new Personagem() { Id = 3, Nome = "Galadriel", PontosVida = 100, Forca = 18, Defesa = 21, Inteligencia = 35, Classe = ClasseEnum.Clerigo },
                new Personagem() { Id = 4, Nome = "Gandalf", PontosVida = 100, Forca = 18, Defesa = 18, Inteligencia = 37, Classe = ClasseEnum.Mago },
                new Personagem() { Id = 5, Nome = "Hobbit", PontosVida = 100, Forca = 20, Defesa = 17, Inteligencia = 31, Classe = ClasseEnum.Cavaleiro },
                new Personagem() { Id = 6, Nome = "Celeborn", PontosVida = 100, Forca = 21, Defesa = 13, Inteligencia = 34, Classe = ClasseEnum.Clerigo },
                new Personagem() { Id = 7, Nome = "Radagast", PontosVida = 100, Forca = 25, Defesa = 11, Inteligencia = 35, Classe = ClasseEnum.Mago }
            );
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<string>()
                .HaveColumnType("varchar").HaveMaxLength(200);
        }
    }
}
