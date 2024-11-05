using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Vertizens.SliceR;

namespace Benchmark;

[MemoryDiagnoser]
public class SliceRBenchmarkHandler
{
    private readonly IServiceProvider _serviceProvider;
    public SliceRBenchmarkHandler()
    {
        var services = new ServiceCollection();
        services.AddSliceRHandlers();

        _serviceProvider = services.BuildServiceProvider();
    }

    [Benchmark]
    public async Task TestHandler()
    {
        var handler = _serviceProvider.GetRequiredService<IHandler<BenchmarkRequest, BenchmarkResponse>>();
        var response = await handler.Handle(new BenchmarkRequest());
    }
}
