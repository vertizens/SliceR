namespace Vertizens.SliceR.Operations;
public interface IEntityDefinitionResolver
{

    EntityDefinition? Get(Type entityType);

    IEnumerable<EntityDefinition> Get();
}
