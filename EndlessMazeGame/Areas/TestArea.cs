using AbstractEngine.Core;
using AbstractEngine.Core.Base;
using EndlessMazeGame.Entities;

namespace EndlessMazeGame.Areas
{
    public class TestArea: Area
    {
        public TestArea(GameGrid gameGrid, Resources resources) : base(gameGrid, resources)
        {
        }

        public override void Init()
        {
            Grid.Core.DrawText("Hello world", Point.Zero);
            var sharp = new TestSharpEntity("test", new Point(0,1), this);
        }

        public override void Update()
        {
            
        }
    }
}