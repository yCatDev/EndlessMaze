using AbstractEngine.Core.Base;
using EndlessMazeGame.Entities;


namespace EndlessMazeGame.Areas
{
    public class GameArea: Area
    {
        private Maze.Maze _maze;         
        public GameArea(GameGrid gameGrid) : base(gameGrid)
        {
            
        }

        public override void Init()
        {
            _maze = new Maze.Maze(this);
            _maze.CreateMaze();
            
        }

        public override void Update()
        {
            
        }
    }
}