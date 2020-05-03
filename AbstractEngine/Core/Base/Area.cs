using System.Collections.Generic;

namespace AbstractEngine.Core.Base
{
    public abstract class Area
    {
        private readonly List<Entity> _entities;

        protected Area(GameGrid gameGrid)
        {
            _entities = new List<Entity>();
            Grid = gameGrid;
            //Init();
        }

        public GameGrid Grid { get; }


        public virtual void Init()
        {
        }

        public virtual void Update()
        {
        }

        public void UpdateEntities()
        {
            var c = _entities.Count;
            for (var i = 0; i < c; i++)
            {
                _entities[i]?.Update();
                c = _entities.Count;
            }
        }

        public T FindEntity<T>(string name) where T : Entity
        {
            return (T) _entities.Find(x => x.Name == name);
        }

        public RenderObject GetResource(string name)
        {
            return Grid.Core.Resources[name];
        }

        private protected virtual void OnUnload()
        {
        }

        internal void DeleteEntity(Entity entity)
        {
            _entities.Remove(entity);
        }

        internal void RegEntity(Entity entity)
        {
            _entities.Add(entity);
        }

        public void Unload(bool clearScreen)
        {
            OnUnload();
            while (_entities.Count > 0) _entities[0]?.Destroy(clearScreen);
            _entities.Clear();
            if (clearScreen)
                Grid.Clear();
        }
    }
}