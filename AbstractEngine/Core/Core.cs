using System;
using System.Diagnostics;
using AbstractEngine.Core.Base;

namespace AbstractEngine.Core
{
    public abstract class AbstractCore
    {
        private GameGrid _grid;
        private Area _currentArea, _tmpArea;

        public AbstractCore(Area startArea)
        {
            _currentArea = startArea;
        }

        public void LoadArea(Area area) => _tmpArea = area;

        public void Run()
        {
            if (_currentArea==null)
                throw new Exception("Area not loaded");
            while (true)
            {
                _currentArea.Update();
                _currentArea.UpdateEntities();
                OnRenderStart();
                Render();
                OnRenderEnd();
                if (_tmpArea != null)
                {
                    _currentArea = _tmpArea;
                    _tmpArea = null;
                }
            }
        }

        private void Render()
        {
            foreach (var cell in _grid.SelectUpdated())
            {
                RenderObject(cell);
            }
        }

        public abstract void OnRenderStart();
        public abstract void RenderObject(Cell cell);
        public abstract void OnRenderEnd();

    }
}