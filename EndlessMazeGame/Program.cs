using System;
using AbstractEngine.Core;
using ConsoleEngine;
using EndlessMazeGame.Areas;

namespace EndlessMazeGame
{
    class Program
    {
        static void Main(string[] args)
        {
            var engine = new ConsoleEngine.ConsoleEngine();
            var resources = new Resources();
            resources.RegisterResource("sharp", '#');
            var test = new TestArea(engine.GameGrid, resources);
            engine.LoadArea(test);
            engine.Run();
        }
    }
}