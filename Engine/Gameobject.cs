using Engine.ConsoleEngine;

namespace Engine
{
    public abstract class GameObject
    {
        public RendererData RendererData;
        public string Name;
        public GameObject(string name, int X, int Y)
        {
            Name = name;
            RendererData = new RendererData();
            RendererData.X = X;
            RendererData.Y = Y;
        }
        public abstract void Update();
    }
}