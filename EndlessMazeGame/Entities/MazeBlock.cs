using AbstractEngine.Core.Base;

namespace EndlessMazeGame.Entities
{
    public class MazeBlock:Entity
    {
        public MazeBlock(string name, Point startPos, string resourceName, Color color, Area area) : base(name, startPos, area)
        {
            SetNewGraphics(resourceName, color);
        }

        public override void Update()
        {
            
        }
    }
}