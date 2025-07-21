namespace ASPJobs.Jobs;

public class HostedService : IHostedService
{
    private Timer? _timer;

    private void PrintHelloWorld(object? state)
    {
        Console.WriteLine("[HostedService] Hello World");
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _timer = new Timer(PrintHelloWorld, null, TimeSpan.Zero, TimeSpan.FromSeconds(3));
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _timer?.Change(Timeout.Infinite, 0);
        return Task.CompletedTask;
    }
}
