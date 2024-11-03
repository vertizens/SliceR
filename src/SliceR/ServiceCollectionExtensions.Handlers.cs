using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Vertizens.ServiceProxy;

namespace Vertizens.SliceR;
public static partial class ServiceCollectionExtensions
{
    public static IServiceCollection AddSliceRHandlers(this IServiceCollection services)
    {
        return services.AddSliceRHandlers(Assembly.GetCallingAssembly());
    }

    public static IServiceCollection AddSliceRHandlers(this IServiceCollection services, Assembly assembly)
    {
        return services.AddSliceRHandlers(assembly.GetTypes());
    }

    public static IServiceCollection AddSliceRHandlers(this IServiceCollection services, params Type[] types)
    {
        services.AddInterfaceTypes(typeof(IHandler<>), types: types);
        services.AddInterfaceTypes(typeof(IHandler<,>), types: types);

        return services;
    }
}
