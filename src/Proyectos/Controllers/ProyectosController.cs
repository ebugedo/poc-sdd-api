using Microsoft.AspNetCore.Mvc;
using PocSddApi.Data;
using PocSddApi.src.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocSddApi.src.Proyectos.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProyectosController : ControllerBase
{
    private readonly PocSddApiContext _context;

    public ProyectosController(PocSddApiContext context)
    {
        _context = context;
    }

    // GET: api/proyectos
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Proyecto>>> GetProyectos()
    {
        return await _context.Proyectos.ToListAsync();
    }

    // GET: api/proyectos/5
    [HttpGet("5")]
    public async Task<ActionResult<Proyecto>> GetProyecto(int id)
    {
        var proyecto = await _context.Proyectos.FindAsync(id);

        if (proyecto == null)
        {
            return NotFound();
        }

        return proyecto;
    }

    // PUT: api/proyectos/5
    [HttpPut("5")]
    public async Task<IActionResult> PutProyecto(int id, Proyecto proyecto)
    {
        if (id != proyecto.Id)
        {
            return BadRequest();
        }

        _context.Entry(proyecto).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ProyectoExists(id))
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

    // POST: api/proyectos
    [HttpPost]
    public async Task<ActionResult<Proyecto>> PostProyecto(Proyecto proyecto)
    {
        _context.Proyectos.Add(proyecto);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetProyecto", new { id = proyecto.Id }, proyecto);
    }

    // DELETE: api/proyectos/5
    [HttpDelete("5")]
    public async Task<IActionResult> DeleteProyecto(int id)
    {
        var proyecto = await _context.Proyectos.FindAsync(id);
        if (proyecto == null)
        {
            return NotFound();
        }

        _context.Proyectos.Remove(proyecto);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ProyectoExists(int id)
    {
        return _context.Proyectos.Any(e => e.Id == id);
    }
}