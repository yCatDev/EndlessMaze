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
            if (!Console.KeyAvailable) return;
            var key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.S:
                    SetPosition(_gridPosition.X, _gridPosition.Y + 1);
                    break;
                case ConsoleKey.W:
                    SetPosition(_gridPosition.X, _gridPosition.Y - 1);
                    break;
                case ConsoleKey.A:
                    SetPosition(_gridPosition.X - 1, _gridPosition.Y);
                    break;
                case ConsoleKey.D:
                    SetPosition(_gridPosition.X + 1, _gridPosition.Y);
                    break;
                
            }
        }
    }
}