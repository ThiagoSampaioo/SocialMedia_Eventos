using Microsoft.AspNetCore.Mvc;
using ProEventos.API.Models;


namespace ProEventos.API.Controllers;

[ApiController]
[Route("api/[controller]")]


public class EventoController : ControllerBase
{
    public IEnumerable<Evento> _evento = new Evento[]{
            new Evento(){
            EventoId = 1,
            Tema = "Angular e .net core",
            Local = "Ceará ",
            Lote = "1",
            QunatidadePessoas  = 250,
            DataEvento = DateTime.Now.AddDays(2).ToString(),
            ImagemUrl = "foto.png",

            },
            new Evento(){
            EventoId = 2,
            Tema = "Angular, .net core e outros mais",
            Local = "Ceará ",
            Lote = "2",
            QunatidadePessoas  = 250,
            DataEvento = DateTime.Now.AddDays(2).ToString(),
            ImagemUrl = "foto.png",

            }

        };


    public EventoController()
    {

    }

    [HttpGet]
    public IEnumerable<Evento> Get()
    {
        return _evento;
    }
    [HttpGet("{id}")]
    public IEnumerable<Evento> GetById(int id)
    {
        return _evento.Where(evento => evento.EventoId == id);
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
