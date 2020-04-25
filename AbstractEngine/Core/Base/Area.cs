using System;
using System.Collections.Generic;

namespace AbstractEngine.Core.Base
{
    public abstract class Area
    {
        private List<Entity> _entities;
        public GameGrid Grid { get; }
        public Area(GameGrid gameGrid)
        {
            _entities = new List<Entity>();
            Grid = gameGrid;
            //Init();
        }



        public abstract void Init();
        public abstract void Update();

        public void UpdateEntities()
        {
            var c = _entities.Count;
            for (int i = 0; i < c; i++)
            {
                _entities[i]?.Update();
                c = _entities.Count;
            }
        }

        public T FindEntity<T>(string name) where T: Entity
            => (T)_entities.Find(x => x.Name == name);
        
        public RenderObject GetResource(string name) => Grid.Core.Resources[name];

        private protected virtual void OnUnload()
        {
            
        }

        internal void DeleteEntity(Entity entity) => _entities.Remove(entity);
        
        internal void RegEntity(Entity entity) => _entities.Add(entity);

        public void Unload(bool clearScreen)
        {
            OnUnload();
            while (_entities.Count>0)
            {
                _entities[0]?.Destroy(clearScreen);
            }
            _entities.Clear();
            if (clearScreen)
                Grid.Clear();
        }

        
    }
}