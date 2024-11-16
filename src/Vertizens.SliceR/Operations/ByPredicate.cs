using System.Linq.Expressions;

namespace Vertizens.SliceR.Operations;

/// <summary>
/// Applies a predicate to a domain query to return data that matches filter
/// </summary>
/// <typeparam name="TFilter">Type of filter used</typeparam>
/// <typeparam name="TEntity">Entity or domain to filter</typeparam>
/// <param name="_filter">Data used to filter a set of domain instances</param>
/// <param name="_predicate">Expression used to filter a domain set</param>
public class ByPredicate<TFilter, TEntity>(TFilter _filter, Expression<Func<TEntity, TFilter, bool>> _predicate)
{
    /// <summary>
    /// The filter instance to use in predicate
    /// </summary>
    public TFilter Filter { get { return _filter; } }

    /// <summary>
    /// The predicate expression to use for a query
    /// </summary>
    internal Expression<Func<TEntity, TFilter, bool>> Predicate { get { return _predicate; } }
}
