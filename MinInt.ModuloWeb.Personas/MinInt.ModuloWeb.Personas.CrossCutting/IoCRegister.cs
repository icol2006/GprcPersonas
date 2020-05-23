using Microsoft.Extensions.DependencyInjection;
using MinInt.ModuloWeb.Personas.Queries;

namespace MinInt.ModuloWeb.Personas.CrossCutting
{
    public static class IoCRegister
    {
        public static IServiceCollection AddRegistration(this IServiceCollection services)
        {
            AddRegisterServices(services);
            return services;
        }

        public static IServiceCollection AddRegisterServices(IServiceCollection services)
        {
            //services.AddTransient<IPersonasQueryService, PersonasQueryService>();

            return services;
        }
    }
}
