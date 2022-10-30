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
}
