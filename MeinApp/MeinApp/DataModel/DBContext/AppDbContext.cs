using System;
using System.IO;
using MeinApp.DataModel.DataForm;
using Microsoft.EntityFrameworkCore;

namespace MeinApp.DataModel.DBContext
{
    public class AppDbContext : DbContext
    {
        public DbSet<FrageStr> Fragen { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var folder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            Directory.CreateDirectory(folder);
            var dbPath = Path.Combine(folder, "Fragen.db");
            optionsBuilder.UseSqlite($"Data Source={dbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FrageStr>()
                .Property(f => f.ArtDerFrage)
                .HasConversion<string>(); // Enum → TEXT
        }
    }
}