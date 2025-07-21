using System.Timers;

namespace TopShelfJob;

internal class HelloWorldPrinter
{
    private readonly System.Timers.Timer _timer;

    public HelloWorldPrinter()
    {
        _timer = new System.Timers.Timer(3000);
        _timer.Elapsed += OnElapsed;
        _timer.AutoReset = true;
    }

    public bool Start()
    {
        _timer.Start();
        return true;
    }

    public bool Stop()
    {
        _timer.Stop();
        return true;
    }

    private void OnElapsed(object? sender, ElapsedEventArgs e)
    {
        Console.WriteLine($"Hello World");
    }
}
