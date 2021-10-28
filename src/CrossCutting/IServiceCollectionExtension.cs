using Microsoft.Extensions.Configuration;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
  public static class IServiceCollectionExtension
  {
    public static IServiceCollection AddAllDi(this IServiceCollection services, IConfiguration configuration)
    {
      services.AddRepositories(configuration);
      services.AddServices(configuration);

      return services;
    }
  }
}
