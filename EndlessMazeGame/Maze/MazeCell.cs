namespace EndlessMazeGame.Maze
{
    public struct MazeCell
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool _isCell { get; set; }
        public bool _isVisited { get; set; }
        public MazeCell(int x, int y, bool isVisited = false, bool isCell = true)
        {
            X = x;
            Y = y;
            _isCell = isCell;
            _isVisited = isVisited;
        }
    }
}