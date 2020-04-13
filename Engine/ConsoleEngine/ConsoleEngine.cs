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
        

        public override void OnRender(Cell renderCell)
        {
            
        }
    }
    public class CellData: ICellData
    {
        public ConsoleColor Foreground;
        public ConsoleColor SymbolColor;
        public Char Element;
    }
}