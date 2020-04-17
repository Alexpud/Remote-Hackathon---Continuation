using AutoMapper;
using Domain.Entities;
using Domain.Models;
using System;

namespace Application
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<HackathonDTO, Hackathon>();
            CreateMap<Hackathon, HackathonDTO>();
        }
    }
}