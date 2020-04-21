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
            if (Console.ReadKey(true).Key == ConsoleKey.S)
                SetPosition(_gridPosition.X, _gridPosition.Y+1);
            if (Console.ReadKey(true).Key == ConsoleKey.W)
                SetPosition(_gridPosition.X, _gridPosition.Y-1);
            if (Console.ReadKey(true).Key == ConsoleKey.A)
                SetPosition(_gridPosition.X-1, _gridPosition.Y);
            if (Console.ReadKey(true).Key == ConsoleKey.D)
                SetPosition(_gridPosition.X+1, _gridPosition.Y);
        }
    }
}