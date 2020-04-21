using System;
using AbstractEngine.Core;
using AbstractEngine.Core.Base;


namespace ConsoleEngine 
{
    public class ConsoleEngine: AbstractCore
    {
        public ConsoleEngine() : base(10, 10)
        {
            Console.CursorVisible = false;
        }

        public override void OnRenderStart()
        {
            Console.Clear();
        }

        public override void OnRenderObject(Cell cell, Point cellPos)
        {
            Console.SetCursorPosition(cellPos.X, cellPos.Y);
            //Console.WriteLine(cellPos.ToString());
            if (cell.GetRenderObject<char>(out var res))
                Console.Write(res);
            else
            {
                Console.Write(' ');
            }
        }

        public override void OnRenderEnd()
        {
            
        }
    }
}