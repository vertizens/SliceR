using Vertizens.SliceR.Operations;

namespace Vertizens.SliceR.Validated;
public class DeleteValidatedHandler<TKey, TEntity>(
    IHandler<Delete<TKey, TEntity>, bool> _handler
    ) : IValidatedHandler<Delete<TKey, TEntity>>
{
    public async Task<ValidatedResult> Handle(Delete<TKey, TEntity> request, CancellationToken cancellationToken)
    {
        var deleteSucces = await _handler.Handle(request, cancellationToken);

        return new ValidatedResult { IsNotFound = !deleteSucces };
    }
}

public class DeleteValidatedHandler<TKey, TDomain, TEntity>(
    IHandler<Delete<TKey, TEntity>, bool> _handler
    ) : IValidatedHandler<Delete<TKey, TDomain>>
{
    public async Task<ValidatedResult> Handle(Delete<TKey, TDomain> request, CancellationToken cancellationToken)
    {
        var deleteSucces = await _handler.Handle(request.Key, cancellationToken);

        return new ValidatedResult { IsNotFound = !deleteSucces };
    }
}
