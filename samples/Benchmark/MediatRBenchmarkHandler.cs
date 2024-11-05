using BenchmarkDotNet.Attributes;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Benchmark;

[MemoryDiagnoser]
public class MediatRBenchmarkHandler
{
    private readonly IServiceProvider _serviceProvider;
    public MediatRBenchmarkHandler()
    {
        var services = new ServiceCollection();
        services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(MediatRBenchmarkHandler).Assembly));

        _serviceProvider = services.BuildServiceProvider();
    }

    [Benchmark]
    public async Task TestHandler()
    {
        var mediatr = _serviceProvider.GetRequiredService<IMediator>();
        var response = await mediatr.Send(new BenchmarkRequest());
    }
}
