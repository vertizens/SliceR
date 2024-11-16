using System.Linq.Expressions;

namespace Vertizens.SliceR.Operations;

/// <summary>
/// Applies a predicate to a domain query to return data that matches filter
/// </summary>
/// <typeparam name="TFilter">Type of filter used</typeparam>
/// <typeparam name="TEntity">Entity or domain to filter</typeparam>
/// <param name="_filterValues">Collection of data used to filter a set of domain instances</param>
/// <param name="_predicate">Expression used to filter a domain set</param>
public class ByPredicateSet<TFilter, TEntity>(ICollection<TFilter> _filterValues, Expression<Func<TEntity, ICollection<TFilter>, bool>> _predicate)
{
    /// <summary>
    /// Collection of filter values to use in predicate
    /// </summary>
    public ICollection<TFilter> FilterValues { get { return _filterValues; } }

    /// <summary>
    /// The predicate expression to use for a query
    /// </summary>
    internal Expression<Func<TEntity, ICollection<TFilter>, bool>> Predicate { get { return _predicate; } }
}
