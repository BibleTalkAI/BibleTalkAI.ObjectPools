using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.ObjectPool;

namespace BibleTalkAI.ObjectPools;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDefaultObjectPoolProvider(this IServiceCollection services) => 
        services.AddSingleton<ObjectPoolProvider, DefaultObjectPoolProvider>();

    public static IServiceCollection AddStringBuilderObjectPool(this IServiceCollection services) => 
        services.AddDefaultObjectPoolProvider()
            .AddSingleton(serviceProvider =>
            {
                var provider = serviceProvider.GetRequiredService<ObjectPoolProvider>();
                var policy = new StringBuilderPooledObjectPolicy();
                return provider.Create(policy);
            })
            .AddSingleton<IStringBuilderPool, StringBuilderPool>();

    public static IServiceCollection AddDictionaryObjectPool(this IServiceCollection services) =>
        services.AddDefaultObjectPoolProvider()
            .AddSingleton(serviceProvider =>
            {
                var provider = serviceProvider.GetRequiredService<ObjectPoolProvider>();
                var policy = new DictionaryPooledObjectPolicy();
                return provider.Create(policy);
            })
            .AddSingleton<IDictionaryPool, DictionaryPool>();
}