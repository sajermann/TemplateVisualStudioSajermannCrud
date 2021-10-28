using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace $ext_rootnamespace$.$safeprojectname$.Context
{
  public class MyContext : DbContext
  {
    public static readonly ILoggerFactory _loggerFactory = LoggerFactory.Create(builder =>
    {
      builder.AddConsole();
    });

    public MyContext(DbContextOptions<MyContext> options)
    : base(options) { }

    //public DbSet<User> Users { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

  }
}