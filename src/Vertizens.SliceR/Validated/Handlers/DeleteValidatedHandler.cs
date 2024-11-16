using Vertizens.SliceR.Operations;

namespace Vertizens.SliceR.Validated;

/// <summary>
/// Validated handler for Deleting an entity by key value.  Returns NotFound if Delete was not successful.
/// </summary>
/// <typeparam name="TKey">Type of key for the <typeparamref name="TEntity"/></typeparam>
/// <typeparam name="TEntity">Entity type to delete</typeparam>
/// <param name="_handler">Entity Delete handler that doesn't require validation</param>
public class DeleteValidatedHandler<TKey, TEntity>(
    IHandler<Delete<TKey, TEntity>, bool> _handler
    ) : IValidatedHandler<Delete<TKey, TEntity>>
{
    /// <summary>
    /// Handles a Delete of an entity by key value.  Returns NotFound if Delete was not successful.
    /// </summary>
    /// <param name="request">Delete by key request</param>
    /// <param name="cancellationToken">CancellationToken</param>
    /// <returns></returns>
    public async Task<ValidatedResult> Handle(Delete<TKey, TEntity> request, CancellationToken cancellationToken)
    {
        var deleteSuccess = await _handler.Handle(request, cancellationToken);

        return new ValidatedResult { IsNotFound = !deleteSuccess };
    }
}

/// <summary>
/// Validated handler for Deleting an entity by key value.  Returns NotFound if Delete was not successful.
/// </summary>
/// <typeparam name="TKey">Type of key for the <typeparamref name="TEntity"/></typeparam>
/// <typeparam name="TDomain">Domain that maps an entity</typeparam>
/// <typeparam name="TEntity">Entity type to delete</typeparam>
/// <param name="_handler">Entity Delete handler that doesn't require validation</param>
public class DeleteValidatedHandler<TKey, TDomain, TEntity>(
    IHandler<Delete<TKey, TEntity>, bool> _handler
    ) : IValidatedHandler<Delete<TKey, TDomain>>
{
    /// <summary>
    /// Handles a Delete of an entity by key value.  Returns NotFound if Delete was not successful.
    /// </summary>
    /// <param name="request">Delete by key request</param>
    /// <param name="cancellationToken">CancellationToken</param>
    /// <returns></returns>
    public async Task<ValidatedResult> Handle(Delete<TKey, TDomain> request, CancellationToken cancellationToken)
    {
        var deleteSucces = await _handler.Handle(request.Key, cancellationToken);

        return new ValidatedResult { IsNotFound = !deleteSucces };
    }
}
