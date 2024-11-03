using System.Linq.Expressions;

namespace Vertizens.SliceR.Operations;
public static class ByPredicateSetExtensions
{
    public static Expression<Func<TEntity, bool>> CreateFilterExpression<TFilter, TEntity>(this ByPredicateSet<TFilter, TEntity> request)
    {
        return ReplaceParameterWithConstantExpressionVisitor.ReplaceParameter(request.Predicate, request.FilterValues);
    }
}
