using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using Teste.Persistence.Context;
using Teste.Persistence.Interfaces;

namespace Teste.Persistence
{
    public class GeralPersistence : IGeralPersistence
    {
        private readonly TesteContext _context;

        public GeralPersistence(TesteContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

    }
}