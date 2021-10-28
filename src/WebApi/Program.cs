using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace $ext_rootnamespace$.$safeprojectname$
{
  public class Program
  {
    public static void Main(string[] args)
    {
      var config = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json").Build();

      // Se ocorrer exceção é pq a connection string no appsettings está em branco, preencha com dados do servidor de banco dados mysql
      // ou delete a o objeto respectivo na seção Serilog:WriteTo;
      Log.Logger = new LoggerConfiguration()
        .ReadFrom.Configuration(config).CreateLogger();

      try
      {
        Log.Information("Sajermann Bifrost inicializando...");
        CreateHostBuilder(args).Build().Run();
      }
      catch (Exception e)
      {
        Log.Fatal(e, "A aplicação falhou a inicializar!");
      }
      finally
      {
        Log.CloseAndFlush();
      }
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
      Host.CreateDefaultBuilder(args)
        .UseSerilog()
        .ConfigureWebHostDefaults(webBuilder =>
        {
          webBuilder.UseStartup<Startup>();
        });
  }
}
