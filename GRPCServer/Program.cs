using GRPCServer.Services;

namespace GRPCServer;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddGrpc();
        builder.Services.AddGrpcReflection();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.MapGrpcReflectionService();
        }

        app.MapGrpcService<GreeterService>();
        app.MapGrpcService<RandomNumberService>();

        app.MapGet("/", () => "App started");

        app.Run();
    }
}