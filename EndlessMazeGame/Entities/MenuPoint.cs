using System;
using AbstractEngine.Core.Base;
using EndlessMazeGame.Areas;

namespace EndlessMazeGame.Entities
{
    public class MenuPoint: Entity
    {
        private Point _menuPlay, _menuContinue, _menuExit;
        private int _index = 0;

        public MenuPoint(string name, Point startPos, string resourceName, Area area) : base(name, startPos, area)
        {
            SetNewGraphics(resourceName);
        }

        public void SetMenuPoints(Point play, Point @continue, Point exit)
        {
            _menuPlay = play;
            _menuContinue = @continue;
            _menuExit = exit;
        }
        
        public override void Update()
        {
            if (InputManger.OnKeyDown(VirtualKeys.Down))
            {
                if (_index < 2)
                    _index++;
                else
                {
                    return;
                }
            }else
            if (InputManger.OnKeyDown(VirtualKeys.Up))
            {
                if (_index > 0)
                    _index--;
                else
                {
                    return;
                }
            }
            UpdatePosition();

            if (InputManger.OnKeyDown(VirtualKeys.Space) || InputManger.OnKeyDown(VirtualKeys.Return))
            {
                switch (_index)
                {
                    case 0:
                        _ownerArea.Grid.Core.LoadArea(new GameArea(false, _ownerArea.Grid.Core.GameGrid));
                        break;
                    case 1:
                        SetPosition(_menuContinue);
                        break;
                    case 2:
                        Environment.Exit(0);
                        break;
                }
            }
        }

        private void UpdatePosition()
        {
            switch (_index)
            {
                case 0:
                    SetPosition(_menuPlay);
                    break;
                case 1:
                    SetPosition(_menuContinue);
                    break;
                case 2:
                    SetPosition(_menuExit);
                    break;
            }
        }
    }
}