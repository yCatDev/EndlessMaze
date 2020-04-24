using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml;
using AbstractEngine.Core.Base;

namespace EndlessMazeGame
{
    public class SaveSystem
    {
        public SaveFile SaveFile; 
        public SaveSystem()
        {
            if (!File.Exists("save.json"))
            {
                File.Create("save.json").Dispose();
                SaveFile = new SaveFile();
                Save();
            }
            SaveFile = new SaveFile();
            StreamReader sr = new StreamReader("save.json");
            SaveFile = JsonSerializer.Deserialize<SaveFile>(sr.ReadToEnd());
            sr.Dispose();
        }

        public void Save()
        {
            StreamWriter streamWriter = new StreamWriter("save.json");
            streamWriter.Write(JsonSerializer.Serialize(SaveFile));
            streamWriter.Flush();
            streamWriter.Dispose();
        }
        
    }

    public class SaveFile
    {
        public int timeInMaze { get; set; }
        //public Cell[,] LastLevel { get; set; }

        public SaveFile()
        {
          //  LastLevel=new Cell[0,0];
            
        }
    }
    
}