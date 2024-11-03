namespace Vertizens.SliceR.Operations;
public class Insert<TDomain>(TDomain _domain)
{
    public TDomain Domain { get { return _domain; } }

    public static implicit operator Insert<TDomain>(TDomain domain) => new(domain);

    public static implicit operator TDomain(Insert<TDomain> insert) => insert.Domain;
}
