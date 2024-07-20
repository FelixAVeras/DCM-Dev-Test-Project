using ClaimProcessing.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ClaimProcessing.Data;

public class SeedDB 
{
    private readonly DataContext _context;

    public SeedDB(DataContext context)
    {
        _context = context;
    }

    public async Task SeedAsync()
    {
        if (!_context.Claims.Any())
        {
            // Check if there any data on DB
            if (await _context.Claims.AnyAsync())
            {
                Console.WriteLine("La base de datos ya contiene datos.");
                
                return;
            }

            var claims = new List<Claim>
            {
                new() { ClaimId = 490521, Score = "720-4", NPI = "1548286172", DOB = new DateTime(2017, 12, 2), Age = 4, StartDate = new DateTime(2021, 11, 29), EndDate = new DateTime(2021, 12, 1), LOS = 2, TotalCharges = 452084.12M },
                new() { ClaimId = 490554, Score = "640-4", NPI = "1548286172", DOB = new DateTime(1958, 5, 2), Age = 64, StartDate = new DateTime(2022, 4, 13), EndDate = new DateTime(2022, 4, 16), LOS = 3, TotalCharges = 532604.65M },
                new() { ClaimId = 490558, Score = "639-1", NPI = "1477643690", DOB = new DateTime(1957, 4, 28), Age = 65, StartDate = new DateTime(2022, 4, 5), EndDate = new DateTime(2022, 4, 12), LOS = 7, TotalCharges = 77641.00M },
                new() { ClaimId = 490559, Score = "560-1", NPI = "1003885641", DOB = new DateTime(1942, 1, 10), Age = 80, StartDate = new DateTime(2021, 12, 5), EndDate = new DateTime(2021, 12, 21), LOS = 16, TotalCharges = 84852.09M },
                new() { ClaimId = 490560, Score = "720-4", NPI = "1447228747", DOB = new DateTime(1953, 5, 9), Age = 69, StartDate = new DateTime(2022, 4, 12), EndDate = new DateTime(2022, 4, 22), LOS = 10, TotalCharges = 88071.06M },
                new() { ClaimId = 490562, Score = "144-2", NPI = "1851343909", DOB = new DateTime(1955, 5, 6), Age = 67, StartDate = new DateTime(2022, 4, 15), EndDate = new DateTime(2022, 4, 19), LOS = 4, TotalCharges = 73615.37M },
                new() { ClaimId = 490563, Score = "137-4", NPI = "1043267701", DOB = new DateTime(2019, 4, 21), Age = 3, StartDate = new DateTime(2022, 4, 17), EndDate = new DateTime(2022, 4, 20), LOS = 3, TotalCharges = 122549.08M },
                new() { ClaimId = 490564, Score = "190-2", NPI = "1154618742", DOB = new DateTime(1948, 5, 4), Age = 74, StartDate = new DateTime(2022, 4, 15), EndDate = new DateTime(2022, 4, 16), LOS = 1, TotalCharges = 29722.92M },
                new() { ClaimId = 490565, Score = "196-3", NPI = "1548286172", DOB = new DateTime(1946, 5, 9), Age = 76, StartDate = new DateTime(2022, 4, 17), EndDate = new DateTime(2022, 4, 20), LOS = 3, TotalCharges = 405365.04M },
                new() { ClaimId = 490566, Score = "206-2", NPI = "1477643690", DOB = new DateTime(1954, 5, 5), Age = 68, StartDate = new DateTime(2022, 4, 16), EndDate = new DateTime(2022, 4, 18), LOS = 2, TotalCharges = 30106.89M },
                new() { ClaimId = 490567, Score = "282-4", NPI = "1003885641", DOB = new DateTime(1944, 1, 5), Age = 78, StartDate = new DateTime(2021, 12, 12), EndDate = new DateTime(2021, 12, 16), LOS = 4, TotalCharges = 26600.92M },
                new() { ClaimId = 490568, Score = "362-3", NPI = "1447228747", DOB = new DateTime(1982, 1, 22), Age = 40, StartDate = new DateTime(2021, 12, 30), EndDate = new DateTime(2022, 1, 12), LOS = 13, TotalCharges = 89015.87M },
                new() { ClaimId = 490569, Score = "423-1", NPI = "1851343909", DOB = new DateTime(2001, 4, 30), Age = 21, StartDate = new DateTime(2022, 4, 23), EndDate = new DateTime(2022, 4, 25), LOS = 2, TotalCharges = 13426.96M },
                new() { ClaimId = 490572, Score = "461-2", NPI = "1043267701", DOB = new DateTime(1933, 11, 25), Age = 88, StartDate = new DateTime(2021, 10, 23), EndDate = new DateTime(2021, 11, 3), LOS = 11, TotalCharges = 143817.43M },
                new() { ClaimId = 490573, Score = "469-1", NPI = "1154618742", DOB = new DateTime(2002, 5, 2), Age = 20, StartDate = new DateTime(2022, 3, 12), EndDate = new DateTime(2022, 4, 27), LOS = 46, TotalCharges = 685223.75M },
                new() { ClaimId = 490574, Score = "561-3", NPI = "1548286172", DOB = new DateTime(1940, 3, 11), Age = 82, StartDate = new DateTime(2022, 2, 19), EndDate = new DateTime(2022, 2, 19), LOS = 0, TotalCharges = 13999.24M },
                new() { ClaimId = 490575, Score = "639-3", NPI = "1477643690", DOB = new DateTime(1962, 5, 11), Age = 60, StartDate = new DateTime(2022, 4, 7), EndDate = new DateTime(2022, 4, 26), LOS = 19, TotalCharges = 152584.53M },
                new() { ClaimId = 490579, Score = "662-3", NPI = "1003885641", DOB = new DateTime(1945, 12, 20), Age = 76, StartDate = new DateTime(2021, 11, 28), EndDate = new DateTime(2021, 12, 1), LOS = 3, TotalCharges = 54005.39M },
                new() { ClaimId = 490585, Score = "810-3", NPI = "1447228747", DOB = new DateTime(1941, 2, 2), Age = 81, StartDate = new DateTime(2022, 1, 9), EndDate = new DateTime(2022, 1, 13), LOS = 4, TotalCharges = 81122.80M },
                new() { ClaimId = 490587, Score = "930-4", NPI = "1851343909", DOB = new DateTime(2020, 2, 23), Age = 2, StartDate = new DateTime(2022, 1, 20), EndDate = new DateTime(2022, 2, 22), LOS = 33, TotalCharges = 459560.04M }
            };

            await _context.Claims.AddRangeAsync(claims);
            await _context.SaveChangesAsync();
        }
    }
}