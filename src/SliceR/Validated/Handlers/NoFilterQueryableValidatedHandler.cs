using Vertizens.SliceR.Operations;

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
