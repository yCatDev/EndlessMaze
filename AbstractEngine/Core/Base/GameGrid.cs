using System;
using System.Linq;

namespace AbstractEngine.Core.Base
{
    public class GameGrid
    {
        private Cell[,] _cells;
        public readonly int Width;
        public readonly int Heigth;
        public readonly AbstractCore Core;

        public Cell this[int i, int j]
        {
            get => _cells[(uint) i, (uint) j];
            set => _cells[(uint) i, (uint) j] = value;
        }

        public Cell this[Point p]
        {
            get => _cells[(uint) p.X, (uint) p.Y];
            set => _cells[(uint) p.X, (uint) p.Y] = value;
        }

        public void MakeCellEmpty(Point point) => MakeCellEmpty(point.X, point.Y);
        public Cell[] SelectUpdated() => _cells.Cast<Cell>().Where(x => x.Updated).ToArray();
        public Cell[,] SelectAll() => _cells;

        public void MakeCellEmpty(int x, int y)
        {
            _cells[x, y] = new Cell();
        }

        public GameGrid(int w, int h, AbstractCore core)
        {
            Core = core;
            Width = w;
            Heigth = h;
           Clear();
        }

        public void Clear()
        {
            _cells = new Cell[Width, Heigth];
            for (var i0 = 0; i0 < _cells.GetLength(0); i0++)
            for (var i1 = 0; i1 < _cells.GetLength(1); i1++)
            {
                _cells[i0, i1] = new Cell(new RenderObject());
            }
        }

        public void SetLevelGrid(Cell[,] output)
        {
            _cells = output;
        }
    }

    public class Cell
    {
        public bool Updated;
       
        private CellData _data;

        public CellData Data
        {
            get
            {
                Updated = true;
                return _data;
            }
            set 
            { 
                Updated = true;
                _data = value;
            }
        }
        
        public Cell(Cell cell)
        {
            Updated = true;
            _data = cell.Data;
        }   
        
        public Cell(RenderObject renderObject)
        {
            Updated = true;
            _data.EntityName = "";
            _data = new CellData()
            {
                RenderObject = renderObject
            };
        }

        public Cell(CellData data)
        {
            Updated = true;
            _data.EntityName = "";
            _data = data;
        }

        public Cell()
        {
            Updated = true;
            
            _data = new CellData()
            {
                RenderObject = null,
                Color = Color.White,
                EntityName = ""
            };
        }

        public bool GetRenderObject<T>(out T obj)
        {
            obj = default;
            if (_data.RenderObject?.renderObject is T)
            {
                obj = (T) _data.RenderObject.renderObject;
                return true;
            }

            var result = true;
            try
            {
                if (_data.RenderObject != null)
                    obj = (T) Convert.ChangeType(_data.RenderObject.renderObject, typeof(T));
            }
            catch (Exception)
            {
                result = false;
            }


            return result;
        }

        public T GetColor<T>() where T: struct, Enum=> Enum.Parse<T>(_data.Color.ToString());
        
        public void SetName(string name) => _data.EntityName = name;
        public string GetName() => _data.EntityName ?? "";
        public bool IsName(string name) => _data.EntityName == name;
    }

    public enum Color
    {
        Black,
        DarkBlue,
        DarkGreen,
        DarkCyan,
        DarkRed,
        DarkMagenta,
        DarkYellow,
        Gray,
        DarkGray,
        Blue,
        Green,
        Cyan,
        Red,
        Magenta,
        Yellow,
        White
    }
    
    

    public struct CellData
    {
        public RenderObject RenderObject;
        public string EntityName;
        public Color Color;
    }

    public class RenderObject
    {
        public object renderObject;
        public RenderObject() => renderObject = new object();
        public RenderObject(object renderObject) => this.renderObject = renderObject;
    }
    
    [Serializable]
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }


        public Point()
        {
            X = 0;
            Y = 0;
        }
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Point(Point p)
        {
            X = p.X;
            Y = p.Y;
        }
        
        public override string ToString()
        {
            return $"{X} {Y}";
        }

        public Point Inverse() => new Point(Y,X);
        
        public static int Distance(Point p1, Point p2)
            => (int)Math.Sqrt(Math.Pow(p2.X - p1.X, 2) +Math.Pow(p2.Y - p1.Y, 2));

        public static readonly Point Zero = new Point(0,0);
        
    }
    
}