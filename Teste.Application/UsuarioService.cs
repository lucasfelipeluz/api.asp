using AutoMapper;
using System;
using System.Threading.Tasks;
using Teste.Application.Dto;
using Teste.Application.Interfaces;
using Teste.Domain;

using Teste.Persistence.Interfaces;

namespace Teste.Application
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IGeralPersistence _geralPersistence;
        private readonly IUsuarioPersistence _usuarioPersistence;
        private readonly IMapper _mapper;

        public UsuarioService(IGeralPersistence geralPersistence, IUsuarioPersistence usuarioPersistence,IMapper mapper)
        {
            this._geralPersistence = geralPersistence;
            this._usuarioPersistence = usuarioPersistence;
            this._mapper = mapper;
        }
        public async Task<bool?> AddUsuario(UsuarioDto usuario)
        {
            try
            {
                Usuario newUsuario = _mapper.Map<Usuario>(usuario);

                _geralPersistence.Add<Usuario>(newUsuario);
                
                if (await _geralPersistence.SaveChangesAsync())
                {
                    return true;
                }
                return null;
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }

        public async Task<bool?> DeleteUsuario(int id)
        {
            try
            {
                var usuario = await _usuarioPersistence.GetUsuarioByIdAsync(id);
                if ( usuario == null ) return false;

                _geralPersistence.Delete<Usuario>(usuario);

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

        public async Task<UsuarioDto[]> GetAllUsuarios()
        {
            try
            {
                Usuario[] usuarios = await _usuarioPersistence.GetAllUsuariosAsync();

                UsuarioDto[] resultado = this._mapper.Map<UsuarioDto[]>(usuarios);

                return resultado;
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }

        public async Task<UsuarioDto> GetUsuarioById(int id)
        {
            try
            {
                var usuario = await _usuarioPersistence.GetUsuarioByIdAsync(id);
                if (usuario == null) return null;

                var resultado = _mapper.Map<UsuarioDto>(usuario);
                
                return resultado;
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }

        public async Task<bool?> UpdateUsuario(int id, UsuarioDto model)
        {
            try
            {
                var usuario = await _usuarioPersistence.GetUsuarioByIdAsync(id);
                if (usuario == null) return null;

                model.Id = usuario.Id;

                _mapper.Map(model, usuario);

                _geralPersistence.Update<Usuario>(usuario);
                if (await _geralPersistence.SaveChangesAsync())
                {
                    return true;
                }
                return null;
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }

    }
}