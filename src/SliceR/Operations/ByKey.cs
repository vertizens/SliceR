namespace Vertizens.SliceR.Operations;
public class ByKey<TKey>(TKey _key)
{
    public TKey Key { get { return _key; } }

    public static implicit operator ByKey<TKey>(TKey key) => new(key);

    public static implicit operator TKey(ByKey<TKey> byKey) => byKey.Key;
}
