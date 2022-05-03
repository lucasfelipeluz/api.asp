using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Teste.Domain;
using Teste.Application.Interfaces;
using Teste.API.Dto;


namespace Teste.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _usuariosServices;

        public UsuariosController(IUsuarioService usuariosService)
        {
            this._usuariosServices = usuariosService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                Usuario[] response = await _usuariosServices.GetAllUsuarios();
                if (response.Length == 0) { 
                    return this.StatusCode(StatusCodes.Status204NoContent);
                }
                
                return Ok(response);
            }
            catch (Exception error)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar os usuarios\n ERROR: {error.Message}");
            }
        }
    
        [HttpPost]
        public async Task<IActionResult> Add(UsuarioDto usuario)
        {
            try
            {
                var newUsuario = new Usuario{
                    Name = usuario.Name,
                    City = usuario.City,
                    CityId = usuario.CityId,
                    Age = usuario.Age,
                    Birth = DateTime.Parse(usuario.Birth)
                };

                var response = await _usuariosServices.AddUsuario(newUsuario);
                if (response)
                {
                    return Ok("Usuário adicionado com sucesso!");
                }
                return this.StatusCode(StatusCodes.Status401Unauthorized);
            }
            catch (Exception error)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar se comunicar com servidor\n ERROR: {error.Message}");
            }
        }
    
        [HttpPut("{id}")]
        public async Task<IActionResult> Put (int id, Usuario usuario)
        {
            try
            {
                Usuario responseUpdateUsuario = await _usuariosServices.UpdateUsuario(id, usuario);
                if(responseUpdateUsuario != null)
                {
                    return Ok(responseUpdateUsuario);
                }
                return BadRequest("Nenhum usuário encontrado!");
            }
            catch (Exception error)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar o usuário\n ERROR: {error.Message}");
            }
            
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete (int id)
        {
            try
            {
                bool responseDeleteUsuario = await _usuariosServices.DeleteUsuario(id);
                if(responseDeleteUsuario)
                {
                    return Ok("Usuário deletado!");
                }
                return BadRequest("Nenhum usuário encontrado!");
            }
            catch (Exception error)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar deletar o usuário\n ERROR: {error.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById (int id)
        {
            try
            {
                Usuario usuario = await _usuariosServices.GetUsuarioById(id);
                
                if (usuario != null){
                    return Ok(usuario);
                }
                return BadRequest("Usuário não encontrado!");
            }
            catch (Exception error)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar obter o usuário\n ERROR: {error.Message}");
            }
        }
    }
}
