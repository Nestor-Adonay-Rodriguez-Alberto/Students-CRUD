using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Acceso_Datos;

namespace Logica_Negocio
{
    public static class DependecyContainer
    {
        public static IServiceCollection AddBLDependecies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDALDependecies(configuration);

            // Registrando Las Clases:
            services.AddScoped<RolBL>();
            services.AddScoped<ProfesorBL>();

            return services;
        }

    }
}
