﻿using System;
using System.Linq;

namespace CoreEngine
{
    public class CoreEngine
    {
        internal GameGrid _grid;
        private Scene _currentScene;
        
        public CoreEngine(int w, int h)
        {
            _grid = new GameGrid(w, h);
        }

        public void Run()
        {
            while (true)
            {
                OnRenderStart();
                _currentScene.OnUpdate();
                _currentScene.Update();
                Render();
                OnRenderEnd();
            }
        }

        public void LoadScene(Scene scene)
        {
            _currentScene?.OnUnload();
            _currentScene = scene;
            _currentScene.OnStart();
        }
        
        
        
        private void Render()
        {
            foreach (var cell in _grid.GetChangedCells().Select(x=>x.CellData))
            {
                OnRender(cell);
            }
        }

        public virtual void OnRenderStart()
        {
            
        }
        
        public virtual void OnRender(CellData cellData)
        {
            
        }
        public virtual void OnRenderEnd()
        {
            
        }
        public virtual void OnUpdate()
        {
            
        }

    }
    
    
}