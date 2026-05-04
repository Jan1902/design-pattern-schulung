namespace LensForge.Kata06;

public class AlertSystem
{
    public void SendAlert(string message)
    {
        Console.WriteLine($"[ALERT]    SMS gesendet: {message}");
    }
}
