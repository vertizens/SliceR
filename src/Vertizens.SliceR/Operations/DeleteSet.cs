namespace Vertizens.SliceR.Operations;
public class DeleteSet<TKey, TEntity>(ICollection<TKey> _keys)
{
    public ICollection<TKey> Keys { get { return _keys; } }
}
