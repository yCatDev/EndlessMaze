using System.Linq;

namespace AbstractEngine.Core.Base
{
    public class GameGrid
    {
        internal Cell[,] Cells;

        public Cell this[int i, int j]
        {
            get { return Cells[(uint)i, (uint)j]; }
            set { Cells[(uint)i, (uint)j] = value; }
        }

        public Cell this[Point p]
        {
            get { return Cells[(uint)p.X, (uint)p.Y]; }
            set { Cells[(uint)p.X, (uint)p.Y] = value; }
        }

        public void MakeCellEmpty(Point point) => MakeCellEmpty(point.X, point.Y);
        public Cell[] SelectUpdated() => Cells.Cast<Cell>().Where(x => x.Updated).ToArray();
        public void MakeCellEmpty(int x, int y)
        {
            Cells[x,y] = new Cell();
        }

        public GameGrid(int w, int h)
        {
            Cells = new Cell[w,h];
        }
        
        
        
    }

    public struct Cell
    {
        public bool Updated;
        private CellData _data;
     
    }

    internal struct CellData
    {
        public IRenderObject RenderObject;
    }

    interface IRenderObject
    {
        public object RenderObject { get; set; }
    }
    
}