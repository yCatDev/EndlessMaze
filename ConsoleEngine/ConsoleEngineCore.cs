using System;
using AbstractEngine.Core;
using AbstractEngine.Core.Base;


namespace ConsoleEngine 
{
    public class ConsoleEngine: AbstractCore
    {
        public ConsoleEngine(int w, int h, string title) : base(w, h, title)
        {
            Console.CursorVisible = false;
            Console.Title = title;
        }

   

        protected override void OnRenderStart()
        {
           
        }

        protected override void OnRenderObject(Cell cell, Point cellPos)
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

        protected override void OnRenderEnd()
        {
           
        }

        protected override void OnTextCharDraw(char c, Point cellPos)
        {
            GameGrid[cellPos] = new Cell(new RenderObject(c));
        }
    }
}