using System;
using System.Threading;
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
            Console.CursorVisible = false;
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
            Thread waitThread = new Thread(() =>Thread.Sleep(100));
            waitThread.Start();                    
            waitThread.Join();
        }

        protected override void OnTextCharDraw(char c, Point cellPos)
        {
            GameGrid[cellPos] = new Cell(new RenderObject(c));
        }
    }
}