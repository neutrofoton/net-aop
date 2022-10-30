using Castle.DynamicProxy;
using NetAOP.WebApi.Model;

namespace NetAOP.WebApi.Interceptors
{
    public class ModelInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            invocation.Proceed();

            var method = invocation.Method.Name;

            if (method.StartsWith("set_"))
            {
                var field = method.Replace("set_", "");
                var proxy = invocation.Proxy as IModel;

                //var model = ProxyUtil.GetUnproxiedInstance(proxy) as IModel;

                if (proxy != null)
                {
                    proxy.PropertyChangeList.Add(new ChangeTracer()
                    {
                        Field = field
                    });
                }

            }
        }
    }
}
