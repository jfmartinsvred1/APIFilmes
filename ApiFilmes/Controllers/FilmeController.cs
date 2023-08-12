﻿
using ApiFilmes.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiFilmes.Controllers;
[ApiController]
[Route("[controller]")]
public class FilmeController:ControllerBase
{
    private static List<Filme> filmes = new List<Filme>();
    private static int id = 0;
    [HttpPost]
    public IActionResult AdicionaFilme([FromBody]Filme filme)
    {
        filme.Id = id++;
        filmes.Add(filme);
        return CreatedAtAction(
            nameof(RecuperaFilmePorID),
            new {id = filme.Id},
            filme);
    }
    [HttpGet]
    public IEnumerable<Filme> RecuperarFilmes([FromQuery]int skip=0, [FromQuery]int take=15)
    {
        return filmes.Skip(skip).Take(take);
    }
    [HttpGet("{id}")]
    public IActionResult RecuperaFilmePorID(int id)
    {
        var result =filmes.FirstOrDefault(filme => filme.Id == id);
        if(result == null) return NotFound();
        return Ok(result);
        
    }

}
