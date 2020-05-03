using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using AbstractEngine.Core.Base;

namespace AbstractEngine.Core
{
    public abstract class AbstractCore
    {
        private readonly GameGrid _grid;
        
        public GameGrid GameGrid => _grid;
        private Area _currentArea, _tmpArea;
        private readonly Stopwatch _delta;
        public readonly Resources Resources;
        public readonly int WindowWidth, WindowHeight;
        public readonly string WindowTitle;
        private bool _clearScreenOnNextArea = true;
        protected Color ClearColor;

        protected AbstractCore(int w, int h, string title)
        {
            _grid = new GameGrid(w,h, this);
            _delta = new Stopwatch();
            Resources = new Resources();
            WindowHeight = h;
            WindowWidth = w;
            WindowTitle = title;
            _tmpArea = null;
        }

        public void LoadArea(Area area, bool clearScreen = true)
        {
            _tmpArea = area;
            _clearScreenOnNextArea = clearScreen;
        }


        public void SetBackgroundColor(Color color) => ClearColor = color;

        public void Run()    
        {
            _delta.Start();
            while (true)
            {
                
                    if (!(_delta.Elapsed.TotalSeconds > 1f / 60)) continue;
                    if (_tmpArea != null)
                    {
                        _currentArea?.Unload(_clearScreenOnNextArea);
                        _currentArea = _tmpArea;
                        _tmpArea = null;
                        _currentArea.Init();
                    }
                    InputManger.WaitForUp();
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
                
                OnRenderObject(cell, new Point(i0, i1));
                
            }
        }
        
        public void DrawText(string text, Point position, Color textColor = Color.White)
        {
            var cs = text.ToCharArray();
            var nextPos = position;
            foreach (var c in cs)
            {
                OnDrawTextSymbol(c, nextPos, textColor);
                nextPos.X++;
            }
        }

        public void DrawTextInCenter(string text, int offset, int y, Color textColor = Color.White)
        {
            DrawText(text, new Point(Other.GetCenterStartPositionForText(text,WindowWidth),y), textColor);
        }
        public void DrawTextInCenter(string text, int offset, int y, out Point textStartPos, Color textColor = Color.White)
        {
            var t = new Point(Other.GetCenterStartPositionForText(text, WindowWidth), y);
            textStartPos = new Point(t.X-1, y);
            DrawText(text, t,textColor);
        }

        protected virtual void OnRenderStart()
        {
            
        }
        protected abstract void OnRenderObject(Cell cell, Point cellPos);

        protected virtual void OnRenderEnd()
        {
            
        }

        public void DrawPrimitive(CellData data, Point cellPos)
        {
            DrawPrimitive(data.RenderObject, cellPos);
        }

        public void DrawPrimitive(RenderObject renderObject, Point cellPos)
        {
            GameGrid[cellPos] = new Cell(renderObject);
        }

        protected abstract void OnDrawTextSymbol(char c, Point nextPos, Color textColor);


        #region WinAPI_Console_Hide

        [DllImport("kernel32.dll")]
        protected static extern IntPtr GetConsoleWindow();
        
        [DllImport("user32.dll")]
        protected static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        
        protected const int SW_HIDE = 0;
        protected const int SW_SHOW = 5;

        #endregion

    }
}