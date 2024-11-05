namespace Vertizens.SliceR.Validated;
public interface IModelValidator<TModel>
{
    Task<ValidatedResult> Validate(TModel model, CancellationToken cancellationToken = default);
}
