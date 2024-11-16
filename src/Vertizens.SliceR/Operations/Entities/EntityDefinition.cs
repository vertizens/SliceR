namespace Vertizens.SliceR.Operations;

/// <summary>
/// Generic definition for a persistence entity
/// </summary>
public class EntityDefinition
{
    /// <summary>
    /// Type that represents Entity
    /// </summary>
    public required Type EntityType { get; set; }

    /// <summary>
    /// The Type that represents the key for the entity if applicable
    /// </summary>
    public Type? KeyType { get; set; }
}
