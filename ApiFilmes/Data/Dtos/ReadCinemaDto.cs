﻿using ApiFilmes.Models;

namespace ApiFilmes.Data.Dtos;

public class ReadCinemaDto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public ReadEnderecoDto Endereco { get; set; }
    public virtual ICollection<ReadSessaoDto> Sessoes { get; set; }
}
