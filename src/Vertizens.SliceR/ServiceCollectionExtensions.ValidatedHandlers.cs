using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Vertizens.ServiceProxy;
using Vertizens.SliceR.Validated;

namespace Vertizens.SliceR;
public static partial class ServiceCollectionExtensions
{
    public static IServiceCollection AddSliceRValidatedHandlers(this IServiceCollection services)
    {
        return services.AddSliceRValidatedHandlers(Assembly.GetCallingAssembly());
    }

    public static IServiceCollection AddSliceRValidatedHandlers(this IServiceCollection services, Assembly assembly)
    {
        return services.AddSliceRValidatedHandlers(assembly.GetTypes());
    }

    public static IServiceCollection AddSliceRValidatedHandlers(this IServiceCollection services, params Type[] types)
    {
        services.AddInterfaceTypes(typeof(IValidatedHandler<>), types: types);
        services.AddInterfaceTypes(typeof(IValidatedHandler<,>), types: types);

        return services;
    }

    public static IServiceCollection AddSliceRValidatorProxy(this IServiceCollection services)
    {
        services.AddServiceProxy(typeof(DefaultValidatorProxyValidatedHandler<>));
        services.AddServiceProxy(typeof(DefaultValidatorProxyValidatedHandler<,>));

        return services;
    }
}
