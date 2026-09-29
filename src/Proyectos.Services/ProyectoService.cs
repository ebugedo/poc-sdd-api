using PocSddApi.Data;
using PocSddApi.src.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocSddApi.src.Proyectos.Services;

public class ProyectoService
{
    private readonly PocSddApiContext _context;

    public ProyectoService(PocSddApiContext context)
    {
        _context = context;
    }

    public async Task<List<Proyecto>> GetProyectosAsync()
    {
        return await _context.Proyectos.ToListAsync();
    }

    public async Task<Proyecto> GetProyectoByIdAsync(int id)
    {
        return await _context.Proyectos.FindAsync(id) ?? throw new KeyNotFoundException($"Proyecto with ID {id} not found");
    }

    public async Task<Proyecto> CreateProyectoAsync(Proyecto proyecto)
    {
        _context.Proyectos.Add(proyecto);
        await _context.SaveChangesAsync();
        return proyecto;
    }

    public async Task UpdateProyectoAsync(Proyecto proyecto)
    {
        _context.Entry(proyecto).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteProyectoAsync(int id)
    {
        var proyecto = await _context.Proyectos.FindAsync(id);
        if (proyecto != null)
        {
            _context.Proyectos.Remove(proyecto);
            await _context.SaveChangesAsync();
        }
    }
}