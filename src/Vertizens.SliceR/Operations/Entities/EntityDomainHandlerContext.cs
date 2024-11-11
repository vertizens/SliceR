using Microsoft.Extensions.DependencyInjection;

namespace Vertizens.SliceR.Operations;
public class EntityDomainHandlerContext
{
    public required IServiceCollection Services { get; set; }
    public required EntityDefinition EntityDefinition { get; set; }
    public required Type DomainType { get; set; }
    public required Type RequestType { get; set; }
    public required Type ResponseType { get; set; }
}
