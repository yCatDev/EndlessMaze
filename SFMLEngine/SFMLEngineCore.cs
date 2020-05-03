using System;
using AbstractEngine.Core;
using AbstractEngine.Core.Base;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using Color = SFML.Graphics.Color;

namespace SFMLEngine
{
    public class SFMLEngine : AbstractCore
    {
        private readonly Color[] Colors =
        {
            Color.Black,
            new Color(0, 0, 139),
            new Color(0, 100, 0),
            new Color(0, 139, 139),
            new Color(139, 0, 0),
            new Color(139, 0, 139),
            new Color(155, 135, 12),
            new Color(178, 190, 181),
            new Color(169, 169, 169),
            Color.Blue,
            Color.Green,
            Color.Cyan,
            Color.Red,
            Color.Magenta,
            Color.Yellow,
            Color.White
        };

        private readonly Font _font;
        private readonly int _scaleFactor;
        private readonly RenderWindow _window;

        public SFMLEngine(int w, int h, int scaleFactor, string title) : base(w, h, title)
        {
            _scaleFactor = scaleFactor;
            _window = new RenderWindow(new VideoMode((uint) (w * _scaleFactor), (uint) (h * _scaleFactor)), title);
            _font = new Font("arial.ttf");
            ShowWindow(GetConsoleWindow(), SW_HIDE);
            _window.Closed += (sender, args) => { Environment.Exit(0); };
        }


        protected override void OnRenderStart()
        {
            _window.DispatchEvents();
            _window.Clear(Colors[(int) ClearColor]);
        }

        protected override void OnRenderObject(Cell cell, Point cellPos)
        {
            if (cell.GetRenderObject<Drawable>(out var obj))
            {
                if (obj is Shape shape)
                    shape.FillColor = Colors[(int) cell.Data.Color];
                if (obj is Text text)
                    text.FillColor = Colors[(int) cell.Data.Color];
                ((Transformable) obj).Position = new Vector2f(cellPos.X * _scaleFactor, cellPos.Y * _scaleFactor);
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


        protected override void OnDrawTextSymbol(char c, Point nextPos, AbstractEngine.Core.Base.Color textColor)
        {
            var text = new Text(c.ToString(), _font, 24);
            var d = new CellData
            {
                RenderObject = new RenderObject(text),
                Color = textColor
            };
            DrawPrimitive(d, nextPos);
        }
    }
}