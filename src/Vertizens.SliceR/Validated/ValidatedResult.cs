namespace Vertizens.SliceR.Validated;

/// <summary>
/// Defines a result that where the request has been validated and return the success evaluation of the execution.
/// </summary>
public class ValidatedResult
{
    /// <summary>
    /// Calculated successful flag
    /// </summary>
    public virtual bool IsSuccessful { get { return !IsNotAuthorized && !IsNotFound && Messages.Count == 0; } }
    /// <summary>
    /// Used for determining if Authorization was the cause for validation to fail
    /// </summary>
    public bool IsNotAuthorized { get; set; }
    /// <summary>
    /// Used for determining if the data was not able to be found was the cause for validation
    /// </summary>
    public bool IsNotFound { get; set; }
    /// <summary>
    /// Error messages as a result of a validation
    /// </summary>
    public Dictionary<string, IEnumerable<string>> Messages { get; set; } = [];
}

/// <summary>
/// Same as base class of <see cref="ValidatedResult"/> but is extended to contain a <typeparamref name="TResult"/> value.
/// </summary>
/// <typeparam name="TResult">Type of result</typeparam>
public class ValidatedResult<TResult> : ValidatedResult
{
    public ValidatedResult()
    {
    }

    public ValidatedResult(ValidatedResult validatedResult) : this()
    {
        IsNotAuthorized = validatedResult.IsNotAuthorized;
        IsNotFound = validatedResult.IsNotFound;
        Messages = new Dictionary<string, IEnumerable<string>>(validatedResult.Messages.Select(x => new KeyValuePair<string, IEnumerable<string>>(x.Key, x.Value.ToList())));
    }

    public ValidatedResult(TResult? result)
    {
        Result = result;
    }

    /// <summary>
    /// Result value instance if request was validated and execution complete
    /// </summary>
    public TResult? Result { get; set; }
    public override bool IsSuccessful => base.IsSuccessful && Result != null;

    public static implicit operator ValidatedResult<TResult>(TResult value) => new(value);

    public static implicit operator TResult?(ValidatedResult<TResult> result) => result.Result;
}