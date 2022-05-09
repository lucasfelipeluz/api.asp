using System.Threading.Tasks;
using Teste.Application.Dto;
using Teste.Domain;

namespace Teste.Application.Interfaces
{
    public interface ICityService
    {
        Task<CityDto[]> GetAllCity ();
        Task<CityDto> GetCityById (int id);
        Task<CityDto> GetCityByCode(int code);
        Task<bool> AddCity (CityDto city);
        Task<bool?> UpdateCity (int id, CityDto newCity);
        Task<bool> DeleteCity (int id);

    }
}