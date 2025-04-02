using Microsoft.EntityFrameworkCore;

namespace RevendaApi.Data;

public class NoTrackingDbContext : AppDbContext
{
    protected NoTrackingDbContext() { }

    public NoTrackingDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTrackingWithIdentityResolution);
        base.OnConfiguring(optionsBuilder);
    }
}