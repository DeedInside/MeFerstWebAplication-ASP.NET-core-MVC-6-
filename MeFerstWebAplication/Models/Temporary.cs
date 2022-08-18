namespace MeFerstWebAplication.Models

{
    public class Temporary
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Temporary(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
