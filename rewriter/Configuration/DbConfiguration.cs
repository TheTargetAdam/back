using rewriter.Settings.Interface;
using Db.Context.Factories;
using Db.Context.Context;
using Microsoft.Extensions.DependencyInjection;
using Db.Context.Setup;

namespace rewriter.api.Configuration
{
    public static  class DbConfiguration
    {
        public static IServiceCollection AddAppDbContext(this IServiceCollection services,IApiSettings settings)
        {
            var dbOptionsDelegate = DbContextOptionFactory.Configure(settings.Db.ConnectionString);
            services.AddDbContextFactory<MainDbContext>(dbOptionsDelegate,ServiceLifetime.Singleton);
            return services;
        }
        public static IApplicationBuilder UseAppDbContext(this IApplicationBuilder app)
        {
            DbInit.Execute(app.ApplicationServices);

            DbSeed.Execute(app.ApplicationServices);

            return app;
        }
    }
}
