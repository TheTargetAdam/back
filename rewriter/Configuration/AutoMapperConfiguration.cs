using rewriter.Shared.Common.Helpers;

namespace rewriter.api.Configuration
{
    public static class AutoMapperConfiguration
    {
        public static IServiceCollection AddAutoMappers(this IServiceCollection services)
        {
            AutoMappersRegisterHelper.Register(services);

            return services;
        }
    }
}
