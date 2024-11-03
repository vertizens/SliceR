using System.Linq.Expressions;

namespace Vertizens.SliceR.Operations;
public class ByPredicateSet<TFilter, TEntity>(ICollection<TFilter> _filterValues, Expression<Func<TEntity, ICollection<TFilter>, bool>> _predicate)
{
    public ICollection<TFilter> FilterValues { get { return _filterValues; } }

    internal Expression<Func<TEntity, ICollection<TFilter>, bool>> Predicate { get { return _predicate; } }
}
