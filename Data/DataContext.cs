using ClaimProcessing.Models;
using Microsoft.EntityFrameworkCore;

public class DataContext : DbContext {
    public DataContext(DbContextOptions<DataContext> options) : base(options) {}

    public DbSet<Claim> Claims { get; set; }
    public DbSet<ClaimItem> ClaimItems { get; set; }
    public DbSet<RuleHit> RuleHits { get; set; }
    public DbSet<ClaimFlag> ClaimFlags { get; set; }
    public DbSet<ClaimPricing> ClaimPricings { get; set; }
    public DbSet<HospitalRate> HospitalRates {  get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Claim>().HasKey(c => c.Id);

        modelBuilder.Entity<ClaimItem>().HasOne(ci => ci.Claim)
                                        .WithMany(c => c.Items)
                                        .HasForeignKey(ci => ci.ClaimId);

        modelBuilder.Entity<HospitalRate>(entity =>
        {
            entity.HasKey(h => h.Id);
            entity.Property(h => h.SDA).HasColumnType("decimal(18,2)");
            entity.Property(h => h.DeliverySDA).HasColumnType("decimal(18,2)");
            entity.Property(h => h.PPR_PPC).HasColumnType("decimal(18,2)");
        });
    }
}