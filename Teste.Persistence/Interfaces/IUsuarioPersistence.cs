using System.Threading.Tasks;
using Teste.Domain;

namespace Teste.Persistence.Interfaces
{
    public interface IUsuarioPersistence
    {
        Task<Usuario[]> GetAllUsuariosByNameAsync (string name);
        Task<Usuario> GetUsuarioByIdAsync (int id);
        Task<Usuario[]> GetAllUsuariosAsync ();
    }
}