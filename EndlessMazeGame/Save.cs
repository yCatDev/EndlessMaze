using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using AbstractEngine.Core.Base;
using Formatting = Newtonsoft.Json.Formatting;

namespace EndlessMazeGame
{
    public class SaveSystem
    {
        public SaveFile SaveFile; 
        public SaveSystem()
        {
            if (!File.Exists("save.json"))
                CreateNewFile();
            try
            {
                var sr = new StreamReader("save.json");
                SaveFile = new SaveFile();
                SaveFile = JsonConvert.DeserializeObject<SaveFile>(sr.ReadToEnd());
                sr.Close();
            }
            catch
            {
                CreateNewFile();
            }
        }

        private void CreateNewFile()
        {
            File.Create("save.json").Dispose();
            SaveFile = new SaveFile();
            Save();
        }
        
        public void Save()
        {
            var sw = new StreamWriter("save.json");
           sw.Write(JsonConvert.SerializeObject(SaveFile, Formatting.Indented));
           sw.Flush();
           sw.Close();
        }

        public void ClearLevel()
        {
            SaveFile.LevelSaveData.ClearLevel();
            Save();
        }

    }

    
    public class SaveFile
    {
        public int TimeInMaze { get; set; }
        public LevelSaveData LevelSaveData { get; set; }

        public SaveFile()
        {
            LevelSaveData = new LevelSaveData();
        }
    }

    
    public class LevelSaveData
    {
        public PointData PlayerPosition { get; set; }
        public List<PointData> TreasurePositions{ get; set; }
        public List<PointData> BlockPositions { get; set; }
        public List<PointData> StonePositions{ get; set; }

        public void SaveLevel(GameGrid grid)
        {
            ClearLevel();
            var cells = grid.SelectAll();
            for (var i = 0; i < cells.GetLength(0); i++)
            for (var j = 0; j < cells.GetLength(1); j++)
            {
                var cell = cells[i, j];
                if (cell.GetName().Contains("Block"))
                    BlockPositions.Add(new PointData(i,j));
                else if (cell.GetName().Contains("Treasure"))
                    TreasurePositions.Add(new PointData(i,j));
                else if (cell.GetName().Contains("Stone"))
                    StonePositions.Add(new PointData(i,j));
                else if (cell.GetName().Contains("Player"))
                    PlayerPosition = new PointData(i,j);
            }
        }

        public bool IsEmpty() =>
            BlockPositions.Count == 0 && TreasurePositions.Count == 0 && StonePositions.Count == 0;
        
        public LevelSaveData()
        {
            BlockPositions = new List<PointData>();
            TreasurePositions = new List<PointData>();
            StonePositions = new List<PointData>();
        }

        public void ClearLevel()
        {
            BlockPositions.Clear();
            TreasurePositions.Clear();
            StonePositions.Clear();
        }
        
        public class PointData
        {
            public Point Point;
            public PointData(int x, int y) => Point = new Point(x, y);
        }
        
    }
    
}