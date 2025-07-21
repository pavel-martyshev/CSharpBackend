using Quartz;

namespace ASPJobs.Jobs;

public class QuartzJob(IConfiguration configuration) : IJob
{
    private readonly IConfiguration _configuration = configuration;

    public Task Execute(IJobExecutionContext context)
    {
        Console.WriteLine($"[QuartzJob] {_configuration["QuartzJobMessage"]}");

        return Task.CompletedTask;
    }
}
