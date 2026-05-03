namespace LensForge.Shared;

using System;

// Shared/ConsoleVisualizer.cs — simpler ASCII-Output
public static class Vis
{
    private static readonly object _lock = new();

    public static void Header(string title)
    {
        lock (_lock)
        {
            int innerWidth = Math.Max(0, title.Length);
            string border = "+" + new string('-', innerWidth + 2) + "+";
            Console.WriteLine(border);
            Console.WriteLine("| " + title + " |");
            Console.WriteLine(border);
        }
    }

    public static void Step(string station, string action)
    {
        lock (_lock)
        {
            Console.WriteLine($"[{station}] {action}...");
        }
    }

    public static void Lens(Lens lens)
    {
        lock (_lock)
        {
            Console.WriteLine($"◯ Lens {lens.Id} ({lens.Type}, {lens.DiameterMm}mm)");
        }
    }

    public static void Result(string label, bool success, string? errorMessage = null)
    {
        lock (_lock)
        {
            string symbol = success ? "✓" : "✗";
            Console.Write($"{label}: ");
            var prev = Console.ForegroundColor;
            Console.ForegroundColor = success ? ConsoleColor.Green : ConsoleColor.Red;
            Console.WriteLine(symbol);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                Console.WriteLine($"  Error: {errorMessage}");
            }
            Console.ForegroundColor = prev;
        }
    }

    public static void Separator()
    {
        lock (_lock)
        {
            Console.WriteLine(new string('─', 40));
        }
    }
}
