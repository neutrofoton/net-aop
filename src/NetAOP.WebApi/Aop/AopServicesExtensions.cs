﻿using Castle.DynamicProxy;

namespace NetAOP.WebApi.Aop
{
    public static class AopServicesExtensions
    {
        public static void AddProxiedScoped<TInterface, TImplementation>(this IServiceCollection services)
            where TInterface : class
            where TImplementation : class, TInterface
        {
            services.AddScoped<TImplementation>();
            services.AddScoped(typeof(TInterface), serviceProvider =>
            {
                var proxyGenerator = serviceProvider.GetRequiredService<ProxyGenerator>();
                var actual = serviceProvider.GetRequiredService<TImplementation>();
                var interceptors = serviceProvider.GetServices<IInterceptor>().ToArray();
                var proxy = ProxyFactory.GetProxiedInstance<TInterface>(proxyGenerator, actual, interceptors);
                
                return proxy;
            });
        }
    }
}
