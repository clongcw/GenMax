using GenMax.Database.Interface;
using GenMax.Database.Service;
using GenMax.Log;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GenMax.HostBuilder
{
    public static class AddServicesHostBuilderExtensions
    {
        public static IHostBuilder AddServices(this IHostBuilder host)
        {
            host.ConfigureServices(services =>
            {
                services.AddSingleton<ILog, LogService>();
                services.AddSingleton<IProtocolService, ProtocolService>();
                services.AddSingleton<IRoleService, RoleService>();
                services.AddSingleton<IUserService, UserService>();
            });

            return host;
        }
    }
}
