using Microsoft.Extensions.DependencyInjection;

namespace Vertizens.SliceR.Operations;

/// <summary>
/// Used to provide context for a <see cref="IEntityDomainHandlerRegistrar"/>
/// </summary>
public class EntityDomainHandlerContext
{
    /// <summary>
    /// Service Collection to register any detault handlers 
    /// </summary>
    public required IServiceCollection Services { get; set; }

    /// <summary>
    /// Entity to register services for
    /// </summary>
    public required EntityDefinition EntityDefinition { get; set; }

    /// <summary>
    /// The Domain type used to map from the entity for a result
    /// </summary>
    public required Type DomainType { get; set; }

    /// <summary>
    /// The already registered handler request type
    /// </summary>
    public required Type RequestType { get; set; }

    /// <summary>
    /// The already registered handler result type
    /// </summary>
    public required Type ResultType { get; set; }
}
