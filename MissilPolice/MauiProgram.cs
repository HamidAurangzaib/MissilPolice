using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using MissilPolice.Data;
using MissilPolice.Services;

namespace MissilPolice
{
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

            // DB Setup - Use portable path that works on any machine
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "MissilPolice.db");
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite($"Data Source={dbPath}"));

            builder.Services.AddScoped<CaseService>();

#if DEBUG
    		builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            var app = builder.Build();

            // Initialize database on startup
            InitializeDatabase(app.Services);

            return app;
        }

        private static void InitializeDatabase(IServiceProvider services)
        {
            using var scope = services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            
            // Check if we need to migrate from old database location
            var oldDbPath = @"c:\Users\Hamid Aurangzaib\source\repos\MissilPolice\DB.sqlite";
            var newDbPath = Path.Combine(FileSystem.AppDataDirectory, "MissilPolice.db");
            
            // If old database exists and new one doesn't, copy it
            if (File.Exists(oldDbPath) && !File.Exists(newDbPath))
            {
                try
                {
                    // Ensure directory exists
                    Directory.CreateDirectory(FileSystem.AppDataDirectory);
                    
                    // Copy the old database to new location
                    File.Copy(oldDbPath, newDbPath, overwrite: false);
                    Console.WriteLine($"Migrated database from {oldDbPath} to {newDbPath}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error migrating database: {ex.Message}");
                }
            }
            
            // Ensure database is created (if it doesn't exist after migration attempt)
            context.Database.EnsureCreated();
        }
    }
}
