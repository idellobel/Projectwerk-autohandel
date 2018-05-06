using Autohandel.Domain.DTO_klassen;
using Autohandel.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autohandel.web.Services
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<Voertuig, VoertuigDTO>();
            CreateMap<VoertuigDTO, Voertuig>();
           
        }
    }
}
