using System;
using System.Linq;
using System.Net.Mime;
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
        
        private const int WIDTH = 20;
        private const int HEIGHT = 10;
        private const string TITLE = "Endless maze";
        
        [STAThread]
        static void Main(string[] args)
        {
            if (!args.Contains("sfml"))//Check what mode you want
            {
                _engine = new ConsoleEngine.ConsoleEngine(WIDTH, HEIGHT, TITLE);//Init engine what you want
                _engine.Resources.RegisterResource("sharp", '#');//Register resources "Sharp" in console form
            }
            else
            {
                _engine = new SFMLEngine.SFMLEngine(WIDTH,HEIGHT, 25,TITLE);
                var s = new CircleShape {Radius = 10, FillColor = Color.Green};
                _engine.Resources.RegisterResource("sharp", s);//Register resources "Sharp" in SFML form
            }
            var test = new TestArea(_engine.GameGrid);//Create area
            _engine.LoadArea(test);//Load area
            _engine.Run();//Run game
        }
        
   
    }
}