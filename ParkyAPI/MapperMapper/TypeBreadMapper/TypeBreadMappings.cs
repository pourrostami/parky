using AutoMapper;
using ParkyAPI.Models;
using ParkyAPI.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkyAPI.MapperMapper.TypeBreadMapper
{
    public class TypeBreadMappings:Profile
    {
        public TypeBreadMappings()
        {
            CreateMap<TypeBread, TypeBreadDto>().ReverseMap();
        }
    }
}
