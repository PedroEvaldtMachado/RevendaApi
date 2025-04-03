using Microsoft.EntityFrameworkCore;
using RevendaApi.Models;
using RevendaApi.Models.Clientes;
using RevendaApi.Models.Items;
using RevendaApi.Models.Pedidos;
using RevendaApi.Models.Revendas;

namespace RevendaApi.Data;

public class AppDbContext : DbContext
{
    protected AppDbContext() { }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Revenda> Revendas { get; set; }   
    public DbSet<RevendaContato> RevendaContatos { get; set; }
    public DbSet<RevendaEndereco> RevendaEnderecos { get; set; }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Item> Itens { get; set; }
    public DbSet<ItemEstoque> Estoques { get; set; }
    public DbSet<Pedido> Pedidos { get; set; }
    public DbSet<PedidoItem> PedidoItens { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Endereco>();

        modelBuilder.Entity<Revenda>(c =>
        {
            c.HasMany(r => r.Contatos)
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
            c.HasKey(r => new { r.RevendaId, r.EnderecoId });

            c.HasOne(r => r.Revenda)
                .WithOne()
                .HasPrincipalKey<Revenda>(r => r.Id)
                .HasForeignKey<RevendaEndereco>(r => r.RevendaId)
                .OnDelete(DeleteBehavior.Cascade);

            c.HasOne(r => r.Endereco)
                .WithOne()
                .HasPrincipalKey<Endereco>(r => r.Id)
                .HasForeignKey<RevendaEndereco>(r => r.EnderecoId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Cliente>(c => 
        {
            c.HasOne(r => r.Endereco)
                .WithOne()
                .HasForeignKey<Cliente>(r => r.EnderecoId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Item>(c => 
        {
            c.HasMany(i => i.Estoques)
                .WithOne(i => i.Item)
                .HasForeignKey(i => i.ItemId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<ItemEstoque>(c =>
        {
            c.HasOne(i => i.Item)
                .WithMany(i => i.Estoques)
                .HasForeignKey(i => i.ItemId)
                .OnDelete(DeleteBehavior.Cascade);

            c.HasOne<Revenda>()
                .WithMany()
                .HasForeignKey(i => i.RevendaId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Pedido>(c =>
        {
            c.HasOne<Revenda>()
                .WithMany()
                .HasForeignKey(p => p.RevendaId)
                .OnDelete(DeleteBehavior.Cascade);

            c.HasOne<Cliente>()
                .WithMany()
                .HasForeignKey(p => p.ClienteId)
                .OnDelete(DeleteBehavior.Cascade);

            c.HasMany(p => p.Itens)
                .WithOne()
                .HasForeignKey(p => p.PedidoId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<PedidoItem>(c =>
        {
            c.HasOne(p => p.Pedido)
                .WithMany(p => p.Itens)
                .HasForeignKey(p => p.PedidoId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        base.OnModelCreating(modelBuilder);
    }
}