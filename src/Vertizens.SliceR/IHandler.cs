namespace Vertizens.SliceR;

/// <summary>
/// Defines a generic handler that has one method that is modeling a method signature with no result.
/// </summary>
/// <typeparam name="TRequest">Request type</typeparam>
public interface IHandler<TRequest>
{
    /// <summary>
    /// Handles execution of the request <typeparamref name="TRequest"/> with no return.
    /// </summary>
    /// <param name="request">The request</param>
    /// <param name="cancellationToken">any cancellation token to use in async methods</param>
    /// <returns></returns>
    Task Handle(TRequest request, CancellationToken cancellationToken = default);
}

/// <summary>
/// Defines a generic handler that has one method that is modeling a method signature.
/// </summary>
/// <typeparam name="TRequest">Request type</typeparam>
/// <typeparam name="TResult">Result type</typeparam>
public interface IHandler<TRequest, TResult>
{
    /// <summary>
    /// Handles execution of the request <typeparamref name="TRequest"/> and return a result <typeparamref name="TResult"/>
    /// </summary>
    /// <param name="request">The request</param>
    /// <param name="cancellationToken">any cancellation token to use in async methods</param>
    /// <returns></returns>
    Task<TResult> Handle(TRequest request, CancellationToken cancellationToken = default);
}
