using Login.Application.Abstract.Interface.Authentication;
using Login.Application.Abstract.Interface.Services;
using Login.Application.Common.Service;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Login.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            services.AddTransient<ILoginService, LoginService>();
            return services;
        }
    }
}
