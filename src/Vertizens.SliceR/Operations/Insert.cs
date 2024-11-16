namespace Vertizens.SliceR.Operations;

/// <summary>
/// Type <typeparamref name="TDomain"/> used to map to an entity for performing an insert request
/// </summary>
/// <typeparam name="TDomain">Type of domain to insert</typeparam>
public class Insert<TDomain>(TDomain _domain)
{
    /// <summary>
    /// The entity or domain defined to be used in Insert operation
    /// </summary>
    public TDomain Domain { get { return _domain; } }

    /// <summary>
    /// Implicitly convert from a Domain instance to an <see cref="Insert{TDomain}"/> instance
    /// </summary>
    /// <param name="domain"></param>
    public static implicit operator Insert<TDomain>(TDomain domain) => new(domain);

    /// <summary>
    /// Implicitly convert from an Insert operation to the domain instance it is using
    /// </summary>
    /// <param name="insert">The Insert operation that has a domain instance</param>
    public static implicit operator TDomain(Insert<TDomain> insert) => insert.Domain;
}
