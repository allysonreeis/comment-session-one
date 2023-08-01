using Microsoft.Extensions.DependencyInjection;

namespace PostComment.Application;

public static class DepencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(c => c.RegisterServicesFromAssembly(typeof(DepencyInjection).Assembly));
        return services;
    }
}