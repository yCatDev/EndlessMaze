using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AbstractEngine.Core.Base;
using Microsoft.VisualBasic;
using SFML.Window;

namespace EndlessMazeGame.Areas
{
    public class GameOverArea: Area
    {
        private bool _animEnd = false;
        public GameOverArea(GameGrid gameGrid) : base(gameGrid)
        {
            
        }

        public override void Init()
        {
            Thread thread = new Thread(new ThreadStart(AnimatedClear));
            thread.Start();
        }

        private async void AnimatedClear()
        {
            List<int> a = new List<int>();
            List<int> b = new List<int>();
            
            for (int i = 0; i < Grid.Heigth; i+=2)
                a.Add(i);
            for (int i = 1; i < Grid.Heigth+1; i+=2)
                b.Add(i);

            for (int i = 0; i < a.Count; i++)
            {
                for (int j = 0; j < Grid.Width; j++)
                {
                    Grid.MakeCellEmpty(j,a[i]);
                    Grid.MakeCellEmpty((Grid.Width-1)-j,b[i]);
                    Thread.Sleep(10);
                }
                 
            }
            
            Thread.Sleep(300);
            Grid.Core.DrawTextInCenter("Press 'ESC' to return", 2, 9);
            Thread.Sleep(300);
            Grid.Core.DrawTextInCenter("Game over", 2, 8);
            _animEnd = true;
        }
        


        public override void Update()
        {
         
            if (_animEnd&&InputManger.OnKeyDown(VirtualKeys.Escape))
                Grid.Core.LoadArea(new MenuArea(Grid));
        }
    }
}