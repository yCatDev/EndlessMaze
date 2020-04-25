using AbstractEngine.Core;
using AbstractEngine.Core.Base;

namespace EndlessMazeGame.Entities
{
    public class Treasure: Entity
    {

        public override void Start()
        {
            SetNewGraphics("Treasure", Other.RandomColor(
                Color.Blue, Color.DarkRed, Color.DarkYellow, Color.DarkCyan, Color.DarkMagenta));
        }

        public override void Update()
        {
            
        }
    }
}