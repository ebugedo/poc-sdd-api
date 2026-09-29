using Microsoft.AspNetCore.Mvc;
using PocSddApi.Data;
using PocSddApi.src.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace PocSddApi.src.Clientes.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientesController : ControllerBase
{
    private readonly PocSddApiContext _context;

    public ClientesController(PocSddApiContext context)
    {
        _context = context;
    }

    // GET: api/clientes
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
    {
        return await _context.Clientes.ToListAsync();
    }

    // GET: api/clientes/5
    [HttpGet("5")]
    public async Task<ActionResult<Cliente>> GetCliente(int id)
    {
        var cliente = await _context.Clientes.FindAsync(id);

        if (cliente == null)
        {
            return NotFound();
        }

        return cliente;
    }

    // PUT: api/clientes/5
    [HttpPut("5")]
    public async Task<IActionResult> PutCliente(int id, Cliente cliente)
    {
        if (id != cliente.Id)
        {
            return BadRequest();
        }

        _context.Entry(cliente).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ClienteExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // POST: api/clientes
    [HttpPost]
    public async Task<ActionResult<Cliente>> PostCliente(Cliente cliente)
    {
        _context.Clientes.Add(cliente);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetCliente", new { id = cliente.Id }, cliente);
    }

    // DELETE: api/clientes/5
    [HttpDelete("5")]
    public async Task<IActionResult> DeleteCliente(int id)
    {
        var cliente = await _context.Clientes.FindAsync(id);
        if (cliente == null)
        {
            return NotFound();
        }

        _context.Clientes.Remove(cliente);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ClienteExists(int id)
    {
        return _context.Clientes.Any(e => e.Id == id);
    }
}