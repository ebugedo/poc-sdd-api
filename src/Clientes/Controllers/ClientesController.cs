using Microsoft.AspNetCore.Mvc;

namespace PocSddApi.src.Clientes.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientesController : ControllerBase
{
    // GET: api/clientes
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("Listado de clientes");
    }

    // GET: api/clientes/5
    [HttpGet("5")]
    public IActionResult GetById(int id)
    {
        return Ok($"Obteniendo cliente con ID {id}");
    }

    // POST: api/clientes
    [HttpPost]
    public IActionResult Create([FromBody] string value)
    {
        return Ok($"Creando cliente: {value}");
    }

    // PUT: api/clientes/5
    [HttpPut("5")]
    public IActionResult Update(int id, [FromBody] string value)
    {
        return Ok($"Actualizando cliente {id}: {value}");
    }

    // DELETE: api/clientes/5
    [HttpDelete("5")]
    public IActionResult Delete(int id)
    {
        return Ok($"Eliminando cliente {id}");
    }
}