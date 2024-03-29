﻿using System;
using System.Collections;
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
            var save = new SaveSystem();
            save.ClearLevel();

            var thread = new Thread(AnimatedClear);
            thread.Start();
        }

        private void AnimatedClear()
        {
            var a = new List<int>();
            var b = new List<int>();
            
            for (var i = 0; i < Grid.Heigth; i+=2)
                a.Add(i);
            for (var i = 1; i < Grid.Heigth+1; i+=2)
                b.Add(i);

            for (var i = 0; i < a.Count; i++)
            {
                for (var j = 0; j < Grid.Width; j++)
                {
                    Grid.MakeCellEmpty(j,a[i]);
                    Grid.MakeCellEmpty((Grid.Width-1)-j,b[i]);
                    Thread.Sleep(10);
                }
            }
            
            Thread.Sleep(300);
            Grid.Core.DrawTextInCenter("Press 'ESC' to return", 2, 9, Color.Black);
            Thread.Sleep(300);
            Grid.Core.DrawTextInCenter("Game over", 2, 7, Color.Black);
            _animEnd = true;
        }
        
        

        public override void Update()
        {
            if (_animEnd&&InputManager.OnKeyDown(VirtualKeys.Escape))
                Grid.Core.LoadArea(new MenuArea(Grid));
        }
    }
}