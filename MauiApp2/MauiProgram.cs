using MauiApp2.Data;
using MauiApp2.Services;
using Microsoft.EntityFrameworkCore;

namespace MauiApp2;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();

        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });

        builder.Services.AddMauiBlazorWebView();

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
#endif
        var dbPath = Path.Combine(FileSystem.AppDataDirectory, "app.db");
        builder.Services.AddDbContextFactory<AppDbContext>(options =>
            options.UseSqlite($"Data Source={dbPath}")
        );

// Create DB once safely
        using var scope = builder.Services.BuildServiceProvider().CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        db.Database.EnsureCreated();

        builder.Services.AddSingleton<AuthService>();
        builder.Services.AddDbContext<AppDbContext>();
        builder.Services.AddScoped<JournalService>();
        return builder.Build();
    }
}
