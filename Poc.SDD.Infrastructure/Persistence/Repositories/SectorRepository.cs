using Microsoft.EntityFrameworkCore;
using Poc.SDD.Domain.Sectors;
using Poc.SDD.Domain.Shared;
using Poc.SDD.Infrastructure.Persistence;

namespace Poc.SDD.Infrastructure.Persistence.Repositories;

public class SectorRepository : ISectorRepository
{
    private readonly ApplicationDbContext _context;

    public SectorRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Sector?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Sectors.FindAsync(id, cancellationToken);
    }

    public async Task<List<Sector>> ListAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Sectors.ToListAsync(cancellationToken);
    }

    public async Task AddAsync(Sector sector, CancellationToken cancellationToken = default)
    {
        await _context.Sectors.AddAsync(sector, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(Sector sector, CancellationToken cancellationToken = default)
    {
        _context.Sectors.Update(sector);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var sector = await _context.Sectors.FindAsync(id);
        if (sector != null)
        {
            _context.Sectors.Remove(sector);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}