using System;
using System.Linq;
using System.Runtime.InteropServices;
using AbstractEngine.Core;
using EndlessMazeGame.Areas;
using SFML.Graphics;
using SFML.System;
using Color = AbstractEngine.Core.Base.Color;


namespace EndlessMazeGame
{
    class Program
    {
        private static AbstractCore _engine;
        
        private const int WIDTH = 40;
        private const int HEIGHT = 20;
        private const string TITLE = "Endless maze";
        
        static void Main(string[] args)
        {
            if (!args.Contains("sfml"))
            {
                _engine = new ConsoleEngine.ConsoleEngine(WIDTH, HEIGHT, 24,TITLE);//Init engine what you want
                ResourceManger.LoadResourcesForConsoleEngine(_engine.Resources);
            }
            else
            {
                _engine = new SFMLEngine.SFMLEngine(WIDTH,HEIGHT, 25,TITLE);
               ResourceManger.LoadResourcesForSfmlEngine(_engine.Resources);
            }

            _engine.SetBackgroundColor(Color.White);
            var menu = new MenuArea(_engine.GameGrid);//Create area
            _engine.LoadArea(menu);//Load area
            
            _engine.Run();//Run game
           
        }
       

        private static class ResourceManger
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
            public static void LoadResourcesForSfmlEngine(Resources resources)
            {
                Shape shape;
                shape = new CircleShape(HEIGHT/2, 3){Rotation = 90};
                resources.RegisterResource("MenuPointer", shape);
                shape = new RectangleShape() {Size = new Vector2f(HEIGHT,HEIGHT)};

                resources.RegisterResource("MenuBorderUL", shape);
                resources.RegisterResource("MenuBorderUR", shape);
                resources.RegisterResource("MenuBorderDL", shape);
                resources.RegisterResource("MenuBorderDR", shape);
                resources.RegisterResource("MenuBorderH", shape);
                resources.RegisterResource("MenuBorderV", shape);

                shape = new CircleShape(10, 4);
                resources.RegisterResource("Treasure", shape);
                shape = new CircleShape(HEIGHT / 2);
                resources.RegisterResource("Player", shape);
                shape = new RectangleShape() {Size = new Vector2f(HEIGHT,HEIGHT)};
                resources.RegisterResource("Block", shape);
                resources.RegisterResource("ExpWave", shape);

                resources.RegisterResource("Bomb1",shape);
                resources.RegisterResource("Bomb3", shape);
                shape = new RectangleShape() {Size = new Vector2f(HEIGHT/2,HEIGHT/2)};
                resources.RegisterResource("Bomb2", shape);
                resources.RegisterResource("Bomb4", shape);
                shape = new CircleShape(HEIGHT / 2, 6);
                resources.RegisterResource("Stone", shape);
            }
        }
     
    }
    
}