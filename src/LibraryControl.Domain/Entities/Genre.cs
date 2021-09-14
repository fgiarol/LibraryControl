namespace LibraryControl.Domain.Entities
{
    public class Genre : Entity
    {
        public Genre(string name)
        {
            Name = name;
        }
        
        public string Name { get; private set; }
    }
}