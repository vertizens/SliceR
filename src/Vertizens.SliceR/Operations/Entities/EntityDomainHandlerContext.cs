using Microsoft.Extensions.DependencyInjection;

namespace Vertizens.SliceR.Operations;

/// <summary>
/// Used to provide context for a <see cref="IEntityDomainHandlerRegistrar"/>
/// </summary>
public class EntityDomainHandlerContext
{
    public required IServiceCollection Services { get; set; }
    public required EntityDefinition EntityDefinition { get; set; }
    public required Type DomainType { get; set; }
    public required Type RequestType { get; set; }
    public required Type ResultType { get; set; }
}
