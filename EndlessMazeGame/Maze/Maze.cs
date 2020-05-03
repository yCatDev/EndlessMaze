using System;
using System.Collections.Generic;
using System.Linq;
using AbstractEngine.Core.Base;
using EndlessMazeGame.Entities;

namespace EndlessMazeGame.Maze
{
    internal class Maze
    {
        public readonly MazeCell[,] _cells;
        private readonly Area _area;
        private readonly int _height;
        public List<MazeCell> _neighbours = new List<MazeCell>();
        public Stack<MazeCell> _path = new Stack<MazeCell>();
        private readonly int _width;
        public MazeCell finish;
        public Random rnd = new Random();
        public MazeCell start;
        public int TreasuresNum;

        public Maze(Area area)
        {
            _area = area;
            _width = _area.Grid.Core.WindowWidth;
            _height = _area.Grid.Core.WindowHeight - 1;
            start = new MazeCell(1, 1, true);
            finish = new MazeCell(_width - 3, _height - 3, true);

            _cells = new MazeCell[_width, _height];
            for (var i = 0; i < _width; i++)
            for (var j = 0; j < _height; j++)
                if (i % 2 != 0 && j % 2 != 0 && i < _width - 1 && j < _height - 1
                )
                    _cells[i, j] = new MazeCell(i, j);
                else
                    _cells[i, j] = new MazeCell(i, j, false, false);

            _path.Push(start);
            _cells[start.Position.X, start.Position.Y] = start;
        }

        public void CreateMaze(out Point playerPos)
        {
            _cells[start.Position.X, start.Position.Y] = start;
            while (_path.Count != 0) //поки в стекі щось є шукаємо всі невідвіданній клітки
            {
                _neighbours.Clear();
                GetNeighbours(_path.Peek()); //_path.Peek() - тимчасова клітка, тобто остання в шляху
                if (_neighbours.Count != 0) //Якщо клітка має сусідів 
                {
                    var nextCell = ChooseNeighbour(_neighbours); //Обераємо сусіда
                    RemoveWall(_path.Peek(), nextCell); //Видаляємо стіну між тимчасовою кліткою та обраною
                    nextCell.IsVisited = true; //Відмічаємо обрану як відвідану
                    _cells[nextCell.Position.X, nextCell.Position.Y].IsVisited = true;
                    _path.Push(nextCell); //Зберігаємо обрану клітку до стеку та робимо її тимчасовою
                }
                else
                {
                    _path.Pop(); //Інакше видаляємо останню клітку ти самим оновлюючи тимчасову
                }
            }

            CreateMazeOnArea();
            playerPos = SpawnObjectsAndPlayer();
        }

        private void GetNeighbours(MazeCell localcell) // Шукаємо сусідів тимчасової клітки
        {
            var x = localcell.Position.X;
            var y = localcell.Position.Y;
            const int distance = 2;
            MazeCell[] possibleNeighbours =
            {
                new MazeCell(x, y - distance), // Up
                new MazeCell(x + distance, y), // Right
                new MazeCell(x, y + distance), // Down
                new MazeCell(x - distance, y) // Left
            };
            for (var i = 0; i < 4; i++) // Перевіряємо всі напрямки
            {
                var curNeighbour = possibleNeighbours[i];
                if (curNeighbour.Position.X > 0 && curNeighbour.Position.X < _width
                                                && curNeighbour.Position.Y > 0 && curNeighbour.Position.Y < _height)
                    // Перевіряємо чи сусід знаходиться в рамках лабіринту
                    if (_cells[curNeighbour.Position.X, curNeighbour.Position.Y].IsEmpty
                        && !_cells[curNeighbour.Position.X, curNeighbour.Position.Y].IsVisited)
                        // А також чи являється пустою кліткою та не відвіданним
                        _neighbours.Add(curNeighbour);
            }
        }

        private MazeCell ChooseNeighbour(List<MazeCell> neighbours)
        {
            var r = rnd.Next(neighbours.Count);
            return neighbours[r];
        }

        private void RemoveWall(MazeCell first, MazeCell second)
        {
            var xDiff = second.Position.X - first.Position.X;
            var yDiff = second.Position.Y - first.Position.Y;
            var addX = xDiff != 0 ? xDiff / Math.Abs(xDiff) : 0; // Шукаємо напрямок видалення
            var addY = yDiff != 0 ? yDiff / Math.Abs(yDiff) : 0;

            _cells[first.Position.X + addX, first.Position.Y + addY].IsEmpty = true; //робимо стіну - пустою кліткою
            _cells[first.Position.X + addX, first.Position.Y + addY].IsVisited = true; //та відвіданною
            second.IsVisited = true; //теж саме
            _cells[second.Position.X, second.Position.Y] = second;
        }

        private Point SpawnObjectsAndPlayer()
        {
            var possiblePos = _cells.Cast<MazeCell>().Where(x => x.IsEmpty)
                .Select(y => y.Position).ToList();
            var playrPos = possiblePos[new Random().Next(0, possiblePos.Count)];
            possiblePos.Remove(playrPos);

            var n = new Random().Next(5, 12);
            TreasuresNum = n;
            for (var i = 0; i < n; i++)
            {
                var r = new Random().Next(0, possiblePos.Count);
                Entity.CreateEntity<Treasure>("Treasure", possiblePos[r], _area);
                possiblePos.RemoveAt(r);
            }


            possiblePos = possiblePos.Where(x => Point.Distance(x, playrPos) > 5).ToList();
            n = new Random().Next(5, 15);
            for (var i = 0; i < n; i++)
            {
                var r = new Random().Next(0, possiblePos.Count);
                Entity.CreateEntity<Stone>("Stone", possiblePos[r], _area);
                possiblePos.RemoveAt(r);
            }


            return playrPos;
        }

        private void CreateMazeOnArea()
        {
            for (var i = 0; i < _cells.GetLength(0); i++)
            for (var j = 0; j < _cells.GetLength(1); j++)
            {
                var mazeCell = _cells[i, j];
                if (!mazeCell.IsEmpty) Entity.CreateEntity<MazeBlock>($"Block{i}_{j}", new Point(i, j), _area);
            }
        }
    }
}