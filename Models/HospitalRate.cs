namespace ClaimProcessing.Models;

public class HospitalRate
{
    public int Id { get; set; }
    public int NPI { get; set; }
    public string Month { get; set; } = string.Empty;
    public string NpiMonth { get; set; } = string.Empty;
    public int IpRate { get; set; }
    public string ProviderName { get; set; } = string.Empty;
    public string HospitalPhysicalCity { get; set; } = string.Empty;
    public string HospitalPhysicalStreetAddress { get; set; } = string.Empty;
    public string HospitalClass { get; set; } = string.Empty;
    public decimal SDA { get; set; }
    public decimal DeliverySDA { get; set; }
    public decimal PPR_PPC { get; set; }
    public int Contract { get; set; }
    public int HundredPercent { get; set; }
    public DateTime HHSC_Publish_Date { get; set; }
    public int CHIRP_Rate { get; set; }
}
