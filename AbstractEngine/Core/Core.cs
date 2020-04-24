﻿using System;
using System.Diagnostics;
using AbstractEngine.Core.Base;

namespace AbstractEngine.Core
{
    public abstract class AbstractCore
    {
        private GameGrid _grid;
        
        public GameGrid GameGrid => _grid;
        private Area _currentArea, _tmpArea;
        private Stopwatch _delta;
        public Resources Resources;

        protected AbstractCore(int w, int h, string title)
        {
            _grid = new GameGrid(w,h, this);
            _delta = new Stopwatch();
            Resources = new Resources();
            InputManger.RegisterInput();
        }

        public void LoadArea(Area area) => _tmpArea = area;

        public void Run()    
        {
            _delta.Start();
            while (true)
            {
                if (_tmpArea != null)
                {
                    _currentArea = _tmpArea;
                    _tmpArea = null;
                }

                if (!(_delta.Elapsed.TotalSeconds > 1f / 60)) continue;
                _currentArea?.Update();
                _currentArea?.UpdateEntities();
                OnRenderStart();
                Render();
                OnRenderEnd();
               
                _delta.Restart();
            }
        }

        private void Render()
        {
            var all = _grid.SelectAll();
            
            for (var i0 = 0; i0 < all.GetLength(0); i0++)
            for (var i1 = 0; i1 < all.GetLength(1); i1++)
            {
                var cell = all[i0, i1];
                OnRenderObject(cell, new Point(i0,i1));
            }
        }
        public void DrawText(string text, Point position)
        {
            var cs = text.ToCharArray();
            Point nextPos = position;
            for (var i = 0; i < cs.Length; i++)
            {
                var c = cs[i];
                nextPos.X++;
                DrawPrimitive(c,nextPos);
            }
        }
        
        protected abstract void OnRenderStart();
        protected abstract void OnRenderObject(Cell cell, Point cellPos);
        protected abstract void OnRenderEnd();
        public abstract void DrawPrimitive(char c, Point cellPos);
        
        
        
        
    }
}