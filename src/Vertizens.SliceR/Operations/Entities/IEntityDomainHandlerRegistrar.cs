namespace Vertizens.SliceR.Operations;

/// <summary>
/// Defines a startup registrar that will be checked to see if it can register any handlers given context of the expected handler service, entity, and domain.
/// </summary>
public interface IEntityDomainHandlerRegistrar
{
    /// <summary>
    /// Register any possible handlers in the given service collection
    /// </summary>
    /// <param name="context"></param>
    void Register(EntityDomainHandlerContext context);
}
