namespace CoreEngine
{
    public abstract class Entity
    {
        public string Name;

        public Entity(string name)
        {
            Name = name;
        }

        public abstract void Update();

    }
}