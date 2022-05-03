using System.Threading.Tasks;

using Teste.Domain;

namespace Teste.Application.Interfaces
{
    public interface ICityService
    {
        Task<City[]> GetAllCity ();
        Task<City> GetCityById (int id);
        Task<bool> AddCity (City city);
        Task<City> UpdateCity (int id, City newCity);
        Task<bool> DeleteCity (int id);

    }
}