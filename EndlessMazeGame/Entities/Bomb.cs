

using System.Collections.Generic;
using System.Timers;
using AbstractEngine.Core.Base;

namespace EndlessMazeGame.Entities
{
    public class Bomb: Entity
    {
        private string[] _bombAnim;
        private int _animInd = 0;
        private int TicksToBoom = 5;
        private Timer _animTimer;
        public bool Exploded = false;
        
        public override void Start()
        {
            _bombAnim = new[] {"Bomb1", "Bomb2", "Bomb3", "Bomb4"};
            _animTimer = new Timer
            {
                Interval = 110,
                AutoReset = true
            };
            _animTimer.Elapsed += (sender, args) => Animate();
            _animTimer.Start();
        }

        public override void Update()
        {
            if (TicksToBoom < 0)
            {
                Boom();
            }
        }

        private void Boom()
        {
            Destroy();
            var positions = new List<Point>();
            var moveNext = GetPosition();
            moveNext.X--;
            while (CheckExp(moveNext))
            {
                positions.Add(new Point(moveNext.X, moveNext.Y));
                moveNext.X--;
            }

            moveNext = GetPosition();
            moveNext.X++;
            while (CheckExp(moveNext))
            {
                positions.Add(new Point(moveNext.X, moveNext.Y));
                moveNext.X++;
            } 
            
            moveNext = GetPosition();
            moveNext.Y--;
            while (CheckExp(moveNext))
            {
                positions.Add(new Point(moveNext.X, moveNext.Y));
                moveNext.Y--;
            }

            moveNext = GetPosition();
            moveNext.Y++;
            while (CheckExp(moveNext))
            {
                positions.Add(new Point(moveNext.X, moveNext.Y));
                moveNext.Y++;
            }

            var selfPos = new Point(GetPosition().X, GetPosition().Y);
            _ownerArea.Grid.MakeCellEmpty(selfPos);
            positions.Add(selfPos);
            bool isPlayerInZone = false;
            foreach (var point in positions)
            {
                if (_ownerArea.Grid[point].IsName("Player"))
                    isPlayerInZone = true;
                CreateEntity<BombWave>("ExplosionWave", point, _ownerArea);
            }
            if (isPlayerInZone)
                _ownerArea.FindEntity<Player>("Player")?.Die();
            Exploded = true;
        }

        private bool CheckExp(Point p) =>
            (_ownerArea.Grid[p].GetName().Contains("Stone") || _ownerArea.Grid[p].GetName().Contains("Player")) 
                || string.IsNullOrEmpty( _ownerArea.Grid[p].GetName());
        
        public override void Destroy(bool clearCell = true)
        {
            _animTimer.Dispose();
            base.Destroy(clearCell);
        }

        private void Animate()
        {
            SetNewGraphics(_bombAnim[_animInd], Color.Red);
            _animInd++;
            if (_animInd > 3)
            {
                _animInd = 0;
                TicksToBoom--;
            }
        }
    }
}