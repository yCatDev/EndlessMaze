﻿using System.Collections.Generic;

namespace CoreEngine
{
    public abstract class Scene
    {
        internal CoreEngine _engine;
        
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

        internal void Update()
        {
            foreach (var entity in Entities)
            {
                entity.Update();
            }
        }

        public virtual void OnUnload()
        {
            Entities.Clear();
        }
        
        
        public void CreateEntity(Entity entity)
        {
            Entities.Add(entity);
        }
    }
}