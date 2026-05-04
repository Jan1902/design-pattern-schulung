using DiContainerDemo;

var container = new TinyContainer();

container.RegisterSingleton<ILogger, ConsoleLogger>();
container.RegisterTransient<IGreeter, LoggingGreeter>();

// Wir holen einen Greeter — der Container baut intern auch 
// den Logger, weil der Greeter ihn braucht
var greeter = container.Resolve<IGreeter>();
greeter.Greet("Welt");

public interface ILogger
{
    void Log(string msg);
}

public class ConsoleLogger : ILogger
{
    public void Log(string msg) => Console.WriteLine($"[LOG] {msg}");
}

public interface IGreeter
{
    void Greet(string name);
}

public class LoggingGreeter : IGreeter
{
    private readonly ILogger _logger;

    // ← Konstruktor-Parameter! Der Container muss das auflösen.
    public LoggingGreeter(ILogger logger)
    {
        _logger = logger;
    }

    public void Greet(string name)
    {
        _logger.Log($"Greet aufgerufen mit {name}");
        Console.WriteLine($"Hallo, {name}!");
    }
}