using System.Collections.Generic;

namespace CoreEngine
{
    public abstract class Scene
    {
        private List<Entity> _entities;

        public List<Entity> Entities
        {
            get => _entities;
        }
        
        public Scene()
        {
            _entities = new List<Entity>();
        }

        public abstract void OnStart();
        public abstract void OnUpdate();
    
    }
}