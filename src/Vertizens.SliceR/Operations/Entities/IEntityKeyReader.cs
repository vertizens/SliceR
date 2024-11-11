namespace Vertizens.SliceR.Operations;
public interface IEntityKeyReader<TKey, TEntity>
{
    TKey ReadKey(TEntity entity);
}
