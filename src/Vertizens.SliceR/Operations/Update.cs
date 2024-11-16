namespace Vertizens.SliceR.Operations;

/// <summary>
/// Type <typeparamref name="TEntity"/> used to execute an update request
/// </summary>
/// <typeparam name="TEntity">Type of entity to update</typeparam>
public class Update<TEntity>(TEntity _entity)
{
    /// <summary>
    /// Entity to update
    /// </summary>
    public TEntity Entity { get { return _entity; } }

    /// <summary>
    /// Implicitly convert entity to Update operation with entity instance
    /// </summary>
    /// <param name="entity">entity instance</param>
    public static implicit operator Update<TEntity>(TEntity entity) => new(entity);

    /// <summary>
    /// Implicitly convert Update operation to the entity instance used for update
    /// </summary>
    /// <param name="update">Update operation</param>
    public static implicit operator TEntity(Update<TEntity> update) => update.Entity;
}

/// <summary>
/// Find an existing entity that the domain maps to by key map the domain instance onto the entity
/// </summary>
/// <typeparam name="TKey">Key on an existing entity to find</typeparam>
/// <typeparam name="TDomain">Domain object to map onto an entity for an update</typeparam>
/// <param name="_key">Key value of existing entity</param>
/// <param name="_domain">Domain instance to map onto entity</param>
public class Update<TKey, TDomain>(TKey _key, TDomain _domain)
{
    /// <summary>
    /// Domain instance to map to entity for an update
    /// </summary>
    public TDomain Domain { get { return _domain; } }

    /// <summary>
    /// Key value used to find existing entity
    /// </summary>
    public TKey Key { get { return _key; } }
}