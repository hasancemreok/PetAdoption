using Microsoft.EntityFrameworkCore;
using PetAdoption.Core.Entities;
using PetAdoption.Core.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetAdoption.Persistence.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Shelter> Shelters { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Tutor> Tutors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Shelter>().HasKey(m => m.Id);
            modelBuilder.Entity<Shelter>()
                .Property(m => m.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Shelter>()
                .Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(250);

            modelBuilder.Entity<Tutor>().HasKey(m => m.Id);
            modelBuilder.Entity<Tutor>()
                .Property(m => m.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Tutor>()
                .Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(250);

            modelBuilder.Entity<Animal>().HasKey(m => m.Id);
            modelBuilder.Entity<Animal>()
                .Property(m => m.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Animal>()
                .Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(250);

            modelBuilder.Entity<Animal>()
                .Property(c => c.Status)
                .HasConversion(
                    d => d.ToString(),
                    d => Enum.Parse<AnimalStatus>(d)
                );

            modelBuilder.Entity<Animal>()
                .Property(c => c.Type)
                .HasConversion(
                    d => d.ToString(),
                    d => Enum.Parse<AnimalType>(d)
                );

            //relations

            modelBuilder.Entity<Shelter>()
               .HasMany(c => c.Animals)
               .WithOne(e => e.Shelter)
               .HasForeignKey(a => a.ShelterId);

            // seed

            modelBuilder.Entity<Shelter>().HasData(
                new
                {
                    Id = Guid.NewGuid(),
                    Name = "Shelter 1",
                    Email = "shelter1@abc.com",
                    Phone = "+902120010101",
                    Manager = "Manager Of Shelter1",
                },

                new Shelter
                {
                    Id = Guid.Parse("2c967af1-4bf4-4332-9b8a-b5b9fc699245"),
                    Name = "Shelter 2",
                    Email = "shelter2@abc.com",
                    Phone = "+902120020202",
                    Manager = "Manager Of Shelter2",
                }
            );

            modelBuilder.Entity<Animal>().HasData(
                new
                {
                    Id = Guid.NewGuid(),
                    Name = "Kitty",
                    Type = AnimalType.CAT,
                    Status = AnimalStatus.AVAILABLE,
                    ShelterId = Guid.Parse("2c967af1-4bf4-4332-9b8a-b5b9fc699245")
                },

                new
                {
                    Id = Guid.NewGuid(),
                    Name = "Dost",
                    Type = AnimalType.DOG,
                    Status = AnimalStatus.AVAILABLE,
                    ShelterId = Guid.Parse("2c967af1-4bf4-4332-9b8a-b5b9fc699245")
                }
            );

            modelBuilder.Entity<Tutor>().HasData(
                new
                {
                    Id = Guid.NewGuid(),
                    Name = "Tutor 1",
                    Phone = "+902120030303",
                    Email = "tutor1@abc.com",
                },

                new
                {
                    Id = Guid.NewGuid(),
                    Name = "Tutor 2",
                    Phone = "+902120040404",
                    Email = "tutor2@abc.com"
                }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
