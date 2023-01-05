using Microsoft.Extensions.DependencyInjection;

namespace Optivify.RequestResponse
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRequestDispatcher(this IServiceCollection services)
        {
            services.AddScoped<IRequestDispatcher, RequestDispatcher>();

            return services;
        }
    }
}
