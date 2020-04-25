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
        public MoveDirection LastMove;
        private Bomb _bomb;
        private bool _alive = true;
        
        public override void Start()
        {
            LastMove = MoveDirection.None;
            SetNewGraphics("Player", Color.DarkBlue);
        }

        public void SetTreasures(int n) => CollectedTreasures = n;

        public override void Update()
        {
            var e = Area.Grid.Core;

            if (_bomb!=null&&_bomb.Exploded)
                _bomb = null;
            
            var t = GetPosition();
            if (InputManger.OnKeyDown(VirtualKeys.Down))
            {
               t.Y++;
                if (t.Y <= e.WindowHeight)
                {
                    Move(t);
                    LastMove = MoveDirection.Down;
                }
            }
            if (InputManger.OnKeyDown(VirtualKeys.Up))
            {
               t.Y--;
                if (t.Y >= 0)
                {
                    Move(t);
                    LastMove = MoveDirection.Up;
                } 
            }
            if (InputManger.OnKeyDown(VirtualKeys.Left))
            {
                t.X--;
                if (t.X>= 0 )
                {
                    Move(t);
                    LastMove = MoveDirection.Left;
                }
            }
            if (InputManger.OnKeyDown(VirtualKeys.Right))
            { 
                t.X++;
                if (t.X  <= e.WindowWidth)
                {
                    Move(t);
                    LastMove = MoveDirection.Right;
                }
            }

            if (InputManger.OnKeyDown(VirtualKeys.Space) && _bomb==null)
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
            Point to = Point.Zero;
            switch (LastMove)
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
            if (o.Contains("Block") || o.Contains("Bomb")|| o.Contains("Stone"))
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