using System.Collections.Generic;

namespace AbstractEngine.Core.Base
{
    public abstract class Area
    {
        private List<Entity> _entities;

        public Area(GameGrid gameGrid)
        {
            _entities = new List<Entity>();
            Grid = gameGrid;
            Init();
        }

        public abstract void Init();

        public abstract void Update();
        public void UpdateEntities() => _entities.ForEach(x => x.Update());
        public GameGrid Grid { get; }
    }
}