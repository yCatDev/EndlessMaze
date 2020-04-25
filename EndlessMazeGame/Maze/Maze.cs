using System;
using System.Collections.Generic;
using System.Linq;
using AbstractEngine.Core.Base;
using EndlessMazeGame.Entities;

namespace EndlessMazeGame.Maze
{
    class Maze
    {
        public readonly MazeCell[,] _cells;
        private int _width;
        private int _height;
        public Stack<MazeCell> _path = new Stack<MazeCell>();
        public List<MazeCell> _neighbours = new List<MazeCell>();
        public Random rnd = new Random();
        public MazeCell start;
        public MazeCell finish;
        private Area _area;
        public int TreasuresNum;

        public Maze(Area area)
        {
            _area = area;
            _width = _area.Grid.Core.WindowWidth;
            _height = _area.Grid.Core.WindowHeight-1;
            start = new MazeCell(1, 1, true, true);
            finish = new MazeCell(_width - 3, _height - 3, true, true);
            
            _cells = new MazeCell[_width, _height];
            for (var i = 0; i < _width; i++)
            for (var j = 0; j < _height; j++)
                if ((i % 2 != 0 && j % 2 != 0) && (i < _width - 1 && j < _height - 1)
                ) //если ячейка нечетная по х и по у и не выходит за пределы лабиринта
                {
                    _cells[i, j] = new MazeCell(i, j); //то это клетка (по умолчанию)
                }
                else
                {
                    _cells[i, j] = new MazeCell(i, j, false, false);
                }

            _path.Push(start);
            _cells[start.Position.X, start.Position.Y] = start;
        }
        
        public void CreateMaze(out Point playerPos)
        {
            _cells[start.Position.X, start.Position.Y] = start;
            while (_path.Count != 0) //пока в стеке есть клетки ищем соседей и строим путь
            {
                _neighbours.Clear();
                GetNeighbours(_path.Peek());
                if (_neighbours.Count != 0)
                {
                    MazeCell nextCell = ChooseNeighbour(_neighbours);
                    RemoveWall(_path.Peek(), nextCell);
                    nextCell._isVisited = true; //делаем текущую клетку посещенной
                    _cells[nextCell.Position.X, nextCell.Position.Y]._isVisited = true; //и в общем массиве
                    _path.Push(nextCell); //затем добавляем её в стек
                }
                else
                {
                    _path.Pop();
                }
            }
            CreateMazeOnArea();
            playerPos = SpawnObjectsAndPlayer();
        }
        private void GetNeighbours(MazeCell localcell) // Получаем соседа текущей клетки
        {
            int x = localcell.Position.X;
            int y = localcell.Position.Y;
            const int distance = 2;
            MazeCell[] possibleNeighbours = new[] // Список всех возможных соседeй
            {
                new MazeCell(x, y - distance), // Up
                new MazeCell(x + distance, y), // Right
                new MazeCell(x, y + distance), // Down
                new MazeCell(x - distance, y) // Left
            };
            for (int i = 0; i < 4; i++) // Проверяем все 4 направления
            {
                MazeCell curNeighbour = possibleNeighbours[i];
                if (curNeighbour.Position.X > 0 && curNeighbour.Position.X < _width && curNeighbour.Position.Y > 0 && curNeighbour.Position.Y < _height)
                {// Если сосед не выходит за стенки лабиринта
                    if (_cells[curNeighbour.Position.X, curNeighbour.Position.Y]._isCell && !_cells[curNeighbour.Position.X, curNeighbour.Position.Y]._isVisited)
                    { // А также является клеткой и непосещен
                        _neighbours.Add(curNeighbour);
                    }// добавляем соседа в Лист соседей
                }
            }
        }
        
        private MazeCell ChooseNeighbour(List<MazeCell> neighbours) //выбор случайного соседа
        {
            int r = rnd.Next(neighbours.Count);
            return neighbours[r];
        }
        private void RemoveWall(MazeCell first, MazeCell second)
        {
            int xDiff = second.Position.X - first.Position.X;
            int yDiff = second.Position.Y - first.Position.Y;
            int addX = (xDiff != 0) ? xDiff / Math.Abs(xDiff) : 0; // Узнаем направление удаления стены
            int addY = (yDiff != 0) ? yDiff / Math.Abs(yDiff) : 0;
            // Координаты удаленной стены
            _cells[first.Position.X + addX, first.Position.Y + addY]._isCell = true; //обращаем стену в клетку
            _cells[first.Position.X + addX, first.Position.Y + addY]._isVisited = true; //и делаем ее посещенной
            second._isVisited = true; //делаем клетку посещенной
            _cells[second.Position.X, second.Position.Y] = second;
        }

        private Point SpawnObjectsAndPlayer()
        {
            var possiblePos = _cells.Cast<MazeCell>().Where(x => x._isCell)
                .Select(y => y.Position).ToList();
            var playrPos = possiblePos[new Random().Next(0, possiblePos.Count)];
            possiblePos.Remove(playrPos);
            
            var n = new Random().Next(5, 12);
            for (int i = 0; i < n; i++)
            {
                var r = new Random().Next(0, possiblePos.Count);
                var t = Entity.CreateEntity<Treasure>("Treasure", possiblePos[r], _area);
                possiblePos.RemoveAt(r);
            }


            possiblePos = possiblePos.Where(x => Point.Distance(x, playrPos) > 5).ToList();
            n = new Random().Next(5, 15);
            for (int i = 0; i < n; i++)
            {
                var r = new Random().Next(0, possiblePos.Count);
                var t = Entity.CreateEntity<Stone>("Stone", possiblePos[r], _area);
                possiblePos.RemoveAt(r);
            }
            
            TreasuresNum = n;
            return playrPos;
        }
        
        private void CreateMazeOnArea()
        {
            for (var i = 0; i < _cells.GetLength(0); i++)
            for (var j = 0; j < _cells.GetLength(1); j++)
            {
                var mazeCell = _cells[i, j];
                if (!mazeCell._isCell)
                {
                    Entity.CreateEntity<MazeBlock>($"Block{i}_{j}", new Point(i, j), _area);
                }
            }
        }
        
    }
}