using ModernWebApiDemo.Notifications;

namespace ModernWebApiDemo;

public static class StrategyExtensions
{
    public static IServiceCollection AddOrderEventHandlersFromAssembly(this IServiceCollection services, Type assemblyLocator)
    {
        var strategyTypes = assemblyLocator.Assembly
            .GetTypes()
            .Where(c => c.IsAssignableTo(typeof(IOrderEventHandler)) && !c.IsInterface && !c.IsAbstract);

        foreach (var strategyType in strategyTypes)
        {
            services.AddTransient(typeof(IOrderEventHandler), strategyType);
        }

        return services;
    }
}
