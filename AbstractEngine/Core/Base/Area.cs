using System.Collections.Generic;

namespace AbstractEngine.Core.Base
{
    public abstract class Area
    {
        private List<Entity> _entities;
        public GameGrid Grid { get; }
        public Area(GameGrid gameGrid, bool clearScreen = true)
        {
            _entities = new List<Entity>();
            Grid = gameGrid;
            if (clearScreen)
                Grid.Clear();
            Init();
        }

        public abstract void Init();

        public abstract void Update();
        public void UpdateEntities() => _entities.ForEach(x => x.Update());
       
        public RenderObject GetResource(string name) => Grid.Core.Resources[name];

        
        
        internal void RegEntity(Entity entity) => _entities.Add(entity);
    }
}