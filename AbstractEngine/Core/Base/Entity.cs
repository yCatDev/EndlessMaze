namespace AbstractEngine.Core.Base
{
    public abstract class Entity
    {
        public string Name;
        private Point _gridPosition;
        private Area _ownerArea;

        public Entity(string name, Point startPos, Area area)
        {
            Name = name;
            _gridPosition = startPos;
            _ownerArea = area;
        }

        public void SetPosition(int x, int y)
        {
            var data = _ownerArea.Grid[_gridPosition];
            _ownerArea.Grid.MakeCellEmpty(_gridPosition);
            _ownerArea.Grid[x, y] = data;
            _gridPosition = new Point(x,y);
        }

        public abstract void Update();

    }

    public class Point
    {
        public int X;
        public int Y;

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}