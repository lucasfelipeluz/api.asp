using System;
using System.Threading.Tasks;

using Teste.Persistence.Interfaces;
using Teste.Application.Interfaces;
using Teste.Domain;

namespace Teste.Application
{
    public class CityService : ICityService
    {   
        private readonly IGeralPersistence _geralPersistence;
        private readonly ICityPersistence _cityPersistence;

        public CityService (IGeralPersistence geralPersistence, ICityPersistence cityPersistence)
        {
            this._cityPersistence = cityPersistence;
            this._geralPersistence = geralPersistence;
        }

        public async Task<bool> AddCity(City city)
        {
            try
            {
                _geralPersistence.Add<City>(city);
                if (await _geralPersistence.SaveChangesAsync()){
                    return true;
                }   
                return false;
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }

        public async Task<bool> DeleteCity(int id)
        {
            try
            {
                City city = await _cityPersistence.GetCityByIdAsync(id);
                if (city == null) return false;

                _geralPersistence.Delete<City>(city);

                if(await _geralPersistence.SaveChangesAsync())
                {
                    return true;
                }
                return false;
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }

        public async Task<City[]> GetAllCity()
        {
            try
            {
                City[] city = await _cityPersistence.GetAllCityAsync();
                return city;
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }

        public async Task<City> GetCityById(int id)
        {
             try
            {
                City city = await _cityPersistence.GetCityByIdAsync(id);
                if (city == null) return null;

                return city;
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }

        public async Task<City> UpdateCity(int id, City newCity)
        {
            try
            {
                City city = await _cityPersistence.GetCityByIdAsync(id);
                if ( city == null) return null;

                newCity.Id = city.Id;

                _geralPersistence.Update<City>(newCity);

                if( await _geralPersistence.SaveChangesAsync())
                { return newCity; }
                return null;

            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }
    }
}