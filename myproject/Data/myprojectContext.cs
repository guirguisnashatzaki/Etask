using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using myproject.Models;

namespace myproject.Data
{
    public partial class myprojectContext : DbContext
    {
        public myprojectContext()
        {
        }

        public myprojectContext(DbContextOptions<myprojectContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Country> Countries { get; set; } = null!;
        public virtual DbSet<Population> Populations { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(e => e.Country1)
                    .HasName("PRIMARY");

                entity.ToTable("country");

                entity.Property(e => e.Country1)
                    .HasMaxLength(30)
                    .HasColumnName("country");

                entity.Property(e => e.Ccode)
                    .HasMaxLength(10)
                    .HasColumnName("ccode");

                entity.Property(e => e.Iso3)
                    .HasMaxLength(10)
                    .HasColumnName("iso3");
            });

            modelBuilder.Entity<Population>(entity =>
            {
                entity.HasKey(e => e.Myyear)
                    .HasName("PRIMARY");

                entity.ToTable("population");

                entity.HasIndex(e => e.Country, "country");

                entity.Property(e => e.Myyear)
                    .ValueGeneratedNever()
                    .HasColumnName("myyear");

                entity.Property(e => e.Country)
                    .HasMaxLength(30)
                    .HasColumnName("country");

                entity.Property(e => e.Myvalue).HasColumnName("myvalue");

                entity.HasOne(d => d.CountryNavigation)
                    .WithMany(p => p.Populations)
                    .HasForeignKey(d => d.Country)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("population_ibfk_1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
