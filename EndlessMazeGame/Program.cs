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
        
        private const int WIDTH = 40;
        private const int HEIGHT = 20;
        private const string TITLE = "Endless maze";
        
        [STAThread]
        static void Main(string[] args)
        {
            if (!args.Contains("sfml"))//Check what mode you want
            {
                _engine = new ConsoleEngine.ConsoleEngine(WIDTH, HEIGHT, TITLE);//Init engine what you want
                
                ResourceManger.LoadResourcesForConsoleEngine(_engine.Resources);
            }
            else
            {
                _engine = new SFMLEngine.SFMLEngine(WIDTH,HEIGHT, 25,TITLE);
                var s = new CircleShape {Radius = 10, FillColor = SFML.Graphics.Color.Green};
                _engine.Resources.RegisterResource("sharp", s);//Register resources "Sharp" in SFML form
            }
            var menu = new MenuArea(_engine.GameGrid);//Create area
            _engine.LoadArea(menu);//Load area
            _engine.Run();//Run game
        }
        
        
        public static class ResourceManger
        {
            public static void LoadResourcesForConsoleEngine(Resources resources)
            {
                resources.RegisterResource("MenuBorderUL", '╔');
                resources.RegisterResource("MenuBorderUR", '╗');
                resources.RegisterResource("MenuBorderDL", '╚');
                resources.RegisterResource("MenuBorderDR", '╝');
                resources.RegisterResource("MenuBorderH", '═');
                resources.RegisterResource("MenuBorderV", '║');
                
                resources.RegisterResource("Player", '#');
            }
        }
        
    }
}