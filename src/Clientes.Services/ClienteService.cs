using PocSddApi.Data;
using PocSddApi.src.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocSddApi.src.Clientes.Services;

public class ClienteService
{
    private readonly PocSddApiContext _context;

    public ClienteService(PocSddApiContext context)
    {
        _context = context;
    }

    public async Task<List<Cliente>> GetClientesAsync()
    {
        return await _context.Clientes.ToListAsync();
    }

    public async Task<Cliente> GetClienteByIdAsync(int id)
    {
        return await _context.Clientes.FindAsync(id) ?? throw new KeyNotFoundException($"Cliente with ID {id} not found");
    }

    public async Task<Cliente> CreateClienteAsync(Cliente cliente)
    {
        _context.Clientes.Add(cliente);
        await _context.SaveChangesAsync();
        return cliente;
    }

    public async Task UpdateClienteAsync(Cliente cliente)
    {
        _context.Entry(cliente).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteClienteAsync(int id)
    {
        var cliente = await _context.Clientes.FindAsync(id);
        if (cliente != null)
        {
            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
        }
    }
}