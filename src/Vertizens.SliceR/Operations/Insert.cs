namespace Vertizens.SliceR.Operations;

/// <summary>
/// Type <typeparamref name="TDomain"/> used to map to an entity for performing an insert request
/// </summary>
/// <typeparam name="TDomain">Type of domain to insert</typeparam>
public class Insert<TDomain>(TDomain _domain)
{
    public TDomain Domain { get { return _domain; } }

    public static implicit operator Insert<TDomain>(TDomain domain) => new(domain);

    public static implicit operator TDomain(Insert<TDomain> insert) => insert.Domain;
}
