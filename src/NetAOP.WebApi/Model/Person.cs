namespace NetAOP.WebApi.Model
{
    public class Person : BaseModel
    {
        public virtual int Id { get; set; }
        public virtual string? Name { get; set; }
    }
}
