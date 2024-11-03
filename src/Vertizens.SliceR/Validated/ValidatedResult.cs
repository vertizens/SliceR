namespace Vertizens.SliceR.Validated;
public class ValidatedResult
{
    public virtual bool IsSuccessful { get { return !IsNotAuthorized && !IsNotFound && Messages.Count == 0; } }
    public bool IsNotAuthorized { get; set; }
    public bool IsNotFound { get; set; }
    public Dictionary<string, IEnumerable<string>> Messages { get; set; } = [];
}

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

    public TResult? Result { get; set; }
    public override bool IsSuccessful => base.IsSuccessful && Result != null;

    public static implicit operator ValidatedResult<TResult>(TResult value) => new(value);

    public static implicit operator TResult?(ValidatedResult<TResult> result) => result.Result;
}