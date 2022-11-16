using Microsoft.Extensions.DependencyInjection;
using rewriter.Services;

namespace rewriter.OrderService
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddOrderService(this IServiceCollection services)
        {
            services.AddSingleton<IOrderService, OrderService>();
            services.AddSingleton<IUserService, UserService>();
            return services;
        }
    }
}