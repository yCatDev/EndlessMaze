using System;

namespace AbstractEngine.Core.Base
{
    public abstract class Entity
    {
        public string Name;

        private Point _gridPosition;
        protected Area _ownerArea;

        public Entity(string name, Point startPos, Area area)
        {
            Name = name;
            _gridPosition = startPos;
            _ownerArea = area;
            
            _ownerArea.Grid[_gridPosition].SetName(Name);
            _ownerArea.RegEntity(this);
        }

        public void SetNewGraphics(string resourceName, Color color = Color.White)
        {
            _ownerArea.Grid[_gridPosition] = new Cell(new CellData(){
                RenderObject = _ownerArea.GetResource(resourceName),
                Color = color,
                EntityName = Name
            });
        }
        
        public void SetPosition(Point position) => SetPosition(position.X, position.Y);
        public void SetPosition(int x, int y)
        {
            if ((x>=_ownerArea.Grid.Width || y>=_ownerArea.Grid.Heigth)
                || x<0 || y<0) return;
            
            var data = _ownerArea.Grid[_gridPosition];
            _ownerArea.Grid.MakeCellEmpty(_gridPosition);
            _ownerArea.Grid[x, y] = new Cell(data);
            _gridPosition = new Point(x,y);
        }

        public Point GetPosition() => new Point(_gridPosition.X, _gridPosition.Y);
        
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