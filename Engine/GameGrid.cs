using System;
using System.Linq;

namespace Engine
{

    public class GameGrid
    {
        private Cell[,] _grid;

        public GameGrid(int w, int h)
        {
            _grid = new Cell[w,h];
        }
        
        public Cell[] SelectCells() => _grid.Cast<Cell>().Where(x => x.Changed).ToArray();

    }
    public class Cell
    {
        public bool Changed = true;

        private RendererData _cellData;
        public RendererData CellData
        {
            get { 
                Changed = true;
                return _cellData;
            }
            
            set { 
                Changed = true;
                _cellData = value;
            }
        }
    }
   
    
}