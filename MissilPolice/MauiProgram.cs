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

            // DB Setup
            var dbPath = @"c:\Users\Hamid Aurangzaib\source\repos\MissilPolice\DB.sqlite";
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite($"Data Source={dbPath}"));

            builder.Services.AddScoped<CaseService>();

#if DEBUG
    		builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
