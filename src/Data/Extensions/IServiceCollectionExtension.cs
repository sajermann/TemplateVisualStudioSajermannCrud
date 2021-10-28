using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
  public static class IServiceCollectionExtension
  {
    public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
    {
      //var serverVersion = new MySqlServerVersion(new Version(5, 6, 48));
      //services.AddDbContextPool<SDContext>(
      //    context => context.UseMySql(configuration.GetConnectionString("Default"), serverVersion)
      //    .EnableSensitiveDataLogging()
      //);

      //services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
      return services;
    }
  }
}
