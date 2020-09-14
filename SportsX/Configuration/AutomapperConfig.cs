using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SportsX.Domain.Entities;
using SportsX.ViewModels;

namespace SportsX.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<PessoaFisica, PessoaFisicaViewModel>().ReverseMap();
            CreateMap<PessoaFisica, ClienteViewModel>().ReverseMap();
            CreateMap<PessoaJuridica, PessoaJuridicaViewModel>().ReverseMap();
            CreateMap<PessoaJuridica, ClienteViewModel>().ReverseMap();
            CreateMap<Telefone, TelefoneViewModel>().ReverseMap();
        }
    }
}
