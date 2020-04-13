namespace Engine
{
    public abstract class Scene
    {

        public Scene() => Init();
        
        public abstract void Init();
        public abstract void Update();

    }
}