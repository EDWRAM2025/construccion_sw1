using ConstruSoftTicket.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConstruSoftTicket.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Ticket> Tickets { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.ToTable("Tickets");
            entity.HasKey(t => t.Id);
            entity.Property(t => t.Titulo).HasMaxLength(200).IsRequired();
            entity.Property(t => t.Descripcion).IsRequired();
            entity.Property(t => t.FechaCreacion).HasDefaultValueSql("CURRENT_TIMESTAMP");
        });
    }
}
