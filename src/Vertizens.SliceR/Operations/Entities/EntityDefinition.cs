namespace Vertizens.SliceR.Operations;

/// <summary>
/// Generic definition for a persistence entity
/// </summary>
public class EntityDefinition
{
    public required Type EntityType { get; set; }
    public Type? KeyType { get; set; }
}
