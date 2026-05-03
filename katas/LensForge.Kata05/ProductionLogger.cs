using LensForge.Shared;

namespace LensForge.Kata05;

public class ProductionLogger
{
    private readonly StreamWriter _fileWriter;
    public LogLevel MinimumLevel { get; set; } = LogLevel.Info;

    public ProductionLogger()
    {
        _fileWriter = new StreamWriter("production.log", append: true)
        {
            AutoFlush = true
        };
    }

    public void Log(LogLevel level, string source, string message)
    {
        if (level < MinimumLevel)
            return;

        var line = $"[{DateTime.Now:HH:mm:ss}] [{level}] [{source}] {message}";

        Console.WriteLine(line);
        _fileWriter.WriteLine(line);
    }

    public void Info(string source, string message) => Log(LogLevel.Info, source, message);
    public void Warning(string source, string message) => Log(LogLevel.Warning, source, message);
    public void Error(string source, string message) => Log(LogLevel.Error, source, message);
}