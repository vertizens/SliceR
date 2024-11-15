using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Vertizens.ServiceProxy;
using Vertizens.SliceR.Validated;

namespace Vertizens.SliceR;
public static partial class ServiceCollectionExtensions
{
    /// <summary>
    /// Registers <see cref="IValidatedHandler{TRequest}"/> and <see cref="IValidatedHandler{TRequest, TResult}"/> implementation types from the calling assembly
    /// </summary>
    /// <param name="services">Service collection</param>
    public static IServiceCollection AddSliceRValidatedHandlers(this IServiceCollection services)
    {
        return services.AddSliceRValidatedHandlers(Assembly.GetCallingAssembly());
    }

    /// <summary>
    /// Registers <see cref="IValidatedHandler{TRequest}"/> and <see cref="IValidatedHandler{TRequest, TResult}"/> implementation types from the assembly
    /// </summary>
    /// <param name="services">Service collection</param>
    /// <param name="assembly">the assembly to register types from</param>
    public static IServiceCollection AddSliceRValidatedHandlers(this IServiceCollection services, Assembly assembly)
    {
        return services.AddSliceRValidatedHandlers(assembly.GetTypes());
    }

    /// <summary>
    /// Registers <see cref="IValidatedHandler{TRequest}"/> and <see cref="IValidatedHandler{TRequest, TResult}"/> for the given types
    /// </summary>
    /// <param name="services">Service collection</param>
    /// <param name="types"></param>
    public static IServiceCollection AddSliceRValidatedHandlers(this IServiceCollection services, params Type[] types)
    {
        services.AddInterfaceTypes(typeof(IValidatedHandler<>), types: types);
        services.AddInterfaceTypes(typeof(IValidatedHandler<,>), types: types);

        return services;
    }

    /// <summary>
    /// Registers a Default Validator Proxy for <see cref="IValidatedHandler{TRequest}"/> and <see cref="IValidatedHandler{TRequest, TResult}"/>
    /// </summary>
    /// <param name="services">Service collection</param>
    /// <param name="filter">a provided filter to limit the registered types the proxy is applied to</param>
    public static IServiceCollection AddSliceRValidatorProxy(this IServiceCollection services, Func<Type, Type, bool>? filter = null)
    {
        services.AddServiceProxy(filter, typeof(DefaultValidatorProxyValidatedHandler<>));
        services.AddServiceProxy(filter, typeof(DefaultValidatorProxyValidatedHandler<,>));

        return services;
    }
}
