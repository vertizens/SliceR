namespace Vertizens.SliceR.Operations;

/// <summary>
/// Defines a get by one key entity operation 
/// </summary>
/// <typeparam name="TKey">Key type to use as filter when getting data</typeparam>
/// <param name="_key"></param>
public class ByKey<TKey>(TKey _key)
{
    public TKey Key { get { return _key; } }

    public static implicit operator ByKey<TKey>(TKey key) => new(key);

    public static implicit operator TKey(ByKey<TKey> byKey) => byKey.Key;
}
