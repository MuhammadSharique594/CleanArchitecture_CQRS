using Login.Application.Abstract.Interface.Authentication;
using Login.Application.Abstract.Interface.Repositories;
using Login.Infrastructure.Authentication;
using Login.Infrastructure.Persistance;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Login.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));

            services.AddSingleton<ITokenGenerator, JwtTokenGenerator>();
            services.AddTransient<ILoginRepository, LoginRepository>();

            return services;
        }
    }
}
