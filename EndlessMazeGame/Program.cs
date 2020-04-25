using System;
using System.Linq;
using System.Net.Mime;
using AbstractEngine.Core;
using AbstractEngine.Core.Base;
using ConsoleEngine;
using EndlessMazeGame.Areas;
using SFML.Graphics;
using SFML.System;


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
               ResourceManger.LoadResourcesForSFMLEngine(_engine.Resources);
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
                resources.RegisterResource("MenuPointer", '>');
                
                resources.RegisterResource("Treasure", '▒');
                resources.RegisterResource("Player", '#');
                resources.RegisterResource("Block", '█');
                resources.RegisterResource("Stone", '@');
                resources.RegisterResource("ExpWave", '█');
                
                resources.RegisterResource("Bomb1", '/');
                resources.RegisterResource("Bomb2", '-');
                resources.RegisterResource("Bomb3", @"\");
                resources.RegisterResource("Bomb4", '|');
            }
            public static void LoadResourcesForSFMLEngine(Resources resources)
            {
                var b = new RectangleShape() {Size = new Vector2f(25,25), FillColor = SFML.Graphics.Color.Black};
                resources.RegisterResource("MenuBorderUL", b);
                resources.RegisterResource("MenuBorderUR", b);
                resources.RegisterResource("MenuBorderDL", b);
                resources.RegisterResource("MenuBorderDR", b);
                resources.RegisterResource("MenuBorderH", b);
                resources.RegisterResource("MenuBorderV", b);
                resources.RegisterResource("MenuPointer", b);
                
                Shape s = new CircleShape {Radius = 10, FillColor = SFML.Graphics.Color.Red};
                resources.RegisterResource("Treasure", s);
                s = new CircleShape {Radius = 10, FillColor = SFML.Graphics.Color.Green};
                resources.RegisterResource("Player", s);
                resources.RegisterResource("Block", b);
                s = new RectangleShape() {Size = new Vector2f(25,25), FillColor = SFML.Graphics.Color.Green}; 
                resources.RegisterResource("Stone", s);
                s = new RectangleShape() {Size = new Vector2f(25,25), FillColor = SFML.Graphics.Color.Red};
                resources.RegisterResource("ExpWave", s);
                
                s = new RectangleShape() {Size = new Vector2f(25,25), FillColor = SFML.Graphics.Color.Red};
                resources.RegisterResource("Bomb1", s);
                resources.RegisterResource("Bomb3", s);
                s = new RectangleShape() {Size = new Vector2f(10,10), FillColor = SFML.Graphics.Color.Red};
                resources.RegisterResource("Bomb2", s);
                resources.RegisterResource("Bomb4", s);
            }
        }
     
    }
    
}