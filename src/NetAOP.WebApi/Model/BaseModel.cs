namespace NetAOP.WebApi.Model
{
    public interface IModel { List<string> PropertyChangeList { get; } }

    public abstract class BaseModel : IModel
    {
        public List<string> PropertyChangeList => new List<string>();
    }
}
