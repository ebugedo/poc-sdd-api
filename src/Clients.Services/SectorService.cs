using PocSddApi.Data;
using PocSddApi.src.Clients.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocSddApi.src.Clients.Services;

public class SectorService
{
    private readonly PocSddApiContext _context;

    public SectorService(PocSddApiContext context)
    {
        _context = context;
    }

    public async Task<List<Sector>> GetSectorsAsync()
    {
        return await _context.Sectors.ToListAsync();
    }

    public async Task<Sector> GetSectorByIdAsync(int id)
    {
        return await _context.Sectors.FindAsync(id) ?? throw new KeyNotFoundException($"Sector with ID {id} not found");
    }

    public async Task<Sector> CreateSectorAsync(Sector sector)
    {
        _context.Sectors.Add(sector);
        await _context.SaveChangesAsync();
        return sector;
    }

    public async Task UpdateSectorAsync(Sector sector)
    {
        _context.Entry(sector).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteSectorAsync(int id)
    {
        var sector = await _context.Sectors.FindAsync(id);
        if (sector != null)
        {
            _context.Sectors.Remove(sector);
            await _context.SaveChangesAsync();
        }
    }
}