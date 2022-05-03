using Microsoft.EntityFrameworkCore;

using Teste.Domain;

namespace Teste.Persistence.Context
{
    public class TesteContext : DbContext
    {
        public TesteContext (DbContextOptions<TesteContext> options) : base(options)
        {    }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<City> City { get; set; }

    }       
}