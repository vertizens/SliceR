using Vertizens.SliceR.Operations;

namespace Vertizens.SliceR.Validated;
public class ByKeyValidatedHandler<TKey, TEntity>(
    IHandler<ByKey<TKey>, TEntity?> _handler
    ) : IValidatedHandler<ByKey<TKey>, TEntity?>
{
    public async Task<ValidatedResult<TEntity?>> Handle(ByKey<TKey> request, CancellationToken cancellationToken)
    {
        return await _handler.Handle(request, cancellationToken);
    }
}