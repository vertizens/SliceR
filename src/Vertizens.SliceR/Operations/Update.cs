namespace Vertizens.SliceR.Operations;
public class Update<TEntity>(TEntity _entity)
{
    public TEntity Entity { get { return _entity; } }

    public static implicit operator Update<TEntity>(TEntity entity) => new(entity);

    public static implicit operator TEntity(Update<TEntity> update) => update.Entity;
}

public class Update<TKey, TDomain>(TKey _key, TDomain _domain)
{
    public TDomain Domain { get { return _domain; } }
    public TKey Key { get { return _key; } }
}