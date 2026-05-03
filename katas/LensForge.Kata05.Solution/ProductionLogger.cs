using LensForge.Shared;

namespace LensForge.Kata05.Solution;

public class ProductionLogger
{
    private static ProductionLogger? _instance;

    private readonly StreamWriter _fileWriter;
    public LogLevel MinimumLevel { get; set; } = LogLevel.Info;

    private ProductionLogger()
    {
        _fileWriter = new StreamWriter("production.log", append: true)
        {
            AutoFlush = true
        };
    }

    public static ProductionLogger Instance
    {
        get
        {
            if (_instance == null)
                _instance = new ProductionLogger();

            return _instance;
        }
    }

    public void Log(LogLevel level, string source, string message)
    {
        if (level < MinimumLevel) return;
        var line = $"[{DateTime.Now:HH:mm:ss}] [{level}] [{source}] {message}";
        Console.WriteLine(line);
        _fileWriter.WriteLine(line);
    }

    public void Info(string source, string message) => Log(LogLevel.Info, source, message);
    public void Warning(string source, string message) => Log(LogLevel.Warning, source, message);
    public void Error(string source, string message) => Log(LogLevel.Error, source, message);
}
