using Microsoft.Extensions.Configuration;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
  public static class IServiceCollectionExtension
  {
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
      services.AddMemoryCache();
      services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
      
      return services;
    }
  }
}
