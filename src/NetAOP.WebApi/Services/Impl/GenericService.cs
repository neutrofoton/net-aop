namespace NetAOP.WebApi;

public class GenericService<T, TId> : IGenericService<T, TId>
{
    public string Echo(string message)
    {
        return $"[Generic Service of {this.GetType().FullName}] => {message}";
    }
}
