namespace DiContainerDemo;

public class TinyContainer
{
    private readonly Dictionary<Type, Registration> _registrations = new();

    private class Registration
    {
        public Type ImplementationType { get; init; } = null!;
        public Lifetime Lifetime { get; init; }
        public object? CachedInstance { get; set; }
    }

    public void RegisterTransient<TInterface, TImplementation>()
        where TImplementation : TInterface
    {
        _registrations[typeof(TInterface)] = new Registration
        {
            ImplementationType = typeof(TImplementation),
            Lifetime = Lifetime.Transient,
        };
    }

    public void RegisterSingleton<TInterface, TImplementation>()
        where TImplementation : TInterface
    {
        _registrations[typeof(TInterface)] = new Registration
        {
            ImplementationType = typeof(TImplementation),
            Lifetime = Lifetime.Singleton,
        };
    }

    public T Resolve<T>()
    {
        return (T)Resolve(typeof(T));
    }

    private object Resolve(Type type)
    {
        if (!_registrations.TryGetValue(type, out var registration))
            throw new InvalidOperationException(
                $"Kein Service für {type.Name} registriert");

        if (registration.Lifetime == Lifetime.Singleton
            && registration.CachedInstance != null)
        {
            return registration.CachedInstance;
        }

        // Konstruktor-Parameter über Reflection auflösen
        var constructor = registration.ImplementationType.GetConstructors().First();
        var parameters = constructor.GetParameters();

        // Für jeden Parameter rekursiv Resolve aufrufen
        var arguments = parameters
            .Select(p => Resolve(p.ParameterType))
            .ToArray();

        var instance = constructor.Invoke(arguments);

        if (registration.Lifetime == Lifetime.Singleton)
            registration.CachedInstance = instance;

        return instance;
    }
}

public enum Lifetime
{
    Transient,   // jedes Mal neu
    Singleton,   // einmal, dann immer dieselbe Instanz
}