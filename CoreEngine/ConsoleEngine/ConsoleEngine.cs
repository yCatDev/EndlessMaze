using System;
using CoreEngine;

namespace ConsoleEngineSpace
{
    public class ConsoleEngine: CoreEngine.CoreEngine
    {
        public ConsoleEngine() : base(Console.BufferWidth, Console.BufferHeight)
        {
            
        }
    }
}