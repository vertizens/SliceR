using Vertizens.SliceR.Operations;
using Vertizens.TypeMapper;

namespace Vertizens.SliceR.Validated;

/// <summary>
/// Handles an InsertRequest for an entity and returns the entity
/// </summary>
/// <typeparam name="TInsertRequest">Domain type to map to new entity</typeparam>
/// <typeparam name="TEntity">Entity type to insert</typeparam>
/// <param name="_handler">Handles the insert of the entity</param>
/// <param name="_typeMapper">Maps from the <typeparamref name="TInsertRequest"/> to <typeparamref name="TEntity"/></param>
public class InsertValidatedHandler<TInsertRequest, TEntity>(
    IHandler<Insert<TEntity>, TEntity> _handler,
    ITypeMapper<TInsertRequest, TEntity> _typeMapper
    ) : IValidatedHandler<Insert<TInsertRequest>, TEntity>
    where TEntity : class, new()
{
    /// <summary>
    /// Handles an InsertRequest for an entity and returns the entity
    /// </summary>
    /// <param name="request">InsertRequest with a domain mapped to the entity</param>
    /// <param name="cancellationToken">CancellationToken</param>
    /// <returns></returns>
    public async Task<ValidatedResult<TEntity>> Handle(Insert<TInsertRequest> request, CancellationToken cancellationToken = default)
    {
        var entity = Map(request);
        return await Insert(entity, cancellationToken);
    }

    /// <summary>
    /// Maps a domain onto a new entity instance
    /// </summary>
    /// <param name="request">Domain to map to entity</param>
    /// <returns></returns>
    protected virtual TEntity Map(TInsertRequest request)
    {
        var entity = new TEntity();
        _typeMapper.Map(request, entity);
        return entity;
    }

    /// <summary>
    /// Insert entity after mapping
    /// </summary>
    /// <param name="entity">Entity to insert</param>
    /// <param name="cancellationToken">CancellationToken</param>
    /// <returns></returns>
    protected virtual async Task<TEntity> Insert(TEntity entity, CancellationToken cancellationToken)
    {
        return await _handler.Handle(new Insert<TEntity>(entity), cancellationToken);
    }
}

/// <summary>
/// Handles an InsertRequest for an entity and returns the entity that is then mapped to a <typeparamref name="TDomain"/>
/// </summary>
/// <typeparam name="TInsertRequest">Type that maps to a new entity</typeparam>
/// <typeparam name="TDomain">Type that is mapped from the new entity inserted</typeparam>
/// <typeparam name="TKey">Type of the key that entity has so the newly inserted entity can be selected</typeparam>
/// <typeparam name="TEntity">Type of entity to insert</typeparam>
/// <param name="_handler">Handles the entity Insert</param>
/// <param name="_typeMapper">Maps the insert request to a new entity instance</param>
/// <param name="_entityKeyReader">EntityKey reader that can read the key from the new entity</param>
/// <param name="_getDomainHandler">Handler that can select the domain instance given the entity key</param>
public class InsertValidatedHandler<TInsertRequest, TDomain, TKey, TEntity>(
    IHandler<Insert<TEntity>, TEntity> _handler,
    ITypeMapper<TInsertRequest, TEntity> _typeMapper,
    IEntityKeyReader<TKey, TEntity> _entityKeyReader,
    IHandler<ByKey<TKey>, TDomain?> _getDomainHandler
    ) : IValidatedHandler<Insert<TInsertRequest>, TDomain>
    where TEntity : class, new()
    where TDomain : class, new()
{
    /// <summary>
    /// Handles an InsertRequest for an entity and returns the entity that is then mapped to a <typeparamref name="TDomain"/>
    /// </summary>
    /// <param name="request">Insert request for an entity</param>
    /// <param name="cancellationToken">CancellationToken</param>
    /// <returns></returns>
    public async Task<ValidatedResult<TDomain>> Handle(Insert<TInsertRequest> request, CancellationToken cancellationToken = default)
    {
        var entity = Map(request);
        var entityInserted = await Insert(entity, cancellationToken);

        var key = _entityKeyReader.ReadKey(entityInserted);
        return await Get(key, cancellationToken);
    }

    /// <summary>
    /// Maps an insert request to a new entity instance
    /// </summary>
    /// <param name="request">Insert request instance that maps to a new entity</param>
    /// <returns></returns>
    protected virtual TEntity Map(TInsertRequest request)
    {
        var entity = new TEntity();
        _typeMapper.Map(request, entity);
        return entity;
    }

    /// <summary>
    /// Insert entity after mapping
    /// </summary>
    /// <param name="entity">Entity to insert</param>
    /// <param name="cancellationToken">CancellationToken</param>
    /// <returns></returns>
    protected virtual async Task<TEntity> Insert(TEntity entity, CancellationToken cancellationToken)
    {
        return await _handler.Handle(new Insert<TEntity>(entity), cancellationToken);
    }

    /// <summary>
    /// Get the domain instance for the entity key
    /// </summary>
    /// <param name="key">key of the domain</param>
    /// <param name="cancellationToken">CancellationToken</param>
    /// <returns></returns>
    protected virtual async Task<TDomain> Get(TKey key, CancellationToken cancellationToken)
    {
        return (await _getDomainHandler.Handle(key, cancellationToken))!;
    }
}