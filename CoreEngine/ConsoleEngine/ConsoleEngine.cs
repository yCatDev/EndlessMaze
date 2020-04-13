﻿using System;
using CoreEngine;

namespace ConsoleEngineSpace
{
    public class ConsoleEngine: CoreEngine.CoreEngine
    {
        public ConsoleEngine() : base(Console.BufferWidth, Console.BufferHeight)
        {
            
        }

        public override void OnRender(CellData cellData)
        {
            base.OnRender(cellData);
            Console.SetCursorPosition(cellData.X, cellData.Y);
            Console.WriteLine(cellData.RenderObject);
        }
    }
}