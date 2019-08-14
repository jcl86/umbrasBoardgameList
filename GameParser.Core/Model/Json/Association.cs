namespace GameParser.Core
{
    public interface IConvert<T>
    {
        T Convert();
    }
    public class Association : IConvert<Entity>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public object Contact { get; set; }
        public object Email { get; set; }
        public object Phone { get; set; }
        public object Comments { get; set; }

        public Entity Convert() => new Entity(Id, Name);
        
    }
}
