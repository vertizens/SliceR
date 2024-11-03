using System.Linq.Expressions;

namespace Vertizens.SliceR.Operations;
internal class ReplaceParameterWithConstantExpressionVisitor : ExpressionVisitor
{
    private readonly ParameterExpression _param;
    private readonly ConstantExpression _constant;

    private ReplaceParameterWithConstantExpressionVisitor(
        ParameterExpression param,
        ConstantExpression constant)
    {
        _param = param;
        _constant = constant;
    }

    public static Expression<Func<TParameter, bool>> ReplaceParameter<TParameter, TConstant>(
        Expression<Func<TParameter, TConstant, bool>> inputExpression,
        TConstant constant)
    {
        var body = inputExpression.Body;
        var visitor = new ReplaceParameterWithConstantExpressionVisitor(inputExpression.Parameters[1], Expression.Constant(constant, typeof(TConstant)));
        var newBody = visitor.Visit(body);

        return Expression.Lambda<Func<TParameter, bool>>(newBody, [inputExpression.Parameters[0]]);
    }

    protected override Expression VisitParameter(ParameterExpression node)
    {
        return node == _param ? _constant : base.VisitParameter(node);
    }
}