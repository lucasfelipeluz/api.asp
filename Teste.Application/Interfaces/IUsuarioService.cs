using System.Threading.Tasks;

using Teste.Domain;

namespace Teste.Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<bool> AddUsuario (Usuario usuario);
        Task<Usuario> UpdateUsuario (int id, Usuario newUsuario);
        Task<bool> DeleteUsuario (int id);
        Task<Usuario[]> GetAllUsuarios ();
        Task<Usuario> GetUsuarioById (int id);
    }
}