using System.Timers;
using AbstractEngine.Core.Base;

namespace EndlessMazeGame.Entities
{
    public class BombWave : Entity
    {
        private Timer _liveTimer;

        protected override void Start()
        {
            SetNewGraphics("ExpWave", Color.Red);
            _liveTimer = new Timer
            {
                Interval = 750
            };
            _liveTimer.Elapsed += (sender, args) =>
            {
                Area.Grid.MakeCellEmpty(GetPosition());
                Destroy();
            };
            _liveTimer.Start();
        }

        public override void Destroy(bool clearCell = true)
        {
            _liveTimer.Dispose();
            base.Destroy(clearCell);
        }
    }
}