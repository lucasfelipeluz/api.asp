using AutoMapper;
using Teste.Application.Dto;
using Teste.Domain;

namespace Teste.Application.Helpers
{
    public class TesteProfile: Profile
    {
        public TesteProfile()
        {
            CreateMap<Usuario, UsuarioDto>();
            CreateMap<UsuarioDto, Usuario>();

            CreateMap<City, CityDto>();
            CreateMap<CityDto, City>();
        }
    }
}
