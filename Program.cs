using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ClaimProcessing.Data;
using ClaimProcessing.Models;
using ClaimProcessing;

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
                var connectionString = context.Configuration.GetConnectionString("DefaultConnection");

                /* Uncomment this for use Sqlite */
                // services.AddDbContext<DataContext>(options => options.UseSqlite("Data Source=ClaimProcessingDb.sqlite"));

                services.AddDbContext<DataContext>(options => options.UseSqlServer(connectionString));

                services.AddTransient<SeedDB>();
                services.AddTransient<ClaimProcessor>();
                services.AddTransient<HospitalRateService>();
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
            var hospitalRateService = services.GetRequiredService<HospitalRateService>();

            Console.WriteLine("Type the Member's Date of Birth (M/D/YYYY) and hit enter: ");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime dob))
            {
                Console.WriteLine($"Date of Birth: {dob.ToShortDateString()}");
            }
            else
            {
                Console.WriteLine("Invalid Date.");
            }
            Console.WriteLine("\n");

            Console.WriteLine("Type the Date of Admission (M/D/YYYY) and hit enter: ");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime admissionDate))
            {
                Console.WriteLine($"Date of Admission: {admissionDate.ToShortDateString()}");
            }
            else
            {
                Console.WriteLine("Invalid Date.");
            }
            Console.WriteLine("\n");

            Console.WriteLine("Type the Date of Discharge (M/D/YYYY) and hit enter: ");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime dischargeDate))
            {
                Console.WriteLine($"Date of Discharge: {dischargeDate.ToShortDateString()}");
            }
            else
            {
                Console.WriteLine("Invalid Date.");
            }
            Console.WriteLine("\n");

            Console.WriteLine("Type the Facility NPI and hit enter: ");
            if (int.TryParse(Console.ReadLine(), out int npi))
            {
                Console.WriteLine($"Facility NPI: {npi}");
            }
            else
            {
                Console.WriteLine("Invalid format.");
            }
            Console.WriteLine("\n");

            Console.WriteLine("Type the Total Amount Billed and hit enter: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal totalAmount))
            {
                Console.WriteLine($"Total Amount: {totalAmount}");
            }
            else
            {
                Console.WriteLine("Invalid format.");
            }
            Console.WriteLine("\n");

            Console.WriteLine("Type the APR DRG-SOI (XXX-X) and hit enter: ");
            string? apr = Console.ReadLine();

            var hospitalRates = hospitalRateService.SearchHospitalRates(npi, admissionDate, dischargeDate);

            foreach (var rate in hospitalRates)
            {
                Console.WriteLine(
                    $"Provider Name: {rate.ProviderName}, " +
                    $"Hospital Physical Street Address: {rate.HospitalPhysicalStreetAddress}, " +
                    $"Hospital Class: {rate.HospitalClass}, " +
                    $"SDA: {rate.SDA}, " +
                    $"Delivery SDA: {rate.DeliverySDA}, " +
                    $"PPR/PPC: {rate.PPR_PPC}, " +
                    $"CHIRP Rate: {rate.CHIRP_Rate}"
                );
            }

            decimal reimbursementAmount = CalculateReimbursement(dob, admissionDate, dischargeDate, npi, totalAmount, apr, hospitalRateService);
            Console.WriteLine($"Calculated Reimbursement Amount: {reimbursementAmount}");

            await processor.ProcessClaim();
        }

        return 0; // Indicate the app is finished successfully
    }

    public static decimal CalculateReimbursement(DateTime dob, DateTime admissionDate, DateTime dischargeDate, int npi, decimal totalAmount, string apr, HospitalRateService hospitalRateService)
    {
        // Implement the logic to calculate reimbursement amount based on the given parameters
        // This is a placeholder logic; actual logic will depend on the business rules from the attached document

        // Example placeholder logic:
        var hospitalRates = hospitalRateService.SearchHospitalRates(npi, admissionDate, dischargeDate);

        decimal reimbursementAmount = 0;
        foreach (var rate in hospitalRates)
        {
            // Assume some calculation here based on the retrieved rates and other parameters
            reimbursementAmount += rate.CHIRP_Rate; // This is a placeholder
        }

        return reimbursementAmount;
    }
}
