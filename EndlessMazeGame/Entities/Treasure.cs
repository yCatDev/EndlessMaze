using AbstractEngine.Core;
using AbstractEngine.Core.Base;

namespace EndlessMazeGame.Entities
{
    public class Treasure: Entity
    {
        public Treasure(string name, string treasureResource, Point startPos, Area area) : base(name, startPos, area)
        {
            SetNewGraphics(treasureResource, Other.RandomColor(Color.Cyan, Color.Red, Color.Yellow));
        }

        public override void Update()
        {
            
        }
    }
}