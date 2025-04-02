using Microsoft.EntityFrameworkCore;
using RevendaApi.Models;

namespace RevendaApi.Data;

public class AppDbContext : DbContext
{
    protected AppDbContext() { }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Revenda> Revendas { get; set; }   
    public DbSet<RevendaContato> RevendaContatos { get; set; }
    public DbSet<RevendaEndereco> RevendaEnderecos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Revenda>(c =>
        {
            c.HasMany(r => r.Contatos)
                .WithOne(r => r.Revenda)
                .HasForeignKey(r => r.RevendaId)
                .OnDelete(DeleteBehavior.Cascade);

            c.HasMany(r => r.Enderecos)
                .WithOne(r => r.Revenda)
                .HasForeignKey(r => r.RevendaId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<RevendaContato>(c =>
        {
            c.HasOne(r => r.Revenda)
                .WithMany(r => r.Contatos)
                .HasForeignKey(r => r.RevendaId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<RevendaEndereco>(c =>
        {
            c.HasOne(r => r.Revenda)
                .WithMany(r => r.Enderecos)
                .HasForeignKey(r => r.RevendaId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        base.OnModelCreating(modelBuilder);
    }
}