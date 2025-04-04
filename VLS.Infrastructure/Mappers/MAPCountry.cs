﻿using AutoMapper;

namespace VLS.Infrastructure.Mappers
{
    public class MAPCountry : Profile
    {
        public MAPCountry() 
        {
            CreateMap<Country, DTOCountry>();
            CreateMap<DTOCountry, Country>();

            CreateMap<Country, VMCountry>()
                .ForMember(dest => dest.Cities, opt => opt.MapFrom(src => src.Cities == null ? new List<string>() : src.Cities.Select(x => x.Name).ToList()));
        }
    }
}
