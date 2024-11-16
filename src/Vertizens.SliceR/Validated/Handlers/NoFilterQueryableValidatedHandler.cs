using Vertizens.SliceR.Operations;

namespace Vertizens.SliceR.Validated;

/// <summary>
/// Handles an expected request/result combination where the request has no filter specified
/// </summary>
/// <typeparam name="TEntity">Type of entity for a result</typeparam>
/// <param name="_handler">Handler that will get 'all' entities given no filter</param>
public class NoFilterQueryableValidatedHandler<TEntity>(
    IHandler<NoFilter, IQueryable<TEntity>> _handler
    ) : IValidatedHandler<NoFilter, IQueryable<TEntity>>
{
    /// <summary>
    /// Handles an expected request/result combination where the request has no filter specified
    /// </summary>
    /// <param name="request">A request with no parameters, ie filter</param>
    /// <param name="cancellationToken">CancellationToken</param>
    /// <returns></returns>
    public async Task<ValidatedResult<IQueryable<TEntity>>> Handle(NoFilter request, CancellationToken cancellationToken = default)
    {
        return new ValidatedResult<IQueryable<TEntity>>(await _handler.Handle(request, cancellationToken));
    }
}
