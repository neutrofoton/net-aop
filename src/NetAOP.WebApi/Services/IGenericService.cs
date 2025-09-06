namespace NetAOP.WebApi;

public interface IGenericService<T,TId>
{
    string Echo(string message);
}
