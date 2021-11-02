using AutoMapper;
using Rental.Web.API.Domain.Entities;
using Rental.Web.API.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rental.Web.API.Infrastructure.DTOs
{
    public class MapperConfigInfra : Profile
    {
        public MapperConfigInfra()
        {
            CreateMap<Client, Clients>();
            CreateMap<Clients, Client>();

            CreateMap<Sale, Sales>();
            CreateMap<Sales, Sale>()
                .ForMember(dest => dest.Concepts, opt => opt.MapFrom(src => src.Concepts));

            CreateMap<Concept, Concepts>();
            CreateMap<Concepts, Concept>();
        }
    }
}
