using AutoMapper;
using ControleCinemas.Api.ViewModels;
using ControleCinemas.Business.Models;

namespace ControleCinemas.Api.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Ator, AtorViewModel>().ReverseMap();
            CreateMap<Cinema, CinemaViewModel>().ReverseMap();
            CreateMap<Endereco, EnderecoViewModel>().ReverseMap();
            CreateMap<Ingresso, IngressoViewModel>().ReverseMap();
            CreateMap<Filme, FilmeViewModel>().ReverseMap();
            CreateMap<Genero, GeneroViewModel>().ReverseMap();
            CreateMap<Sessao, SessaoViewModel>().ReverseMap();
        }
    }
}