using System;
using AbstractEngine.Core.Base;

namespace EndlessMazeGame.Entities
{
    public class Player:Entity
    {
        public Player(string name, string playerResource,Point startPos, Area area) : base(name, startPos, area)
        {
            SetNewGraphics(playerResource);
        }

        public override void Update()
        {
            var e = _ownerArea.Grid.Core;
            var t = GetPosition();
            if (InputManger.OnKeyDown(VirtualKeys.Down))
            {
               t.Y++;
                if (t.Y <= e.WindowHeight && !_ownerArea.Grid[t].GetName().Contains("Block"))
                {
                    
                    SetPosition(t);
                   
                }
            }
            if (InputManger.OnKeyDown(VirtualKeys.Up))
            {
               t.Y--;
                if (t.Y >= 0 && !_ownerArea.Grid[t].GetName().Contains("Block"))
                {
                    
                    SetPosition(t);
                } 
            }
            if (InputManger.OnKeyDown(VirtualKeys.Left))
            {
                t.X--;
                if (t.X>= 0 && !_ownerArea.Grid[t].GetName().Contains("Block"))
                {
                    
                    SetPosition(t);
                }
            }
            if (InputManger.OnKeyDown(VirtualKeys.Right))
            { 
                t.X++;
                if (t.X  <= e.WindowWidth && !_ownerArea.Grid[t].GetName().Contains("Block"))
                {
                   
                    SetPosition(t);
                }
            }
            
        }
    }
}