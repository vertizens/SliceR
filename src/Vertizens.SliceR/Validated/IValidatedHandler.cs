namespace Vertizens.SliceR.Validated;

/// <summary>
/// Defines a generic validated handler that has one method that is modeling a method signature with a validated result.
/// </summary>
/// <typeparam name="TRequest">Request type</typeparam>
public interface IValidatedHandler<TRequest> : IHandler<TRequest, ValidatedResult>
{

}

/// <summary>
/// Defines a generic validated handler that has one method that is modeling a method signature with a typed validated result.
/// </summary>
/// <typeparam name="TRequest">Request type</typeparam>
/// <typeparam name="TResult">Result type</typeparam>
public interface IValidatedHandler<TRequest, TResult> : IHandler<TRequest, ValidatedResult<TResult>>
{

}
