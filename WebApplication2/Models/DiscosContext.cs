using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class DiscosContext : DbContext
    {
        public DbSet<Grupo> Grupos { get; set; } //Taula
        public DbSet<Disco> Discos { get; set; } //Taula

        public DiscosContext()
        {
        }
        
        public DiscosContext(DbContextOptions options)
        : base(options)
        {
        }

        //Mètode de configuració
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {            
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("Server=localhost;Database=musica2;Uid=root;Pwd=''; SslMode = none");//màquina retos
               
            }
        }

        //Inserció inicial de dades
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Grupo>().HasData(new Grupo(1, "Iron Maiden"));
            modelBuilder.Entity<Grupo>().HasData(new Grupo(2, "Gamma Ray"));
            modelBuilder.Entity<Grupo>().HasData(new Grupo(3, "Stratovarius"));
            modelBuilder.Entity<Disco>().HasData(new Disco(1, "The number of the beast",1982,1));
            modelBuilder.Entity<Disco>().HasData(new Disco(2, "Land of the free", 1998, 2));
        }
    }
}