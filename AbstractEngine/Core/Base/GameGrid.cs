﻿using System;
using System.Linq;

namespace AbstractEngine.Core.Base
{
    public class GameGrid
    {
        internal Cell[,] Cells;
        public int Width, Heigth;
        public AbstractCore Core;

        public Cell this[int i, int j]
        {
            get { return Cells[(uint) i, (uint) j]; }
            set { Cells[(uint) i, (uint) j] = value; }
        }

        public Cell this[Point p]
        {
            get { return Cells[(uint) p.X, (uint) p.Y]; }
            set { Cells[(uint) p.X, (uint) p.Y] = value; }
        }

        public void MakeCellEmpty(Point point) => MakeCellEmpty(point.X, point.Y);
        public Cell[] SelectUpdated() => Cells.Cast<Cell>().Where(x => x.Updated).ToArray();
        public Cell[,] SelectAll() => Cells;

        public void MakeCellEmpty(int x, int y)
        {
            Cells[x, y] = new Cell();
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
            Cells = new Cell[Width, Heigth];
            for (var i0 = 0; i0 < Cells.GetLength(0); i0++)
            for (var i1 = 0; i1 < Cells.GetLength(1); i1++)
            {
                Cells[i0, i1] = new Cell(new RenderObject());
            }
        }

        public void SetLevelGrid(Cell[,] output)
        {
            Cells = output;
        }
    }

    public class Cell
    {
        public bool Updated;
       
        private CellData _data;
        public CellData Data => _data;
        
        public Cell(Cell cell)
        {
            Updated = cell.Updated;
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
        public RenderObject(object _renderObject) => renderObject = _renderObject;
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