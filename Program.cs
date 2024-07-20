using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ClaimProcessing.Data;

public class Program
{
    public static async Task<int> Main(string[] args)
    {
        var host = Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((context, config) =>
            {
                config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            })
            .ConfigureServices((context, services) =>
            {
                var connectionString = context.Configuration
                                              .GetConnectionString("DefaultConnection");

                /*Uncomment this for use Sqlite*/
                // services.AddDbContext<DataContext>(options => 
                //     options.UseSqlite(connectionString));
                
                services.AddDbContext<DataContext>(options => 
                    options.UseSqlServer(connectionString));

                services.AddTransient<SeedDB>();
                services.AddTransient<ClaimProcessor>();
            }).Build();

        using (var scope = host.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            var seeder = services.GetRequiredService<SeedDB>();
            
            await seeder.SeedAsync();
        }

        using (var scope = host.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            var processor = services.GetRequiredService<ClaimProcessor>();
            
            await processor.ProcessClaim();
        }

        return 0; // Indicate the app is finished successfully
    }
}