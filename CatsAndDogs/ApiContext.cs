using CatsAndDogs.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatsAndDogs
{
    public class ApiContext : DbContext
    {
        public DbSet<Owner> OwnerTable { get; set; }
        public DbSet<Cats> CatsTable { get; set; }
        public DbSet<Dogs> DogsTable { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("DB_CONN"));

        private void PetsModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cats>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.ToTable("Cats");
            });

            modelBuilder.Entity<Dogs>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.ToTable("Dogs");
            });

            modelBuilder.Entity<Cats>()
               .HasOne(x => x.Owner)
               .WithMany(x => x.Cats)
               .HasForeignKey(x => x.OwnerId);

            modelBuilder.Entity<Dogs>()
              .HasOne(x => x.Owner)
              .WithMany(x => x.Dogs)
              .HasForeignKey(x => x.OwnerId);
        }

        private void OwnerModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Owner>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.ToTable("Owner");
            });

            modelBuilder.Entity<Owner>()
                .HasMany(x => x.Dogs)
                .WithOne(x => x.Owner);

            modelBuilder.Entity<Owner>()
                .HasMany(x => x.Cats)
                .WithOne(x => x.Owner);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OwnerModel(modelBuilder);
            PetsModel(modelBuilder);
        }
    }
}
