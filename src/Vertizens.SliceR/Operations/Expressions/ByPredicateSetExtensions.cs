using System.Linq.Expressions;

namespace Vertizens.SliceR.Operations;

/// <summary>
/// Extensions for <see cref="ByPredicateSet{TFilter, TEntity}"/>
/// </summary>
public static class ByPredicateSetExtensions
{
    /// <summary>
    /// Creates a filtering expression from a <see cref="ByPredicateSet{TFilter, TEntity}"/>
    /// </summary>
    /// <typeparam name="TFilter">The type of filter for a set of filter values</typeparam>
    /// <typeparam name="TEntity">Type of entities to filter on</typeparam>
    /// <param name="request">a <see cref="ByPredicateSet{TFilter, TEntity}"/> request</param>
    /// <returns></returns>
    public static Expression<Func<TEntity, bool>> CreateFilterExpression<TFilter, TEntity>(this ByPredicateSet<TFilter, TEntity> request)
    {
        return ReplaceParameterWithConstantExpressionVisitor.ReplaceParameter(request.Predicate, request.FilterValues);
    }
}
