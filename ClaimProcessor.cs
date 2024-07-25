using Microsoft.EntityFrameworkCore;

public class ClaimProcessor {
    private readonly DataContext _context;

    public ClaimProcessor(DataContext context)
    {
        _context = context;
    }

    public async Task ProcessClaim()
    {
        var claims = await _context.Claims.Include(c => c.Items).ToListAsync();

        foreach (var claim in claims)
        {
            var ruleHits = new List<RuleHit>();
            var claimFlags = new List<ClaimFlag>();

            //Applying rule (Example for the rule one)
            bool hitRuleOne = ApplyRuleOne(claim);

            if (hitRuleOne) 
            {
                ruleHits.Add(new RuleHit { ClaimId = claim.ClaimId, RuleId = "1" });
            }

            decimal totalPrice = CalculateClaimPrice(claim);
            var claimPrincing = new ClaimPricing { ClaimId = claim.ClaimId, Price = totalPrice };

            _context.RuleHits.AddRange(ruleHits);
            _context.ClaimFlags.AddRange(claimFlags);
            _context.ClaimPricings.Add(claimPrincing);

            await _context.SaveChangesAsync();

            Console.WriteLine($"Claim ID: {claim.ClaimId}, Rules: {string.Join(",", ruleHits.Select(r => r.RuleId))}, Flags: {string.Join(",", claimFlags.Select(f => f.Flag))}, Price: {totalPrice}");
        }
    }

    private bool ApplyRuleOne(Claim claim)
    {
        // Counting "CC" o "MCC" entries excluding position 1
        var ccMccCount = claim.Items
            .Where(item => item.Position != 1 && (item.DgxCCMCC == "CC" || item.DgxCCMCC == "MCC"))
            .Count();

        // Identifying the first item with DgxAffect is equal to 3 excluding position 1
        var firstItem = claim.Items
            .Where(item => item.Position != 1 && item.DgxAffect == 3)
            .OrderBy(item => item.Position)
            .FirstOrDefault();

        if (firstItem != null)
        {
            if (firstItem.DgxCCMCC == "CC" && ccMccCount == 1)
            {
                FlagClaim(claim, firstItem);
                return true;
            }
            else if (firstItem.DgxCCMCC == "MCC" && ccMccCount == 1)
            {
                FlagClaim(claim, firstItem);
                return true;
            }
        }

        return false;
    }

    private decimal CalculateClaimPrice(Claim claim)
    {
        decimal price = claim.TotalCharges;

        // Rule: Urban & Rural Hospitals outlier reduction for patients under 21 years
        if (claim.Age < 21)
        {
            price *= 0.9m;
        }

        // Rule: Additional reduction for claims with score "720-4"
        if (claim.Score == "720-4")
        {
            price *= 0.95m;
        }

        // Rule: Apply outlier reduction for a long LOS (Length of Stay)
        if (claim.LOS > 15)
        {
            price *= 0.85m;
        }

        return price;
    }

    private void FlagClaim(Claim claim, ClaimItem firstItem)
    {
        // Flag according to LOS value
        if (claim.LOS <= 5)
        {
            _context.ClaimFlags
                .Add(new ClaimFlag { ClaimId = claim.ClaimId, Flag = "Audit" });
        }
        else if (claim.LOS >= 10)
        {
            _context.ClaimFlags
                .Add(new ClaimFlag { ClaimId = claim.ClaimId, Flag = "Close" });
        }
        else
        {
            _context.ClaimFlags
                .Add(new ClaimFlag { ClaimId = claim.ClaimId, Flag = "Human Review" });
        }

        // Excepción
        if (claim.Score == "720-4" && firstItem.DGXCode == "I248")
        {
            _context.RuleHits.Add(new RuleHit { ClaimId = claim.ClaimId, RuleId = "-1" });
        }
    }

    
}