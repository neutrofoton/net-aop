using Castle.DynamicProxy;
using NetAOP.WebApi.Aop;
using NetAOP.WebApi.Interceptors;

namespace NetAOP.WebApi.Model
{
    public interface IModel
    {
        List<ChangeTracer> PropertyChangeList { get; }
    }

    public abstract class BaseModel : IModel
    {
        public List<ChangeTracer> PropertyChangeList
        {
            get;
        } = new List<ChangeTracer>();
    }

    public static class IModelExtension
    {
        public static T? ApplyModelTracer<T>(this T? model) where T: class, IModel, new() 
        {
            var proxied = ProxyFactory.GetProxiedInstance(
                     new ProxyGenerator(),
                     model!,
                     new IInterceptor[]
                     {
                        new ModelInterceptor()

                     });

            return proxied ?? model;

        }
    }
}
