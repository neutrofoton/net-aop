using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;

namespace NetAOP.WebApi.Aop
{
    public class ProxyFactory 
    {
        public static TInterface? GetProxiedInstance<TInterface>(IProxyGenerator proxyGenerator, TInterface source, params IInterceptor[] interceptors) where TInterface : class
        {
            TInterface? proxy = null;

            if (typeof(TInterface).IsInterface)
                proxy = proxyGenerator.CreateInterfaceProxyWithTarget(typeof(TInterface), source, interceptors) as TInterface;
            else
                proxy = proxyGenerator.CreateClassProxyWithTarget(typeof(TInterface), source, interceptors) as TInterface;

            return proxy;
        }

       
    }
}
