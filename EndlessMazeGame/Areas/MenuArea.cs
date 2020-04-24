using AbstractEngine.Core.Base;

namespace EndlessMazeGame.Areas
{
    public class MenuArea: Area
    {
        public MenuArea(GameGrid gameGrid) : base(gameGrid)
        {
        }

        public override void Init()
        {
            var MenuUL = Grid.Core.Resources["MenuBorderUL"];
            Grid.Core.DrawPrimitive(MenuUL, Point.Zero);
        }

        public override void Update()
        {
            
        }
    }
}