namespace Vertizens.SliceR.Validated;
public interface IValidatedHandler<TRequest> : IHandler<TRequest, ValidatedResult>
{

}

public interface IValidatedHandler<TRequest, TResult> : IHandler<TRequest, ValidatedResult<TResult>>
{

}
