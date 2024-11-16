using System.Linq.Expressions;

namespace Vertizens.SliceR.Operations;

/// <summary>
/// Extensions for <see cref="ByPredicate{TFilter, TEntity}"/>
/// </summary>
public static class ByPredicateExtensions
{
    /// <summary>
    /// Creates a projection by creating a Expression from the predicate and filter instance
    /// </summary>
    /// <typeparam name="TFilter">Filter type to use in predicate</typeparam>
    /// <typeparam name="TEntity">Entity to filter with predicate</typeparam>
    /// <param name="request">The <see cref="ByPredicate{TFilter, TEntity}"/> instance to get a projection from</param>
    /// <returns></returns>
    public static Expression<Func<TEntity, bool>> CreateFilterExpression<TFilter, TEntity>(this ByPredicate<TFilter, TEntity> request)
    {
        return ReplaceParameterWithConstantExpressionVisitor.ReplaceParameter(request.Predicate, request.Filter);
    }
}
