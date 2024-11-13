using Vertizens.SliceR.Operations;

namespace Vertizens.SliceR.Validated;
public class ByKeyValidatedHandler<TKey, TEntity>(
    IHandler<ByKey<TKey>, TEntity?> _handler
    ) : IValidatedHandler<ByKey<TKey>, TEntity?>
{
    public async Task<ValidatedResult<TEntity?>> Handle(ByKey<TKey> request, CancellationToken cancellationToken)
    {
        var entity = await _handler.Handle(request, cancellationToken);
        return new ValidatedResult<TEntity?>(entity)
        {
            IsNotFound = entity == null
        };
    }
}