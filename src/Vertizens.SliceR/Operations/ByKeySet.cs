namespace Vertizens.SliceR.Operations;

/// <summary>
/// Gets a set of data given a set of keys
/// </summary>
/// <typeparam name="TKey">Type of key used for domain</typeparam>
/// <param name="_keys">collection of instances of keys</param>
public class ByKeySet<TKey>(ICollection<TKey> _keys)
{
    public ICollection<TKey> Keys { get { return _keys; } }

    public static implicit operator ByKeySet<TKey>(TKey[] keys) => new(keys);

    public static implicit operator TKey[](ByKeySet<TKey> byKeySet) => [.. byKeySet.Keys];
}
