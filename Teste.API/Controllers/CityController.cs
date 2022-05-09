using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Teste.Domain;
using Teste.Application.Interfaces;
using Teste.Application.Dto;

namespace Teste.API.Controllers
{
    [ApiController]
    [Route("city")]
    public class CityController : ControllerBase
    {

        private readonly ICityService _cityService;

        public CityController (ICityService cityService)
        {
            this._cityService = cityService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                CityDto[] city = await _cityService.GetAllCity();
                if (city.Length == 0) return this.StatusCode(StatusCodes.Status204NoContent);

                return Ok(city);
            }
            catch (Exception error)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar se comunicar com servidor!\n {error.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById (int id)
        {
            try
            {
                CityDto city = await _cityService.GetCityById(id);
                if (city == null) return BadRequest("Cidade não encontrada!");
                return Ok(city);
            }
            catch (Exception error)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar obter o usuário\n ERROR: {error.Message}");
            }
        }

        [HttpGet("code={code}")]
        public async Task<IActionResult> GetByCode (int code)
        {
            try
            {
                CityDto city = await this._cityService.GetCityByCode(code);
                if (city == null) return BadRequest("Cidade não encontrada!");
                return Ok(city);

            }
            catch (Exception error)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar obter o usuário\n ERROR: {error.Message}");
            }
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Post(CityDto city)
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

        [HttpPut]
        [Route("edit/{id}")]
        public async Task<IActionResult> Put(int id, CityDto city)
        {
            try
            {
                bool? response = await _cityService.UpdateCity(id, city);
                if (response == null) return BadRequest("Id informado não corresponde a nenhuma cidade!");

                return Ok(response);
            }
            catch (Exception error)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar se comunicar com servidor!\n {error.Message}");
            }
        }
    
        [HttpDelete]
        [Route("delete/{id}")]
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