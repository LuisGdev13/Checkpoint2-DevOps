using DimDim.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace DimDim.Web.Data;

public class DimDimDbContext : DbContext
{
    public DimDimDbContext(DbContextOptions<DimDimDbContext> options)
        : base(options)
    {
    }

    public DbSet<Cliente> Clientes => Set<Cliente>();

    public DbSet<Transacao> Transacoes => Set<Transacao>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.ToTable("Clientes");

            entity.HasKey(c => c.Id);

            entity.Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(150);

            entity.Property(c => c.Email)
                .HasMaxLength(150);

            entity.Property(c => c.Telefone)
                .HasMaxLength(30);
        });

        modelBuilder.Entity<Transacao>(entity =>
        {
            entity.ToTable("Transacoes");

            entity.HasKey(t => t.Id);

            entity.Property(t => t.Descricao)
                .IsRequired()
                .HasMaxLength(200);

            entity.Property(t => t.Valor)
                .HasPrecision(18, 2);

            entity.Property(t => t.Tipo)
                .IsRequired()
                .HasMaxLength(20);

            entity.Property(t => t.Data)
                .IsRequired();

            entity.HasOne(t => t.Cliente)
                .WithMany(c => c.Transacoes)
                .HasForeignKey(t => t.ClienteId)
                .OnDelete(DeleteBehavior.Restrict);
        });
    }
}