using System;
using System.Threading.Tasks;

using Teste.Persistence.Interfaces;
using Teste.Application.Interfaces;
using Teste.Domain;
using Teste.Application.Dto;
using AutoMapper;

namespace Teste.Application
{
    public class CityService : ICityService
    {   
        private readonly IGeralPersistence _geralPersistence;
        private readonly ICityPersistence _cityPersistence;
        private readonly IMapper _mapper;

        public CityService (IGeralPersistence geralPersistence, ICityPersistence cityPersistence, IMapper mapper)
        {
            this._cityPersistence = cityPersistence;
            this._geralPersistence = geralPersistence;
            this._mapper = mapper;
        }

        public async Task<CityDto[]> GetAllCity()
        {
            try
            {
                City[] cities = await _cityPersistence.GetAllCityAsync();
                CityDto[] citiesDto = this._mapper.Map<CityDto[]>(cities);
                return citiesDto;
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }

        public async Task<CityDto> GetCityById(int id)
        {
            try
            {
                City city = await _cityPersistence.GetCityByIdAsync(id);
                if (city == null) return null;

                CityDto cityDto = this._mapper.Map<CityDto>(city);

                return cityDto;
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }

        public async Task<CityDto> GetCityByCode(int code)
        {
            try
            {
                City city = await _cityPersistence.GetCityByCodeAsync(code);
                if (city == null) return null;
                CityDto cityDto = this._mapper.Map<CityDto>(city);
                return cityDto;
            }
            catch (Exception error)
            {

                throw new Exception(error.Message);
            }
        }

        public async Task<bool> AddCity(CityDto cityDto)
        {
            try
            {
                City city = this._mapper.Map<City>(cityDto);
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

        public async Task<bool?> UpdateCity(int id, CityDto cityDto)
        {
            try
            {
                City city = await _cityPersistence.GetCityByIdAsync(id);
                if (city == null) return null;

                cityDto.Id = city.Id;
                
                _mapper.Map(cityDto, city);

                _geralPersistence.Update<City>(city);

                if (await _geralPersistence.SaveChangesAsync())
                { return true; }
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

    }
}