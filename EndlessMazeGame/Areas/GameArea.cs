using System.Diagnostics;
using AbstractEngine.Core.Base;
using EndlessMazeGame.Entities;


namespace EndlessMazeGame.Areas
{
    public class GameArea: Area
    {
        private Maze.Maze _maze;
        private Player _player;
        private SaveSystem _saveSystem;
        private bool c = false;
        private Stopwatch _clock;
        
        public GameArea(bool c, GameGrid gameGrid) : base(gameGrid)
        {
            this.c = c;
        }

        public override void Init()
        {
            _saveSystem = new SaveSystem();
            if (!c)
            {
                _maze = new Maze.Maze(this);
                _maze.CreateMaze(out var player);

                _player = Entity.CreateEntity<Player>("Player", player, this);
                _player.SetTreasures(_maze.TreasuresNum);
                
                _saveSystem.SaveFile.LevelSaveData.SaveLevel(Grid);
                
                
            }
            else
            {
                foreach (var point in _saveSystem.SaveFile.LevelSaveData.BlockPositions)
                {
                    Entity.CreateEntity<MazeBlock>($"Block", point.Point, this);
                }

                var t = 0;
                foreach (var point in _saveSystem.SaveFile.LevelSaveData.TreasurePositions)
                {
                    Entity.CreateEntity<Treasure>("Treasure", point.Point, this);
                    t++;
                }
                foreach (var point in _saveSystem.SaveFile.LevelSaveData.StonePositions)
                {
                    Entity.CreateEntity<Stone>("Stone", point.Point, this);
                }
                
                _player = Entity.CreateEntity<Player>("Player", _saveSystem.SaveFile.LevelSaveData.PlayerPosition.Point, this);
                _player.SetTreasures(t);
            }
            _clock = new Stopwatch();
            _clock.Start();
        }

        public override void Update()
        {
            AddTime();
            Grid.Core.DrawText($"Treasurse in maze: x{_player.CollectedTreasures}   ECS to exit", new Point(0, Grid.Heigth-1));
            if (InputManger.OnKeyDown(VirtualKeys.Escape))
            {
                
                Grid.Core.LoadArea(new MenuArea(Grid));
            }

            if (_player.CollectedTreasures == 0)
            {
                Grid.Core.LoadArea(new GameArea(false, Grid));
            }
        }
         
        private void AddTime()
        {
            _saveSystem.SaveFile.TimeInMaze += (int)_clock.Elapsed.TotalMilliseconds;
            _saveSystem.Save();
            _clock.Restart();
        }
        
    }
}