namespace Vertizens.SliceR.Operations;

/// <summary>
/// Gets a set of data given a set of keys
/// </summary>
/// <typeparam name="TKey">Type of key used for domain</typeparam>
/// <param name="_keys">collection of instances of keys</param>
public class ByKeySet<TKey>(ICollection<TKey> _keys)
{
    /// <summary>
    /// The set of keys used to find entities in a request
    /// </summary>
    public ICollection<TKey> Keys { get { return _keys; } }

    /// <summary>
    /// Implicitly convert from an array of keys to an instance of <see cref="ByKeySet{TKey}"/>
    /// </summary>
    /// <param name="keys">keys to use</param>
    public static implicit operator ByKeySet<TKey>(TKey[] keys) => new(keys);

    /// <summary>
    /// Implicitly convert to an array of key values from a <see cref="ByKeySet{TKey}"/>
    /// </summary>
    /// <param name="byKeySet">ByKeySet instance to get keys from</param>
    public static implicit operator TKey[](ByKeySet<TKey> byKeySet) => [.. byKeySet.Keys];
}
