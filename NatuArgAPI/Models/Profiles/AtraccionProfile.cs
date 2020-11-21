using AutoMapper;
using NatuArgAPI.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NatuArgAPI.Models.Profiles
{
    public class AtraccionProfile: Profile
    {
        public AtraccionProfile()
        {
            CreateMap<Atraccion, AtraccionDto>().ReverseMap();
            CreateMap<Atraccion, AtraccionInsertDto>().ReverseMap();
        }
    }
}
