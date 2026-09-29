using Microsoft.EntityFrameworkCore;

namespace PocSddApi.Data;

public class PocSddApiContext : DbContext
{
    public PocSddApiContext(DbContextOptions<PocSddApiContext> options)
        : base(options)
    {
    }

    // Clients table
    public DbSet<Client> Clients { get; set; }

    // Projects table
    public DbSet<Project> Projects { get; set; }

    // Sectors table
    public DbSet<Sector> Sectors { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Client configuration
        modelBuilder.Entity<Client>(entity =>
        {
            entity.ToTable("Clients");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Email).IsRequired().HasMaxLength(200);
        });

        // Project configuration
        modelBuilder.Entity<Project>(entity =>
        {
            entity.ToTable("Projects");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Description).HasMaxLength(500);
        });

        // Sector configuration
        modelBuilder.Entity<Sector>(entity =>
        {
            entity.ToTable("Sectors");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(50);
        });
    }
}