using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Vertizens.ServiceProxy;

namespace Vertizens.SliceR;
public static partial class ServiceCollectionExtensions
{
    /// <summary>
    /// Registers <see cref="IHandler{TRequest}"/> and <see cref="IHandler{TRequest, TResult}"/> implementation types from the calling assembly
    /// </summary>
    /// <param name="services">Service collection</param>
    public static IServiceCollection AddSliceRHandlers(this IServiceCollection services)
    {
        return services.AddSliceRHandlers(Assembly.GetCallingAssembly());
    }

    /// <summary>
    /// Registers <see cref="IHandler{TRequest}"/> and <see cref="IHandler{TRequest, TResult}"/> implementation types from the assembly
    /// </summary>
    /// <param name="services">Service collection</param>
    /// <param name="assembly">the assembly to register types from</param>
    public static IServiceCollection AddSliceRHandlers(this IServiceCollection services, Assembly assembly)
    {
        return services.AddSliceRHandlers(assembly.GetTypes());
    }

    /// <summary>
    /// Registers <see cref="IHandler{TRequest}"/> and <see cref="IHandler{TRequest, TResult}"/> implementation types from the given types
    /// </summary>
    /// <param name="services">Service collection</param>
    /// <param name="types">types to register as handlers</param>
    /// <returns></returns>
    public static IServiceCollection AddSliceRHandlers(this IServiceCollection services, params Type[] types)
    {
        services.AddInterfaceTypes(typeof(IHandler<>), types: types);
        services.AddInterfaceTypes(typeof(IHandler<,>), types: types);

        return services;
    }
}
