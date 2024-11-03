namespace Vertizens.SliceR.Operations;
public class UpdateSet<TEntity>(IEnumerable<TEntity> _entities)
{
    public IEnumerable<TEntity> Entities { get { return _entities; } }
}
