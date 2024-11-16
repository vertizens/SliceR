namespace Vertizens.SliceR.Validated;

/// <summary>
/// Defines a request <typeparamref name="TModel"/> to validate before executing a validated handler
/// </summary>
/// <typeparam name="TModel">Model type to validate before executing a validated handler in pipeline</typeparam>
public interface IModelValidator<TModel>
{
    /// <summary>
    /// Validates a model if any validation rules have been defined
    /// </summary>
    /// <param name="model">Model to validate</param>
    /// <param name="cancellationToken">CancellationToken</param>
    /// <returns></returns>
    Task<ValidatedResult> Validate(TModel model, CancellationToken cancellationToken = default);
}
