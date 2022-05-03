using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

using Teste.Application.Interfaces;
using Teste.Application;
using Teste.Persistence.Context;
using Teste.Persistence.Interfaces;
using Teste.Persistence;

namespace Teste.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TesteContext>(
                options => options
                    .UseSqlite(Configuration.GetConnectionString("Default.Sqlite"))
            );

            services.AddScoped<IGeralPersistence, GeralPersistence>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IUsuarioPersistence, UsuarioPersistence>();
            services.AddScoped<ICityPersistence, CityPersistence>();
            services.AddScoped<ICityService, CityService>();

            services.AddControllers()
                .AddNewtonsoftJson(
                    x => x.SerializerSettings.ReferenceLoopHandling = 
                        Newtonsoft.Json.ReferenceLoopHandling.Ignore
                );
            services.AddCors();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
