﻿using System.ComponentModel.DataAnnotations;

namespace ApiFilmes.Data.Dtos
{
    public class CreateSessaoDto
    {
        public int FilmeId { get; set; }
        public int CinemaId { get; set; }
    }
}
