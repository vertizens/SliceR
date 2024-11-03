using Vertizens.SliceR.Operations;
using Vertizens.TypeMapper;

namespace Vertizens.SliceR.Validated;
public class InsertValidatedHandler<TInsertRequest, TEntity>(
    IHandler<Insert<TEntity>, TEntity> _handler,
    ITypeMapper _typeMapper
    ) : IValidatedHandler<Insert<TInsertRequest>, TEntity>
    where TEntity : class, new()
{
    public async Task<ValidatedResult<TEntity>> Handle(Insert<TInsertRequest> request, CancellationToken cancellationToken = default)
    {
        return await _handler.Handle(new Insert<TEntity>(Map(request)), cancellationToken);
    }

    protected virtual TEntity Map(TInsertRequest request)
    {
        return _typeMapper.Map<TInsertRequest, TEntity>(request);
    }
}

public class InsertValidatedHandler<TInsertRequest, TDomain, TEntity>(
    IHandler<Insert<TEntity>, TEntity> _handler,
    ITypeMapper _typeMapper
    ) : IValidatedHandler<Insert<TInsertRequest>, TDomain>
    where TEntity : class, new()
    where TDomain : class, new()
{
    public async Task<ValidatedResult<TDomain>> Handle(Insert<TInsertRequest> request, CancellationToken cancellationToken = default)
    {
        var entityInserted = await _handler.Handle(new Insert<TEntity>(Map(request.Domain)), cancellationToken);

        return Map(entityInserted);
    }

    protected virtual TEntity Map(TInsertRequest request)
    {
        return _typeMapper.Map<TInsertRequest, TEntity>(request);
    }
    protected virtual TDomain Map(TEntity entity)
    {
        return _typeMapper.Map<TEntity, TDomain>(entity);
    }
}
