using Vertizens.SliceR.Operations;
using Vertizens.TypeMapper;

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

public class ByKeyValidatedHandler<TKey, TEntity, TDomain>(
    IHandler<ByKey<TKey>, TEntity?> _handler,
    ITypeMapper _typeMapper
    ) : IValidatedHandler<ByKey<TKey>, TDomain?>
    where TDomain : class, new()
{
    public async Task<ValidatedResult<TDomain?>> Handle(ByKey<TKey> request, CancellationToken cancellationToken)
    {
        var entity = await _handler.Handle(request, cancellationToken);
        TDomain? result = null;
        if (entity != null)
        {
            result = Map(entity);
        }

        return result;
    }

    protected virtual TDomain Map(TEntity entity)
    {
        return _typeMapper.Map<TEntity, TDomain>(entity);
    }
}
