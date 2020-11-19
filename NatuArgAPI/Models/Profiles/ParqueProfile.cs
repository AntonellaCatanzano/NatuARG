using AutoMapper;
using NatuArgAPI.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NatuArgAPI.Models.Profiles
{
    public class ParqueProfile: Profile
    {
        public ParqueProfile()
        {
            CreateMap<Parque, ParqueDto>().ReverseMap();
        }
    }
}
