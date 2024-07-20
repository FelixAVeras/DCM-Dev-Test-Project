public class ClaimItem
{
    public int Id { get; set; }
    public int ClaimId { get; set; }
    public int Position { get; set; }
    public string DGXCode { get; set; } = string.Empty;
    public int DgxAffect { get; set; }
    public string DgxCCMCC { get; set; } = string.Empty;

    public Claim? Claim { get; set; }
}