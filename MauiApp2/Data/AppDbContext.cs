namespace MauiApp2.Data
{
    using MauiApp2.Models;
    using Microsoft.EntityFrameworkCore;

    public class AppDbContext : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<JournalEntry> JournalEntries => Set<JournalEntry>(); // Added this

        private readonly string _dbPath;

        public AppDbContext()
        {
            var folder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            _dbPath = Path.Combine(folder, "app.db");

            // Ensure database is created
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={_dbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the relationship: One User has Many JournalEntries
            modelBuilder.Entity<JournalEntry>()
                .HasOne(j => j.User)
                .WithMany() // Or .WithMany(u => u.JournalEntries) if you add a list to User model
                .HasForeignKey(j => j.UserId);
        }
    }
}
