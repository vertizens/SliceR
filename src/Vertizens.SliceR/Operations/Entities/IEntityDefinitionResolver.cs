namespace Vertizens.SliceR.Operations;

/// <summary>
/// Resolver that can resolve an type to an EntityDefinition if its represents an entity
/// </summary>
public interface IEntityDefinitionResolver
{
    /// <summary>
    /// Gets any known EntityDefinition for a given type
    /// </summary>
    /// <param name="entityType"></param>
    EntityDefinition? Get(Type entityType);
    /// <summary>
    /// Gets all known EntityDefinitions
    /// </summary>
    IEnumerable<EntityDefinition> Get();
}
