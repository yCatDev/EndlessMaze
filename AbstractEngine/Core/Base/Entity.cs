using System;

namespace AbstractEngine.Core.Base
{
    public abstract class Entity
    {
        public string Name;

        private Point _gridPosition;
            
        protected Area _ownerArea;

        protected Entity()
        {
            
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


        public abstract void Start();
        public abstract void Update();

        public static T CreateEntity<T>(string name, Point startPos, Area area) where T : Entity, new()
        {
            var e = new T()
            {
                Name = name,
                _gridPosition = startPos,
                _ownerArea = area,
            };
            
            
            e._ownerArea.Grid[e._gridPosition].SetName(e.Name);
            e._ownerArea.RegEntity(e);
            e.Start();
            return e;
        }

        public virtual void Destroy(bool clearCell = true)
        {
            _ownerArea.DeleteEntity(this);
            if (clearCell)
                _ownerArea.Grid.MakeCellEmpty(_gridPosition);
        }
    }

   
}