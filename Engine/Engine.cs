using System;
using System.Collections.Generic;
using System.Linq;

namespace Engine
{
    public abstract class Engine
    {
        
        protected List<GameObject> GameObjects;
        private Scene _currentScene;
        
        public Engine(int width, int height)
        {
            GameObjects = new List<GameObject>();
            OnInit();
        }

        public void Run()
        {
            while (true)
            {
                Update();
                Render();
            }
        }

        public void RunScene(Scene scene)
        {
            if (_currentScene!=null)
                scene.Unload();
            _currentScene = scene;
            GameObjects = _currentScene.GetGameObjectList;
            _currentScene.Init();
        }

        private void Update()
        {
            _currentScene.Update();
            foreach (var gameObject in GameObjects)
            {
                gameObject.Update();
            }
        }

        private void Render()
        {
            foreach (var cell in GameObjects.Select(x=>x.RendererData))
            {
                OnRender(cell);
            }
        }
        
        public abstract void OnInit();
        public abstract void OnRender(RendererData renderCell);

    }

    public class Point
    {
        public int X, Y;
    }
}