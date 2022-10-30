using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;

namespace NetAOP.WebApi.Aop
{
    public class ProxyFactory 
    {
        public static T? GetProxiedInstance<T>(IProxyGenerator proxyGenerator, T source, params IInterceptor[] interceptors) where T : class
        {
            T? proxy = null;

            if (typeof(T).IsInterface)
                proxy = proxyGenerator.CreateInterfaceProxyWithTarget(typeof(T), source, interceptors) as T;
            else
                proxy = proxyGenerator.CreateClassProxyWithTarget(typeof(T), source, interceptors) as T;

            return proxy;
        }

       
    }
}
