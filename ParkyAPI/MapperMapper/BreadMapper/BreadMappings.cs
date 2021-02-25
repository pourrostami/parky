using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ParkyAPI.Models;
using ParkyAPI.Models.Dtos;

namespace ParkyAPI.MapperMapper.BreadMapper
{
    public class BreadMappings : Profile
    {
        public BreadMappings()
        {
            CreateMap<Bread, BreadDto>().ReverseMap();
        }
    }
}
