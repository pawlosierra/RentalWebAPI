using AutoMapper;
using Rental.Web.API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rental.Web.API.DTOs
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<ClientDTO, Clients>();
            CreateMap<Clients, ClientDTO>();

            CreateMap<SaleDTO, Sales>()
                .ForMember(dest => dest.Concepts, opt => opt.MapFrom(src => src.Concepts));
            CreateMap<Sales, SaleDTO>();

            CreateMap<ConceptDTO, Concepts>();
            CreateMap<Concepts, ConceptDTO>();
        }
    }
}
