namespace Vertizens.SliceR.Operations;

/// <summary>
/// Represents a Delete a domain by key request
/// </summary>
/// <typeparam name="TKey">Type of key</typeparam>
/// <typeparam name="TDomain">Type of domain objects to delete</typeparam>
/// <param name="_key">instances of keys</param>
public class DeleteSet<TKey, TEntity>(ICollection<TKey> _keys)
{
    public ICollection<TKey> Keys { get { return _keys; } }
}
