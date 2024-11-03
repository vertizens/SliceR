using System.Linq.Expressions;

namespace Vertizens.SliceR.Operations;
public class ByPredicate<TFilter, TEntity>(TFilter _filter, Expression<Func<TEntity, TFilter, bool>> _predicate)
{
    public TFilter Filter { get { return _filter; } }

    internal Expression<Func<TEntity, TFilter, bool>> Predicate { get { return _predicate; } }
}
