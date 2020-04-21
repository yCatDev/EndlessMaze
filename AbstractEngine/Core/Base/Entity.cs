namespace AbstractEngine.Core.Base
{
    public abstract class Entity
    {
        public string Name;
        protected Point _gridPosition;
        private Area _ownerArea;

        public Entity(string name, Point startPos, string resourceName, Area area)
        {
            Name = name;
            _gridPosition = startPos;
            _ownerArea = area;
            
            _ownerArea.Grid[_gridPosition] = new Cell(_ownerArea.GetResource(resourceName));
            _ownerArea.RegEntity(this);
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

        public override string ToString()
        {
            return $"{X} {Y}";
        }

        public static readonly Point Zero = new Point(0,0);
        
    }
}