
using Microsoft.Extensions.DependencyInjection;
using Neoj4.API.Data.Abstract;

namespace Neoj4.API.Data.Configuration
{
    public static class Configuration
    {
        public static void ConfigureDataAccess(this IServiceCollection services)
        {
            services.AddSingleton(c => new ClientConfiguration
            {
                ConnectionString = "mongodb://http://localhost:53308",
                DatabaseName = "netdb"
            });
            services.AddSingleton<IDBContext, DBContext>();
        }
    }

    public class ClientConfiguration
    {
        public string ConnectionString { get; set; }

        public string DatabaseName { get; set; }
    }
}