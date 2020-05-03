using System;
using System.Threading;
using AbstractEngine.Core.Base;
using EndlessMazeGame.Areas;

namespace EndlessMazeGame.Entities
{
    public class Player:Entity
    {
        public enum MoveDirection
        {
            None,Up, Down, Left, Right
        }
        public int CollectedTreasures = 0;
        private MoveDirection _lastMove;
        private Bomb _bomb;
        private bool _alive = true;

        protected override void Start()
        {
            _lastMove = MoveDirection.None;
            SetNewGraphics("Player", Color.DarkBlue);
        }

        public void SetTreasures(int n) => CollectedTreasures = n;

        public override void Update()
        {
            
            var e = Area.Grid.Core;

            if (_bomb!=null&&_bomb.Exploded)
                _bomb = null;
            
            var t = GetPosition();
            if (InputManager.OnKeyDown(VirtualKeys.Down))
            {
               t.Y++;
                if (t.Y <= e.WindowHeight)
                {
                    Move(t);
                    _lastMove = MoveDirection.Down;
                }
            }
            if (InputManager.OnKeyDown(VirtualKeys.Up))
            {
               t.Y--;
                if (t.Y >= 0)
                {
                    Move(t);
                    _lastMove = MoveDirection.Up;
                } 
            }
            if (InputManager.OnKeyDown(VirtualKeys.Left))
            {
                t.X--;
                if (t.X>= 0 )
                {
                    Move(t);
                    _lastMove = MoveDirection.Left;
                }
            }
            if (InputManager.OnKeyDown(VirtualKeys.Right))
            { 
                t.X++;
                if (t.X  <= e.WindowWidth)
                {
                    Move(t);
                    _lastMove = MoveDirection.Right;
                }
            }

            if (InputManager.OnKeyDown(VirtualKeys.Space) && _bomb==null)
                SpawnBomb();
            if (!_alive)
                ReallyDie();
        }

        private void ReallyDie()
        {
            Thread.Sleep(250);
            Area.Grid.Core.LoadArea(new GameOverArea(Area.Grid), false);
        }
        
        public void Die()
        {
            _alive = false;
        }
        
        private void SpawnBomb()
        {
            var t = GetPosition();
            var to = Point.Zero;
            switch (_lastMove)
            {
                
                case MoveDirection.None:
                    break;
                case MoveDirection.Up:
                    t.Y++;
                    if (string.IsNullOrEmpty(Area.Grid[t].GetName()) && t.Y <= Area.Grid.Core.WindowHeight)
                        to = t;
                    break;
                case MoveDirection.Down:
                    t.Y--;
                    if (string.IsNullOrEmpty(Area.Grid[t].GetName()) && t.Y >= 0)
                        to = t;
                    break;
                case MoveDirection.Left:
                    t.X++;
                    if (string.IsNullOrEmpty(Area.Grid[t].GetName()) && t.X  <= Area.Grid.Core.WindowWidth)
                        to = t;
                    break;
                case MoveDirection.Right:
                    t.X--;
                    if (string.IsNullOrEmpty(Area.Grid[t].GetName()) && t.X>= 0)
                        to = t;
                    break;
            }
            if (to!=Point.Zero)
                _bomb = CreateEntity<Bomb>("Bomb", to, Area);
        }
        
        private void Move(Point to)
        {
            var nextCell = Area.Grid[to];
            var o = nextCell.GetName();
            if (o.Contains("Block") || o.Contains("Bomb")|| o.Contains("Stone") || o.Contains("ExpWave"))
                return;
            if (o.Contains("Treasure"))
            {
                Area.Grid.MakeCellEmpty(to);
                CollectedTreasures--;
            }

            SetPosition(to);
        }
    }
}