using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ModernDemo;

using var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddSingleton<LensFactory>();
        services.AddSingleton<EventLogger>();

        services.AddMediatR(typeof(Program).Assembly);
        services.AddTransient<IRequestHandler<PingCommand, Unit>, PingHandler>();

        services.AddHttpClient("demo", c => c.BaseAddress = new Uri("https://example.com"));
    })
    .Build();

_ = host.Services.GetRequiredService<EventLogger>();

var mediator = host.Services.GetRequiredService<IMediator>();
await mediator.Send(new PingCommand("Hello from MediatR"));

var factory = host.Services.GetRequiredService<LensFactory>();
await factory.ProduceAsync();

Console.WriteLine("Demo finished. Press Enter to exit.");
Console.ReadLine();