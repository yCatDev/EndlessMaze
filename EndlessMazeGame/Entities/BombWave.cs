﻿using System.Timers;
using AbstractEngine.Core.Base;

namespace EndlessMazeGame.Entities
{
    public class BombWave: Entity
    {
        private Timer _liveTimer;
        
        public override void Start()
        {
            SetNewGraphics("ExpWave", Color.Red);
            _liveTimer = new Timer()
            {
                Interval = 750
            };
            _liveTimer.Elapsed += (sender, args) => Destroy();
            _liveTimer.Start();
        }

        public override void Update()
        {
            
        }

        public override void Destroy()
        {
            _liveTimer.Dispose();
            base.Destroy();
        }
    }
}