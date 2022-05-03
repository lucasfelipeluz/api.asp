using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Teste.Domain;
using Teste.Application.Interfaces;

namespace Teste.API.Controllers
{
    [ApiController]
    [Route("city")]
    public class CityControllers : ControllerBase
    {

        private readonly ICityService _cityService;

        public CityControllers (ICityService cityService)
        {
            this._cityService = cityService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                City[] city = await _cityService.GetAllCity();
                if (city.Length == 0) return this.StatusCode(StatusCodes.Status204NoContent);

                return Ok(city);
            }
            catch (Exception error)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar se comunicar com servidor!\n {error.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(City city)
        {
            try
            {
                bool response = await _cityService.AddCity(city);
                if (response == false) return StatusCode(StatusCodes.Status401Unauthorized);

                return Ok("City adicionada com sucesso!");
            }
            catch (Exception error)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar se comunicar com servidor!\n {error.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, City city)
        {
            try
            {
                City response = await _cityService.UpdateCity(id, city);
                if (response == null) return BadRequest("Id informado não corresponde a nenhuma cidade!");

                return Ok(response);
            }
            catch (Exception error)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar se comunicar com servidor!\n {error.Message}");
            }
        }
    
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) {
            try
            {
                bool response = await _cityService.DeleteCity(id);
                if (response != false) return Ok("Cidade deletada!");

                return BadRequest("Id informado não corresponde a nenhuma cidade!");
            }
            catch (Exception error)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar se comunicar com servidor!\n {error.Message}");
            }
        }
    }
}