namespace rewriter.api.Configuration
{
    public static class HealthCheckConfiguration
    {
        public static IServiceCollection AddAppHealthCheck(this IServiceCollection services)
        {
            services.AddHealthChecks();
            return services;
        }
        
        public static WebApplication UseAppHealthCheck(this WebApplication app)
        {
            app.MapHealthChecks("/health");
            return app;
        }
    }

}
