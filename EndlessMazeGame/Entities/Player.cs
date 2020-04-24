using System;
using AbstractEngine.Core.Base;

namespace EndlessMazeGame.Entities
{
    public class Player:Entity
    {
        public int CollectedTreasures = 0;
        public Player(string name, string playerResource,Point startPos, int treasures, Area area) : base(name, startPos, area)
        {
            SetNewGraphics(playerResource);
            CollectedTreasures = treasures;
        }

        public override void Update()
        {
            var e = _ownerArea.Grid.Core;
            var t = GetPosition();
            if (InputManger.OnKeyDown(VirtualKeys.Down))
            {
               t.Y++;
                if (t.Y <= e.WindowHeight)
                {
                    
                    Move(t);
                   
                }
            }
            if (InputManger.OnKeyDown(VirtualKeys.Up))
            {
               t.Y--;
                if (t.Y >= 0)
                {
                    
                    Move(t);
                } 
            }
            if (InputManger.OnKeyDown(VirtualKeys.Left))
            {
                t.X--;
                if (t.X>= 0 )
                {
                    
                    Move(t);
                }
            }
            if (InputManger.OnKeyDown(VirtualKeys.Right))
            { 
                t.X++;
                if (t.X  <= e.WindowWidth)
                {
                   
                    Move(t);
                }
            }
            
        }

        private void Move(Point to)
        {
            var nextCell = _ownerArea.Grid[to];
            if (nextCell.GetName().Contains("Block"))
                return;
            if (nextCell.GetName().Contains("Treasure"))
            {
                _ownerArea.Grid.MakeCellEmpty(to);
                CollectedTreasures--;
            }

            SetPosition(to);
        }
    }
}