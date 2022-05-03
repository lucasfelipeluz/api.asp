using System;
using System.Threading.Tasks;
using Teste.Application.Interfaces;
using Teste.Domain;

using Teste.Persistence.Interfaces;

namespace Teste.Application
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IGeralPersistence _geralPersistence;
        private readonly IUsuarioPersistence _usuarioPersistence;

        public UsuarioService(IGeralPersistence geralPersistence, IUsuarioPersistence usuarioPersistence)
        {
            this._geralPersistence = geralPersistence;
            this._usuarioPersistence = usuarioPersistence;
        }
        public async Task<bool> AddUsuario(Usuario usuario)
        {
            try
            {
                _geralPersistence.Add<Usuario>(usuario);
                if (await _geralPersistence.SaveChangesAsync())
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

        public async Task<bool> DeleteUsuario(int id)
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

        public async Task<Usuario[]> GetAllUsuarios()
        {
            try
            {
                var usuarios = await _usuarioPersistence.GetAllUsuariosAsync();
                return usuarios;
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }

        public async Task<Usuario> GetUsuarioById(int id)
        {
            try
            {
                var usuario = await _usuarioPersistence.GetUsuarioByIdAsync(id);
                if (usuario == null) return null;
                
                return usuario;
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }

        public async Task<Usuario> UpdateUsuario(int id, Usuario newUsuario)
        {
            try
            {
                var usuario = await _usuarioPersistence.GetUsuarioByIdAsync(id);
                if ( usuario == null ) return null;

                newUsuario.Id = usuario.Id;

                _geralPersistence.Update<Usuario>(newUsuario);
                if(await _geralPersistence.SaveChangesAsync())
                {
                    return newUsuario;
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