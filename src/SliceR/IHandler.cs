namespace Vertizens.SliceR;

public interface IHandler<TRequest>
{
    Task Handle(TRequest request, CancellationToken cancellationToken = default);
}

public interface IHandler<TRequest, TResult>
{
    Task<TResult> Handle(TRequest request, CancellationToken cancellationToken = default);
}
