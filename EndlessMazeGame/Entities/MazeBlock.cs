using AbstractEngine.Core.Base;

namespace EndlessMazeGame.Entities
{
    public class MazeBlock:Entity
    {
        protected override void Start()
        {
            SetNewGraphics("Block", Color.DarkGray);
        }

        public override void Update()
        {
            
        }
    }
}