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
        public readonly int WindowWidth, WindowHeight;
        public readonly string WindowTitle;

        protected AbstractCore(int w, int h, string title)
        {
            _grid = new GameGrid(w,h, this);
            _delta = new Stopwatch();
            Resources = new Resources();
            InputManger.RegisterInput();
            WindowHeight = h;
            WindowWidth = w;
            WindowTitle = title;
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
        public void DrawText(string text, Point position, Color textColor = Color.White)
        {
            var cs = text.ToCharArray();
            Point nextPos = position;
            for (var i = 0; i < cs.Length; i++)
            {
                var c = cs[i];
                nextPos.X++;
                var d = new CellData()
                {
                    RenderObject = new RenderObject(c),
                    Color = textColor
                };
                DrawPrimitive(d,nextPos);
            }
        }

        public void DrawTextInCenter(string text, int offset, int y, Color textColor = Color.White)
        {
            DrawText(text, new Point(Other.GetCenterStartPositionForText(text,WindowWidth, offset),y), textColor);
        }
        public void DrawTextInCenter(string text, int offset, int y, out Point textStartPos, Color textColor = Color.White)
        {
            var t = new Point(Other.GetCenterStartPositionForText(text, WindowWidth, offset), y);
            textStartPos = new Point(WindowWidth-t.X, y);
            DrawText(text, t,textColor);
        }
        
        protected abstract void OnRenderStart();
        protected abstract void OnRenderObject(Cell cell, Point cellPos);
        protected abstract void OnRenderEnd();
        public abstract void DrawPrimitive(CellData data, Point cellPos);
        public abstract void DrawPrimitive(RenderObject renderObject, Point cellPos);
        
        
        
        
    }
}