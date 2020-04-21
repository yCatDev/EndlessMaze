using System;
using System.Linq;
using AbstractEngine.Core;
using AbstractEngine.Core.Base;
using ConsoleEngine;
using EndlessMazeGame.Areas;
using SFML.Graphics;

namespace EndlessMazeGame
{
    class Program
    {
        private static AbstractCore _engine;
        private static Resources _resources; 
        
        static void Main(string[] args)
        {
            if (!args.Contains("g"))
            {
                _engine = new ConsoleEngine.ConsoleEngine(20, 10, "Endless maze");
                _resources = new Resources();
                _resources.RegisterResource("sharp", '#');
            }
            else
            {
                _engine = new SFMLEngine.SFMLEngine(20,10, 25,"Endless maze");
                _resources = new Resources();
                var s = new CircleShape {Radius = 10, FillColor = Color.Green};
                _resources.RegisterResource("sharp", s);
            }
            
            var test = new TestArea(_engine.GameGrid, _resources);
            _engine.LoadArea(test);
            _engine.Run();
           
        }
        
        static int LostNumber(int[] mas) {
            //0 1 2 4 5
            //0 1 2 3 4 5
            Array.Sort(mas);
            int n = mas[mas.Length-1];
            for (int i = 0; i<=n; i++)
            {
                if (mas[i]!=i)
                    return i;
            }
            return -1;
        }
    }
}