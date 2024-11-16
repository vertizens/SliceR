namespace Vertizens.SliceR.Operations;

/// <summary>
/// Defines a get by one key entity operation 
/// </summary>
/// <typeparam name="TKey">Key type to use as filter when getting data</typeparam>
/// <param name="_key"></param>
public class ByKey<TKey>(TKey _key)
{
    /// <summary>
    /// Key value to use for request
    /// </summary>
    public TKey Key { get { return _key; } }

    /// <summary>
    /// Implicitly convert to an instance of this class from a key
    /// </summary>
    /// <param name="key">Key value</param>
    public static implicit operator ByKey<TKey>(TKey key) => new(key);

    /// <summary>
    /// Implicitly convert to an instance of the key value an instance of this class holds
    /// </summary>
    /// <param name="byKey">ByKey instance</param>
    public static implicit operator TKey(ByKey<TKey> byKey) => byKey.Key;
}
