using AbstractEngine.Core.Base;

namespace EndlessMazeGame.Entities
{
    public class Stone:Entity
    {

        public override void Start()
        {
            SetNewGraphics("Stone", Color.Black);
        }

        public override void Update()
        {
            
        }
    }
}