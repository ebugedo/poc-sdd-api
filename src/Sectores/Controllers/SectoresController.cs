using Microsoft.AspNetCore.Mvc;

namespace PocSddApi.src.Sectores.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SectoresController : ControllerBase
{
    // GET: api/sectores
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("Listado de sectores");
    }

    // GET: api/sectores/5
    [HttpGet("5")]
    public IActionResult GetById(int id)
    {
        return Ok($"Obteniendo sector con ID {id}");
    }

    // POST: api/sectores
    [HttpPost]
    public IActionResult Create([FromBody] string value)
    {
        return Ok($"Creando sector: {value}");
    }

    // PUT: api/sectores/5
    [HttpPut("5")]
    public IActionResult Update(int id, [FromBody] string value)
    {
        return Ok($"Actualizando sector {id}: {value}");
    }

    // DELETE: api/sectores/5
    [HttpDelete("5")]
    public IActionResult Delete(int id)
    {
        return Ok($"Eliminando sector {id}");
    }
}