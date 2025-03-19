namespace EFD.WebApi.Configuration;

using EFD.Data.Context;
using Microsoft.EntityFrameworkCore;

public static class DataBaseConfig
{
    public static void AddDataBaseConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.
            AddDbContext<EFDContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("EFDConnection")));
    }

    public static void UseDatabaseConfiguration(this IApplicationBuilder app)
    {
        //using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
        //using var context = serviceScope.ServiceProvider.GetService<EFDContext>();

        //context.Database.Migrate(); // Aplica qualquer migração pendente no contexto do banco de dados. 
        //context.Database.EnsureCreated();   // Garantir que a base de dados está criada
    }
}
