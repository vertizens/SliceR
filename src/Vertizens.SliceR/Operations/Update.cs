namespace Vertizens.SliceR.Operations;

/// <summary>
/// Type <typeparamref name="TEntity"/> used to execute an update request
/// </summary>
/// <typeparam name="TEntity">Type of entity to update</typeparam>
public class Update<TEntity>(TEntity _entity)
{
    public TEntity Entity { get { return _entity; } }

    public static implicit operator Update<TEntity>(TEntity entity) => new(entity);

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
    public TDomain Domain { get { return _domain; } }
    public TKey Key { get { return _key; } }
}