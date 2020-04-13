﻿namespace CoreEngine
{
    public abstract class Entity
    {
        public string Name;
        private GameObjectID _id;
        private CellData _cellData;
        private Scene _scene;
        
        public Entity(string name)
        {
            Name = name;
            _id = new GameObjectID();
        }

        private void UpdateCell()
        {
            var g = _scene._engine._grid;
            g[_cellData.X, _cellData.Y].CellData.RenderObject = null;
            
        }
        
        public abstract void Update();

    }
}