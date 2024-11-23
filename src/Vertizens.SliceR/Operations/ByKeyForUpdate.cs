namespace Vertizens.SliceR.Operations;

/// <summary>
/// Defines a get by one key entity operation that has special consideration for selection for an 
/// update operation that will map a domain to the entity.  Only needed for entities that have relationships that are only populated 
/// for the purposes of the update
/// </summary>
/// <typeparam name="TKey">Key type to use as filter when getting data</typeparam>
/// <typeparam name="TUpdateDomain">Expected domain that will be mapped to the entity</typeparam>
/// <param name="_key"></param>
public class ByKeyForUpdate<TKey, TUpdateDomain>(TKey _key) : ByKey<TKey>(_key)
{
    /// <summary>
    /// Implicitly convert to an instance of this class from a key
    /// </summary>
    /// <param name="key">Key value</param>
    public static implicit operator ByKeyForUpdate<TKey, TUpdateDomain>(TKey key) => new(key);

    /// <summary>
    /// Implicitly convert to an instance of the key value an instance of this class holds
    /// </summary>
    /// <param name="byKey">ByKey instance</param>
    public static implicit operator TKey(ByKeyForUpdate<TKey, TUpdateDomain> byKey) => byKey.Key;
}
