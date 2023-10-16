using GenMax.Database.DbContext;
using GenMax.Log;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GenMax.HostBuilder
{
    public static class AddDbContextHostBuilderExtensions
    {
        public static IHostBuilder AddDbContext(this IHostBuilder host)
        {
            host.ConfigureServices(services =>
            {
                services.AddSingleton(s => new UserDbContext(s.GetRequiredService<ILog>()));
                services.AddSingleton(s => new ProtocolDbContext(s.GetRequiredService<ILog>()));
            });

            return host;
        }
    }
}
