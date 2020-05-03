using AbstractEngine.Core.Base;

namespace EndlessMazeGame.Maze
{
    public struct MazeCell
    {
        public Point Position;
        public bool IsEmpty { get; set; }
        public bool IsVisited { get; set; }
        public MazeCell(int x, int y, bool isVisited = false, bool isCell = true)
        {
            Position = new Point(x,y);
            IsEmpty = isCell;
            IsVisited = isVisited;
        }
    }
}