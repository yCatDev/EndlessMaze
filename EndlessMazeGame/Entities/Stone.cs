using AbstractEngine.Core.Base;

namespace EndlessMazeGame.Entities
{
    public class Stone:Entity
    {
        protected override void Start()
        {
            SetNewGraphics("Stone", Color.Black);
        }

        public override void Update()
        {
            
        }
    }
}