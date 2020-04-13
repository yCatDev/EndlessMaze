using System;

namespace Engine.ConsoleEngine
{
    public class ConsoleEngine: Engine
    {

        public ConsoleEngine():base(Console.BufferWidth, Console.BufferHeight)
        {
            
        }
        
        public override void OnInit()
        {
            Console.Clear();
        }

        public override void OnRender(RendererData renderCell)
        {
            throw new NotImplementedException();
        }

        
    }
    public class ConsoleRendererData: RendererData
    {
        public ConsoleColor Foreground = ConsoleColor.Black;
        public ConsoleColor SymbolColor = ConsoleColor.White;
        public Char Element = ' ';
        public int X { get; set; }
        public int Y { get; set; }
    }
}