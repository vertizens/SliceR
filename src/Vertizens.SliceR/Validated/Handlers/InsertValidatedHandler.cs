using Vertizens.SliceR.Operations;
using Vertizens.TypeMapper;

namespace Vertizens.SliceR.Validated;
public class InsertValidatedHandler<TInsertRequest, TEntity>(
    IHandler<Insert<TEntity>, TEntity> _handler,
    ITypeMapper<TInsertRequest, TEntity> _typeMapper
    ) : IValidatedHandler<Insert<TInsertRequest>, TEntity>
    where TEntity : class, new()
{
    public async Task<ValidatedResult<TEntity>> Handle(Insert<TInsertRequest> request, CancellationToken cancellationToken = default)
    {
        return await _handler.Handle(new Insert<TEntity>(Map(request)), cancellationToken);
    }

    protected virtual TEntity Map(TInsertRequest request)
    {
        var entity = new TEntity();
        _typeMapper.Map(request, entity);
        return entity;
    }
}

public class InsertValidatedHandler<TInsertRequest, TDomain, TKey, TEntity>(
    IHandler<Insert<TEntity>, TEntity> _handler,
    ITypeMapper<TInsertRequest, TEntity> _typeMapper,
    IEntityKeyReader<TKey, TEntity> _entityKeyReader,
    IHandler<ByKey<TKey>, TDomain?> _getDomainHandler
    ) : IValidatedHandler<Insert<TInsertRequest>, TDomain>
    where TEntity : class, new()
    where TDomain : class, new()
{
    public async Task<ValidatedResult<TDomain>> Handle(Insert<TInsertRequest> request, CancellationToken cancellationToken = default)
    {
        var entityInserted = await _handler.Handle(new Insert<TEntity>(Map(request.Domain)), cancellationToken);

        var key = _entityKeyReader.ReadKey(entityInserted);
        return (await _getDomainHandler.Handle(key!, cancellationToken))!;
    }

    protected virtual TEntity Map(TInsertRequest request)
    {
        var entity = new TEntity();
        _typeMapper.Map(request, entity);
        return entity;
    }
}