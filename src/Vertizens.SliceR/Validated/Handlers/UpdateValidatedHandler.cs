using Vertizens.SliceR.Operations;
using Vertizens.TypeMapper;

namespace Vertizens.SliceR.Validated;
public class UpdateValidatedHandler<TKey, TUpdateRequest, TEntity>(
    IHandler<Update<TEntity>, TEntity> _updateHandler,
    IHandler<ByKey<TKey>, TEntity?> _getHandler,
    ITypeMapper _typeMapper
    ) : IValidatedHandler<Update<TKey, TUpdateRequest>, TEntity>
    where TEntity : class, new()
{
    public async Task<ValidatedResult<TEntity>> Handle(Update<TKey, TUpdateRequest> request, CancellationToken cancellationToken = default)
    {
        var existingEntity = await _getHandler.Handle(request.Key, cancellationToken);
        var result = new ValidatedResult<TEntity> { IsNotFound = existingEntity == null };

        if (!result.IsNotFound)
        {
            Map(request.Domain, existingEntity!);
            result = await _updateHandler.Handle(new Update<TEntity>(existingEntity!), cancellationToken);
        }

        return result;
    }

    protected virtual void Map(TUpdateRequest request, TEntity existingEntity)
    {
        _typeMapper.Map(request, existingEntity);
    }
}

public class UpdateValidatedHandler<TKey, TUpdateRequest, TDomain, TEntity>(
    IHandler<Update<TEntity>, TEntity> _updateHandler,
    IHandler<ByKey<TKey>, TEntity?> _getEntityHandler,
    IHandler<ByKey<TKey>, TDomain?> _getDomainHandler,
    ITypeMapper _typeMapper
    ) : IValidatedHandler<Update<TKey, TUpdateRequest>, TDomain>
    where TDomain : class, new()
{
    public async Task<ValidatedResult<TDomain>> Handle(Update<TKey, TUpdateRequest> request, CancellationToken cancellationToken = default)
    {
        var existingEntity = await _getEntityHandler.Handle(request.Key, cancellationToken);
        var result = new ValidatedResult<TDomain> { IsNotFound = existingEntity == null };

        if (!result.IsNotFound)
        {
            Map(request.Domain, existingEntity!);
            await _updateHandler.Handle(new Update<TEntity>(existingEntity!), cancellationToken);

            result.Result = await _getDomainHandler.Handle(request.Key, cancellationToken);
        }

        return result;
    }

    protected virtual void Map(TUpdateRequest request, TEntity existingEntity)
    {
        _typeMapper.Map(request, existingEntity);
    }
}
