namespace NetAOP.WebApi.Model
{
    public class ChangeTracer
    {
        public string Field { get; set; }
        public object OldValue { get; set; }
        public object NewValue { get; set; }
    }
}
