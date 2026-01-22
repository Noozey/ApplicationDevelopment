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

        public async Task<List<JournalEntry>> GetAllEntriesForUser(int userId)
        {
            return await _context.JournalEntries
                .AsNoTracking()
                .Where(j => j.UserId == userId)
                .OrderByDescending(j => j.EntryDate)
                .ToListAsync();
        }

        public async Task DeleteEntry(JournalEntry entry)
        {
            // Find and attach the entity if not tracked
            var tracked = _context.JournalEntries.Local.FirstOrDefault(e => e.EntryId == entry.EntryId);
            if (tracked != null)
            {
                _context.JournalEntries.Remove(tracked);
            }
            else
            {
                _context.JournalEntries.Remove(entry);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<JournalEntry?> GetEntryByDate(int userId, DateTime date)
        {
            var targetDate = date.Date;
            return await _context.JournalEntries
                .AsNoTracking()
                .FirstOrDefaultAsync(j => j.UserId == userId && j.EntryDate.Date == targetDate);
        }

        public async Task SaveOrUpdateEntry(JournalEntry entry)
        {
            if (string.IsNullOrWhiteSpace(entry.SecondaryMood1)) entry.SecondaryMood1 = null;
            if (string.IsNullOrWhiteSpace(entry.SecondaryMood2)) entry.SecondaryMood2 = null;

            try
            {
                // Check if there's already a tracked instance
                var trackedEntity = _context.JournalEntries.Local
                    .FirstOrDefault(e => e.EntryId == entry.EntryId);

                if (trackedEntity != null)
                {
                    // If already tracked, detach it first
                    _context.Entry(trackedEntity).State = EntityState.Detached;
                }

                // Now safely update or add
                if (entry.EntryId > 0)
                {
                    _context.JournalEntries.Update(entry);
                }
                else
                {
                    _context.JournalEntries.Add(entry);
                }

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                var innerMsg = ex.InnerException?.Message ?? "No inner exception";
                System.Diagnostics.Debug.WriteLine($"CRITICAL DATABASE ERROR: {ex.Message}");
                System.Diagnostics.Debug.WriteLine($"INNER ERROR: {innerMsg}");
                throw;
            }
        }
    }
}