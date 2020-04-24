using AbstractEngine.Core;
using AbstractEngine.Core.Base;

namespace EndlessMazeGame.Entities
{
    public class Treasure: Entity
    {

        public override void Start()
        {
            SetNewGraphics("Treasure", Other.RandomColor(Color.Cyan, Color.Red, Color.Yellow));
        }

        public override void Update()
        {
            
        }
    }
}