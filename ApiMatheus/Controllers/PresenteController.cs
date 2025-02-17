using System.Threading.Tasks;
using ApiMatheus.DTOs;
using ApiMatheus.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class PresentesController : ControllerBase
{
    private readonly PresenteService _service;

    public PresentesController(PresenteService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var presentes = await _service.BuscarTodosPresentes();
        return Ok(presentes);
    }

    [HttpPost("confirmar")]
    public async Task<IActionResult> Confirmar([FromBody] ConfirmacaoDto dto)
    {
        var result = await _service.ConfirmarPresente(dto.PresenteId, dto.Pessoa);
        return result ? Ok() : BadRequest();
    }

    [HttpPost("convidado/{convidadoId}/presente/{presenteId}")]
    public async Task<IActionResult> EscolherPresente(int convidadoId, int presenteId)
    {
        var result = await _service.EscolherPresente(convidadoId, presenteId);
        return result ? Ok() : BadRequest();
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ConfirmarPresenteDto presenteDto)
    {
        if (ModelState.IsValid)
        {
            var result = await _service.CriarPresente(presenteDto);
            return result ? Ok(presenteDto) : BadRequest();
        }
        return BadRequest(ModelState);
    }
}

public class ConfirmacaoDto
{
    public int PresenteId { get; set; }
    public string Pessoa { get; set; }
}