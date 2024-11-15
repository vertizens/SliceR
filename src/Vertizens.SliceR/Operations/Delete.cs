namespace Vertizens.SliceR.Operations;

/// <summary>
/// Represents a Delete a domain by key request
/// </summary>
/// <typeparam name="TKey">Type of key</typeparam>
/// <typeparam name="TDomain">Type of domain to delete</typeparam>
/// <param name="_key">instance of key</param>
public class Delete<TKey, TDomain>(TKey _key)
{
    public TKey Key { get { return _key; } }

    public static implicit operator Delete<TKey, TDomain>(TKey key) => new(key);

    public static implicit operator TKey(Delete<TKey, TDomain> delete) => delete.Key;
}