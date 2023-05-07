using Microsoft.AspNetCore.Mvc;
using ProEventos.API.Models;
using ProEventos.API.Data;


namespace ProEventos.API.Controllers;

[ApiController]
[Route("api/[controller]")]


public class EventoController : ControllerBase
{
    
        private readonly DataContext _context;

    public EventoController(DataContext context)
    {
            this._context = context;

    }

    [HttpGet]
    public IEnumerable<Evento> Get()
    {
        return _context.Eventos;
    }
    [HttpGet("{id}")]
    public Evento GetById(int id)
    {
        return _context.Eventos.FirstOrDefault(evento => evento.EventoId == id);
    }
    [HttpPost]
    public String Post()
    {
        return "Deu certo";
    }
    [HttpPut("{id}")]
    public String Put(int id)
    {
        return $"value by id: {id}";
    }
    [HttpDelete("{id}")]
    public String Delete(int id)
    {
        return $"Delete by id: {id}";
    }
}
