
using ApiFilmes.Data;
using ApiFilmes.Data.Dtos;
using ApiFilmes.Models;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace ApiFilmes.Controllers;
[ApiController]
[Route("[controller]")]
public class FilmeController:ControllerBase
{
    
    private FilmesContext _context;
    private IMapper _mapper;

    public FilmeController(FilmesContext context,IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AdicionaFilme([FromBody]CreateFilmeDto filmeDto)
    {
        Filme filme = _mapper.Map<Filme>(filmeDto);
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
    [HttpPut("{id}")]
    public IActionResult AtualizaFilme(int id, 
        [FromBody]UpdateFilmeDto filmeDto)
    {
        var filme = _context.Filmes
            .FirstOrDefault(filme => filme.Id == id);
        if(filme == null) return NotFound();
        _mapper.Map(filmeDto, filme);
        _context.SaveChanges();
        return NoContent();
    }
    [HttpPatch("{id}")]
    public IActionResult AtualizaFilmeParcial(int id, JsonPatchDocument<UpdateFilmeDto> patch)
    {
        var filme = _context.Filmes
            .FirstOrDefault(filme => filme.Id == id);
        if (filme == null) return NotFound();

        var filmeParaAtualizar = _mapper.Map<UpdateFilmeDto>(filme);
        patch.ApplyTo(filmeParaAtualizar, ModelState);

        if (!TryValidateModel(filmeParaAtualizar))
        {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(filmeParaAtualizar, filme);
        _context.SaveChanges();
        return NoContent();
    }

}
