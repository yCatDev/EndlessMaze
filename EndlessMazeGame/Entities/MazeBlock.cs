﻿using AbstractEngine.Core.Base;

namespace EndlessMazeGame.Entities
{
    public class MazeBlock:Entity
    {

        public override void Start()
        {
            SetNewGraphics("Block", Color.DarkGray);
        }

        public override void Update()
        {
            
        }
    }
}