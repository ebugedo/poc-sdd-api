using Microsoft.AspNetCore.Mvc;

namespace PocSddApi.src.Proyectos.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProyectosController : ControllerBase
{
    // GET: api/proyectos
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("Listado de proyectos");
    }

    // GET: api/proyectos/5
    [HttpGet("5")]
    public IActionResult GetById(int id)
    {
        return Ok($"Obteniendo proyecto con ID {id}");
    }

    // POST: api/proyectos
    [HttpPost]
    public IActionResult Create([FromBody] string value)
    {
        return Ok($"Creando proyecto: {value}");
    }

    // PUT: api/proyectos/5
    [HttpPut("5")]
    public IActionResult Update(int id, [FromBody] string value)
    {
        return Ok($"Actualizando proyecto {id}: {value}");
    }

    // DELETE: api/proyectos/5
    [HttpDelete("5")]
    public IActionResult Delete(int id)
    {
        return Ok($"Eliminando proyecto {id}");
    }
}