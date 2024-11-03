namespace Vertizens.SliceR.Validated;
public interface IModelValidator
{
    Task<ValidatedResult> Validate<TModel>(TModel model, CancellationToken cancellationToken = default);

    Task<ValidatedResult<TResult>> Validate<TModel, TResult>(TModel model, CancellationToken cancellationToken = default);
}
