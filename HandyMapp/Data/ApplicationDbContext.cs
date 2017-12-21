using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using HandyMapp.Models;
using HandyMapp.Models.Navigation;
using HandyMapp.Models.AddressModels;

namespace HandyMapp.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public virtual DbSet<Example> Example { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<PostCode> PostCodes { get; set; }
        public virtual DbSet<Province> Provinces { get; set; }
        public virtual DbSet<Street> Streets { get; set; }

        public virtual DbSet<Vector> Vectors { get; set; }
        public virtual DbSet<VectorPath> VectorPaths { get; set; }
        public virtual DbSet<Obstacle> Obstacles { get; set; }
        public virtual DbSet<ReviewPlace> ReviewAddress { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Address>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.PlaceId).IsRequired();

                entity.Property(e => e.StreetNumber)
                    .IsRequired()
                    .HasColumnType("nchar(10)");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Address)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Address_City");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Address)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Address_Country");

                entity.HasOne(d => d.PostCode)
                    .WithMany(p => p.Address)
                    .HasForeignKey(d => d.PostCodeId)
                    .HasConstraintName("FK_Address_PostCode");

                entity.HasOne(d => d.Province)
                    .WithMany(p => p.Address)
                    .HasForeignKey(d => d.ProvinceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Address_Province");

                entity.HasOne(d => d.Street)
                    .WithMany(p => p.Address)
                    .HasForeignKey(d => d.StreetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Address_Street");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.LongName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ShortName).HasColumnType("nchar(10)");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.LongName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ShortName).HasColumnType("nchar(10)");
            });

            modelBuilder.Entity<Obstacle>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Vector)
                    .WithMany(p => p.Obstacle)
                    .HasForeignKey(d => d.VectorId)
                    .HasConstraintName("FK_Obstacle_Vector");
            });

            modelBuilder.Entity<PostCode>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.PostCode1)
                    .IsRequired()
                    .HasColumnName("PostCode")
                    .HasColumnType("nchar(10)");
            });

            modelBuilder.Entity<Province>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.LongName)
                    .IsRequired()
                    .HasColumnType("nchar(10)");

                entity.Property(e => e.ShortName).HasColumnType("nchar(10)");
            });

            modelBuilder.Entity<Street>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.LongName).HasMaxLength(50);
            });

            modelBuilder.Entity<Vector>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<VectorPath>(entity =>
            {
                entity.HasKey(e => new { e.VectorId1, e.VectorId2 });

                entity.HasOne(d => d.VectorId1Navigation)
                    .WithMany(p => p.VectorPathVectorId1Navigation)
                    .HasForeignKey(d => d.VectorId1)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VectorPath_Vector");

                entity.HasOne(d => d.VectorId2Navigation)
                    .WithMany(p => p.VectorPathVectorId2Navigation)
                    .HasForeignKey(d => d.VectorId2)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VectorPath_Vector1");
            });
        }
    }
}