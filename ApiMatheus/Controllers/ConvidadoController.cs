using System.Threading.Tasks;
using ApiMatheus.DTOs;
using ApiMatheus.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ConvidadosController : ControllerBase
{
    private readonly ConvidadoService _service;

    public ConvidadosController(ConvidadoService service)
    {
        _service = service;
    }

    // Endpoint para criar um novo convidado (confirmação de presença)
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ConfirmarConvidadoDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _service.CriarConvidado(dto);
        return result ? Ok(dto) : BadRequest();
    }
}