using LensForge.Shared;

namespace LensForge.Kata05;

public interface ILogger
{
    LogLevel MinimumLevel { get; set; }
    void Info(string source, string message);
    void Warning(string source, string message);
    void Error(string source, string message);
}
