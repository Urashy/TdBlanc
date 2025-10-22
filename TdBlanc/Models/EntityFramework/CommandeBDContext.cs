using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Intrinsics.X86;
using Microsoft.EntityFrameworkCore;

namespace TdBlanc.Models.EntityFramework
{
    public partial class CommandeBDContext : DbContext
    {
        public DbSet<Commande> Commandes { get; set; }
        public DbSet<Animal> Animaux { get; set; }

        public CommandeBDContext()
        {
        }

        public CommandeBDContext(DbContextOptions<CommandeBDContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Animal>(entity =>
            {
                entity.ToTable("T_E_ANIMAL_ANI");

                entity.HasKey(e => e.IdAnnimal);

                entity.Property(e => e.IdAnnimal)
                      .ValueGeneratedOnAdd()
                      .UseIdentityColumn();
            });

                modelBuilder.HasDefaultSchema("public");
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}