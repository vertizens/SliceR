namespace Vertizens.SliceR.Validated;
internal class DefaultValidatorProxyValidatedHandler<TRequest, TResult>(
    IValidatedHandler<TRequest, TResult> _nextHandler,
    IModelValidator<TRequest> _modelValidator
    ) : IValidatedHandler<TRequest, TResult>
{
    public async Task<ValidatedResult<TResult>> Handle(TRequest request, CancellationToken cancellationToken = default)
    {
        var modelValidatedResult = await _modelValidator.Validate(request, cancellationToken);
        var validatedResult = new ValidatedResult<TResult>(modelValidatedResult);
        if (modelValidatedResult.IsSuccessful)
        {
            validatedResult = await _nextHandler.Handle(request, cancellationToken);
        }

        return validatedResult;
    }
}

internal class DefaultValidatorProxyValidatedHandler<TRequest>(
    IValidatedHandler<TRequest> _nextHandler,
    IModelValidator<TRequest> _modelValidator
    ) : IValidatedHandler<TRequest>
{
    public async Task<ValidatedResult> Handle(TRequest request, CancellationToken cancellationToken = default)
    {
        var validatedResult = await _modelValidator.Validate(request, cancellationToken);
        if (validatedResult.IsSuccessful)
        {
            validatedResult = await _nextHandler.Handle(request, cancellationToken);
        }

        return validatedResult;
    }
}