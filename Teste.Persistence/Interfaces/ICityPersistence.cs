using System.Threading.Tasks;
using Teste.Domain;

namespace Teste.Persistence.Interfaces
{
    public interface ICityPersistence
    {
        Task<City[]> GetAllCityAsync (); 
        Task<City> GetCityByIdAsync (int id);
        Task<City> GetCityByCodeAsync (int code);
    }
}