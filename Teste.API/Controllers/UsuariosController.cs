using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Teste.Application.Interfaces;
using Teste.Application.Dto;

namespace Teste.API.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {
        private readonly IUsuarioService _usuariosServices;

        public UserController(IUsuarioService usuariosService)
        {
            this._usuariosServices = usuariosService;
        }
       
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                UsuarioDto[] response = await _usuariosServices.GetAllUsuarios();
                if (response.Length == 0) {
                    return NoContent();
                }
                
                return Ok(response);
            }
            catch (Exception error)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar os usuarios\n ERROR: {error.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                UsuarioDto usuario = await _usuariosServices.GetUsuarioById(id);

                if (usuario != null)
                {
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

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add(UsuarioDto usuario)
        {
            try
            {
                var response = await _usuariosServices.AddUsuario(usuario);
                if (response == true)
                {
                    return Ok("Usuário adicionado com sucesso!");
                }
                return Unauthorized();
            }
            catch (Exception error)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar se comunicar com servidor\n ERROR: {error.Message}");
            }
        }
    
        [HttpPut("edit/{id}")]
        public async Task<IActionResult> Put (int id, UsuarioDto usuario)
        {
            try
            {
                bool? responseUpdateUsuario = await _usuariosServices.UpdateUsuario(id, usuario);
                if(responseUpdateUsuario != null)
                {
                    return Ok($"Usuário editado!");
                }
                if (responseUpdateUsuario == false)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao editar o Usuário.");
                }
                return BadRequest("Nenhum usuário encontrado!");
            }
            catch (Exception error)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar o usuário\n ERROR: {error.Message}");
            }
            
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete (int id)
        {
            try
            {
                bool? responseDeleteUsuario = await _usuariosServices.DeleteUsuario(id);
                if(responseDeleteUsuario == true)
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

    }
}
