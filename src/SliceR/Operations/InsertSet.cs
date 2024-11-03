namespace Vertizens.SliceR.Operations;
public class InsertSet<TDomain>(IEnumerable<TDomain> _domains)
{
    public IEnumerable<TDomain> Domains { get { return _domains; } }

    public static implicit operator InsertSet<TDomain>(TDomain[] domains) => new(domains);

    public static implicit operator TDomain[](InsertSet<TDomain> insert) => insert.Domains.ToArray();
}
