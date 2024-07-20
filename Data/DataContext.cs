using Microsoft.EntityFrameworkCore;

public class DataContext : DbContext {
    public DataContext(DbContextOptions<DataContext> options) : base(options) {}

    public DbSet<Claim> Claims { get; set; }
    public DbSet<ClaimItem> ClaimItems { get; set; }
    public DbSet<RuleHit> RuleHits { get; set; }
    public DbSet<ClaimFlag> ClaimFlags { get; set; }
    public DbSet<ClaimPricing> ClaimPricings { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        // if (!optionsBuilder.IsConfigured) {
        //     optionsBuilder.UseSqlServer("");
        // }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ClaimItem>().HasOne(ci => ci.Claim)
                                        .WithMany(c => c.Items)
                                        .HasForeignKey(ci => ci.ClaimId);
    }
}