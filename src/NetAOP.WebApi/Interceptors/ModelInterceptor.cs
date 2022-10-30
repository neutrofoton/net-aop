using Castle.DynamicProxy;
using NetAOP.WebApi.Model;

namespace NetAOP.WebApi.Interceptors
{
    public class ModelInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            var method = invocation.Method.Name;

            if (method.StartsWith("set_"))
            {
                var field = method.Replace("set_", string.Empty);

                //var actual = ProxyUtil.GetUnproxiedInstance(invocation.Proxy) as IModel;
                var proxy = invocation.Proxy as IModel;

                var pi = proxy!.GetType().GetProperty(field);

                ChangeTracer tracer = new ChangeTracer()
                {
                    Field = field,
                    OldValue = pi!.GetValue(proxy)
                }; 

                invocation.Proceed();

                tracer.NewValue = pi.GetValue(proxy);
                proxy.PropertyChangeList.Add(tracer);
            }
            else
            {
                invocation.Proceed();
            }

    }

            
        
    }
}
