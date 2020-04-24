using System;
using SFML.System;
using SFML.Window;
using SFML.Graphics;
using AbstractEngine.Core;
using AbstractEngine.Core.Base;

namespace SFMLEngine
{
    public class SFMLEngine:AbstractCore
    {
        private RenderWindow _window;
        private int _scaleFactor;
        public SFMLEngine(int w, int h, int scaleFactor,string title) : base(w, h, title)
        {
            _scaleFactor = scaleFactor;
            _window = new RenderWindow(new VideoMode((uint) (w*_scaleFactor), (uint)(h*_scaleFactor)), title);
            
        }
        

        protected override void OnRenderStart()
        {
            _window.DispatchEvents();
            _window.Clear(SFML.Graphics.Color.White);
        }

        protected override void OnRenderObject(Cell cell, Point cellPos)
        {
            if (cell.GetRenderObject<Drawable>(out var obj))
            {
                ((Transformable)obj).Position = new Vector2f(cellPos.X*_scaleFactor, cellPos.Y*_scaleFactor);
                _window.Draw(obj);
            }
            else
            {
                ;
            }
        }

        protected override void OnRenderEnd()
        {
            _window.Display();
        }

        public override void DrawPrimitive(CellData data, Point cellPos)
        {
            GameGrid[cellPos] = new Cell(data); 
        }

        public override void DrawPrimitive(RenderObject renderObject, Point cellPos)
        {
            GameGrid[cellPos] = new Cell(renderObject); 
        }
    }
}