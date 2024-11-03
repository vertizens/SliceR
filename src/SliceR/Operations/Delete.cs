namespace Vertizens.SliceR.Operations;
public class Delete<TKey, TDomain>(TKey _key)
{
    public TKey Key { get { return _key; } }

    public static implicit operator Delete<TKey, TDomain>(TKey key) => new(key);

    public static implicit operator TKey(Delete<TKey, TDomain> delete) => delete.Key;
}