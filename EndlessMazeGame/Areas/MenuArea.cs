using System;
using AbstractEngine.Core.Base;
using EndlessMazeGame.Entities;

namespace EndlessMazeGame.Areas
{
    public class MenuArea : Area
    {
        private SaveSystem _saveSystem;

        public MenuArea(GameGrid gameGrid) : base(gameGrid)
        {
        }

        public override void Init()
        {
            var e = Grid.Core;
            _saveSystem = new SaveSystem();

            var menuUl = new CellData
            {
                RenderObject = e.Resources["MenuBorderUL"],
                Color = Color.Black
            };
            var menuUr = new CellData
            {
                RenderObject = e.Resources["MenuBorderUR"],
                Color = Color.Black
            };
            var menuDl = new CellData
            {
                RenderObject = e.Resources["MenuBorderDL"],
                Color = Color.Black
            };
            var menuDr = new CellData
            {
                RenderObject = e.Resources["MenuBorderDR"],
                Color = Color.Black
            };
            var menuV = new CellData
            {
                RenderObject = e.Resources["MenuBorderV"],
                Color = Color.Black
            };
            var menuH = new CellData
            {
                RenderObject = e.Resources["MenuBorderH"],
                Color = Color.Black
            };

            e.DrawPrimitive(menuUl, Point.Zero);
            e.DrawPrimitive(menuUr, new Point(e.WindowWidth - 1, 0));
            e.DrawPrimitive(menuDl, new Point(0, e.WindowHeight - 1));
            e.DrawPrimitive(menuDr, new Point(e.WindowWidth - 1, e.WindowHeight - 1));

            for (var i = 1; i < e.WindowWidth - 1; i++)
            {
                e.DrawPrimitive(menuH, new Point(i, 0));
                e.DrawPrimitive(menuH, new Point(i, e.WindowHeight - 1));
            }

            for (var i = 1; i < e.WindowHeight - 1; i++)
            {
                e.DrawPrimitive(menuV, new Point(0, i));
                e.DrawPrimitive(menuV, new Point(e.WindowWidth - 1, i));
            }

            e.DrawTextInCenter(e.WindowTitle, 2, 4, Color.Black);
            e.DrawTextInCenter("Total time in mazes", 2, 7, Color.Black);

            var time = TimeSpan.FromMilliseconds(_saveSystem.SaveFile.TimeInMaze).ToString(@"hh\:mm\:ss");
            e.DrawTextInCenter(time, 2, 8, Color.Black);
            e.DrawTextInCenter("Play", 2, 12, out var playPoint, Color.Black);
            e.DrawTextInCenter("Continue", 2, 13, out var continuePoint, Color.Black);
            e.DrawTextInCenter("Exit", 2, 14, out var exitPoint, Color.Black);

            var menuPoint = Entity.CreateEntity<MenuPoint>("MenuPoint", playPoint, this);
            menuPoint.SetMenuPoints(playPoint, continuePoint, exitPoint);

            if (!_saveSystem.SaveFile.LevelSaveData.IsEmpty())
                menuPoint.EnableContinue();
        }
    }
}