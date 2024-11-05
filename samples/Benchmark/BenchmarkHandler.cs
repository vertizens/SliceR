using MediatR;
using Vertizens.SliceR;

namespace Benchmark;
public class BenchmarkHandler :
    IRequestHandler<BenchmarkRequest, BenchmarkResponse>,
    IHandler<BenchmarkRequest, BenchmarkResponse>
{
    public Task<BenchmarkResponse> Handle(BenchmarkRequest request, CancellationToken cancellationToken)
    {
        return Task.FromResult(new BenchmarkResponse { Id = 1234 });
    }
}
