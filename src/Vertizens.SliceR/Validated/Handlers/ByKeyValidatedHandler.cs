using Vertizens.SliceR.Operations;

namespace Vertizens.SliceR.Validated;

/// <summary>
/// Handles a <see cref="ByKey{TKey}"/> request with a <typeparamref name="TEntity"/> response
/// </summary>
/// <typeparam name="TKey">Type of key for the <typeparamref name="TEntity"/></typeparam>
/// <typeparam name="TEntity">Entity type to find by key</typeparam>
/// <param name="_handler"></param>
public class ByKeyValidatedHandler<TKey, TEntity>(
    IHandler<ByKey<TKey>, TEntity?> _handler
    ) : IValidatedHandler<ByKey<TKey>, TEntity?>
{
    /// <summary>
    /// Handles a <see cref="ByKey{TKey}"/> request with a <typeparamref name="TEntity"/> response
    /// </summary>
    /// <param name="request">ByKey request with a key to filter on</param>
    /// <param name="cancellationToken">CancellationToken</param>
    /// <returns></returns>
    public async Task<ValidatedResult<TEntity?>> Handle(ByKey<TKey> request, CancellationToken cancellationToken)
    {
        var entity = await _handler.Handle(request, cancellationToken);
        return new ValidatedResult<TEntity?>(entity)
        {
            IsNotFound = entity == null
        };
    }
}