using Vertizens.SliceR.Operations;
using Vertizens.TypeMapper;

namespace Vertizens.SliceR.Validated;

/// <summary>
/// Handles an update request to an existing entity instance.  Find instance by key and pass a type that maps to the existing entity.
/// </summary>
/// <typeparam name="TKey">Type of key for the <typeparamref name="TEntity"/></typeparam>
/// <typeparam name="TUpdateRequest">Domain type to map to the existing entity</typeparam>
/// <typeparam name="TEntity">Type of entity to update</typeparam>
/// <param name="_updateHandler">Handler to do the entity update</param>
/// <param name="_getHandler">Handler to find the existing entity</param>
/// <param name="_typeMapper"></param>
public class UpdateValidatedHandler<TKey, TUpdateRequest, TEntity>(
    IHandler<Update<TEntity>, TEntity> _updateHandler,
    IHandler<ByKeyForUpdate<TKey, TUpdateRequest>, TEntity?> _getHandler,
    ITypeMapper<TUpdateRequest, TEntity> _typeMapper
    ) : IValidatedHandler<Update<TKey, TUpdateRequest>, TEntity>
    where TEntity : class, new()
{
    /// <summary>
    /// Handles an update request to an existing entity instance.  Find instance by key and pass a type that maps to the existing entity.
    /// </summary>
    /// <param name="request">Update request by key</param>
    /// <param name="cancellationToken">CancellationToken</param>
    /// <returns></returns>
    public async Task<ValidatedResult<TEntity>> Handle(Update<TKey, TUpdateRequest> request, CancellationToken cancellationToken = default)
    {
        var existingEntity = await Get(request.Key, cancellationToken);
        var result = new ValidatedResult<TEntity> { IsNotFound = existingEntity == null };

        if (!result.IsNotFound)
        {
            Map(request.Domain, existingEntity!);
            result = await Update(new Update<TEntity>(existingEntity!), cancellationToken);
        }

        return result;
    }

    /// <summary>
    /// Gets the existing entity instance
    /// </summary>
    /// <param name="key">TKey of entity</param>
    /// <param name="cancellationToken">CancellationToken</param>
    /// <returns></returns>
    protected virtual Task<TEntity?> Get(TKey key, CancellationToken cancellationToken)
    {
        return _getHandler.Handle(key, cancellationToken);
    }

    /// <summary>
    /// Maps an update request to an existing entity instance
    /// </summary>
    /// <param name="request">Update type that maps onto the entity</param>
    /// <param name="existingEntity">Entity that was found by key</param>
    protected virtual void Map(TUpdateRequest request, TEntity existingEntity)
    {
        _typeMapper.Map(request, existingEntity);
    }

    /// <summary>
    /// Updates an instance of an entity
    /// </summary>
    /// <param name="entity">Entity to update</param>
    /// <param name="cancellationToken">CancellationToken</param>
    /// <returns></returns>
    protected virtual Task<TEntity> Update(TEntity entity, CancellationToken cancellationToken)
    {
        return _updateHandler.Handle(new Update<TEntity>(entity), cancellationToken);
    }
}

/// <summary>
/// Handles an update request to an existing entity instance.  Find instance by key and pass a type that maps to the existing entity.
/// </summary>
/// <typeparam name="TKey">Type of key for the <typeparamref name="TEntity"/></typeparam>
/// <typeparam name="TUpdateRequest">Update type to map onto the existing entity</typeparam>
/// <typeparam name="TDomain">Domain to map to from the entity being returned</typeparam>
/// <typeparam name="TEntity">Entity type to update</typeparam>
/// <param name="_updateHandler">Handler that performs the update</param>
/// <param name="_getEntityHandler">Handler that finds the existing entity</param>
/// <param name="_getDomainHandler">Handler that selects the domain by key</param>
/// <param name="_typeMapper">Maps update request to the existing entity</param>
public class UpdateValidatedHandler<TKey, TUpdateRequest, TDomain, TEntity>(
    IHandler<Update<TEntity>, TEntity> _updateHandler,
    IHandler<ByKeyForUpdate<TKey, TUpdateRequest>, TEntity?> _getEntityHandler,
    IHandler<ByKey<TKey>, TDomain?> _getDomainHandler,
    ITypeMapper<TUpdateRequest, TEntity> _typeMapper
    ) : IValidatedHandler<Update<TKey, TUpdateRequest>, TDomain>
    where TDomain : class, new()
{
    /// <summary>
    /// Handles an update request to an existing entity instance.  Find instance by key and pass a type that maps to the existing entity.
    /// </summary>
    /// <param name="request">Update request by key</param>
    /// <param name="cancellationToken">CancellationToken</param>
    /// <returns></returns>
    public async Task<ValidatedResult<TDomain>> Handle(Update<TKey, TUpdateRequest> request, CancellationToken cancellationToken = default)
    {
        var existingEntity = await Get(request.Key, cancellationToken);
        var result = new ValidatedResult<TDomain> { IsNotFound = existingEntity == null };

        if (!result.IsNotFound)
        {
            Map(request.Domain, existingEntity!);
            await Update(new Update<TEntity>(existingEntity!), cancellationToken);

            result.Result = await GetDomain(request.Key, cancellationToken);
        }

        return result;
    }

    /// <summary>
    /// Gets the existing entity instance
    /// </summary>
    /// <param name="key">TKey of entity</param>
    /// <param name="cancellationToken">CancellationToken</param>
    /// <returns></returns>
    protected virtual Task<TEntity?> Get(TKey key, CancellationToken cancellationToken)
    {
        return _getEntityHandler.Handle(key, cancellationToken);
    }

    /// <summary>
    /// Maps an update request to an existing entity instance
    /// </summary>
    /// <param name="request">Update type that maps onto the entity</param>
    /// <param name="existingEntity">Entity that was found by key</param>
    protected virtual void Map(TUpdateRequest request, TEntity existingEntity)
    {
        _typeMapper.Map(request, existingEntity);
    }

    /// <summary>
    /// Updates an instance of an entity
    /// </summary>
    /// <param name="entity">Entity to update</param>
    /// <param name="cancellationToken">CancellationToken</param>
    /// <returns></returns>
    protected virtual Task<TEntity> Update(TEntity entity, CancellationToken cancellationToken)
    {
        return _updateHandler.Handle(new Update<TEntity>(entity), cancellationToken);
    }

    /// <summary>
    /// Gets the existing domain instance
    /// </summary>
    /// <param name="key">TKey of domain</param>
    /// <param name="cancellationToken">CancellationToken</param>
    /// <returns></returns>
    protected virtual Task<TDomain?> GetDomain(TKey key, CancellationToken cancellationToken)
    {
        return _getDomainHandler.Handle(key, cancellationToken);
    }
}
