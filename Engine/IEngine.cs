using System;
using System.Collections.Generic;

namespace Engine
{
    public abstract class Engine
    {

        protected GameGrid Grid;
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
            _currentScene = scene;
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
            foreach (var cell in Grid.SelectCells())
            {
                OnRender(cell);
            }
        }
        
        public abstract void OnInit();
        public abstract void OnRender(Cell renderCell);

    }
}