using MauiApp2.Models;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace MauiApp2.Data
{
    public class AppDbContext : DbContext
    {
        // Tables
        public DbSet<User> Users => Set<User>();
        public DbSet<JournalEntry> JournalEntries => Set<JournalEntry>();

        // Constructor: takes options from DI
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            // DO NOT call EnsureCreated here
            // This prevents UI freeze on macOS
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure One User has Many JournalEntries
            modelBuilder.Entity<JournalEntry>()
                .HasOne(j => j.User)
                .WithMany() // or .WithMany(u => u.JournalEntries) if User has a collection
                .HasForeignKey(j => j.UserId);
        }
    }
}