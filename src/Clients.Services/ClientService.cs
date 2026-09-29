using PocSddApi.Data;
using PocSddApi.src.Clients.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocSddApi.src.Clients.Services;

public class ClientService
{
    private readonly PocSddApiContext _context;

    public ClientService(PocSddApiContext context)
    {
        _context = context;
    }

    public async Task<List<Client>> GetClientsAsync()
    {
        return await _context.Clients.ToListAsync();
    }

    public async Task<Client> GetClientByIdAsync(int id)
    {
        return await _context.Clients.FindAsync(id) ?? throw new KeyNotFoundException($"Client with ID {id} not found");
    }

    public async Task<Client> CreateClientAsync(Client client)
    {
        _context.Clients.Add(client);
        await _context.SaveChangesAsync();
        return client;
    }

    public async Task UpdateClientAsync(Client client)
    {
        _context.Entry(client).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteClientAsync(int id)
    {
        var client = await _context.Clients.FindAsync(id);
        if (client != null)
        {
            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();
        }
    }
}