namespace Vertizens.SliceR.Operations;

/// <summary>
/// Used to read the key value from a specific entity type
/// </summary>
/// <typeparam name="TKey">Expected Type of key</typeparam>
/// <typeparam name="TEntity">Given entity</typeparam>
public interface IEntityKeyReader<TKey, TEntity>
{
    /// <summary>
    /// Returns a key instance from the given entity instance
    /// </summary>
    /// <param name="entity">entity instance</param>
    TKey ReadKey(TEntity entity);
}
