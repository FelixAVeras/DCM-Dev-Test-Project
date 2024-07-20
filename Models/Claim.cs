public class Claim
{
    public int Id { get; set; }
    public int ClaimId { get; set; }
    public decimal TotalPrice { get; set; }
    public string Score { get; set; } = string.Empty;
    public string NPI { get; set; } = string.Empty;
    public DateTime DOB { get; set; }
    public int Age { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int LOS { get; set; }
    public decimal TotalCharges { get; set; }

    // public List<ClaimItem> Items { get; set; } = new();
    public ICollection<ClaimItem>? Items { get; set; }
}