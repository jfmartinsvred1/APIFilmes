﻿using ApiFilmes.Data.Dtos;
using ApiFilmes.Models;
using AutoMapper;

namespace ApiFilmes.Profiles;

public class FIlmeProfile:Profile
{
    public FIlmeProfile()
    {
        CreateMap<CreateFilmeDto, Filme>();
        CreateMap<UpdateFilmeDto, Filme>();
        CreateMap<Filme, UpdateFilmeDto>();
    }
}