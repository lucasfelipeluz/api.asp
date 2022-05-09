using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using Teste.Domain;
using Teste.Persistence.Context;
using Teste.Persistence.Interfaces;

namespace Teste.Persistence
{
    public class CityPersistence: ICityPersistence
    {
        private readonly TesteContext _context;

        public CityPersistence(TesteContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public async Task<City[]> GetAllCityAsync()
        {
            IQueryable<City> query = _context.City;

            query = query.OrderBy(usuario => usuario.Id);

            return await query.ToArrayAsync();
        }

        public async Task<City> GetCityByIdAsync(int id)
        {
            IQueryable<City> query = _context.City;

            query = query.OrderBy(city => city.Id)
                .Where(city => city.Id == id);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<City> GetCityByCodeAsync (int code)
        {
            IQueryable<City> query = _context.City;
            query = query.OrderBy(city => city.CityCode)
                .Where(city => city.CityCode == code);

            return await query.FirstOrDefaultAsync();
        }
    }
}