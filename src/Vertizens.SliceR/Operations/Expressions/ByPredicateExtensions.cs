using System.Linq.Expressions;

namespace Vertizens.SliceR.Operations;
public static class ByPredicateExtensions
{
    public static Expression<Func<TEntity, bool>> CreateFilterExpression<TFilter, TEntity>(this ByPredicate<TFilter, TEntity> request)
    {
        return ReplaceParameterWithConstantExpressionVisitor.ReplaceParameter(request.Predicate, request.Filter);
    }
}
