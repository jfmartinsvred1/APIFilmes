﻿using System.ComponentModel.DataAnnotations;

namespace ApiFilmes.Data.Dtos;

public class ReadFilmeDto
{
    public string Titulo { get; set; }
    public string Genero { get; set; }
    public int Duracao { get; set; }
    public DateTime HourOfConsult { get; set; } = DateTime.Now;
}
