using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoCatalogMini.Data.Entities;

namespace PhotoCatalogMini.Data
{
    public class PhotoCatalogDbContext : DbContext
    {
        public PhotoCatalogDbContext(DbContextOptions<PhotoCatalogDbContext> options) : base(options)
        {

        }

        public DbSet<Photographer> Photographers => Set<Photographer>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Photo> Photos => Set<Photo>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Photographer>(entity =>
            {
                entity.HasKey(p => p.PhotographerId);
                entity.Property(p => p.Name).IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(c => c.CategoryId);
                entity.Property(c => c.Name).IsRequired().HasMaxLength(50);
                entity.HasIndex(c => c.Name).IsUnique();
            });

            modelBuilder.Entity<Photo>(entity =>
            {
                entity.HasKey(e => e.PhotoId);
                entity.Property(e => e.Title).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Location).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Description).IsRequired().HasMaxLength(500);

                entity.HasOne(p => p.Photographer)
                      .WithMany(ph => ph.Photos)
                      .HasForeignKey(p => p.PhotographerId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(p => p.Category)
                      .WithMany(c => c.Photos)
                      .HasForeignKey(p => p.CategoryId)
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
