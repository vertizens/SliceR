namespace Vertizens.SliceR.Operations;

/// <summary>
/// Bulk version of insert for <typeparamref name="TDomain"/> used to map to an entity for performing an insert
/// </summary>
/// <typeparam name="TDomain">Type to map to an entity</typeparam>
/// <param name="_domains"></param>
public class InsertSet<TDomain>(IEnumerable<TDomain> _domains)
{
    public IEnumerable<TDomain> Domains { get { return _domains; } }

    public static implicit operator InsertSet<TDomain>(TDomain[] domains) => new(domains);

    public static implicit operator TDomain[](InsertSet<TDomain> insert) => insert.Domains.ToArray();
}
