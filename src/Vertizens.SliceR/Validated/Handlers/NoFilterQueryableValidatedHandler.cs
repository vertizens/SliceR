using System.Linq.Expressions;
using Vertizens.SliceR.Operations;
using Vertizens.TypeMapper;

namespace Vertizens.SliceR.Validated;
public class NoFilterQueryableValidatedHandler<TEntity>(
    IHandler<NoFilter, IQueryable<TEntity>> _handler
    ) : IValidatedHandler<NoFilter, IQueryable<TEntity>>
{
    public async Task<ValidatedResult<IQueryable<TEntity>>> Handle(NoFilter request, CancellationToken cancellationToken = default)
    {
        return new ValidatedResult<IQueryable<TEntity>>(await _handler.Handle(request, cancellationToken));
    }
}

public class NoFilterQueryableValidatedHandler<TEntity, TDomain>(
    IHandler<NoFilter, IQueryable<TEntity>> _handler,
    ITypeProjector<TEntity, TDomain> _typeProjector
    ) : IValidatedHandler<NoFilter, IQueryable<TDomain>>
    where TDomain : class, new()
{
    public async Task<ValidatedResult<IQueryable<TDomain>>> Handle(NoFilter request, CancellationToken cancellationToken = default)
    {
        var queryable = await _handler.Handle(request, cancellationToken);
        return new ValidatedResult<IQueryable<TDomain>>(queryable.Select(Project()));
    }

    protected virtual Expression<Func<TEntity, TDomain>> Project()
    {
        return _typeProjector.GetProjection();
    }
}
