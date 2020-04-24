using System;
using AbstractEngine.Core.Base;

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

        public override void Start()
        {
            LastMove = MoveDirection.None;
            SetNewGraphics("Player");
        }

        public void SetTreasures(int n) => CollectedTreasures = n;

        public override void Update()
        {
            var e = _ownerArea.Grid.Core;

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
                    if (string.IsNullOrEmpty(_ownerArea.Grid[t].GetName()) && t.Y <= _ownerArea.Grid.Core.WindowHeight)
                        to = t;
                    break;
                case MoveDirection.Down:
                    t.Y--;
                    if (string.IsNullOrEmpty(_ownerArea.Grid[t].GetName()) && t.Y >= 0)
                        to = t;
                    break;
                case MoveDirection.Left:
                    t.X++;
                    if (string.IsNullOrEmpty(_ownerArea.Grid[t].GetName()) && t.X  <= _ownerArea.Grid.Core.WindowWidth)
                        to = t;
                    break;
                case MoveDirection.Right:
                    t.X--;
                    if (string.IsNullOrEmpty(_ownerArea.Grid[t].GetName()) && t.X>= 0)
                        to = t;
                    break;
            }
            if (to!=Point.Zero)
                _bomb = CreateEntity<Bomb>("Bomb", to, _ownerArea);
        }
        
        private void Move(Point to)
        {
            var nextCell = _ownerArea.Grid[to];
            var o = nextCell.GetName();
            if (o.Contains("Block") || o.Contains("Bomb")|| o.Contains("Stone"))
                return;
            if (o.Contains("Treasure"))
            {
                _ownerArea.Grid.MakeCellEmpty(to);
                CollectedTreasures--;
            }

            SetPosition(to);
        }
    }
}