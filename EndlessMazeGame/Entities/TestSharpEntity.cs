using System;
using AbstractEngine.Core.Base;

namespace EndlessMazeGame.Entities
{
    public class TestSharpEntity: Entity
    {
        public TestSharpEntity(string name, Point startPos, Area area) : base(name, startPos, "sharp", area)
        {
        }

        public override void Update()
        {

            if (InputManger.OnKeyDown(VirtualKeys.Down))
            {
                SetPosition(_gridPosition.X, _gridPosition.Y + 1);
            }

            if (InputManger.OnKeyDown(VirtualKeys.Up))   
               SetPosition(_gridPosition.X, _gridPosition.Y - 1);
           if (InputManger.OnKeyDown(VirtualKeys.Left))
               SetPosition(_gridPosition.X - 1, _gridPosition.Y);
           if (InputManger.OnKeyDown(VirtualKeys.Right))
               SetPosition(_gridPosition.X + 1, _gridPosition.Y);
        }
    }
}