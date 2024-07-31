using ClaimProcessing.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimProcessing
{
    public class HospitalRateService
    {
        private readonly DataContext _context;

        public HospitalRateService(DataContext context)
        {
            _context = context;
        }

        public List<HospitalRate> SearchHospitalRates(int npi, DateTime admissionDate, DateTime dischargeDate)
        {

            var hospitalRates = _context.HospitalRates
            .AsEnumerable() // Convert to IEnumerable for do the convertion on memory.
            .Where(hr => hr.NPI == npi
                         && DateTime.TryParseExact(hr.Month, "M/d/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime monthDate)
                         && monthDate >= admissionDate
                         && monthDate <= dischargeDate).ToList();

            return hospitalRates;
        }
    }
}
