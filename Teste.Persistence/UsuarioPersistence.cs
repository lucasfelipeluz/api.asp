using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Teste.Domain;
using Teste.Persistence.Context;
using Teste.Persistence.Interfaces;

namespace Teste.Persistence
{
    public class UsuarioPersistence : IUsuarioPersistence
    {
        private readonly TesteContext _context;

        public UsuarioPersistence(TesteContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        public async Task<Usuario[]> GetAllUsuariosAsync()
        {
            IQueryable<Usuario> query = _context.Usuarios
                .Include(usuario => usuario.City);

            query = query.OrderBy(usuario => usuario.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Usuario[]> GetAllUsuariosByNameAsync(string name)
        {
            IQueryable<Usuario> query = _context.Usuarios
                .Include(usuario => usuario.City);

            query = query.OrderBy(usuario => usuario.Id)
                .Where(usuario => usuario.Name
                    .ToLower()
                    .Contains(name.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Usuario> GetUsuarioByIdAsync(int id)
        {
            IQueryable<Usuario> query = _context.Usuarios
                .Include(usuario => usuario.City);

            query = query.OrderBy(usuario => usuario.Id)
                .Where(usuario => usuario.Id == id);

            return await query.FirstOrDefaultAsync();
        }
    }
}