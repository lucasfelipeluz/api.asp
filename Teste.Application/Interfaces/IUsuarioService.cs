using System.Threading.Tasks;
using Teste.Application.Dto;

namespace Teste.Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<UsuarioDto[]> GetAllUsuarios ();
        Task<UsuarioDto> GetUsuarioById (int id);
        Task<bool?> AddUsuario (UsuarioDto usuario);
        Task<bool?> UpdateUsuario (int id, UsuarioDto usuario);
        Task<bool?> DeleteUsuario (int id);
    }
}