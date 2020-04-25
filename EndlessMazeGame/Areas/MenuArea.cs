using System;
using AbstractEngine.Core.Base;
using EndlessMazeGame.Entities;
using SFML.Window;

namespace EndlessMazeGame.Areas
{
    public class MenuArea: Area
    {

        private SaveSystem _saveSystem;
        
        public MenuArea(GameGrid gameGrid) : base(gameGrid)
        {
        }

        public override void Init()
        {
            var e = Grid.Core;
            _saveSystem = new SaveSystem();
            
            var MenuUL = new CellData()
            {
                RenderObject = e.Resources["MenuBorderUL"],
                Color = Color.Black
            };
            var MenuUR = new CellData()
            {
                RenderObject = e.Resources["MenuBorderUR"],
                Color = Color.Black
            };
            var MenuDL= new CellData()
            {
                RenderObject = e.Resources["MenuBorderDL"],
                Color = Color.Black
            }; 
            var MenuDR= new CellData()
            {
                RenderObject = e.Resources["MenuBorderDR"],
                Color = Color.Black
            }; 
            var MenuV= new CellData()
            {
                RenderObject = e.Resources["MenuBorderV"],
                Color = Color.Black
            };
            var MenuH= new CellData()
            {
                RenderObject = e.Resources["MenuBorderH"],
                Color = Color.Black
            };
            
            e.DrawPrimitive(MenuUL, Point.Zero);
            e.DrawPrimitive(MenuUR, new Point(e.WindowWidth-1, 0));
            e.DrawPrimitive(MenuDL, new Point(0, e.WindowHeight-1));
            e.DrawPrimitive(MenuDR, new Point(e.WindowWidth-1, e.WindowHeight-1));

            for (int i = 1; i < e.WindowWidth - 1; i++)
            {
                e.DrawPrimitive(MenuH, new Point(i, 0));
                e.DrawPrimitive(MenuH, new Point(i, e.WindowHeight - 1));
            }
            for (int i = 1; i < e.WindowHeight - 1; i++)
            {
                e.DrawPrimitive(MenuV, new Point(0, i));
                e.DrawPrimitive(MenuV, new Point(e.WindowWidth-1, i));
            }
            
            e.DrawTextInCenter(e.WindowTitle, 2, 4, Color.Black);
            e.DrawTextInCenter("Total time in mazes", 2, 7, Color.Black);

            var time = TimeSpan.FromMilliseconds(_saveSystem.SaveFile.TimeInMaze).ToString(@"hh\:mm\:ss");
            e.DrawTextInCenter(time, 2, 8, Color.Black);
            e.DrawTextInCenter("Play", 2, 12, out var playPoint, Color.Black);
            e.DrawTextInCenter("Continue", 2, 13, out var continuePoint, Color.Black);
            e.DrawTextInCenter("Exit", 2, 14, out var exitPoint,Color.Black);
            
            var menuPoint = Entity.CreateEntity<MenuPoint>("MenuPoint", playPoint, this);
            menuPoint.SetMenuPoints(playPoint, continuePoint, exitPoint);
            
        }

        
        
        public override void Update()
        {
            
        }
    }
}