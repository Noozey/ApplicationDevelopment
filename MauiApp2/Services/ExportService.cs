using MauiApp2.Models;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
// Use an alias to resolve the ambiguity
using QuestColors = QuestPDF.Helpers.Colors;

namespace MauiApp2.Services
{
    public class ExportService
    {
        public byte[] GenerateJournalPdf(List<JournalEntry> entries)
        {
            QuestPDF.Settings.License = LicenseType.Community;

            return Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(1, Unit.Inch);

                    // Fixed the Color reference using the alias
                    page.Header().Text("My Journal Entries")
                        .FontSize(24)
                        .SemiBold()
                        .FontColor(QuestColors.Blue.Medium);

                    page.Content().PaddingVertical(10).Column(col =>
                    {
                        // Set spacing between items in the column directly
                        col.Spacing(15);

                        foreach (var entry in entries)
                        {
                            col.Item().BorderBottom(1).PaddingBottom(5).Column(entryCol =>
                            {
                                entryCol.Item().Text(entry.EntryDate.ToString("MMMM dd, yyyy"))
                                    .FontSize(14)
                                    .Bold();

                                entryCol.Item().Text($"Mood: {entry.PrimaryMood}")
                                    .Italic()
                                    .FontSize(10)
                                    .FontColor(QuestColors.Grey.Medium);

                                // Strip HTML tags for the PDF
                                var plainText = System.Text.RegularExpressions.Regex.Replace(entry.Content, "<.*?>", string.Empty);
                                entryCol.Item().Text(plainText);
                            });
                        }
                    });

                    page.Footer().AlignCenter().Text(x =>
                    {
                        x.Span("Page ");
                        x.CurrentPageNumber();
                    });
                });
            }).GeneratePdf();
        }
    }
}