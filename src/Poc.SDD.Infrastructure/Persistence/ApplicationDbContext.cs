using Microsoft.EntityFrameworkCore;
using Poc.SDD.Domain.Clients;
using Poc.SDD.Domain.Projects;
using Poc.SDD.Domain.Sectors;

namespace Poc.SDD.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Client> Clients { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Sector> Sectors { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id)
                .HasConversion(
                    id => id.Value,
                    value => new ClientId(value));

            entity.Property(e => e.Name)
                .HasMaxLength(200);

            entity.Property(e => e.Email)
                .HasMaxLength(450);

            entity.Property(e => e.Phone)
                .HasMaxLength(50);
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id)
                .HasConversion(
                    id => id.Value,
                    value => new ProjectId(value));

            entity.Property(e => e.Name)
                .HasMaxLength(200);

            entity.Property(e => e.Description).HasMaxLength(500);

            entity.HasOne(e => e.Client)
                .WithMany()
                .HasForeignKey(e => e.ClientId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Sector>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id)
                .HasConversion(
                    id => id.Value,
                    value => new SectorId(value));

            entity.Property(e => e.Name)
                .HasMaxLength(200);

            entity.Property(e => e.Description).HasMaxLength(500);
        });

        // Many-to-Many: Client-Sector using explicit join entity
        modelBuilder.Entity<ClientSector>()
            .HasKey(cs => new { cs.ClientId, cs.SectorId });

        modelBuilder.Entity<ClientSector>()
            .HasOne(cs => cs.Client)
            .WithMany()
            .HasForeignKey(cs => cs.ClientId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<ClientSector>()
            .HasOne(cs => cs.Sector)
            .WithMany()
            .HasForeignKey(cs => cs.SectorId)
            .OnDelete(DeleteBehavior.Cascade);

        // Many-to-Many: Project-Sector using explicit join entity
        modelBuilder.Entity<ProjectSector>()
            .HasKey(ps => new { ps.ProjectId, ps.SectorId });

        modelBuilder.Entity<ProjectSector>()
            .HasOne(ps => ps.Project)
            .WithMany()
            .HasForeignKey(ps => ps.ProjectId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<ProjectSector>()
            .HasOne(ps => ps.Sector)
            .WithMany()
            .HasForeignKey(ps => ps.SectorId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}