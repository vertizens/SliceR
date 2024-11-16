namespace Vertizens.SliceR.Operations;

/// <summary>
/// Represents a Delete a domain by key request
/// </summary>
/// <typeparam name="TKey">Type of key</typeparam>
/// <typeparam name="TEntity">Type of domain objects to delete</typeparam>
/// <param name="_keys">instances of keys</param>
public class DeleteSet<TKey, TEntity>(ICollection<TKey> _keys)
{
    /// <summary>
    /// The collection of keys used in a Delete operation for deleting multiple entities
    /// </summary>
    public ICollection<TKey> Keys { get { return _keys; } }
}
