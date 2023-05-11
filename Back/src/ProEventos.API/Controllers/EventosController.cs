using Microsoft.AspNetCore.Mvc;
using ProEventos.Domain;
using ProEventos.Application.Contratos;

namespace ProEventos.API.Controllers;

[ApiController]
[Route("api/[controller]")]


public class EventosController : ControllerBase
{

    private readonly IEventoService _eventoService;

    public EventosController(IEventoService eventoService)
    {
        _eventoService = eventoService;


    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var eventos = await _eventoService.GetAllEventosAsync(true);
            if (eventos == null) return NotFound("Nenhum evento encontrado");

            return Ok(eventos);

        }
        catch (Exception error)
        {

            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar eventos. Erro: {error.Message}");
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var evento = await _eventoService.GetEventosByIdAsync(id, true);
            if (evento == null) return NotFound("Nenhum evento encontrado");

            return Ok(evento);

        }
        catch (Exception error)
        {

            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar buscar eventos. Erro: {error.Message}");
        }
    }
    [HttpGet("{tema}/tema")]
    public async Task<IActionResult> GetByTema(string tema)
    {
        try
        {
            var eventos = await _eventoService.GetAllEventosByTemaAsync(tema, true);
            if (eventos == null) return NotFound("Nenhum evento encontrado");

            return Ok(eventos);

        }
        catch (Exception error)
        {

            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar buscar eventos. Erro: {error.Message}");
        }
    }
    [HttpPost]
    public async Task<IActionResult> Post(Evento model)
    {
        try
        {
            var eventos = await _eventoService.AddEventos(model);
            if (eventos == null) return BadRequest("Erro ao tentar adicionar eventos.");

            return Ok(eventos);

        }
        catch (Exception error)
        {

            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar postar eventos. Erro: {error.Message}");
        }
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Evento model)
    {
        try
        {
            var eventos = await _eventoService.UpdateEventos(id, model);
            if (eventos == null) return BadRequest("Nenhum evento encontrado");

            return Ok(eventos);

        }
        catch (Exception error)
        {

            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar editar eventos. Erro: {error.Message}");
        }
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {

            return await _eventoService.DeleteEventos(id) ? Ok("Deletado") : BadRequest("Erro ao deletar");


        }
        catch (Exception error)
        {

            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar deletar eventos. Erro: {error.Message}");
        }
    }
}
