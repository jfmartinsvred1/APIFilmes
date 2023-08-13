
using ApiFilmes.Data;
using ApiFilmes.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiFilmes.Controllers;
[ApiController]
[Route("[controller]")]
public class FilmeController:ControllerBase
{
    
    private FilmesContext _context;

    public FilmeController(FilmesContext context)
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult AdicionaFilme([FromBody]Filme filme)
    {
        _context.Filmes.Add(filme);
        _context.SaveChanges();
        return CreatedAtAction(
            nameof(RecuperaFilmePorID),
            new {id = filme.Id},
            filme);
    }
    [HttpGet]
    public IEnumerable<Filme> RecuperarFilmes([FromQuery]int skip=0, [FromQuery]int take=15)
    {
        return _context.Filmes.Skip(skip).Take(take);
    }
    [HttpGet("{id}")]
    public IActionResult RecuperaFilmePorID(int id)
    {
        var result =_context.Filmes.FirstOrDefault(filme => filme.Id == id);
        if(result == null) return NotFound();
        return Ok(result);
        
    }

}
