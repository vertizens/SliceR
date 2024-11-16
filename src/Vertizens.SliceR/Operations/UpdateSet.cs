namespace Vertizens.SliceR.Operations;

/// <summary>
/// Update operation for a set of entities
/// </summary>
/// <typeparam name="TEntity">Entity type to execute updates for</typeparam>
/// <param name="_entities">Entity instances to update</param>
public class UpdateSet<TEntity>(IEnumerable<TEntity> _entities)
{
    /// <summary>
    /// Enumerable of entities to update
    /// </summary>
    public IEnumerable<TEntity> Entities { get { return _entities; } }
}
