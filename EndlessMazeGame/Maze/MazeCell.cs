using AbstractEngine.Core.Base;

namespace EndlessMazeGame.Maze
{
    public struct MazeCell
    {
        public Point Position;
        public bool _isCell { get; set; }
        public bool _isVisited { get; set; }
        public MazeCell(int x, int y, bool isVisited = false, bool isCell = true)
        {
            Position = new Point(x,y);
            _isCell = isCell;
            _isVisited = isVisited;
        }
    }
}