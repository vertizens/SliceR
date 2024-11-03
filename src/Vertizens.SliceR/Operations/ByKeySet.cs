namespace Vertizens.SliceR.Operations;
public class ByKeySet<TKey>(ICollection<TKey> _keys)
{
    public ICollection<TKey> Keys { get { return _keys; } }

    public static implicit operator ByKeySet<TKey>(TKey[] keys) => new(keys);

    public static implicit operator TKey[](ByKeySet<TKey> byKeySet) => [.. byKeySet.Keys];
}
