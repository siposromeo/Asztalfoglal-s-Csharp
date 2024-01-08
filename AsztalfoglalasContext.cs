using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asztalfoglalas
{
    public class AsztalfoglalasContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Server=localhost;Database=AsztalFoglalas14f;Uid=root;Pwd=", ServerVersion.AutoDetect("Server=localhost;Database=AsztalFoglalas14f;Uid=root;Pwd="));
        }
        public DbSet<Asztal> Asztal {  get; set; }
        public DbSet<Foglalas> Foglalas { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Asztal>().HasData(
                new Asztal() { Id = 1, Megnevezes = "1-es asztal", Ferohely = 6 },
                new Asztal() { Id = 2, Megnevezes = "2-es asztal", Ferohely = 3 },
                new Asztal() { Id = 3, Megnevezes = "3-es asztal", Ferohely = 4 },
                new Asztal() { Id = 4, Megnevezes = "4-es asztal", Ferohely = 5 },
                new Asztal() { Id = 5, Megnevezes = "5-es asztal", Ferohely = 8 }
            ) ;
            modelBuilder.Entity<Foglalas>().HasData(
                new Foglalas() { ID=1, AsztalID=1, Datum=DateTime.Parse("2023.12.15"), Letszam=3, Nev="Soós Gábor", Telefonszam="06201231234"},
                new Foglalas() { ID=2, AsztalID=3, Datum=DateTime.Parse("2023.12.22"), Letszam=2, Nev="Nits László", Telefonszam="06201231230"}
                );
        }
    }
}
