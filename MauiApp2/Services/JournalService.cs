using MauiApp2.Data;
using MauiApp2.Models;
using Microsoft.EntityFrameworkCore;

namespace MauiApp2.Services
{
    public class JournalService
    {
        private readonly AppDbContext _context;

        public JournalService(AppDbContext context)
        {
            _context = context;
        }

        // --- ADD THIS METHOD ---
        public async Task<List<JournalEntry>> GetAllEntriesForUser(int userId)
        {
            return await _context.JournalEntries
                .Where(j => j.UserId == userId)
                .OrderByDescending(j => j.EntryDate) // Shows newest at the top
                .ToListAsync();
        }

        // --- ADD THIS METHOD ---
        public async Task DeleteEntry(JournalEntry entry)
        {
            _context.JournalEntries.Remove(entry);
            await _context.SaveChangesAsync();
        }

        public async Task<JournalEntry?> GetEntryByDate(int userId, DateTime date)
        {
            var targetDate = date.Date;
            return await _context.JournalEntries
                .FirstOrDefaultAsync(j => j.UserId == userId && j.EntryDate.Date == targetDate);
        }

        public async Task SaveOrUpdateEntry(JournalEntry entry)
        {
            if (string.IsNullOrWhiteSpace(entry.SecondaryMood1)) entry.SecondaryMood1 = null;
            if (string.IsNullOrWhiteSpace(entry.SecondaryMood2)) entry.SecondaryMood2 = null;
            try
            {
                var existingEntry = await GetEntryByDate(entry.UserId, entry.EntryDate);

                if (existingEntry != null)
                {
                    _context.JournalEntries.Update(existingEntry);
                }
                else
                {
                    _context.JournalEntries.Add(entry);
                }

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // LOOK AT YOUR "OUTPUT" WINDOW IN VISUAL STUDIO FOR THIS:
                var innerMsg = ex.InnerException?.Message ?? "No inner exception";
                System.Diagnostics.Debug.WriteLine($"CRITICAL DATABASE ERROR: {ex.Message}");
                System.Diagnostics.Debug.WriteLine($"INNER ERROR: {innerMsg}");
                throw;
            }
        }
    }
}
