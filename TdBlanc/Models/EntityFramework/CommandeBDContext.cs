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
        public DbSet<Utilisateur> Utilisateurs { get; set; }

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
            modelBuilder.Entity<Commande>(entity =>
            {
                entity.ToTable("T_E_COMMANDE_COM");

                entity.HasKey(e => e.IdCommande);

                entity.Property(e => e.IdCommande)
                      .ValueGeneratedOnAdd()
                      .UseIdentityColumn();

                // Configuration de la relation avec clé étrangère explicite
                entity.HasOne(c => c.CommandeUtlisateurNavigation)
                      .WithMany(u => u.Commandes)
                      .HasForeignKey(c => c.UtilisateurId)  // AJOUT IMPORTANT
                      .OnDelete(DeleteBehavior.Restrict)     // Changé de ClientSetNull à Restrict
                      .HasConstraintName("FK_T_E_COMMANDE_COM_T_E_UTILISATEUR_UTI");
            });

            modelBuilder.Entity<Utilisateur>(entity =>
            {
                entity.ToTable("T_E_UTILISATEUR_UTI");

                entity.HasKey(e => e.IdUtilisateur);

                entity.Property(e => e.IdUtilisateur)
                      .ValueGeneratedOnAdd()
                      .UseIdentityColumn();
            });

            modelBuilder.HasDefaultSchema("public");
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}