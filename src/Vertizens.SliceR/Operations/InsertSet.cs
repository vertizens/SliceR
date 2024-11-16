namespace Vertizens.SliceR.Operations;

/// <summary>
/// Bulk version of insert for <typeparamref name="TDomain"/> used to map to an entity for performing an insert
/// </summary>
/// <typeparam name="TDomain">Type to map to an entity</typeparam>
/// <param name="_domains">Set of domain objects to insert</param>
public class InsertSet<TDomain>(IEnumerable<TDomain> _domains)
{
    /// <summary>
    /// Enumerable of <typeparamref name="TDomain"/> instances for inserting
    /// </summary>
    public IEnumerable<TDomain> Domains { get { return _domains; } }

    /// <summary>
    /// Implicitly convert from <typeparamref name="TDomain"/> instances to an InsertSet operation
    /// </summary>
    /// <param name="domains">Array of <typeparamref name="TDomain"/> instances</param>
    public static implicit operator InsertSet<TDomain>(TDomain[] domains) => new(domains);

    /// <summary>
    /// Implicitly convert from an InsertSet operation to the <typeparamref name="TDomain"/> instances used for insert
    /// </summary>
    /// <param name="insert">InsertSet operation</param>
    public static implicit operator TDomain[](InsertSet<TDomain> insert) => insert.Domains.ToArray();
}
