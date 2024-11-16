namespace Vertizens.SliceR.Operations;

/// <summary>
/// Represents a Delete a domain by key request
/// </summary>
/// <typeparam name="TKey">Type of key</typeparam>
/// <typeparam name="TDomain">Type of domain to delete</typeparam>
/// <param name="_key">instance of key</param>
public class Delete<TKey, TDomain>(TKey _key)
{
    /// <summary>
    /// Key used in Delete Operation
    /// </summary>
    public TKey Key { get { return _key; } }

    /// <summary>
    /// Implicitly convert a key to a Delete Operation with that key
    /// </summary>
    /// <param name="key">Key value to use in a Delete</param>
    public static implicit operator Delete<TKey, TDomain>(TKey key) => new(key);

    /// <summary>
    /// Implicitly convert a Delete operation to the key value its using
    /// </summary>
    /// <param name="delete">Delete operation to get key value from</param>
    public static implicit operator TKey(Delete<TKey, TDomain> delete) => delete.Key;
}