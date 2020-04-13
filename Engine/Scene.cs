using System.Collections.Generic;

namespace Engine
{
    public abstract class Scene
    {
        protected List<GameObject<RendererData>> GameObjects;
        public Scene() => Init();
        
        public abstract void Init();
        public abstract void Update();

        public abstract void Unload();

        public GameObject<T> CreateGameObject<T>(GameObject<T> gameObject) where  T: RendererData, new()
            => GameObjects.Add(gameObject);
        
        internal List<GameObject<RendererData>> GetGameObjectList
        {
            get => GameObjects;
        }
        
        
        
    }
}