using System.Linq;

namespace CoreEngine
{
    public class GameGrid
    {
        private Cell[,] _cells;

        public GameGrid(int w, int h)
        {
            _cells = new Cell[w,h];
        }

        public Cell[] GetChangedCells()
            => _cells.Cast<Cell>().Where(x => x.IsUpdated).ToArray();

    }

    public class Cell
    {
        public bool IsUpdated = false;

        private CellData _data;
        public CellData CellData
        {
            get
            {
                IsUpdated = true; return _data; 
            }
            set
            {
                IsUpdated = true;
                _data = value;
            }
        }
    }

    public class CellData
    {
        public int X;
        public int Y;
        internal IRenderObject RenderObject;
    }
    
    internal interface IRenderObject
    {
        public object Object { get; set; }
    }
}