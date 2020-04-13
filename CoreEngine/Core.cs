using System;
using System.Linq;

namespace CoreEngine
{
    public class CoreEngine
    {
        private GameGrid _grid;
        private Scene _currentScene;
        
        public CoreEngine(int w, int h)
        {
            _grid = new GameGrid(w, h);
        }

        public void Run()
        {
            while (true)
            {
                _currentScene.OnUpdate();
                Update();
                Render();
            }
        }
        
        private void Update()
        {
            foreach (var entity in _currentScene.Entities)
            {
                entity.Update();
            }
        }
        
        private void Render()
        {
            foreach (var cell in _grid.GetChangedCells().Select(x=>x.CellData))
            {
                OnRender(cell);
            }
        }

        public virtual void OnRender(CellData cellData)
        {
            
        }

        public virtual void OnUpdate()
        {
            
        }

    }
    
    
}