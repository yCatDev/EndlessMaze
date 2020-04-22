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
            Cells = new Cell[w, h];
            for (var i0 = 0; i0 < Cells.GetLength(0); i0++)
            for (var i1 = 0; i1 < Cells.GetLength(1); i1++)
            {
                Cells[i0, i1] = new Cell(new RenderObject());
            }
        }
    }

    public struct Cell
    {
        public bool Updated;
        public string EntityName;
        private CellData _data;

        public Cell(RenderObject renderObject)
        {
            Updated = true;
            EntityName = "";
            _data = new CellData()
            {
                RenderObject = renderObject
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

        public void SetName(string name) => EntityName = name;
    }

    internal struct CellData
    {
        public RenderObject RenderObject;
    }

    public class RenderObject
    {
        public object renderObject;
        public RenderObject() => renderObject = new object();
        public RenderObject(object _renderObject) => renderObject = _renderObject;
    }
}