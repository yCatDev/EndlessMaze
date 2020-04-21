using System.Collections.Generic;

namespace AbstractEngine.Core.Base
{
    public abstract class Area
    {
        private List<Entity> _entities;
        private Resources _resources;

        public Area(GameGrid gameGrid, Resources resources)
        {
            _entities = new List<Entity>();
            Grid = gameGrid;
            _resources = resources;
            Init();
        }

        public abstract void Init();

        public abstract void Update();
        public void UpdateEntities() => _entities.ForEach(x => x.Update());
        public GameGrid Grid { get; }
        public RenderObject GetResource(string name) => _resources[name];

        internal void RegEntity(Entity entity) => _entities.Add(entity);
    }
}