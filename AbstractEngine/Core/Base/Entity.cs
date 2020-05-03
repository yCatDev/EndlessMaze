namespace AbstractEngine.Core.Base
{
    public abstract class Entity
    {
        private Point _gridPosition;

        public string Name;


        public Area Area { get; private set; }

        protected void SetNewGraphics(string resourceName, Color color = Color.White)
        {
            Area.Grid[_gridPosition] = new Cell(new CellData
            {
                RenderObject = Area.GetResource(resourceName),
                Color = color,
                EntityName = Name
            });
        }

        protected void SetPosition(Point position)
        {
            SetPosition(position.X, position.Y);
        }

        private void SetPosition(int x, int y)
        {
            if (x >= Area.Grid.Width || y >= Area.Grid.Heigth
                                     || x < 0 || y < 0) return;

            var data = Area.Grid[_gridPosition];
            Area.Grid.MakeCellEmpty(_gridPosition);
            Area.Grid[x, y] = new Cell(data);
            _gridPosition = new Point(x, y);
        }

        public Point GetPosition()
        {
            return new Point(_gridPosition);
        }


        protected virtual void Start()
        {
        }

        public virtual void Update()
        {
        }

        public static T CreateEntity<T>(string name, Point startPos, Area area) where T : Entity, new()
        {
            var e = new T
            {
                Name = name,
                _gridPosition = startPos,
                Area = area
            };


            e.Area.Grid[e._gridPosition].SetName(e.Name);
            e.Area.RegEntity(e);
            e.Start();
            return e;
        }

        public virtual void Destroy(bool clearCell = true)
        {
            Area.DeleteEntity(this);
            if (clearCell)
                Area.Grid.MakeCellEmpty(_gridPosition);
        }
    }
}